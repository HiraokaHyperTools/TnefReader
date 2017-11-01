using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TnefReader {
    /// <summary>
    /// [2.1.3.4 Encapsulated Message and Attachment Properties] decoder
    /// </summary>
    /// <remarks>
    /// See,
    /// [MS-OXTNEF]: Transport Neutral Encapsulation Format (TNEF) Data Algorithm
    /// https://msdn.microsoft.com/ja-jp/library/cc425498.aspx
    /// </remarks>
    public class MsgProps : IEnumerable<MsgProp> {
        public List<MsgProp> Props { get; } = new List<MsgProp>();

        public MsgProps(BinaryReader br) {
            //MsgPropsData = MsgPropertyList
            // MsgPropertyList = MsgPropertyCount *MsgPropertyValue
            //  MsgPropertyCount = UINT32
            // MsgPropertyValue = MsgPropertyTag MsgPropertyData
            //  MsgPropertyTag = MsgPropertyType MsgPropertyId [NamedPropSpec]
            //   MsgPropertyType = TypeUnspecified / TypeNull / TypeInt16 / TypeInt32 / TypeFlt32 / TypeFlt64 / TypeCurrency / TypeAppTime / TypeError / TypeBoolean / TypeObject / TypeInt64 / TypeString8 / TypeUnicode / TypeSystime / TypeCLSID / TypeBinary / TypeMVInt16 / TypeMVInt32 / TypeMVFlt32 / TypeMVFlt64 / TypeMVCurrency / TypeMVAppTime / TypeMVSystime / TypeMVString8 / TypeMVBinary / TypeMVUnicode / TypeMVCLSID / TypeMVInt64
            //    TypeUnspecified = %x00.00
            //    TypeNull = %x01.00
            //    TypeInt16 = %x02.00
            //    TypeMVInt16 = %x02.10
            //    TypeInt32 = %x03.00
            //    TypeMVInt32 = %x03.10
            //    TypeFlt32 = %x04.00
            //    TypeMVFlt32 = %x04.10
            //    TypeFlt64 = %x05.00
            //    TypeMVFlt64 = %x05.10
            //    TypeCurrency = %x06.00
            //    TypeMVCurrency = %x06.10
            //    TypeAppTime = %x07.00
            //    TypeMVAppTime = %x07.10
            //    TypeError = %x0A.00
            //    TypeBoolean = %x0B.00
            //    TypeObject = %x0D.00
            //    TypeInt64 = %x14.00
            //    TypeMVInt64 = %x14.10
            //    TypeString8 = %x1E.00
            //    TypeMVString8 = %x1E.10
            //    TypeUnicode = %x1F.00
            //    TypeMVUnicode = %x1F.10
            //    TypeSystime = %x40.00
            //    TypeMVSystime = %x40.10
            //    TypeCLSID = %x48.00
            //    TypeMVCLSID = %x48.10
            //    TypeBinary = %x02.01
            //    TypeMVBinary = %x02.11
            //   MsgPropertyId = UINT16
            //   NamedPropSpec = PropNameSpace PropIDType PropMap
            //    PropNameSpace = GUID
            //    PropIDType = IDTypeNumber / IDTypeString
            //     IDTypeNumber = %x00.00.00.00
            //     IDTypeString = %x01.00.00.00
            //    PropMap = PropMapID / PropMapString
            //     PropMapID = UINT32
            //     PropMapString = UINT32 *UINT16 %x00.00 [PropMapPad]
            //      PropMapPad=*1UINT16
            //  MsgPropertyData = PropertyScalarContent / PropertyMultiScalarContent / PropertyMultiVariableContent
            //   PropertyScalarContent = MsgPropertyContent [PropertyPad]
            //   PropertyMultiScalarContent = PropertyContentCount *PropertyScalarContent
            //    PropertyContentCount = UINT32
            //   PropertyMultiVariableContent = MsgPropertyCount 1*PropertyVariableContent
            //    PropertyVariableContent = MsgPropertySize MsgPropertyContent [PropertyPad]
            //     MsgPropertySize = UINT32
            var MsgPropertyCount = br.ReadInt32();
            for (int y = 0; y < MsgPropertyCount; y++) {
                PropType pType = (PropType)br.ReadUInt16();
                var pId = br.ReadUInt16();
                uint? PropMapID = null;
                string PropMapString = null;
                if (pId >= 0x8000) {
                    var PropNameSpace = new Guid(br.ReadBytes(16));
                    var PropIDType = br.ReadInt32();
                    if (PropIDType == 0) {
                        // PropMapID
                        PropMapID = br.ReadUInt32();
                    }
                    else if (PropIDType == 1) {
                        // PropMapString
                        var n = br.ReadInt32();
                        PropMapString = Encoding.Unicode.GetString(br.ReadBytes(2 * n));
                        br.ReadBytes(2);
                        br.FourByteBoundary();
                    }
                }
                object value = null;
                switch (pType) {
                    case PropType.TypeUnspecified:
                    case PropType.TypeNull:
                        value = null;
                        break;
                    case PropType.TypeInt16:
                        value = br.ReadUInt16();
                        break;
                    case PropType.TypeInt32:
                        value = br.ReadInt32();
                        break;
                    case PropType.TypeString8:
                    case PropType.TypeMVString8: {
                            int count = br.ReadInt32();
                            string[] contents = new string[count];
                            for (int x = 0; x < count; x++) {
                                int size = br.ReadInt32();
                                contents[x] = Encoding.Default.GetString(br.ReadBytes(size)).Split('\0')[0];
                                br.FourByteBoundary();
                            }
                            value = contents;
                            break;
                        }
                    case PropType.TypeFlt32:
                        value = br.ReadSingle();
                        break;
                    case PropType.TypeFlt64:
                        value = br.ReadDouble();
                        break;
                    case PropType.TypeSystime: {
                            value = DateTime.FromFileTimeUtc(br.ReadInt64());
                            break;
                        }
                    case PropType.TypeBinary:
                    case PropType.TypeMVBinary: {
                            var binaryCount = br.ReadInt32();
                            byte[][] binaries = new byte[binaryCount][];
                            for (int x = 0; x < binaryCount; x++) {
                                var binarySize = br.ReadInt32();
                                binaries[x] = br.ReadBytes(binarySize);
                                br.FourByteBoundary();
                            }
                            value = binaries;
                            break;
                        }
                    case PropType.TypeBoolean:
                        value = br.ReadUInt16() != 0;
                        break;
                    default:
                        throw new NotSupportedException("" + pType);
                }
                br.FourByteBoundary();
                //Console.WriteLine("{0,24} {1:x4} {2}", pType, pId, value);
                Props.Add(new MsgProp {
                    key = (PropId)pId,
                    value = value,
                });
            }
        }

        public IEnumerator<MsgProp> GetEnumerator() {
            return Props.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return Props.GetEnumerator();
        }

        public override string ToString() {
            return string.Format("{0:#,##0} props", Props.Count);
        }
    }

    static class BinaryReaderExtensions {
        internal static BinaryReader FourByteBoundary(this BinaryReader br) {
            br.ReadBytes(((int)(4 - br.BaseStream.Position)) & 3); // align dword
            return br;
        }
    }
}

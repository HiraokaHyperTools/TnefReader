using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TnefReader {
    /// <summary>
    /// TNEF reader
    /// </summary>
    public class TNEFReader : IEnumerable<TNEFEntry> {
        public List<TNEFEntry> Entries { get; } = new List<TNEFEntry>();

        /// <summary>
        /// Decode entire TNEF on memory
        /// </summary>
        /// <param name="si"></param>
        /// <exception cref="InvalidDataException">TNEF header not matched</exception>
        public TNEFReader(Stream si) {
            BinaryReader br = new BinaryReader(si);

            //TNEFStream = TNEFHeader TNEFVersion OEMCodePage MessageData *AttachData

            // TNEFHeader = TNEFSignature LegacyKey
            if (false
                || br.ReadByte() != 0x78
                || br.ReadByte() != 0x9f
                || br.ReadByte() != 0x3e
                || br.ReadByte() != 0x22
            ) {
                throw new InvalidDataException();
            }
            var LegacyKey = br.ReadUInt16();

            try {
                //int n = 1;
                while (true) {
                    byte attr = br.ReadByte();
                    // TNEFVersion = attrLevelMessage idTnefVersion Length TNEFVersionData Checksum
                    // OEMCodePage = attrLevelMessage idOEMCodePage Length OEMCodePageData Checksum
                    // MessageData = *MessageAttribute [MessageProps]
                    //  MessageAttribute = attrLevelMessage idMessageAttr Length Data Checksum
                    //  MessageProps = attrLevelMessage idMsgProps Length Data Checksum
                    // AttachData = AttachRendData [*AttachAttribute] [AttachProps]
                    //  AttachRendData = attrLevelAttachment idAttachRendData Length Data Checksum
                    //  AttachAttribute = attrLevelAttachment idAttachAttr Length Data Checksum
                    //  AttachProps = attrLevelAttachment idAttachment Length Data Checksum
                    AttrId id = (AttrId)br.ReadInt32();
                    int length = br.ReadInt32();
                    var data = br.ReadBytes(length);
                    var checkSum = br.ReadUInt16();
                    //Console.WriteLine("{3} {0,20} {1,6} {2:x4}", id, length, checkSum, (attr == attrLevelMessage) ? "M" : (attr == attrLevelAttachment) ? "A" : "?");
                    //File.WriteAllBytes(string.Format("{0}-{1}.bin", n++, id), data);
                    object value = null;
                    if (id == AttrId.Attachment || id == AttrId.MsgProps) {
                        value = new MsgProps(new BinaryReader(new MemoryStream(data)));
                    }
                    Entries.Add(new TNEFEntry {
                        key = id,
                        data = data,
                        value = value
                    });
                }
            }
            catch (EndOfStreamException) {

            }
        }

        const byte attrLevelMessage = 0x01;
        const byte attrLevelAttachment = 0x02;

        public IEnumerator<TNEFEntry> GetEnumerator() {
            return Entries.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return Entries.GetEnumerator();
        }

        public override string ToString() {
            return string.Format("{0:#,##0} entries", Entries.Count);
        }
    }

}

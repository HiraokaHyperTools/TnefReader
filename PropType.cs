using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TnefReader {
    /// <summary>
    /// MsgPropertyType
    /// </summary>
    /// <remarks>
    /// See,
    /// [MS-OXTNEF]: Transport Neutral Encapsulation Format (TNEF) Data Algorithm
    /// https://msdn.microsoft.com/ja-jp/library/cc425498.aspx
    /// </remarks>
    public enum PropType {
        TypeUnspecified = 0x0000,
        TypeNull = 0x0001,
        TypeInt16 = 0x0002,
        TypeMVInt16 = 0x1002,
        TypeInt32 = 0x0003,
        TypeMVInt32 = 0x1003,
        TypeFlt32 = 0x0004,
        TypeMVFlt32 = 0x1004,
        TypeFlt64 = 0x0005,
        TypeMVFlt64 = 0x1005,
        TypeCurrency = 0x0006,
        TypeMVCurrency = 0x1006,
        TypeAppTime = 0x0007,
        TypeMVAppTime = 0x1007,
        TypeError = 0x000A,
        TypeBoolean = 0x000B,
        TypeObject = 0x000D,
        TypeInt64 = 0x0014,
        TypeMVInt64 = 0x1014,
        TypeString8 = 0x001E,
        TypeMVString8 = 0x101E,
        TypeUnicode = 0x001F,
        TypeMVUnicode = 0x101F,
        TypeSystime = 0x0040,
        TypeMVSystime = 0x1040,
        TypeCLSID = 0x0048,
        TypeMVCLSID = 0x1048,
        TypeBinary = 0x0102,
        TypeMVBinary = 0x1102,

        MultiVariable = 0x1000,
    }
}

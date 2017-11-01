using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TnefReader {
    /// <summary>
    /// TNEF Attribute id
    /// </summary>
    /// <remarks>
    /// See,
    /// [MS-OXTNEF]: Transport Neutral Encapsulation Format (TNEF) Data Algorithm
    /// https://msdn.microsoft.com/ja-jp/library/cc425498.aspx
    /// </remarks>
    public enum AttrId {
        TnefVersion = 0x00089006,
        OEMCodePage = 0x00069007,
        MessageClass = 0x00078008,
        From = 0x00008000,
        Subject = 0x00018004,
        DateSent = 0x00038005,
        DateRecd = 0x00038006,
        MessageStatus = 0x00068007,
        MessageID = 0x00018009,
        Body = 0x0002800C,
        Priority = 0x0004800D,
        DateModified = 0x00038020,
        MsgProps = 0x00069003,
        RecipTable = 0x00069004,
        OriginalMessageClass = 0x00070600,
        Owner = 0x00060000,
        SentFor = 0x00060001,
        Delegate = 0x00060002,
        DateStart = 0x00030006,
        DateEnd = 0x00030007,
        AidOwner = 0x00050008,
        RequestRes = 0x00040009,

        AttachData = 0x0006800F,
        AttachTitle = 0x00018010,
        AttachMetaFile = 0x00068011,
        AttachCreateDate = 0x00038012,
        AttachModifyDate = 0x00038013,
        AttachTransportFilename = 0x00069001,
        AttachRendData = 0x00069002,
        Attachment = 0x00069005,
    }
}

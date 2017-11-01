﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kaizenc.LEML {
    /// <summary>
    /// RFC 822 EML decoder
    /// </summary>
    public class EML {
        /// <summary>
        /// Mail or multipart entity
        /// </summary>
        public Mail entity { get; set; }
        /// <summary>
        /// All headers that allow same key names
        /// </summary>
        public List<Tuple<string, string>> allHeaders = new List<Tuple<string, string>>();
        /// <summary>
        /// Some headers: last one captured by key name
        /// </summary>
        public SortedDictionary<string, string> dictHeaders = new SortedDictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

        public string GetValue(string key) {
            string text;
            if (!dictHeaders.TryGetValue(key, out text)) {
                text = null;
            }
            return text;
        }

        /// <summary>
        /// MIME type
        /// </summary>
        /// <returns>Content type</returns>
        public override string ToString() {
            return ContentType;
        }

        /// <summary>
        /// body includes multipart entities (latin1, LF)
        /// </summary>
        public String fullBody { get; set; }

        /// <summary>
        /// Output (Main contents, latin1, LF)
        /// </summary>
        public String contents { get; set; }

        /// <summary>
        /// multipart entites
        /// </summary>
        public List<EML> multiparts = new List<EML>();

        public EML(Mail entity) {
            this.entity = entity;
            var rows = entity.rawBody.Replace("\r\n", "\n").Split('\n');
            String key = null, value = null;
            int y = 0, cy = rows.Length;
            for (; y < cy; y++) {
                var row = rows[y];
                if (row.Length == 0) {
                    y++;
                    break;
                }
                if (!char.IsWhiteSpace(row[0])) {
                    if (key != null) {
                        allHeaders.Add(new Tuple<string, string>(key, value));
                        key = null; value = null;
                    }
                    String[] cols = row.Split(new char[] { ':' }, 2);
                    if (cols.Length == 2) {
                        key = cols[0].TrimEnd();
                        value = cols[1].TrimStart();
                    }
                }
                else {
                    if (key != null) {
                        value += "\n";
                        value += row;
                    }
                }
            }
            if (key != null) {
                allHeaders.Add(new Tuple<string, string>(key, value));
            }
            foreach (var pair in allHeaders) {
                dictHeaders[pair.Item1] = pair.Item2;
            }
            fullBody = String.Join("\n", rows, y, cy - y);

            if ("multipart".Equals(PerceivedType)) {
                String boundary = Boundary;
                String p1 = "--" + boundary;
                String p2 = "--" + boundary + "--";

                StringBuilder b = new StringBuilder();
                int z = 0;
                foreach (String row in fullBody.Split('\n')) {
                    if (p2.Equals(row)) break;
                    if (p1.Equals(row)) {
                        if (z == 0) {
                            contents = b.ToString();
                        }
                        else {
                            multiparts.Add(new EML(entity.CreateChild(b.ToString())));
                        }
                        b.Length = 0;
                        z++;
                    }
                    else {
                        b.Append(row + "\n");
                    }
                }
                {
                    {
                        if (z == 0) {
                            contents = b.ToString();
                        }
                        else {
                            multiparts.Add(new EML(entity.CreateChild(b.ToString())));
                        }
                    }
                }
            }
            else {
                contents = fullBody;
            }
        }

        public String ContentType {
            get {
                foreach (var pair in new HorzKeyValue(GetValue("Content-Type") ?? "").pairs) {
                    if (pair.Item1.Length == 0) {
                        return pair.Item2;
                    }
                }
                return "";
            }
        }

        public String ContentDisposition {
            get {
                foreach (var pair in new HorzKeyValue(GetValue("Content-Disposition") ?? "").pairs) {
                    if (pair.Item1.Length == 0) {
                        return pair.Item2;
                    }
                }
                return "";
            }
        }

        public String FileName {
            get {
                foreach (var pair in new HorzKeyValue(GetValue("Content-Disposition") ?? "").pairs) {
                    if (pair.Item1.Equals("FileName", StringComparison.InvariantCultureIgnoreCase)) {
                        return pair.Item2;
                    }
                }
                foreach (var pair in new HorzKeyValue(GetValue("Content-Type") ?? "").pairs) {
                    if (pair.Item1.Equals("Name", StringComparison.InvariantCultureIgnoreCase)) {
                        return pair.Item2;
                    }
                }
                return "";
            }
        }

        public String From {
            get {
                return GetValue("From") ?? "";
            }
        }

        public String To {
            get {
                return GetValue("To") ?? "";
            }
        }

        public String Subject {
            get {
                return GetValue("Subject") ?? "";
            }
        }

        public String PerceivedType {
            get {
                String[] cols = ContentType.Split('/');
                return cols[0];
            }
        }

        public String Boundary {
            get {
                foreach (var pair in new HorzKeyValue(GetValue("Content-Type") ?? "").pairs) {
                    if (StringComparer.InvariantCultureIgnoreCase.Compare("boundary", pair.Item1) == 0) {
                        return pair.Item2;
                    }
                }
                return "";
            }
        }

        public String CharacterSet {
            get {
                foreach (var pair in new HorzKeyValue(GetValue("Content-Type") ?? "").pairs) {
                    if (StringComparer.InvariantCultureIgnoreCase.Compare("charset", pair.Item1) == 0) {
                        return pair.Item2;
                    }
                }
                return "";
            }
        }

        public String ContentTransferEncoding {
            get {
                foreach (var pair in new HorzKeyValue(GetValue("Content-Transfer-Encoding") ?? "").pairs) {
                    if (pair.Item1.Length == 0) {
                        return pair.Item2;
                    }
                }
                return "";
            }
        }

        /// <summary>
        /// Main contents in byte array
        /// </summary>
        public byte[] RawContents {
            get {
                return UtilMimeBody.GetBodyBytes(this);
            }
        }

        /// <summary>
        /// Main contents text body in readable Unicode (decodes ContentTransferEncoding)
        /// </summary>
        public String MessageBody {
            get {
                String charSet = CharacterSet;
                if (charSet.Length == 0) {
                    charSet = "ascii";
                }
                else if ("cp932".Equals(charSet)) {
                    charSet = "Shift_JIS";
                }
                return Encoding.GetEncoding(charSet).GetString(UtilMimeBody.GetBodyBytes(this));
            }
        }

        public DateTime? Date {
            get {
                try {
                    return DateTime.Parse(GetValue("Date"));
                }
                catch (FormatException) {
                    return null;
                }
            }
        }
    }

    class UtilMimeBody {
        public static byte[] GetBodyBytes(EML eml) {
            var cte = eml.ContentTransferEncoding;
            if (cte == "base64") {
                return Convert.FromBase64String(eml.contents);
            }
            return Encoding.GetEncoding("latin1").GetBytes(eml.contents);
        }
    }

    /// <summary>
    /// RFC 2047 encoded-word decoder
    /// </summary>
    class UtilDecodeRfc2047 {
        public String Decode(String text) {
            String r = Regex.Replace(text, "=\\?(?<c>[^\\?]+)\\?(?<e>[BbQq])\\?(?<b>[^\\?]+)\\?=", Repl);
            return r;
        }

        String Repl(Match M) {
            var c = M.Groups["c"].Value;
            var e = M.Groups["e"].Value;
            var b = M.Groups["b"].Value;
            byte[] bin = null;
            if (e == "B" || e == "b") {
                bin = Convert.FromBase64String(b);
            }
            else {
                bin = FromQuotedPrintable(b);
            }
            Encoding enc = Encoding.GetEncoding(c) ?? Encoding.GetEncoding("latin1");
            return enc.GetString(bin);
        }

        static byte[] FromQuotedPrintable(String s) {
            MemoryStream os = new MemoryStream();
            String hex = "0123456789ABCDEF";
            for (int x = 0, cx = s.Length; x < cx;) {
                if (s[x] == ' ') {
                    os.WriteByte((byte)' ');
                    x++;
                    continue;
                }
                if (s[x] == '=') {
                    if (x + 2 < cx) {
                        int a = hex.IndexOf(s[x + 1]);
                        int b = hex.IndexOf(s[x + 2]);
                        if (a >= 0 && b >= 0) {
                            os.WriteByte((byte)((a << 4) | b));
                            x += 3;
                            continue;
                        }
                    }
                }
                os.WriteByte((byte)s[x]);
                x++;
            }
            return os.ToArray();
        }
    }

    /// <summary>
    /// Horizontal key-value pairs
    /// </summary>
    class HorzKeyValue {
        /// <summary>
        /// key=value
        /// </summary>
        /// <remarks>
        /// - ""="text/plain"
        /// - "charset"="utf-8"
        /// </remarks>
        public List<Tuple<string, string>> pairs = new List<Tuple<string, string>>();

        public HorzKeyValue(String s) {
            for (int x = 0, cx = s.Length; x < cx;) {
                while (x < cx && char.IsWhiteSpace(s[x])) {
                    x++;
                }
                String key = "";
                bool isPair = false;
                while (x < cx) {
                    if (s[x] == ';') {
                        x++;
                        break;
                    }
                    else if (s[x] == '=') {
                        x++;
                        isPair = true;
                        break;
                    }
                    else {
                        key += s[x];
                        x++;
                    }
                }
                if (!isPair) {
                    pairs.Add(new Tuple<string, string>("", key));
                    continue;
                }
                while (x < cx && char.IsWhiteSpace(s[x])) {
                    x++;
                }
                if (x < cx) {
                    String value = "";
                    if (s[x] == '"') {
                        x++;
                        while (x < cx) {
                            if (s[x] == '"') {
                                x++;
                                break;
                            }
                            else {
                                value += s[x];
                                x++;
                            }
                        }
                    }
                    else {
                        while (x < cx) {
                            if (s[x] == ';') {
                                x++;
                                break;
                            }
                            else {
                                value += s[x];
                                x++;
                            }
                        }
                    }
                    pairs.Add(new Tuple<string, string>(key, value));
                }
            }
        }
    }

    /// <summary>
    /// Mail or multipart entity
    /// </summary>
    public class Mail {
        /// <summary>
        /// file path
        /// </summary>
        public String filePath { get; set; }
        /// <summary>
        /// unique id
        /// </summary>
        public String uuid { get; set; }
        /// <summary>
        /// body in latin1
        /// </summary>
        public String rawBody { get; set; }

        /// <summary>
        /// parent entity for multipart/*
        /// </summary>
        public Mail parentEntity { get; set; }

        internal Mail CreateChild(String childRawBody) {
            return new Mail { filePath = filePath, uuid = uuid, rawBody = childRawBody, parentEntity = this };
        }

        /// <summary>
        /// Load from file
        /// </summary>
        /// <param name="filePath">file path</param>
        /// <returns></returns>
        public static Mail FromFile(string filePath) {
            return new Mail { filePath = filePath, uuid = filePath, rawBody = File.ReadAllText(filePath, Encoding.GetEncoding("latin1")) };
        }

    }

    /// <summary>
    /// EdMax MBOX file Reader
    /// </summary>
    class EdMaxMboxReader {
        static readonly Encoding raw = Encoding.GetEncoding("latin1");
        static readonly Encoding jis = Encoding.GetEncoding("iso-2022-jp");
        static readonly Encoding sjis = Encoding.GetEncoding(932);
        static readonly Encoding eucjp = Encoding.GetEncoding("euc-jp");

        /// <summary>
        /// Load EdMax MBOX file
        /// </summary>
        /// <param name="filePath">file path</param>
        /// <returns>mails</returns>
        public IEnumerable<Mail> LoadFrom(string filePath) {
            using (StreamReader reader = new StreamReader(filePath, raw)) {
                String row;
                StringBuilder b = new StringBuilder();
                int z = 0;
                while (null != (row = reader.ReadLine())) {
                    if (row == ".") {
                        yield return Convert(new Mail { filePath = filePath, uuid = filePath + "/" + z, rawBody = b.ToString() });
                        z++;
                        b.Length = 0;
                    }
                    else {
                        b.Append(row + "\n");
                    }
                }
                yield return Convert(new Mail { filePath = filePath, uuid = filePath + "/" + z, rawBody = b.ToString() });
            }
        }

        private Mail Convert(Mail entity) {
            EML eml = new EML(entity);
            var cs = eml.CharacterSet;
            // box は sjis で入っている。
            if ("|utf-8|utf_8|utf8|".IndexOf("|" + cs + "|", StringComparison.InvariantCultureIgnoreCase) >= 0) {
                String s = raw.GetString(Encoding.UTF8.GetBytes(sjis.GetString(raw.GetBytes(entity.rawBody))));
                entity.rawBody = s;
            }
            else if ("|euc_jp|eucjp|euc-jp|".IndexOf("|" + cs + "|", StringComparison.InvariantCultureIgnoreCase) >= 0) {
                String s = raw.GetString(eucjp.GetBytes(sjis.GetString(raw.GetBytes(entity.rawBody))));
                entity.rawBody = s;
            }
            else if ("|iso-2022-jp|".IndexOf("|" + cs + "|", StringComparison.InvariantCultureIgnoreCase) >= 0) {
                String s = raw.GetString(jis.GetBytes(sjis.GetString(raw.GetBytes(entity.rawBody))));
                entity.rawBody = s;
            }
            else {
                String s = raw.GetString(sjis.GetBytes(sjis.GetString(raw.GetBytes(entity.rawBody))));
                entity.rawBody = s;
            }
            return entity;
        }
    }

    /// <summary>
    /// UNIX MBOX file decoder
    /// </summary>
    public class UnixMboxReader {
        /// <summary>
        /// Load mails from UNIX MBOX file
        /// </summary>
        /// <param name="filePath">file path</param>
        /// <returns>mails</returns>
        public static IEnumerable<Mail> LoadFrom(string filePath) {
            var raw = Encoding.GetEncoding("latin1");
            using (StreamReader reader = new StreamReader(filePath, raw)) {
                String row;
                StringBuilder b = new StringBuilder();
                while (null != (row = reader.ReadLine())) {
                    if (row == ".") {
                        yield return new Mail { filePath = filePath, rawBody = b.ToString() };
                        b.Length = 0;
                    }
                    else {
                        b.Append(row + "\n");
                    }
                }
                yield return new Mail { filePath = filePath, rawBody = b.ToString() };
            }
        }
    }
}
using DecodeMsOxprops.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DecodeMsOxprops {
    class Program {

        static void Main(string[] args) {
            var body = File.ReadAllText(@"C:\A\A");
            body = Regex.Replace(body, Regex.Escape(Resources.Exclude).Replace("NUM", "\\d+"), "", RegexOptions.Singleline);
            body = Regex.Replace(body, "(?<a>2\\.\\d+)\\s+(?<b>Pid)", match => "!" + match.Groups["b"].Value);

            File.WriteAllText("A.txt", body);

            var root = new JObject();
            JObject next = null;
            var rows = body.Replace("\r\n", "\n").Split('\n');
            int n = 0;
            for (int y = 0; y < rows.Length; y++) {
                var row = rows[y];
                if (row.StartsWith("!")) {
                    next = new JObject();
                    var key = row.Substring(1).Trim();
                    Debug.Assert(root[key] == null);
                    root[key] = next;
                    n++;
                    continue;
                }
                var cols = row.Split(':');
                if (cols.Length == 2) {
                    var text = cols[1];
                    while (true) {
                        if (y + 1 >= rows.Length || rows[y + 1].Trim().Length == 0 || rows[y + 1].Contains(":")) {
                            break;
                        }
                        text += " " + rows[y + 1];
                        y++;
                    }
                    next[cols[0]] = text.Trim();
                }
            }

            Console.WriteLine("{0} {1}", n, root.Count);
            File.WriteAllText("A.json", JsonConvert.SerializeObject(root, Formatting.Indented));
        }
    }
}

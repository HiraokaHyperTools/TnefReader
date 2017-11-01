using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumMaker {
    class Program {
        static void Main(string[] args) {
            JObject json = (JObject)JsonConvert.DeserializeObject(File.ReadAllText(@"C:\Proj\TnefReader\DecodeMsOxprops\bin\Debug\OXPROPS.json"));
            foreach (KeyValuePair<string, JToken> kv in json) {
                var value = kv.Value["Property ID"];
                if (value == null) {
                    continue;
                }
                Console.WriteLine($"{kv.Key}={value},");
            }
        }
    }
}

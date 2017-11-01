using Kaizenc.LEML;
using LibFileNameSanitizer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TnefReader.Properties;

namespace TnefReader {
    class Program {
        static void Main(string[] args) {
            if (args.Length < 1) {
                Console.Error.WriteLine(Resources.Usage);
                Environment.ExitCode = 1;
                return;
            }
            new Program().Run(args[0]);
        }

        string tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
        int nFilesWritten = 0;

        void Run(string filePath) {
            Directory.CreateDirectory(tempDir);
            Run2(filePath);
            if (nFilesWritten != 0) {
                Process.Start(tempDir);
            }
        }

        void Run2(string filePath) {
            var fileExt = Path.GetExtension(filePath);
            if (false) { }
            else if (string.Compare(fileExt, ".eml", true) == 0) {
                var oneMail = Mail.FromFile(filePath);
                var oneEml = new EML(oneMail);
                foreach (var part in oneEml.multiparts) {
                    if (part.FileName.Length != 0) {
                        var newFilePath = Path.Combine(tempDir, FileNameSanitizer.forFileName(part.FileName));
                        File.WriteAllBytes(newFilePath, part.RawContents);
                        Run2(newFilePath);
                        nFilesWritten++;
                    }
                }
            }
            else if (string.Compare(Path.GetFileName(filePath), "winmail.dat", true) == 0) {
                using (var si = File.OpenRead(filePath)) {
                    var tnef = new TNEFReader(si);
                    var walker = new TnefWalker(tnef);
                    walker.Walk(tempDir);
                }
            }
        }

        class TnefWalker {
            private string fileName;
            private byte[] rawData;
            private TNEFReader tnef;
            private string tempDir;

            private void Flush() {
                if (fileName != null && rawData != null) {
                    File.WriteAllBytes(Path.Combine(tempDir, FileNameSanitizer.forFileName(fileName)), rawData);
                }
                fileName = null;
                rawData = null;
            }

            public TnefWalker(TNEFReader tnef) {
                this.tnef = tnef;
            }

            internal void Walk(string tempDir) {
                this.tempDir = tempDir;
                foreach (var entry in tnef) {
                    if (entry.key == AttrId.AttachRendData) {
                        Flush();
                    }
                    if (entry.key == AttrId.Attachment) {
                        foreach (var prop in entry.value as MsgProps) {
                            if (prop.key == PropId.PidTagAttachLongFilename && prop.value is string[]) {
                                fileName = ((string[])prop.value).FirstOrDefault();
                            }
                        }
                    }
                    if (entry.key == AttrId.AttachData) {
                        rawData = entry.data;
                    }
                }
                Flush();
            }
        }
    }
}

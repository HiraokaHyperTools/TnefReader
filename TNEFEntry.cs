using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TnefReader {
    public class TNEFEntry {
        /// <summary>
        /// raw data
        /// </summary>
        public byte[] data { get; internal set; }

        /// <summary>
        /// attribute id
        /// </summary>
        public AttrId key { get; internal set; }

        /// <summary>
        /// decoded value
        /// </summary>
        public object value { get; internal set; }

        public override string ToString() {
            return $"{key} = {value}";
        }
    }
}

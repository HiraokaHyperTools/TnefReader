using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TnefReader {
    public class MsgProp {
        /// <summary>
        /// property id
        /// </summary>
        public PropId key { get; internal set; }

        /// <summary>
        /// decoded value
        /// </summary>
        public object value { get; internal set; }

        public override string ToString() {
            return $"{key} ({((int)key).ToString("X4")}) = {value}";
        }
    }
}

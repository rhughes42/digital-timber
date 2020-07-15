using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalTimber
{
    /// <summary>
    /// Info to accompany geometry.
    /// </summary>
    public class Attributes
    {
        public Dictionary<string, object> attribs { get; set; }
        public int size { get; set; }
        public Type type {get; set;}

        public Attributes()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            //this.type = type;
            this.attribs = dict;
            this.size = dict.Count;
        }

        public Attributes(List<string> keys, List<object> values)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            for (int i = 0; i < keys.Count; i++)
            {
                if ((keys[i] != null) && (values[i] != null))
                    dict.Add(keys[i], values[i]);
            }
            this.attribs = dict;
            this.size = dict.Count;
        }
    }
}

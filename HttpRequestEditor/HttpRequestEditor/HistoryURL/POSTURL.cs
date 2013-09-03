using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HttpRequestEditor.HistoryURL
{
    [XmlInclude(typeof(HistoryURL))]
    public class POSTURL : HistoryURL
    {
        public string Parameter { get; set; }
    }
}

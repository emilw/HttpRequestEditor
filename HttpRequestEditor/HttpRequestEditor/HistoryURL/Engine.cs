using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HttpRequestEditor.HistoryURL
{
    public class Engine
    {
        List<string> _url;
        XmlSerializer serializer;

        public Engine()
        {
            serializer = new XmlSerializer(typeof(HistoryURL));
        }

        public string[] MatchinURL(string input)
        {
            return _url.Where(x => x.StartsWith(input)).ToArray();
        }

        public void Load()
        {
            
        }

        public void Save()
        {
        
        }
    }
}

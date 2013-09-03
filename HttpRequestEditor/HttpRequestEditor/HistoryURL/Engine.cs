using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HttpRequestEditor.HistoryURL
{
    public class Engine
    {
        XmlSerializer _serializer;
        string _filePath;
        List<HistoryURL> _url;
        System.IO.FileStream _stream;

        public Engine()
        {
            _url = new List<HistoryURL>();
            _serializer = new XmlSerializer(typeof(List<HistoryURL>), getAllHistoryTypes());
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var thisAppDir = new DirectoryInfo(appDataPath + @"\HttpRequestEditor");
            
            if(!thisAppDir.Exists)
                thisAppDir.Create();

            _filePath = thisAppDir.ToString() + @"\HistoryURL.xml";
        }

        private Type[] getAllHistoryTypes()
        {
            var historyType = typeof(HistoryURL);

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            var childTypes = historyType.Assembly.GetTypes().Where(x => x.BaseType == historyType);

            return childTypes.ToArray();
        }

        public string[] URL
        {
            get
            {
                return _url.Select(x => x.URL).ToArray();
            }
        }

        public void Add(HistoryURL url)
        {
            var result = _url.Where(x => x.GetType() == url.GetType()
                                    && x.URL == url.URL);

            /*if (_url.Where(x => String.Equals(x.URL, url, StringComparison.InvariantCultureIgnoreCase)).Count() > 0)
                return;*/
            if (result.Count() > 0)
                return;

            _url.Add(url);//new PostURL() { URL = url, Parameter = parameter});
            Save();
        }

        public HistoryURL GetHistoryURLObject(string url)
        {
            return _url.Where(x => x.URL == url).FirstOrDefault();
        }

        public string GetParameterFromURL(string url)
        {
            var historyURL = _url.Where(x => String.Equals(x.URL, url, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            if (historyURL is POSTURL)
                return ((POSTURL)historyURL).Parameter;

            return "";
        }

        public void Load()
        {
            try
            {
                _stream = new System.IO.FileStream(_filePath, System.IO.FileMode.OpenOrCreate);
                _url = (List<HistoryURL>)_serializer.Deserialize(_stream);
                _stream.Close();
            }
            catch (Exception ex)
            {

                _stream.Close();
                throw new Exception("There was a problem reading the History URL file, if this is the first time you start the app just ignore this error");
            }
        }

        public void Save()
        {
            try
            {
                _stream = new System.IO.FileStream(_filePath, System.IO.FileMode.OpenOrCreate);
                _serializer.Serialize(_stream, _url);
            }
            catch (Exception ex)
            {
                throw new Exception("Problem when saving the history file...");
            }
            finally
            {
                _stream.Close();
                HistoryFileUpdate(_url, EventArgs.Empty);
            }

        }

        public event EventHandler HistoryFileUpdate; 
    }
}

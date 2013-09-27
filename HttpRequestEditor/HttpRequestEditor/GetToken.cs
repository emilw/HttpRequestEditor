using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HttpRequestEditor
{
    public partial class GetToken : Form
    {
        private string _token = null;
        private string _url;
        private bool gotRoot = false;

        public string SecurityToken
        {
            get
            {
                return _token;
            }
        }

        public GetToken(string url)
        {
            InitializeComponent();
            webBrowser.Navigate(url + "//Account/LogOff/");
            _url = url;
        }

        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            try
            {
                if (webBrowser.DocumentText.StartsWith("WRAP access_token="))
                {
                    _token = webBrowser.DocumentText;
                    this.Close();
                }
                else if (webBrowser.DocumentText.Contains("medius-app"/*"siteroot"*/) && !gotRoot)
                {
                    gotRoot = true;
                    webBrowser.Navigate(_url + "/SwtIssuer/Issue");
                }
            }
            catch { }
        }
    }
}

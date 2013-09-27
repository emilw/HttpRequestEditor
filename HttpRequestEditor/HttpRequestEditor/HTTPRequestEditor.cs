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
    public partial class HTTPRequestEditor : Form
    {
        HistoryURL.Engine _historyURLEngine;
        private Timer _timer = new Timer();
        //List<HistoryURL> urlList;

        public HTTPRequestEditor()
        {
            InitializeComponent();
            ExecURL = "https://localhost:19310/MainTenantManager/InboxManager/GetInboxData";
            txtLoginAddress.Text = "http://localhost/MainTenantManager/";
            try
            {
                _historyURLEngine = new HistoryURL.Engine();
                _historyURLEngine.Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGetToken_Click(object sender, EventArgs e)
        {
            var getToken = new GetToken(txtLoginAddress.Text);
            getToken.Show();

            getToken.FormClosed += getToken_FormClosed;
        }

        void getToken_FormClosed(object sender, FormClosedEventArgs e)
        {
            SecurityToken = ((GetToken)sender).SecurityToken;
            mainTabControl.SelectedTab = tabExecution;
        }

        private HistoryURL.HistoryURL getRequestObject()
        {
            HistoryURL.HistoryURL result;

            if (SelectedRequestMethodType is HttpRequestPOSTMethodType)
            {
                var parameters = this.Parameters;
                if (parameters == "")
                {
                    parameters = _historyURLEngine.GetParameterFromURL(this.ExecURL);

                    if (parameters != "")
                        MessageBox.Show("The application found parameters related to this URL, they are added to the parameter section due to that you have not added any parameters by yourself");
                }

                result = new HistoryURL.POSTURL() { Parameter = parameters };
                this.Parameters = parameters;
            }
            else if (SelectedRequestMethodType is HttpRequestGETMethodType)
            {
                result = new HistoryURL.GETURL();
            }
            else
            {
                result = new HistoryURL.POSTURL();
                throw new Exception("Could not identify the request type");
            }

            result.URL = this.ExecURL;

            return result;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            StartProgress();
            
            //var contentType = (ContentType)ddlRequestType.SelectedItem;
            var request = getRequestObject();

            var client = new HttpRestClient(request.URL, SecurityToken);
            ExecSource = "Getting data...";

            HttpRestClientResponse response;

            if (request is HistoryURL.POSTURL)
            {
                response = client.Execute("null", this.Parameters, SelectedContentType, SelectedRequestMethodType);
            }
            else
            {
                response = client.Execute("null", "", SelectedContentType, SelectedRequestMethodType);
            }

            this.ExecSource = response.Content;

            //Save the history
            if (response.ResultCode == "OK")
            {
                _historyURLEngine.Add(request);
                tabControlExecution.SelectedTab = tabExecutionContent;
                SetLabel(response.ResultCode, Color.Green);
            }
            else
            {
                SetLabel(response.ResultCode, Color.Red);
            }

            StopProgress();

            UpdateExecutionStatus(response.ExecTime, response.Size, response.ResultCode, response.ResultCodeDescription);
            
        }

        private void StartProgress()
        {
            progress.Value = 0;
            progress.Step = 1;
            //progress.Maximum = 100;
            progress.Minimum = 0;
            _timer.Interval = 10;
            _timer.Tick += timer_Tick;
            _timer.Start();
        }

        private void StopProgress()
        {
            _timer.Stop();
            progress.Value = 0;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            progress.PerformStep();
            if (progress.Value == progress.Maximum)
                progress.Value = 0;

        }

        private void HTTPRequestEditor_Load(object sender, EventArgs e)
        {
            ddlRequestType.DataSource = HttpRestClient.ContentType;
            ddlRequestType.ValueMember = "Name";
            ddlRequestType.DisplayMember = "Name";

            ddlExecutionType.DataSource = HttpRestClient.RequestMehtodType;
            ddlExecutionType.ValueMember = "Type";
            ddlExecutionType.DisplayMember = "Type";

            //var autoCompleteList = new AutoCompleteStringCollection();
            //autoCompleteList.AddRange(_historyURLEngine.URL);
            refreshURLAutoComplete();
            _historyURLEngine.HistoryFileUpdate += _historyURLEngine_HistoryFileUpdate;
        }

        void _historyURLEngine_HistoryFileUpdate(object sender, EventArgs e)
        {
            refreshURLAutoComplete();
        }

        private void refreshURLAutoComplete()
        {
            /*txtURL.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtURL.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtURL.AutoCompleteCustomSource = this.HistoryURL;*/

            /*comboExecutionURL.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboExecutionURL.AutoCompleteSource = AutoCompleteSource.CustomSource;
            comboExecutionURL.AutoCompleteCustomSource = this.HistoryURL;*/
            comboExecutionURL.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboExecutionURL.AutoCompleteSource = AutoCompleteSource.ListItems;
            
            comboExecutionURL.DataSource = this.HistoryURLEx;
            comboExecutionURL.ValueMember = "URL";
            comboExecutionURL.DisplayMember = "URL";

            comboExecutionURL.SelectedIndexChanged += comboExecutionURL_SelectedIndexChanged;
        }

        void comboExecutionURL_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var historyURL = (HistoryURL.HistoryURL)comboBox.SelectedItem;
            initFromHistoryURL(historyURL);
            MessageBox.Show(historyURL.URL);
        }

        private void initFromHistoryURL(HistoryURL.HistoryURL url)
        {
            if (url is HistoryURL.POSTURL)
                this.SelectedRequestMethodType = HttpRestClient.RequestMehtodType.Where(x => x is HttpRequestPOSTMethodType).FirstOrDefault();
            else if (url is HistoryURL.GETURL)
                this.SelectedRequestMethodType = HttpRestClient.RequestMehtodType.Where(x => x is HttpRequestGETMethodType).FirstOrDefault();            
        }

        public void UpdateExecutionStatus(long execTime, decimal size, string statusCode, string statusCodeDescription)
        {
            ExecutionStatusBar = "Exec time: {0} ms({1} sec), Size: {2} Kb({3} Mb), Status code(description): {4}({5})";

            var kb = size / 1024;

            ExecutionStatusBar = String.Format(ExecutionStatusBar, execTime, execTime/1000, kb, kb/1024, statusCode, statusCodeDescription);
        }

        public string ExecutionStatusBar
        {
            get
            {
                return statusLabel.Text;
            }
            set
            {
                statusLabel.Text = value;
            }
        }

        public AutoCompleteStringCollection HistoryURL
        {
            get
            {
                var result = new AutoCompleteStringCollection();
                result.AddRange(_historyURLEngine.URL);
                return result;
            }
        }

        public HistoryURL.HistoryURL[] HistoryURLEx
        {
            get
            {
                return _historyURLEngine.URLEx;
            }
        }


        public string Parameters
        {
            get
            {
                return richParameters.Text;
            }
            set
            {
                richParameters.Text = value;
            }
        }

        public string ExecURL
        {
            get
            {
                return comboExecutionURL.Text;
            }
            set
            {
                comboExecutionURL.Text = value;
            }
        }

        public string ExecSource
        {
            get
            {
                return richSourceXML.Text;
            }
            set
            {
                richSourceXML.Text = value;
            }
        }

        public string SecurityToken
        {
            get
            {
                return richSecurityToken.Text;
            }
            set
            {
                richSecurityToken.Text = value;
            }
        }

        public HTTPRequestMethodType SelectedRequestMethodType
        {
            get
            {
                return (HTTPRequestMethodType)ddlExecutionType.SelectedItem;
            }
            set
            {
                ddlExecutionType.SelectedItem = value;
                
            }
        }

        public ContentType SelectedContentType
        {
            get
            {
                return (ContentType)ddlRequestType.SelectedItem;
            }
        }

        public void SetLabel(string text, Color color)
        {
            lblResultCode.Text = text;
            lblResultCode.ForeColor = color;
        }

        private void Run2_Click(object sender, EventArgs e)
        {
            MessageBox.Show((string)comboExecutionURL.Text);
        }
    }
}

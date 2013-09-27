namespace HttpRequestEditor
{
    partial class HTTPRequestEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGetToken = new System.Windows.Forms.Button();
            this.richSourceXML = new System.Windows.Forms.RichTextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.lblResultCode = new System.Windows.Forms.Label();
            this.ddlRequestType = new System.Windows.Forms.ComboBox();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabAuthentication = new System.Windows.Forms.TabPage();
            this.richSecurityToken = new System.Windows.Forms.RichTextBox();
            this.txtLoginAddress = new System.Windows.Forms.TextBox();
            this.tabExecution = new System.Windows.Forms.TabPage();
            this.ddlExecutionType = new System.Windows.Forms.ComboBox();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.tabControlExecution = new System.Windows.Forms.TabControl();
            this.tabExecutionParameters = new System.Windows.Forms.TabPage();
            this.richParameters = new System.Windows.Forms.RichTextBox();
            this.tabExecutionContent = new System.Windows.Forms.TabPage();
            this.statusExecution = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.comboExecutionURL = new System.Windows.Forms.ComboBox();
            this.mainTabControl.SuspendLayout();
            this.tabAuthentication.SuspendLayout();
            this.tabExecution.SuspendLayout();
            this.tabControlExecution.SuspendLayout();
            this.tabExecutionParameters.SuspendLayout();
            this.tabExecutionContent.SuspendLayout();
            this.statusExecution.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetToken
            // 
            this.btnGetToken.Location = new System.Drawing.Point(6, 6);
            this.btnGetToken.Name = "btnGetToken";
            this.btnGetToken.Size = new System.Drawing.Size(75, 23);
            this.btnGetToken.TabIndex = 0;
            this.btnGetToken.Text = "Login";
            this.btnGetToken.UseVisualStyleBackColor = true;
            this.btnGetToken.Click += new System.EventHandler(this.btnGetToken_Click);
            // 
            // richSourceXML
            // 
            this.richSourceXML.Location = new System.Drawing.Point(2, 0);
            this.richSourceXML.Name = "richSourceXML";
            this.richSourceXML.Size = new System.Drawing.Size(815, 569);
            this.richSourceXML.TabIndex = 1;
            this.richSourceXML.Text = "";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(592, 7);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 3;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // lblResultCode
            // 
            this.lblResultCode.AutoSize = true;
            this.lblResultCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultCode.Location = new System.Drawing.Point(673, 6);
            this.lblResultCode.Name = "lblResultCode";
            this.lblResultCode.Size = new System.Drawing.Size(14, 20);
            this.lblResultCode.TabIndex = 4;
            this.lblResultCode.Text = "-";
            // 
            // ddlRequestType
            // 
            this.ddlRequestType.FormattingEnabled = true;
            this.ddlRequestType.Location = new System.Drawing.Point(6, 7);
            this.ddlRequestType.Name = "ddlRequestType";
            this.ddlRequestType.Size = new System.Drawing.Size(61, 21);
            this.ddlRequestType.TabIndex = 5;
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.tabAuthentication);
            this.mainTabControl.Controls.Add(this.tabExecution);
            this.mainTabControl.Location = new System.Drawing.Point(-1, -1);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(829, 656);
            this.mainTabControl.TabIndex = 6;
            // 
            // tabAuthentication
            // 
            this.tabAuthentication.Controls.Add(this.richSecurityToken);
            this.tabAuthentication.Controls.Add(this.txtLoginAddress);
            this.tabAuthentication.Controls.Add(this.btnGetToken);
            this.tabAuthentication.Location = new System.Drawing.Point(4, 22);
            this.tabAuthentication.Name = "tabAuthentication";
            this.tabAuthentication.Padding = new System.Windows.Forms.Padding(3);
            this.tabAuthentication.Size = new System.Drawing.Size(821, 630);
            this.tabAuthentication.TabIndex = 0;
            this.tabAuthentication.Text = "Authentication";
            this.tabAuthentication.UseVisualStyleBackColor = true;
            // 
            // richSecurityToken
            // 
            this.richSecurityToken.Location = new System.Drawing.Point(7, 36);
            this.richSecurityToken.Name = "richSecurityToken";
            this.richSecurityToken.Size = new System.Drawing.Size(573, 520);
            this.richSecurityToken.TabIndex = 4;
            this.richSecurityToken.Text = "No token retrieved";
            // 
            // txtLoginAddress
            // 
            this.txtLoginAddress.Location = new System.Drawing.Point(87, 8);
            this.txtLoginAddress.Name = "txtLoginAddress";
            this.txtLoginAddress.Size = new System.Drawing.Size(493, 20);
            this.txtLoginAddress.TabIndex = 3;
            this.txtLoginAddress.Text = "URL to login service";
            // 
            // tabExecution
            // 
            this.tabExecution.Controls.Add(this.comboExecutionURL);
            this.tabExecution.Controls.Add(this.ddlExecutionType);
            this.tabExecution.Controls.Add(this.progress);
            this.tabExecution.Controls.Add(this.tabControlExecution);
            this.tabExecution.Controls.Add(this.lblResultCode);
            this.tabExecution.Controls.Add(this.ddlRequestType);
            this.tabExecution.Controls.Add(this.btnRun);
            this.tabExecution.Location = new System.Drawing.Point(4, 22);
            this.tabExecution.Name = "tabExecution";
            this.tabExecution.Padding = new System.Windows.Forms.Padding(3);
            this.tabExecution.Size = new System.Drawing.Size(821, 630);
            this.tabExecution.TabIndex = 1;
            this.tabExecution.Text = "Execution";
            this.tabExecution.UseVisualStyleBackColor = true;
            // 
            // ddlExecutionType
            // 
            this.ddlExecutionType.FormattingEnabled = true;
            this.ddlExecutionType.Location = new System.Drawing.Point(73, 7);
            this.ddlExecutionType.Name = "ddlExecutionType";
            this.ddlExecutionType.Size = new System.Drawing.Size(58, 21);
            this.ddlExecutionType.TabIndex = 8;
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(765, 5);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(46, 22);
            this.progress.TabIndex = 7;
            // 
            // tabControlExecution
            // 
            this.tabControlExecution.Controls.Add(this.tabExecutionParameters);
            this.tabControlExecution.Controls.Add(this.tabExecutionContent);
            this.tabControlExecution.Location = new System.Drawing.Point(0, 33);
            this.tabControlExecution.Name = "tabControlExecution";
            this.tabControlExecution.SelectedIndex = 0;
            this.tabControlExecution.Size = new System.Drawing.Size(825, 601);
            this.tabControlExecution.TabIndex = 6;
            // 
            // tabExecutionParameters
            // 
            this.tabExecutionParameters.Controls.Add(this.richParameters);
            this.tabExecutionParameters.Location = new System.Drawing.Point(4, 22);
            this.tabExecutionParameters.Name = "tabExecutionParameters";
            this.tabExecutionParameters.Padding = new System.Windows.Forms.Padding(3);
            this.tabExecutionParameters.Size = new System.Drawing.Size(817, 575);
            this.tabExecutionParameters.TabIndex = 0;
            this.tabExecutionParameters.Text = "Parameters";
            this.tabExecutionParameters.UseVisualStyleBackColor = true;
            // 
            // richParameters
            // 
            this.richParameters.Location = new System.Drawing.Point(3, 0);
            this.richParameters.Name = "richParameters";
            this.richParameters.Size = new System.Drawing.Size(811, 579);
            this.richParameters.TabIndex = 0;
            this.richParameters.Text = "";
            // 
            // tabExecutionContent
            // 
            this.tabExecutionContent.Controls.Add(this.statusExecution);
            this.tabExecutionContent.Controls.Add(this.richSourceXML);
            this.tabExecutionContent.Location = new System.Drawing.Point(4, 22);
            this.tabExecutionContent.Name = "tabExecutionContent";
            this.tabExecutionContent.Padding = new System.Windows.Forms.Padding(3);
            this.tabExecutionContent.Size = new System.Drawing.Size(817, 575);
            this.tabExecutionContent.TabIndex = 1;
            this.tabExecutionContent.Text = "Result content";
            this.tabExecutionContent.UseVisualStyleBackColor = true;
            // 
            // statusExecution
            // 
            this.statusExecution.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusExecution.Location = new System.Drawing.Point(3, 550);
            this.statusExecution.Name = "statusExecution";
            this.statusExecution.Size = new System.Drawing.Size(811, 22);
            this.statusExecution.TabIndex = 2;
            this.statusExecution.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(66, 17);
            this.statusLabel.Text = "statusLabel";
            // 
            // comboExecutionURL
            // 
            this.comboExecutionURL.FormattingEnabled = true;
            this.comboExecutionURL.Location = new System.Drawing.Point(137, 9);
            this.comboExecutionURL.Name = "comboExecutionURL";
            this.comboExecutionURL.Size = new System.Drawing.Size(449, 21);
            this.comboExecutionURL.TabIndex = 9;
            // 
            // HTTPRequestEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 652);
            this.Controls.Add(this.mainTabControl);
            this.Name = "HTTPRequestEditor";
            this.Text = "HttpRequestEditor";
            this.Load += new System.EventHandler(this.HTTPRequestEditor_Load);
            this.mainTabControl.ResumeLayout(false);
            this.tabAuthentication.ResumeLayout(false);
            this.tabAuthentication.PerformLayout();
            this.tabExecution.ResumeLayout(false);
            this.tabExecution.PerformLayout();
            this.tabControlExecution.ResumeLayout(false);
            this.tabExecutionParameters.ResumeLayout(false);
            this.tabExecutionContent.ResumeLayout(false);
            this.tabExecutionContent.PerformLayout();
            this.statusExecution.ResumeLayout(false);
            this.statusExecution.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetToken;
        private System.Windows.Forms.RichTextBox richSourceXML;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label lblResultCode;
        private System.Windows.Forms.ComboBox ddlRequestType;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabAuthentication;
        private System.Windows.Forms.RichTextBox richSecurityToken;
        private System.Windows.Forms.TextBox txtLoginAddress;
        private System.Windows.Forms.TabPage tabExecution;
        private System.Windows.Forms.TabControl tabControlExecution;
        private System.Windows.Forms.TabPage tabExecutionParameters;
        private System.Windows.Forms.RichTextBox richParameters;
        private System.Windows.Forms.TabPage tabExecutionContent;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.ComboBox ddlExecutionType;
        private System.Windows.Forms.StatusStrip statusExecution;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ComboBox comboExecutionURL;
    }
}


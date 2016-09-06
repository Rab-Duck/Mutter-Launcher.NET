namespace MutterLauncher
{
    partial class SettingFormUserItem
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingFormUserItem));
            this.txtCmd = new System.Windows.Forms.TextBox();
            this.cbName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkFixedItem = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEncoding = new System.Windows.Forms.TextBox();
            this.chkUseUrlEncode = new System.Windows.Forms.CheckBox();
            this.chkUseCmdOption = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCmd
            // 
            this.txtCmd.Location = new System.Drawing.Point(68, 39);
            this.txtCmd.Name = "txtCmd";
            this.txtCmd.Size = new System.Drawing.Size(223, 19);
            this.txtCmd.TabIndex = 3;
            this.toolTip.SetToolTip(this.txtCmd, "Input command (%1 replaced with input text)\r\nexample\r\n%1\r\n");
            this.txtCmd.Validating += new System.ComponentModel.CancelEventHandler(this.txtCmd_Validating);
            this.txtCmd.Validated += new System.EventHandler(this.txtCmd_Validated);
            // 
            // cbName
            // 
            this.cbName.FormattingEnabled = true;
            this.cbName.Items.AddRange(new object[] {
            "Run",
            "Google Search",
            "netstat"});
            this.cbName.Location = new System.Drawing.Point(68, 13);
            this.cbName.Name = "cbName";
            this.cbName.Size = new System.Drawing.Size(223, 20);
            this.cbName.TabIndex = 1;
            this.toolTip.SetToolTip(this.cbName, "Input Display Name\r\nexample:\r\nRun\r\nGoogle\r\nnetstat\r\n");
            this.cbName.SelectionChangeCommitted += new System.EventHandler(this.cbName_SelectionChangeCommitted);
            this.cbName.Validating += new System.ComponentModel.CancelEventHandler(this.cbName_Validating);
            this.cbName.Validated += new System.EventHandler(this.cbName_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name(&N)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cmd(&C)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkFixedItem);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtEncoding);
            this.groupBox1.Controls.Add(this.chkUseUrlEncode);
            this.groupBox1.Controls.Add(this.chkUseCmdOption);
            this.groupBox1.Location = new System.Drawing.Point(14, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 122);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details(&D)";
            // 
            // chkFixedItem
            // 
            this.chkFixedItem.AutoSize = true;
            this.chkFixedItem.Location = new System.Drawing.Point(6, 18);
            this.chkFixedItem.Name = "chkFixedItem";
            this.chkFixedItem.Size = new System.Drawing.Size(129, 16);
            this.chkFixedItem.TabIndex = 0;
            this.chkFixedItem.Text = "Fixed position in list";
            this.chkFixedItem.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Encoding";
            // 
            // txtEncoding
            // 
            this.txtEncoding.Enabled = false;
            this.txtEncoding.Location = new System.Drawing.Point(80, 90);
            this.txtEncoding.Name = "txtEncoding";
            this.txtEncoding.Size = new System.Drawing.Size(67, 19);
            this.txtEncoding.TabIndex = 4;
            this.txtEncoding.Text = "UTF-8";
            this.txtEncoding.Validating += new System.ComponentModel.CancelEventHandler(this.txtEncoding_Validating);
            this.txtEncoding.Validated += new System.EventHandler(this.txtEncoding_Validated);
            // 
            // chkUseUrlEncode
            // 
            this.chkUseUrlEncode.AutoSize = true;
            this.chkUseUrlEncode.Location = new System.Drawing.Point(6, 74);
            this.chkUseUrlEncode.Name = "chkUseUrlEncode";
            this.chkUseUrlEncode.Size = new System.Drawing.Size(131, 16);
            this.chkUseUrlEncode.TabIndex = 2;
            this.chkUseUrlEncode.Text = "Use urlencode for %1";
            this.chkUseUrlEncode.UseVisualStyleBackColor = true;
            this.chkUseUrlEncode.CheckedChanged += new System.EventHandler(this.chkUseUrlEncode_CheckedChanged);
            // 
            // chkUseCmdOption
            // 
            this.chkUseCmdOption.AutoSize = true;
            this.chkUseCmdOption.Location = new System.Drawing.Point(6, 40);
            this.chkUseCmdOption.Name = "chkUseCmdOption";
            this.chkUseCmdOption.Size = new System.Drawing.Size(193, 28);
            this.chkUseCmdOption.TabIndex = 1;
            this.chkUseCmdOption.Text = "First SPACE(\" \") in \"Cmd\" is\r\nthe separator of command option";
            this.chkUseCmdOption.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(216, 192);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(135, 192);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // SettingFormUserItem
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(303, 223);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbName);
            this.Controls.Add(this.txtCmd);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingFormUserItem";
            this.Text = "Setting User Item";
            this.Load += new System.EventHandler(this.SettingFormUserItem_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCmd;
        private System.Windows.Forms.ComboBox cbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEncoding;
        private System.Windows.Forms.CheckBox chkUseUrlEncode;
        private System.Windows.Forms.CheckBox chkUseCmdOption;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox chkFixedItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
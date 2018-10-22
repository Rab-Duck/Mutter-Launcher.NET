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
            this.chkUseEnvironmentVariable = new System.Windows.Forms.CheckBox();
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
            resources.ApplyResources(this.txtCmd, "txtCmd");
            this.txtCmd.Name = "txtCmd";
            this.toolTip.SetToolTip(this.txtCmd, resources.GetString("txtCmd.ToolTip"));
            this.txtCmd.Validating += new System.ComponentModel.CancelEventHandler(this.txtCmd_Validating);
            this.txtCmd.Validated += new System.EventHandler(this.txtCmd_Validated);
            // 
            // cbName
            // 
            this.cbName.FormattingEnabled = true;
            this.cbName.Items.AddRange(new object[] {
            resources.GetString("cbName.Items"),
            resources.GetString("cbName.Items1"),
            resources.GetString("cbName.Items2")});
            resources.ApplyResources(this.cbName, "cbName");
            this.cbName.Name = "cbName";
            this.toolTip.SetToolTip(this.cbName, resources.GetString("cbName.ToolTip"));
            this.cbName.SelectionChangeCommitted += new System.EventHandler(this.cbName_SelectionChangeCommitted);
            this.cbName.Validating += new System.ComponentModel.CancelEventHandler(this.cbName_Validating);
            this.cbName.Validated += new System.EventHandler(this.cbName_Validated);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkUseEnvironmentVariable);
            this.groupBox1.Controls.Add(this.chkFixedItem);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtEncoding);
            this.groupBox1.Controls.Add(this.chkUseUrlEncode);
            this.groupBox1.Controls.Add(this.chkUseCmdOption);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // chkUseEnvironmentVariable
            // 
            resources.ApplyResources(this.chkUseEnvironmentVariable, "chkUseEnvironmentVariable");
            this.chkUseEnvironmentVariable.Name = "chkUseEnvironmentVariable";
            this.chkUseEnvironmentVariable.UseVisualStyleBackColor = true;
            // 
            // chkFixedItem
            // 
            resources.ApplyResources(this.chkFixedItem, "chkFixedItem");
            this.chkFixedItem.Name = "chkFixedItem";
            this.chkFixedItem.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtEncoding
            // 
            resources.ApplyResources(this.txtEncoding, "txtEncoding");
            this.txtEncoding.Name = "txtEncoding";
            this.txtEncoding.Validating += new System.ComponentModel.CancelEventHandler(this.txtEncoding_Validating);
            this.txtEncoding.Validated += new System.EventHandler(this.txtEncoding_Validated);
            // 
            // chkUseUrlEncode
            // 
            resources.ApplyResources(this.chkUseUrlEncode, "chkUseUrlEncode");
            this.chkUseUrlEncode.Name = "chkUseUrlEncode";
            this.chkUseUrlEncode.UseVisualStyleBackColor = true;
            this.chkUseUrlEncode.CheckedChanged += new System.EventHandler(this.chkUseUrlEncode_CheckedChanged);
            // 
            // chkUseCmdOption
            // 
            resources.ApplyResources(this.chkUseCmdOption, "chkUseCmdOption");
            this.chkUseCmdOption.Name = "chkUseCmdOption";
            this.chkUseCmdOption.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
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
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbName);
            this.Controls.Add(this.txtCmd);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingFormUserItem";
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
        private System.Windows.Forms.CheckBox chkUseEnvironmentVariable;
    }
}
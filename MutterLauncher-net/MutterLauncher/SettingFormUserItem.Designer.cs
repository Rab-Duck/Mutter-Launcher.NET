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
            this.errorProvider.SetError(this.txtCmd, resources.GetString("txtCmd.Error"));
            this.errorProvider.SetIconAlignment(this.txtCmd, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtCmd.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.txtCmd, ((int)(resources.GetObject("txtCmd.IconPadding"))));
            this.txtCmd.Name = "txtCmd";
            this.toolTip.SetToolTip(this.txtCmd, resources.GetString("txtCmd.ToolTip"));
            this.txtCmd.Validating += new System.ComponentModel.CancelEventHandler(this.txtCmd_Validating);
            this.txtCmd.Validated += new System.EventHandler(this.txtCmd_Validated);
            // 
            // cbName
            // 
            resources.ApplyResources(this.cbName, "cbName");
            this.errorProvider.SetError(this.cbName, resources.GetString("cbName.Error"));
            this.cbName.FormattingEnabled = true;
            this.errorProvider.SetIconAlignment(this.cbName, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cbName.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.cbName, ((int)(resources.GetObject("cbName.IconPadding"))));
            this.cbName.Items.AddRange(new object[] {
            resources.GetString("cbName.Items"),
            resources.GetString("cbName.Items1"),
            resources.GetString("cbName.Items2")});
            this.cbName.Name = "cbName";
            this.toolTip.SetToolTip(this.cbName, resources.GetString("cbName.ToolTip"));
            this.cbName.SelectionChangeCommitted += new System.EventHandler(this.cbName_SelectionChangeCommitted);
            this.cbName.Validating += new System.ComponentModel.CancelEventHandler(this.cbName_Validating);
            this.cbName.Validated += new System.EventHandler(this.cbName_Validated);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.errorProvider.SetError(this.label1, resources.GetString("label1.Error"));
            this.errorProvider.SetIconAlignment(this.label1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label1.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.label1, ((int)(resources.GetObject("label1.IconPadding"))));
            this.label1.Name = "label1";
            this.toolTip.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.errorProvider.SetError(this.label2, resources.GetString("label2.Error"));
            this.errorProvider.SetIconAlignment(this.label2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label2.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.label2, ((int)(resources.GetObject("label2.IconPadding"))));
            this.label2.Name = "label2";
            this.toolTip.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.chkUseEnvironmentVariable);
            this.groupBox1.Controls.Add(this.chkFixedItem);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtEncoding);
            this.groupBox1.Controls.Add(this.chkUseUrlEncode);
            this.groupBox1.Controls.Add(this.chkUseCmdOption);
            this.errorProvider.SetError(this.groupBox1, resources.GetString("groupBox1.Error"));
            this.errorProvider.SetIconAlignment(this.groupBox1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("groupBox1.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.groupBox1, ((int)(resources.GetObject("groupBox1.IconPadding"))));
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.toolTip.SetToolTip(this.groupBox1, resources.GetString("groupBox1.ToolTip"));
            // 
            // chkUseEnvironmentVariable
            // 
            resources.ApplyResources(this.chkUseEnvironmentVariable, "chkUseEnvironmentVariable");
            this.errorProvider.SetError(this.chkUseEnvironmentVariable, resources.GetString("chkUseEnvironmentVariable.Error"));
            this.errorProvider.SetIconAlignment(this.chkUseEnvironmentVariable, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("chkUseEnvironmentVariable.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.chkUseEnvironmentVariable, ((int)(resources.GetObject("chkUseEnvironmentVariable.IconPadding"))));
            this.chkUseEnvironmentVariable.Name = "chkUseEnvironmentVariable";
            this.toolTip.SetToolTip(this.chkUseEnvironmentVariable, resources.GetString("chkUseEnvironmentVariable.ToolTip"));
            this.chkUseEnvironmentVariable.UseVisualStyleBackColor = true;
            // 
            // chkFixedItem
            // 
            resources.ApplyResources(this.chkFixedItem, "chkFixedItem");
            this.errorProvider.SetError(this.chkFixedItem, resources.GetString("chkFixedItem.Error"));
            this.errorProvider.SetIconAlignment(this.chkFixedItem, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("chkFixedItem.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.chkFixedItem, ((int)(resources.GetObject("chkFixedItem.IconPadding"))));
            this.chkFixedItem.Name = "chkFixedItem";
            this.toolTip.SetToolTip(this.chkFixedItem, resources.GetString("chkFixedItem.ToolTip"));
            this.chkFixedItem.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.errorProvider.SetError(this.label3, resources.GetString("label3.Error"));
            this.errorProvider.SetIconAlignment(this.label3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label3.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.label3, ((int)(resources.GetObject("label3.IconPadding"))));
            this.label3.Name = "label3";
            this.toolTip.SetToolTip(this.label3, resources.GetString("label3.ToolTip"));
            // 
            // txtEncoding
            // 
            resources.ApplyResources(this.txtEncoding, "txtEncoding");
            this.errorProvider.SetError(this.txtEncoding, resources.GetString("txtEncoding.Error"));
            this.errorProvider.SetIconAlignment(this.txtEncoding, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtEncoding.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.txtEncoding, ((int)(resources.GetObject("txtEncoding.IconPadding"))));
            this.txtEncoding.Name = "txtEncoding";
            this.toolTip.SetToolTip(this.txtEncoding, resources.GetString("txtEncoding.ToolTip"));
            this.txtEncoding.Validating += new System.ComponentModel.CancelEventHandler(this.txtEncoding_Validating);
            this.txtEncoding.Validated += new System.EventHandler(this.txtEncoding_Validated);
            // 
            // chkUseUrlEncode
            // 
            resources.ApplyResources(this.chkUseUrlEncode, "chkUseUrlEncode");
            this.errorProvider.SetError(this.chkUseUrlEncode, resources.GetString("chkUseUrlEncode.Error"));
            this.errorProvider.SetIconAlignment(this.chkUseUrlEncode, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("chkUseUrlEncode.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.chkUseUrlEncode, ((int)(resources.GetObject("chkUseUrlEncode.IconPadding"))));
            this.chkUseUrlEncode.Name = "chkUseUrlEncode";
            this.toolTip.SetToolTip(this.chkUseUrlEncode, resources.GetString("chkUseUrlEncode.ToolTip"));
            this.chkUseUrlEncode.UseVisualStyleBackColor = true;
            this.chkUseUrlEncode.CheckedChanged += new System.EventHandler(this.chkUseUrlEncode_CheckedChanged);
            // 
            // chkUseCmdOption
            // 
            resources.ApplyResources(this.chkUseCmdOption, "chkUseCmdOption");
            this.errorProvider.SetError(this.chkUseCmdOption, resources.GetString("chkUseCmdOption.Error"));
            this.errorProvider.SetIconAlignment(this.chkUseCmdOption, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("chkUseCmdOption.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.chkUseCmdOption, ((int)(resources.GetObject("chkUseCmdOption.IconPadding"))));
            this.chkUseCmdOption.Name = "chkUseCmdOption";
            this.toolTip.SetToolTip(this.chkUseCmdOption, resources.GetString("chkUseCmdOption.ToolTip"));
            this.chkUseCmdOption.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.errorProvider.SetError(this.btnCancel, resources.GetString("btnCancel.Error"));
            this.errorProvider.SetIconAlignment(this.btnCancel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnCancel.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.btnCancel, ((int)(resources.GetObject("btnCancel.IconPadding"))));
            this.btnCancel.Name = "btnCancel";
            this.toolTip.SetToolTip(this.btnCancel, resources.GetString("btnCancel.ToolTip"));
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.errorProvider.SetError(this.btnOk, resources.GetString("btnOk.Error"));
            this.errorProvider.SetIconAlignment(this.btnOk, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnOk.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.btnOk, ((int)(resources.GetObject("btnOk.IconPadding"))));
            this.btnOk.Name = "btnOk";
            this.toolTip.SetToolTip(this.btnOk, resources.GetString("btnOk.ToolTip"));
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            resources.ApplyResources(this.errorProvider, "errorProvider");
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
            this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
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
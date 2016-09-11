namespace MutterLauncher
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.txtbxHotkey = new System.Windows.Forms.TextBox();
            this.tbAnyFolder = new System.Windows.Forms.TextBox();
            this.cbCtrl = new System.Windows.Forms.CheckBox();
            this.cbWin = new System.Windows.Forms.CheckBox();
            this.cbAlt = new System.Windows.Forms.CheckBox();
            this.cbShift = new System.Windows.Forms.CheckBox();
            this.toolTipSetting = new System.Windows.Forms.ToolTip(this.components);
            this.btnUserItemDel = new System.Windows.Forms.Button();
            this.btnUserItemUpdate = new System.Windows.Forms.Button();
            this.btnUserItemAdd = new System.Windows.Forms.Button();
            this.btnUserItemUp = new System.Windows.Forms.Button();
            this.btnUserItemDown = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lsvUserItem = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbEqual = new System.Windows.Forms.TextBox();
            this.tbSkipMatching = new System.Windows.Forms.TextBox();
            this.tbEndWith = new System.Windows.Forms.TextBox();
            this.tbStartWith = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDisplayItemMax = new System.Windows.Forms.TextBox();
            this.tbExecHistoryMax = new System.Windows.Forms.TextBox();
            this.tbSearchHistoryMax = new System.Windows.Forms.TextBox();
            this.tbUpdateInterval = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbxHotkey
            // 
            resources.ApplyResources(this.txtbxHotkey, "txtbxHotkey");
            this.errorProvider1.SetError(this.txtbxHotkey, resources.GetString("txtbxHotkey.Error"));
            this.errorProvider1.SetIconAlignment(this.txtbxHotkey, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtbxHotkey.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.txtbxHotkey, ((int)(resources.GetObject("txtbxHotkey.IconPadding"))));
            this.txtbxHotkey.Name = "txtbxHotkey";
            this.toolTipSetting.SetToolTip(this.txtbxHotkey, resources.GetString("txtbxHotkey.ToolTip"));
            this.txtbxHotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbxHotkey_KeyDown);
            this.txtbxHotkey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxHotkey_KeyPress);
            this.txtbxHotkey.Validating += new System.ComponentModel.CancelEventHandler(this.txtbxHotkey_Validating);
            this.txtbxHotkey.Validated += new System.EventHandler(this.txtbxHotkey_Validated);
            // 
            // tbAnyFolder
            // 
            resources.ApplyResources(this.tbAnyFolder, "tbAnyFolder");
            this.errorProvider1.SetError(this.tbAnyFolder, resources.GetString("tbAnyFolder.Error"));
            this.errorProvider1.SetIconAlignment(this.tbAnyFolder, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tbAnyFolder.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.tbAnyFolder, ((int)(resources.GetObject("tbAnyFolder.IconPadding"))));
            this.tbAnyFolder.Name = "tbAnyFolder";
            this.toolTipSetting.SetToolTip(this.tbAnyFolder, resources.GetString("tbAnyFolder.ToolTip"));
            // 
            // cbCtrl
            // 
            resources.ApplyResources(this.cbCtrl, "cbCtrl");
            this.errorProvider1.SetError(this.cbCtrl, resources.GetString("cbCtrl.Error"));
            this.errorProvider1.SetIconAlignment(this.cbCtrl, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cbCtrl.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.cbCtrl, ((int)(resources.GetObject("cbCtrl.IconPadding"))));
            this.cbCtrl.Name = "cbCtrl";
            this.toolTipSetting.SetToolTip(this.cbCtrl, resources.GetString("cbCtrl.ToolTip"));
            this.cbCtrl.UseVisualStyleBackColor = true;
            // 
            // cbWin
            // 
            resources.ApplyResources(this.cbWin, "cbWin");
            this.errorProvider1.SetError(this.cbWin, resources.GetString("cbWin.Error"));
            this.errorProvider1.SetIconAlignment(this.cbWin, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cbWin.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.cbWin, ((int)(resources.GetObject("cbWin.IconPadding"))));
            this.cbWin.Name = "cbWin";
            this.toolTipSetting.SetToolTip(this.cbWin, resources.GetString("cbWin.ToolTip"));
            this.cbWin.UseVisualStyleBackColor = true;
            // 
            // cbAlt
            // 
            resources.ApplyResources(this.cbAlt, "cbAlt");
            this.errorProvider1.SetError(this.cbAlt, resources.GetString("cbAlt.Error"));
            this.errorProvider1.SetIconAlignment(this.cbAlt, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cbAlt.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.cbAlt, ((int)(resources.GetObject("cbAlt.IconPadding"))));
            this.cbAlt.Name = "cbAlt";
            this.toolTipSetting.SetToolTip(this.cbAlt, resources.GetString("cbAlt.ToolTip"));
            this.cbAlt.UseVisualStyleBackColor = true;
            // 
            // cbShift
            // 
            resources.ApplyResources(this.cbShift, "cbShift");
            this.errorProvider1.SetError(this.cbShift, resources.GetString("cbShift.Error"));
            this.errorProvider1.SetIconAlignment(this.cbShift, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cbShift.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.cbShift, ((int)(resources.GetObject("cbShift.IconPadding"))));
            this.cbShift.Name = "cbShift";
            this.toolTipSetting.SetToolTip(this.cbShift, resources.GetString("cbShift.ToolTip"));
            this.cbShift.UseVisualStyleBackColor = true;
            // 
            // btnUserItemDel
            // 
            resources.ApplyResources(this.btnUserItemDel, "btnUserItemDel");
            this.errorProvider1.SetError(this.btnUserItemDel, resources.GetString("btnUserItemDel.Error"));
            this.errorProvider1.SetIconAlignment(this.btnUserItemDel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnUserItemDel.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.btnUserItemDel, ((int)(resources.GetObject("btnUserItemDel.IconPadding"))));
            this.btnUserItemDel.Name = "btnUserItemDel";
            this.toolTipSetting.SetToolTip(this.btnUserItemDel, resources.GetString("btnUserItemDel.ToolTip"));
            this.btnUserItemDel.UseVisualStyleBackColor = true;
            this.btnUserItemDel.Click += new System.EventHandler(this.btnUserItemDel_Click);
            // 
            // btnUserItemUpdate
            // 
            resources.ApplyResources(this.btnUserItemUpdate, "btnUserItemUpdate");
            this.errorProvider1.SetError(this.btnUserItemUpdate, resources.GetString("btnUserItemUpdate.Error"));
            this.errorProvider1.SetIconAlignment(this.btnUserItemUpdate, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnUserItemUpdate.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.btnUserItemUpdate, ((int)(resources.GetObject("btnUserItemUpdate.IconPadding"))));
            this.btnUserItemUpdate.Name = "btnUserItemUpdate";
            this.toolTipSetting.SetToolTip(this.btnUserItemUpdate, resources.GetString("btnUserItemUpdate.ToolTip"));
            this.btnUserItemUpdate.UseVisualStyleBackColor = true;
            this.btnUserItemUpdate.Click += new System.EventHandler(this.btnUserItemUpdate_Click);
            // 
            // btnUserItemAdd
            // 
            resources.ApplyResources(this.btnUserItemAdd, "btnUserItemAdd");
            this.errorProvider1.SetError(this.btnUserItemAdd, resources.GetString("btnUserItemAdd.Error"));
            this.errorProvider1.SetIconAlignment(this.btnUserItemAdd, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnUserItemAdd.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.btnUserItemAdd, ((int)(resources.GetObject("btnUserItemAdd.IconPadding"))));
            this.btnUserItemAdd.Name = "btnUserItemAdd";
            this.toolTipSetting.SetToolTip(this.btnUserItemAdd, resources.GetString("btnUserItemAdd.ToolTip"));
            this.btnUserItemAdd.UseVisualStyleBackColor = true;
            this.btnUserItemAdd.Click += new System.EventHandler(this.btnUserItemAdd_Click);
            // 
            // btnUserItemUp
            // 
            resources.ApplyResources(this.btnUserItemUp, "btnUserItemUp");
            this.errorProvider1.SetError(this.btnUserItemUp, resources.GetString("btnUserItemUp.Error"));
            this.errorProvider1.SetIconAlignment(this.btnUserItemUp, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnUserItemUp.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.btnUserItemUp, ((int)(resources.GetObject("btnUserItemUp.IconPadding"))));
            this.btnUserItemUp.Image = global::MutterLauncher.Properties.Resources.ARW07UP;
            this.btnUserItemUp.Name = "btnUserItemUp";
            this.toolTipSetting.SetToolTip(this.btnUserItemUp, resources.GetString("btnUserItemUp.ToolTip"));
            this.btnUserItemUp.UseVisualStyleBackColor = true;
            this.btnUserItemUp.Click += new System.EventHandler(this.btnUserItemUp_Click);
            // 
            // btnUserItemDown
            // 
            resources.ApplyResources(this.btnUserItemDown, "btnUserItemDown");
            this.errorProvider1.SetError(this.btnUserItemDown, resources.GetString("btnUserItemDown.Error"));
            this.errorProvider1.SetIconAlignment(this.btnUserItemDown, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnUserItemDown.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.btnUserItemDown, ((int)(resources.GetObject("btnUserItemDown.IconPadding"))));
            this.btnUserItemDown.Image = global::MutterLauncher.Properties.Resources.ARW07DN;
            this.btnUserItemDown.Name = "btnUserItemDown";
            this.toolTipSetting.SetToolTip(this.btnUserItemDown, resources.GetString("btnUserItemDown.ToolTip"));
            this.btnUserItemDown.UseVisualStyleBackColor = true;
            this.btnUserItemDown.Click += new System.EventHandler(this.btnUserItemDown_Click);
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.errorProvider1.SetError(this.label12, resources.GetString("label12.Error"));
            this.errorProvider1.SetIconAlignment(this.label12, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label12.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.label12, ((int)(resources.GetObject("label12.IconPadding"))));
            this.label12.Name = "label12";
            this.toolTipSetting.SetToolTip(this.label12, resources.GetString("label12.ToolTip"));
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.errorProvider1.SetError(this.label9, resources.GetString("label9.Error"));
            this.errorProvider1.SetIconAlignment(this.label9, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label9.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.label9, ((int)(resources.GetObject("label9.IconPadding"))));
            this.label9.Name = "label9";
            this.toolTipSetting.SetToolTip(this.label9, resources.GetString("label9.ToolTip"));
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.errorProvider1.SetError(this.label1, resources.GetString("label1.Error"));
            this.errorProvider1.SetIconAlignment(this.label1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label1.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.label1, ((int)(resources.GetObject("label1.IconPadding"))));
            this.label1.Name = "label1";
            this.toolTipSetting.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.errorProvider1.SetError(this.label7, resources.GetString("label7.Error"));
            this.errorProvider1.SetIconAlignment(this.label7, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label7.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.label7, ((int)(resources.GetObject("label7.IconPadding"))));
            this.label7.Name = "label7";
            this.toolTipSetting.SetToolTip(this.label7, resources.GetString("label7.ToolTip"));
            // 
            // lsvUserItem
            // 
            resources.ApplyResources(this.lsvUserItem, "lsvUserItem");
            this.lsvUserItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.errorProvider1.SetError(this.lsvUserItem, resources.GetString("lsvUserItem.Error"));
            this.lsvUserItem.FullRowSelect = true;
            this.lsvUserItem.GridLines = true;
            this.lsvUserItem.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvUserItem.HideSelection = false;
            this.errorProvider1.SetIconAlignment(this.lsvUserItem, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lsvUserItem.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.lsvUserItem, ((int)(resources.GetObject("lsvUserItem.IconPadding"))));
            this.lsvUserItem.MultiSelect = false;
            this.lsvUserItem.Name = "lsvUserItem";
            this.toolTipSetting.SetToolTip(this.lsvUserItem, resources.GetString("lsvUserItem.ToolTip"));
            this.lsvUserItem.UseCompatibleStateImageBehavior = false;
            this.lsvUserItem.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.errorProvider1.SetError(this.btnOk, resources.GetString("btnOk.Error"));
            this.errorProvider1.SetIconAlignment(this.btnOk, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnOk.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.btnOk, ((int)(resources.GetObject("btnOk.IconPadding"))));
            this.btnOk.Name = "btnOk";
            this.toolTipSetting.SetToolTip(this.btnOk, resources.GetString("btnOk.ToolTip"));
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.errorProvider1.SetError(this.btnCancel, resources.GetString("btnCancel.Error"));
            this.errorProvider1.SetIconAlignment(this.btnCancel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnCancel.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.btnCancel, ((int)(resources.GetObject("btnCancel.IconPadding"))));
            this.btnCancel.Name = "btnCancel";
            this.toolTipSetting.SetToolTip(this.btnCancel, resources.GetString("btnCancel.ToolTip"));
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.tbEqual);
            this.groupBox1.Controls.Add(this.tbSkipMatching);
            this.groupBox1.Controls.Add(this.tbEndWith);
            this.groupBox1.Controls.Add(this.tbStartWith);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.errorProvider1.SetError(this.groupBox1, resources.GetString("groupBox1.Error"));
            this.errorProvider1.SetIconAlignment(this.groupBox1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("groupBox1.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.groupBox1, ((int)(resources.GetObject("groupBox1.IconPadding"))));
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.toolTipSetting.SetToolTip(this.groupBox1, resources.GetString("groupBox1.ToolTip"));
            // 
            // tbEqual
            // 
            resources.ApplyResources(this.tbEqual, "tbEqual");
            this.errorProvider1.SetError(this.tbEqual, resources.GetString("tbEqual.Error"));
            this.errorProvider1.SetIconAlignment(this.tbEqual, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tbEqual.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.tbEqual, ((int)(resources.GetObject("tbEqual.IconPadding"))));
            this.tbEqual.Name = "tbEqual";
            this.toolTipSetting.SetToolTip(this.tbEqual, resources.GetString("tbEqual.ToolTip"));
            this.tbEqual.Validating += new System.ComponentModel.CancelEventHandler(this.tbEqual_Validating);
            this.tbEqual.Validated += new System.EventHandler(this.tbEqual_Validated);
            // 
            // tbSkipMatching
            // 
            resources.ApplyResources(this.tbSkipMatching, "tbSkipMatching");
            this.errorProvider1.SetError(this.tbSkipMatching, resources.GetString("tbSkipMatching.Error"));
            this.errorProvider1.SetIconAlignment(this.tbSkipMatching, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tbSkipMatching.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.tbSkipMatching, ((int)(resources.GetObject("tbSkipMatching.IconPadding"))));
            this.tbSkipMatching.Name = "tbSkipMatching";
            this.toolTipSetting.SetToolTip(this.tbSkipMatching, resources.GetString("tbSkipMatching.ToolTip"));
            this.tbSkipMatching.Validating += new System.ComponentModel.CancelEventHandler(this.tbSkipMatching_Validating);
            this.tbSkipMatching.Validated += new System.EventHandler(this.tbSkipMatching_Validated);
            // 
            // tbEndWith
            // 
            resources.ApplyResources(this.tbEndWith, "tbEndWith");
            this.errorProvider1.SetError(this.tbEndWith, resources.GetString("tbEndWith.Error"));
            this.errorProvider1.SetIconAlignment(this.tbEndWith, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tbEndWith.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.tbEndWith, ((int)(resources.GetObject("tbEndWith.IconPadding"))));
            this.tbEndWith.Name = "tbEndWith";
            this.toolTipSetting.SetToolTip(this.tbEndWith, resources.GetString("tbEndWith.ToolTip"));
            this.tbEndWith.Validating += new System.ComponentModel.CancelEventHandler(this.tbEndWith_Validating);
            this.tbEndWith.Validated += new System.EventHandler(this.tbEndWith_Validated);
            // 
            // tbStartWith
            // 
            resources.ApplyResources(this.tbStartWith, "tbStartWith");
            this.errorProvider1.SetError(this.tbStartWith, resources.GetString("tbStartWith.Error"));
            this.errorProvider1.SetIconAlignment(this.tbStartWith, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tbStartWith.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.tbStartWith, ((int)(resources.GetObject("tbStartWith.IconPadding"))));
            this.tbStartWith.Name = "tbStartWith";
            this.toolTipSetting.SetToolTip(this.tbStartWith, resources.GetString("tbStartWith.ToolTip"));
            this.tbStartWith.Validating += new System.ComponentModel.CancelEventHandler(this.tbStartWith_Validating);
            this.tbStartWith.Validated += new System.EventHandler(this.tbStartWith_Validated);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.errorProvider1.SetError(this.label6, resources.GetString("label6.Error"));
            this.errorProvider1.SetIconAlignment(this.label6, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label6.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.label6, ((int)(resources.GetObject("label6.IconPadding"))));
            this.label6.Name = "label6";
            this.toolTipSetting.SetToolTip(this.label6, resources.GetString("label6.ToolTip"));
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.errorProvider1.SetError(this.label5, resources.GetString("label5.Error"));
            this.errorProvider1.SetIconAlignment(this.label5, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label5.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.label5, ((int)(resources.GetObject("label5.IconPadding"))));
            this.label5.Name = "label5";
            this.toolTipSetting.SetToolTip(this.label5, resources.GetString("label5.ToolTip"));
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.errorProvider1.SetError(this.label4, resources.GetString("label4.Error"));
            this.errorProvider1.SetIconAlignment(this.label4, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label4.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.label4, ((int)(resources.GetObject("label4.IconPadding"))));
            this.label4.Name = "label4";
            this.toolTipSetting.SetToolTip(this.label4, resources.GetString("label4.ToolTip"));
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.errorProvider1.SetError(this.label3, resources.GetString("label3.Error"));
            this.errorProvider1.SetIconAlignment(this.label3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label3.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.label3, ((int)(resources.GetObject("label3.IconPadding"))));
            this.label3.Name = "label3";
            this.toolTipSetting.SetToolTip(this.label3, resources.GetString("label3.ToolTip"));
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbDisplayItemMax);
            this.groupBox2.Controls.Add(this.tbExecHistoryMax);
            this.groupBox2.Controls.Add(this.tbSearchHistoryMax);
            this.groupBox2.Controls.Add(this.tbUpdateInterval);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.errorProvider1.SetError(this.groupBox2, resources.GetString("groupBox2.Error"));
            this.errorProvider1.SetIconAlignment(this.groupBox2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("groupBox2.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.groupBox2, ((int)(resources.GetObject("groupBox2.IconPadding"))));
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            this.toolTipSetting.SetToolTip(this.groupBox2, resources.GetString("groupBox2.ToolTip"));
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.errorProvider1.SetError(this.label2, resources.GetString("label2.Error"));
            this.errorProvider1.SetIconAlignment(this.label2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label2.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.label2, ((int)(resources.GetObject("label2.IconPadding"))));
            this.label2.Name = "label2";
            this.toolTipSetting.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            // 
            // tbDisplayItemMax
            // 
            resources.ApplyResources(this.tbDisplayItemMax, "tbDisplayItemMax");
            this.errorProvider1.SetError(this.tbDisplayItemMax, resources.GetString("tbDisplayItemMax.Error"));
            this.errorProvider1.SetIconAlignment(this.tbDisplayItemMax, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tbDisplayItemMax.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.tbDisplayItemMax, ((int)(resources.GetObject("tbDisplayItemMax.IconPadding"))));
            this.tbDisplayItemMax.Name = "tbDisplayItemMax";
            this.toolTipSetting.SetToolTip(this.tbDisplayItemMax, resources.GetString("tbDisplayItemMax.ToolTip"));
            this.tbDisplayItemMax.Validating += new System.ComponentModel.CancelEventHandler(this.tbDisplayItemMax_Validating);
            this.tbDisplayItemMax.Validated += new System.EventHandler(this.tbDisplayItemMax_Validated);
            // 
            // tbExecHistoryMax
            // 
            resources.ApplyResources(this.tbExecHistoryMax, "tbExecHistoryMax");
            this.errorProvider1.SetError(this.tbExecHistoryMax, resources.GetString("tbExecHistoryMax.Error"));
            this.errorProvider1.SetIconAlignment(this.tbExecHistoryMax, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tbExecHistoryMax.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.tbExecHistoryMax, ((int)(resources.GetObject("tbExecHistoryMax.IconPadding"))));
            this.tbExecHistoryMax.Name = "tbExecHistoryMax";
            this.toolTipSetting.SetToolTip(this.tbExecHistoryMax, resources.GetString("tbExecHistoryMax.ToolTip"));
            this.tbExecHistoryMax.Validating += new System.ComponentModel.CancelEventHandler(this.tbExecHistoryMax_Validating);
            this.tbExecHistoryMax.Validated += new System.EventHandler(this.tbExecHistoryMax_Validated);
            // 
            // tbSearchHistoryMax
            // 
            resources.ApplyResources(this.tbSearchHistoryMax, "tbSearchHistoryMax");
            this.errorProvider1.SetError(this.tbSearchHistoryMax, resources.GetString("tbSearchHistoryMax.Error"));
            this.errorProvider1.SetIconAlignment(this.tbSearchHistoryMax, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tbSearchHistoryMax.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.tbSearchHistoryMax, ((int)(resources.GetObject("tbSearchHistoryMax.IconPadding"))));
            this.tbSearchHistoryMax.Name = "tbSearchHistoryMax";
            this.toolTipSetting.SetToolTip(this.tbSearchHistoryMax, resources.GetString("tbSearchHistoryMax.ToolTip"));
            this.tbSearchHistoryMax.Validating += new System.ComponentModel.CancelEventHandler(this.tbSearchHistoryMax_Validating);
            this.tbSearchHistoryMax.Validated += new System.EventHandler(this.tbSearchHistoryMax_Validated);
            // 
            // tbUpdateInterval
            // 
            resources.ApplyResources(this.tbUpdateInterval, "tbUpdateInterval");
            this.errorProvider1.SetError(this.tbUpdateInterval, resources.GetString("tbUpdateInterval.Error"));
            this.errorProvider1.SetIconAlignment(this.tbUpdateInterval, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tbUpdateInterval.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.tbUpdateInterval, ((int)(resources.GetObject("tbUpdateInterval.IconPadding"))));
            this.tbUpdateInterval.Name = "tbUpdateInterval";
            this.toolTipSetting.SetToolTip(this.tbUpdateInterval, resources.GetString("tbUpdateInterval.ToolTip"));
            this.tbUpdateInterval.Validating += new System.ComponentModel.CancelEventHandler(this.tbUpdateInterval_Validating);
            this.tbUpdateInterval.Validated += new System.EventHandler(this.tbUpdateInterval_Validated);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.errorProvider1.SetError(this.label11, resources.GetString("label11.Error"));
            this.errorProvider1.SetIconAlignment(this.label11, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label11.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.label11, ((int)(resources.GetObject("label11.IconPadding"))));
            this.label11.Name = "label11";
            this.toolTipSetting.SetToolTip(this.label11, resources.GetString("label11.ToolTip"));
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.errorProvider1.SetError(this.label10, resources.GetString("label10.Error"));
            this.errorProvider1.SetIconAlignment(this.label10, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label10.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.label10, ((int)(resources.GetObject("label10.IconPadding"))));
            this.label10.Name = "label10";
            this.toolTipSetting.SetToolTip(this.label10, resources.GetString("label10.ToolTip"));
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.errorProvider1.SetError(this.label8, resources.GetString("label8.Error"));
            this.errorProvider1.SetIconAlignment(this.label8, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label8.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.label8, ((int)(resources.GetObject("label8.IconPadding"))));
            this.label8.Name = "label8";
            this.toolTipSetting.SetToolTip(this.label8, resources.GetString("label8.ToolTip"));
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            resources.ApplyResources(this.errorProvider1, "errorProvider1");
            // 
            // SettingForm
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnUserItemDown);
            this.Controls.Add(this.btnUserItemUp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnUserItemAdd);
            this.Controls.Add(this.btnUserItemUpdate);
            this.Controls.Add(this.btnUserItemDel);
            this.Controls.Add(this.lsvUserItem);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbShift);
            this.Controls.Add(this.cbAlt);
            this.Controls.Add(this.cbWin);
            this.Controls.Add(this.cbCtrl);
            this.Controls.Add(this.tbAnyFolder);
            this.Controls.Add(this.txtbxHotkey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.toolTipSetting.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbxHotkey;
        private System.Windows.Forms.TextBox tbAnyFolder;
        private System.Windows.Forms.CheckBox cbCtrl;
        private System.Windows.Forms.CheckBox cbWin;
        private System.Windows.Forms.CheckBox cbAlt;
        private System.Windows.Forms.CheckBox cbShift;
        private System.Windows.Forms.ToolTip toolTipSetting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView lsvUserItem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnUserItemDel;
        private System.Windows.Forms.Button btnUserItemUpdate;
        private System.Windows.Forms.Button btnUserItemAdd;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUserItemUp;
        private System.Windows.Forms.Button btnUserItemDown;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbDisplayItemMax;
        private System.Windows.Forms.TextBox tbExecHistoryMax;
        private System.Windows.Forms.TextBox tbSearchHistoryMax;
        private System.Windows.Forms.TextBox tbUpdateInterval;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbEqual;
        private System.Windows.Forms.TextBox tbSkipMatching;
        private System.Windows.Forms.TextBox tbEndWith;
        private System.Windows.Forms.TextBox tbStartWith;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}
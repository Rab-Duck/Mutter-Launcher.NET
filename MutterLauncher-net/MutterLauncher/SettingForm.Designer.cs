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
            this.tbAnyFolder.Name = "tbAnyFolder";
            this.toolTipSetting.SetToolTip(this.tbAnyFolder, resources.GetString("tbAnyFolder.ToolTip"));
            // 
            // cbCtrl
            // 
            resources.ApplyResources(this.cbCtrl, "cbCtrl");
            this.cbCtrl.Name = "cbCtrl";
            this.cbCtrl.UseVisualStyleBackColor = true;
            // 
            // cbWin
            // 
            resources.ApplyResources(this.cbWin, "cbWin");
            this.cbWin.Name = "cbWin";
            this.cbWin.UseVisualStyleBackColor = true;
            // 
            // cbAlt
            // 
            resources.ApplyResources(this.cbAlt, "cbAlt");
            this.cbAlt.Name = "cbAlt";
            this.cbAlt.UseVisualStyleBackColor = true;
            // 
            // cbShift
            // 
            resources.ApplyResources(this.cbShift, "cbShift");
            this.cbShift.Name = "cbShift";
            this.cbShift.UseVisualStyleBackColor = true;
            // 
            // btnUserItemDel
            // 
            resources.ApplyResources(this.btnUserItemDel, "btnUserItemDel");
            this.btnUserItemDel.Name = "btnUserItemDel";
            this.toolTipSetting.SetToolTip(this.btnUserItemDel, resources.GetString("btnUserItemDel.ToolTip"));
            this.btnUserItemDel.UseVisualStyleBackColor = true;
            this.btnUserItemDel.Click += new System.EventHandler(this.btnUserItemDel_Click);
            // 
            // btnUserItemUpdate
            // 
            resources.ApplyResources(this.btnUserItemUpdate, "btnUserItemUpdate");
            this.btnUserItemUpdate.Name = "btnUserItemUpdate";
            this.toolTipSetting.SetToolTip(this.btnUserItemUpdate, resources.GetString("btnUserItemUpdate.ToolTip"));
            this.btnUserItemUpdate.UseVisualStyleBackColor = true;
            this.btnUserItemUpdate.Click += new System.EventHandler(this.btnUserItemUpdate_Click);
            // 
            // btnUserItemAdd
            // 
            resources.ApplyResources(this.btnUserItemAdd, "btnUserItemAdd");
            this.btnUserItemAdd.Name = "btnUserItemAdd";
            this.toolTipSetting.SetToolTip(this.btnUserItemAdd, resources.GetString("btnUserItemAdd.ToolTip"));
            this.btnUserItemAdd.UseVisualStyleBackColor = true;
            this.btnUserItemAdd.Click += new System.EventHandler(this.btnUserItemAdd_Click);
            // 
            // btnUserItemUp
            // 
            this.btnUserItemUp.Image = global::MutterLauncher.Properties.Resources.ARW07UP;
            resources.ApplyResources(this.btnUserItemUp, "btnUserItemUp");
            this.btnUserItemUp.Name = "btnUserItemUp";
            this.toolTipSetting.SetToolTip(this.btnUserItemUp, resources.GetString("btnUserItemUp.ToolTip"));
            this.btnUserItemUp.UseVisualStyleBackColor = true;
            this.btnUserItemUp.Click += new System.EventHandler(this.btnUserItemUp_Click);
            // 
            // btnUserItemDown
            // 
            this.btnUserItemDown.Image = global::MutterLauncher.Properties.Resources.ARW07DN;
            resources.ApplyResources(this.btnUserItemDown, "btnUserItemDown");
            this.btnUserItemDown.Name = "btnUserItemDown";
            this.toolTipSetting.SetToolTip(this.btnUserItemDown, resources.GetString("btnUserItemDown.ToolTip"));
            this.btnUserItemDown.UseVisualStyleBackColor = true;
            this.btnUserItemDown.Click += new System.EventHandler(this.btnUserItemDown_Click);
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            this.toolTipSetting.SetToolTip(this.label12, resources.GetString("label12.ToolTip"));
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            this.toolTipSetting.SetToolTip(this.label9, resources.GetString("label9.ToolTip"));
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // lsvUserItem
            // 
            this.lsvUserItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lsvUserItem.FullRowSelect = true;
            this.lsvUserItem.GridLines = true;
            this.lsvUserItem.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvUserItem.HideSelection = false;
            resources.ApplyResources(this.lsvUserItem, "lsvUserItem");
            this.lsvUserItem.MultiSelect = false;
            this.lsvUserItem.Name = "lsvUserItem";
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
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbEqual);
            this.groupBox1.Controls.Add(this.tbSkipMatching);
            this.groupBox1.Controls.Add(this.tbEndWith);
            this.groupBox1.Controls.Add(this.tbStartWith);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // tbEqual
            // 
            resources.ApplyResources(this.tbEqual, "tbEqual");
            this.tbEqual.Name = "tbEqual";
            this.tbEqual.Validating += new System.ComponentModel.CancelEventHandler(this.tbEqual_Validating);
            this.tbEqual.Validated += new System.EventHandler(this.tbEqual_Validated);
            // 
            // tbSkipMatching
            // 
            resources.ApplyResources(this.tbSkipMatching, "tbSkipMatching");
            this.tbSkipMatching.Name = "tbSkipMatching";
            this.tbSkipMatching.Validating += new System.ComponentModel.CancelEventHandler(this.tbSkipMatching_Validating);
            this.tbSkipMatching.Validated += new System.EventHandler(this.tbSkipMatching_Validated);
            // 
            // tbEndWith
            // 
            resources.ApplyResources(this.tbEndWith, "tbEndWith");
            this.tbEndWith.Name = "tbEndWith";
            this.tbEndWith.Validating += new System.ComponentModel.CancelEventHandler(this.tbEndWith_Validating);
            this.tbEndWith.Validated += new System.EventHandler(this.tbEndWith_Validated);
            // 
            // tbStartWith
            // 
            resources.ApplyResources(this.tbStartWith, "tbStartWith");
            this.tbStartWith.Name = "tbStartWith";
            this.tbStartWith.Validating += new System.ComponentModel.CancelEventHandler(this.tbStartWith_Validating);
            this.tbStartWith.Validated += new System.EventHandler(this.tbStartWith_Validated);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbDisplayItemMax);
            this.groupBox2.Controls.Add(this.tbExecHistoryMax);
            this.groupBox2.Controls.Add(this.tbSearchHistoryMax);
            this.groupBox2.Controls.Add(this.tbUpdateInterval);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tbDisplayItemMax
            // 
            resources.ApplyResources(this.tbDisplayItemMax, "tbDisplayItemMax");
            this.tbDisplayItemMax.Name = "tbDisplayItemMax";
            this.tbDisplayItemMax.Validating += new System.ComponentModel.CancelEventHandler(this.tbDisplayItemMax_Validating);
            this.tbDisplayItemMax.Validated += new System.EventHandler(this.tbDisplayItemMax_Validated);
            // 
            // tbExecHistoryMax
            // 
            resources.ApplyResources(this.tbExecHistoryMax, "tbExecHistoryMax");
            this.tbExecHistoryMax.Name = "tbExecHistoryMax";
            this.tbExecHistoryMax.Validating += new System.ComponentModel.CancelEventHandler(this.tbExecHistoryMax_Validating);
            this.tbExecHistoryMax.Validated += new System.EventHandler(this.tbExecHistoryMax_Validated);
            // 
            // tbSearchHistoryMax
            // 
            resources.ApplyResources(this.tbSearchHistoryMax, "tbSearchHistoryMax");
            this.tbSearchHistoryMax.Name = "tbSearchHistoryMax";
            this.tbSearchHistoryMax.Validating += new System.ComponentModel.CancelEventHandler(this.tbSearchHistoryMax_Validating);
            this.tbSearchHistoryMax.Validated += new System.EventHandler(this.tbSearchHistoryMax_Validated);
            // 
            // tbUpdateInterval
            // 
            resources.ApplyResources(this.tbUpdateInterval, "tbUpdateInterval");
            this.tbUpdateInterval.Name = "tbUpdateInterval";
            this.tbUpdateInterval.Validating += new System.ComponentModel.CancelEventHandler(this.tbUpdateInterval_Validating);
            this.tbUpdateInterval.Validated += new System.EventHandler(this.tbUpdateInterval_Validated);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
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
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
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lsvUserItem = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
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
            this.tbDisplayItemMax = new System.Windows.Forms.TextBox();
            this.tbExecHistoryMax = new System.Windows.Forms.TextBox();
            this.tbSearchHistoryMax = new System.Windows.Forms.TextBox();
            this.tbUpdateInterval = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtbxHotkey
            // 
            this.txtbxHotkey.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtbxHotkey.Location = new System.Drawing.Point(268, 21);
            this.txtbxHotkey.Name = "txtbxHotkey";
            this.txtbxHotkey.Size = new System.Drawing.Size(120, 19);
            this.txtbxHotkey.TabIndex = 5;
            this.toolTipSetting.SetToolTip(this.txtbxHotkey, "Input a key for Hotkey");
            this.txtbxHotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbxHotkey_KeyDown);
            this.txtbxHotkey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxHotkey_KeyPress);
            this.txtbxHotkey.Validating += new System.ComponentModel.CancelEventHandler(this.txtbxHotkey_Validating);
            this.txtbxHotkey.Validated += new System.EventHandler(this.txtbxHotkey_Validated);
            // 
            // tbAnyFolder
            // 
            this.tbAnyFolder.Location = new System.Drawing.Point(12, 128);
            this.tbAnyFolder.Multiline = true;
            this.tbAnyFolder.Name = "tbAnyFolder";
            this.tbAnyFolder.Size = new System.Drawing.Size(320, 91);
            this.tbAnyFolder.TabIndex = 8;
            this.toolTipSetting.SetToolTip(this.tbAnyFolder, "example:\r\nc:\\Windows\r\nc:\\Program Files;*.exe;*.lnk\r\n");
            // 
            // cbCtrl
            // 
            this.cbCtrl.AutoSize = true;
            this.cbCtrl.Location = new System.Drawing.Point(117, 23);
            this.cbCtrl.Name = "cbCtrl";
            this.cbCtrl.Size = new System.Drawing.Size(43, 16);
            this.cbCtrl.TabIndex = 2;
            this.cbCtrl.Text = "Ctrl";
            this.cbCtrl.UseVisualStyleBackColor = true;
            // 
            // cbWin
            // 
            this.cbWin.AutoSize = true;
            this.cbWin.Location = new System.Drawing.Point(220, 23);
            this.cbWin.Name = "cbWin";
            this.cbWin.Size = new System.Drawing.Size(42, 16);
            this.cbWin.TabIndex = 4;
            this.cbWin.Text = "Win";
            this.cbWin.UseVisualStyleBackColor = true;
            // 
            // cbAlt
            // 
            this.cbAlt.AutoSize = true;
            this.cbAlt.Location = new System.Drawing.Point(72, 23);
            this.cbAlt.Name = "cbAlt";
            this.cbAlt.Size = new System.Drawing.Size(39, 16);
            this.cbAlt.TabIndex = 1;
            this.cbAlt.Text = "Alt";
            this.cbAlt.UseVisualStyleBackColor = true;
            // 
            // cbShift
            // 
            this.cbShift.AutoSize = true;
            this.cbShift.Location = new System.Drawing.Point(166, 23);
            this.cbShift.Name = "cbShift";
            this.cbShift.Size = new System.Drawing.Size(48, 16);
            this.cbShift.TabIndex = 3;
            this.cbShift.Text = "Shift";
            this.cbShift.UseVisualStyleBackColor = true;
            // 
            // btnUserItemDel
            // 
            this.btnUserItemDel.Location = new System.Drawing.Point(228, 337);
            this.btnUserItemDel.Name = "btnUserItemDel";
            this.btnUserItemDel.Size = new System.Drawing.Size(75, 23);
            this.btnUserItemDel.TabIndex = 15;
            this.btnUserItemDel.Text = "Delete";
            this.toolTipSetting.SetToolTip(this.btnUserItemDel, "Not Implimented");
            this.btnUserItemDel.UseVisualStyleBackColor = true;
            this.btnUserItemDel.Click += new System.EventHandler(this.btnUserItemDel_Click);
            // 
            // btnUserItemUpdate
            // 
            this.btnUserItemUpdate.Location = new System.Drawing.Point(148, 337);
            this.btnUserItemUpdate.Name = "btnUserItemUpdate";
            this.btnUserItemUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUserItemUpdate.TabIndex = 14;
            this.btnUserItemUpdate.Text = "Update";
            this.toolTipSetting.SetToolTip(this.btnUserItemUpdate, "Not Implimented");
            this.btnUserItemUpdate.UseVisualStyleBackColor = true;
            this.btnUserItemUpdate.Click += new System.EventHandler(this.btnUserItemUpdate_Click);
            // 
            // btnUserItemAdd
            // 
            this.btnUserItemAdd.Location = new System.Drawing.Point(68, 337);
            this.btnUserItemAdd.Name = "btnUserItemAdd";
            this.btnUserItemAdd.Size = new System.Drawing.Size(75, 23);
            this.btnUserItemAdd.TabIndex = 13;
            this.btnUserItemAdd.Text = "Add";
            this.toolTipSetting.SetToolTip(this.btnUserItemAdd, "Not Implimented");
            this.btnUserItemAdd.UseVisualStyleBackColor = true;
            this.btnUserItemAdd.Click += new System.EventHandler(this.btnUserItemAdd_Click);
            // 
            // btnUserItemUp
            // 
            this.btnUserItemUp.Image = global::MutterLauncher.Properties.Resources.ARW07UP;
            this.btnUserItemUp.Location = new System.Drawing.Point(306, 266);
            this.btnUserItemUp.Name = "btnUserItemUp";
            this.btnUserItemUp.Size = new System.Drawing.Size(26, 23);
            this.btnUserItemUp.TabIndex = 11;
            this.toolTipSetting.SetToolTip(this.btnUserItemUp, "Not Implimented");
            this.btnUserItemUp.UseVisualStyleBackColor = true;
            this.btnUserItemUp.Click += new System.EventHandler(this.btnUserItemUp_Click);
            // 
            // btnUserItemDown
            // 
            this.btnUserItemDown.Image = global::MutterLauncher.Properties.Resources.ARW07DN;
            this.btnUserItemDown.Location = new System.Drawing.Point(305, 295);
            this.btnUserItemDown.Name = "btnUserItemDown";
            this.btnUserItemDown.Size = new System.Drawing.Size(27, 23);
            this.btnUserItemDown.TabIndex = 12;
            this.toolTipSetting.SetToolTip(this.btnUserItemDown, "Not Implimented");
            this.btnUserItemDown.UseVisualStyleBackColor = true;
            this.btnUserItemDown.Click += new System.EventHandler(this.btnUserItemDown_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 227);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 12);
            this.label12.TabIndex = 9;
            this.label12.Text = "User Item List(&U)";
            this.toolTipSetting.SetToolTip(this.label12, "Not Implimented");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "HotKey(&K)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "Any Foler List(&F)";
            // 
            // lsvUserItem
            // 
            this.lsvUserItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lsvUserItem.FullRowSelect = true;
            this.lsvUserItem.GridLines = true;
            this.lsvUserItem.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvUserItem.HideSelection = false;
            this.lsvUserItem.Location = new System.Drawing.Point(12, 242);
            this.lsvUserItem.MultiSelect = false;
            this.lsvUserItem.Name = "lsvUserItem";
            this.lsvUserItem.Size = new System.Drawing.Size(291, 89);
            this.lsvUserItem.TabIndex = 10;
            this.lsvUserItem.UseCompatibleStateImageBehavior = false;
            this.lsvUserItem.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "User Item";
            this.columnHeader1.Width = 244;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(339, 373);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 17;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(419, 373);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
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
            this.groupBox1.Location = new System.Drawing.Point(14, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 56);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Type Char(&S)";
            // 
            // tbEqual
            // 
            this.tbEqual.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbEqual.Location = new System.Drawing.Point(229, 32);
            this.tbEqual.MaxLength = 1;
            this.tbEqual.Name = "tbEqual";
            this.tbEqual.Size = new System.Drawing.Size(27, 19);
            this.tbEqual.TabIndex = 7;
            this.tbEqual.Validating += new System.ComponentModel.CancelEventHandler(this.tbEqual_Validating);
            this.tbEqual.Validated += new System.EventHandler(this.tbEqual_Validated);
            // 
            // tbSkipMatching
            // 
            this.tbSkipMatching.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbSkipMatching.Location = new System.Drawing.Point(126, 32);
            this.tbSkipMatching.MaxLength = 1;
            this.tbSkipMatching.Name = "tbSkipMatching";
            this.tbSkipMatching.Size = new System.Drawing.Size(27, 19);
            this.tbSkipMatching.TabIndex = 5;
            this.tbSkipMatching.Validating += new System.ComponentModel.CancelEventHandler(this.tbSkipMatching_Validating);
            this.tbSkipMatching.Validated += new System.EventHandler(this.tbSkipMatching_Validated);
            // 
            // tbEndWith
            // 
            this.tbEndWith.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbEndWith.Location = new System.Drawing.Point(229, 12);
            this.tbEndWith.MaxLength = 1;
            this.tbEndWith.Name = "tbEndWith";
            this.tbEndWith.Size = new System.Drawing.Size(27, 19);
            this.tbEndWith.TabIndex = 3;
            this.tbEndWith.Validating += new System.ComponentModel.CancelEventHandler(this.tbEndWith_Validating);
            this.tbEndWith.Validated += new System.EventHandler(this.tbEndWith_Validated);
            // 
            // tbStartWith
            // 
            this.tbStartWith.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbStartWith.Location = new System.Drawing.Point(126, 12);
            this.tbStartWith.MaxLength = 1;
            this.tbStartWith.Name = "tbStartWith";
            this.tbStartWith.Size = new System.Drawing.Size(27, 19);
            this.tbStartWith.TabIndex = 1;
            this.tbStartWith.Validating += new System.ComponentModel.CancelEventHandler(this.tbStartWith_Validating);
            this.tbStartWith.Validated += new System.EventHandler(this.tbStartWith_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(177, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "Equal";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "SkipMatching";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(177, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "EndWith";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "StartWith";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbDisplayItemMax);
            this.groupBox2.Controls.Add(this.tbExecHistoryMax);
            this.groupBox2.Controls.Add(this.tbSearchHistoryMax);
            this.groupBox2.Controls.Add(this.tbUpdateInterval);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(339, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(155, 312);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Details(&D)";
            // 
            // tbDisplayItemMax
            // 
            this.tbDisplayItemMax.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbDisplayItemMax.Location = new System.Drawing.Point(8, 180);
            this.tbDisplayItemMax.MaxLength = 3;
            this.tbDisplayItemMax.Name = "tbDisplayItemMax";
            this.tbDisplayItemMax.Size = new System.Drawing.Size(42, 19);
            this.tbDisplayItemMax.TabIndex = 7;
            this.tbDisplayItemMax.Validating += new System.ComponentModel.CancelEventHandler(this.tbDisplayItemMax_Validating);
            this.tbDisplayItemMax.Validated += new System.EventHandler(this.tbDisplayItemMax_Validated);
            // 
            // tbExecHistoryMax
            // 
            this.tbExecHistoryMax.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbExecHistoryMax.Location = new System.Drawing.Point(8, 133);
            this.tbExecHistoryMax.MaxLength = 3;
            this.tbExecHistoryMax.Name = "tbExecHistoryMax";
            this.tbExecHistoryMax.Size = new System.Drawing.Size(42, 19);
            this.tbExecHistoryMax.TabIndex = 5;
            this.tbExecHistoryMax.Validating += new System.ComponentModel.CancelEventHandler(this.tbExecHistoryMax_Validating);
            this.tbExecHistoryMax.Validated += new System.EventHandler(this.tbExecHistoryMax_Validated);
            // 
            // tbSearchHistoryMax
            // 
            this.tbSearchHistoryMax.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbSearchHistoryMax.Location = new System.Drawing.Point(8, 88);
            this.tbSearchHistoryMax.MaxLength = 3;
            this.tbSearchHistoryMax.Name = "tbSearchHistoryMax";
            this.tbSearchHistoryMax.Size = new System.Drawing.Size(42, 19);
            this.tbSearchHistoryMax.TabIndex = 3;
            this.tbSearchHistoryMax.Validating += new System.ComponentModel.CancelEventHandler(this.tbSearchHistoryMax_Validating);
            this.tbSearchHistoryMax.Validated += new System.EventHandler(this.tbSearchHistoryMax_Validated);
            // 
            // tbUpdateInterval
            // 
            this.tbUpdateInterval.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbUpdateInterval.Location = new System.Drawing.Point(8, 44);
            this.tbUpdateInterval.MaxLength = 4;
            this.tbUpdateInterval.Name = "tbUpdateInterval";
            this.tbUpdateInterval.Size = new System.Drawing.Size(42, 19);
            this.tbUpdateInterval.TabIndex = 1;
            this.tbUpdateInterval.Validating += new System.ComponentModel.CancelEventHandler(this.tbUpdateInterval_Validating);
            this.tbUpdateInterval.Validated += new System.EventHandler(this.tbUpdateInterval_Validated);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 165);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(136, 12);
            this.label11.TabIndex = 6;
            this.label11.Text = "Display Item Max (0-100)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(138, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = "Exec History Max (0-100)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(148, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "Search History Max (0-100)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "Update Interval (10-9999)";
            // 
            // SettingForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(505, 408);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.Text = "Setting Dialog";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
    }
}
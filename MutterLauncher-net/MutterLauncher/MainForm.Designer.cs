namespace MutterLauncher
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lsvFileList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnExec = new System.Windows.Forms.Button();
            this.cmbbxSearcText = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSetenv = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtViewPath = new System.Windows.Forms.TextBox();
            this.timerInput = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lsvFileList
            // 
            resources.ApplyResources(this.lsvFileList, "lsvFileList");
            this.lsvFileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lsvFileList.FullRowSelect = true;
            this.lsvFileList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvFileList.HideSelection = false;
            this.lsvFileList.MultiSelect = false;
            this.lsvFileList.Name = "lsvFileList";
            this.toolTip.SetToolTip(this.lsvFileList, resources.GetString("lsvFileList.ToolTip"));
            this.lsvFileList.UseCompatibleStateImageBehavior = false;
            this.lsvFileList.View = System.Windows.Forms.View.Details;
            this.lsvFileList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lsvFileList_ItemSelectionChanged);
            this.lsvFileList.DoubleClick += new System.EventHandler(this.lsvFileList_DoubleClick);
            this.lsvFileList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvFileList_KeyDown);
            this.lsvFileList.Resize += new System.EventHandler(this.lsvFileList_Resize);
            // 
            // btnExec
            // 
            resources.ApplyResources(this.btnExec, "btnExec");
            this.btnExec.Name = "btnExec";
            this.btnExec.UseVisualStyleBackColor = true;
            this.btnExec.Click += new System.EventHandler(this.btnExec_Click);
            // 
            // cmbbxSearcText
            // 
            resources.ApplyResources(this.cmbbxSearcText, "cmbbxSearcText");
            this.cmbbxSearcText.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbbxSearcText.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbbxSearcText.FormattingEnabled = true;
            this.cmbbxSearcText.Name = "cmbbxSearcText";
            this.toolTip.SetToolTip(this.cmbbxSearcText, resources.GetString("cmbbxSearcText.ToolTip"));
            this.cmbbxSearcText.TextUpdate += new System.EventHandler(this.cmbbxSearcText_TextUpdate);
            this.cmbbxSearcText.TextChanged += new System.EventHandler(this.cmbbxSearcText_TextChanged);
            this.cmbbxSearcText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbbxSearcText_KeyDown);
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSetenv
            // 
            resources.ApplyResources(this.btnSetenv, "btnSetenv");
            this.btnSetenv.Image = global::MutterLauncher.Properties.Resources.Ctrpanel16;
            this.btnSetenv.Name = "btnSetenv";
            this.toolTip.SetToolTip(this.btnSetenv, resources.GetString("btnSetenv.ToolTip"));
            this.btnSetenv.UseVisualStyleBackColor = true;
            this.btnSetenv.Click += new System.EventHandler(this.btnSetenv_Click);
            // 
            // btnUpdate
            // 
            resources.ApplyResources(this.btnUpdate, "btnUpdate");
            this.btnUpdate.Image = global::MutterLauncher.Properties.Resources.Refresh;
            this.btnUpdate.Name = "btnUpdate";
            this.toolTip.SetToolTip(this.btnUpdate, resources.GetString("btnUpdate.ToolTip"));
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnExit
            // 
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.Image = global::MutterLauncher.Properties.Resources.Close;
            this.btnExit.Name = "btnExit";
            this.toolTip.SetToolTip(this.btnExit, resources.GetString("btnExit.ToolTip"));
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtViewPath
            // 
            resources.ApplyResources(this.txtViewPath, "txtViewPath");
            this.txtViewPath.BackColor = System.Drawing.SystemColors.Window;
            this.txtViewPath.Name = "txtViewPath";
            this.txtViewPath.ReadOnly = true;
            this.toolTip.SetToolTip(this.txtViewPath, resources.GetString("txtViewPath.ToolTip"));
            // 
            // timerInput
            // 
            this.timerInput.Interval = 250;
            this.timerInput.Tick += new System.EventHandler(this.timerInput_Tick);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnExec;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExec);
            this.Controls.Add(this.txtViewPath);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSetenv);
            this.Controls.Add(this.cmbbxSearcText);
            this.Controls.Add(this.lsvFileList);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.VisibleChanged += new System.EventHandler(this.MainForm_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lsvFileList;
        private System.Windows.Forms.Button btnExec;
        private System.Windows.Forms.ComboBox cmbbxSearcText;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSetenv;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtViewPath;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Timer timerInput;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label1;
    }
}


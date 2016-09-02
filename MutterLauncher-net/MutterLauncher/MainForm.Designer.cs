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
            this.lsvFileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvFileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lsvFileList.FullRowSelect = true;
            this.lsvFileList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvFileList.HideSelection = false;
            this.lsvFileList.Location = new System.Drawing.Point(4, 40);
            this.lsvFileList.MultiSelect = false;
            this.lsvFileList.Name = "lsvFileList";
            this.lsvFileList.Size = new System.Drawing.Size(295, 264);
            this.lsvFileList.TabIndex = 2;
            this.lsvFileList.UseCompatibleStateImageBehavior = false;
            this.lsvFileList.View = System.Windows.Forms.View.Details;
            this.lsvFileList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lsvFileList_ItemSelectionChanged);
            this.lsvFileList.DoubleClick += new System.EventHandler(this.lsvFileList_DoubleClick);
            this.lsvFileList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvFileList_KeyDown);
            this.lsvFileList.Resize += new System.EventHandler(this.lsvFileList_Resize);
            // 
            // btnExec
            // 
            this.btnExec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExec.Location = new System.Drawing.Point(144, 335);
            this.btnExec.Name = "btnExec";
            this.btnExec.Size = new System.Drawing.Size(75, 23);
            this.btnExec.TabIndex = 4;
            this.btnExec.Text = "Exec";
            this.btnExec.UseVisualStyleBackColor = true;
            this.btnExec.Click += new System.EventHandler(this.btnExec_Click);
            // 
            // cmbbxSearcText
            // 
            this.cmbbxSearcText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbbxSearcText.FormattingEnabled = true;
            this.cmbbxSearcText.Items.AddRange(new object[] {
            "test",
            "google",
            "hoge"});
            this.cmbbxSearcText.Location = new System.Drawing.Point(20, 13);
            this.cmbbxSearcText.Name = "cmbbxSearcText";
            this.cmbbxSearcText.Size = new System.Drawing.Size(279, 20);
            this.cmbbxSearcText.TabIndex = 1;
            this.toolTip.SetToolTip(this.cmbbxSearcText, "Search Text");
            this.cmbbxSearcText.TextUpdate += new System.EventHandler(this.cmbbxSearcText_TextUpdate);
            this.cmbbxSearcText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbbxSearcText_KeyDown);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(224, 335);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSetenv
            // 
            this.btnSetenv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetenv.Image = global::MutterLauncher.Properties.Resources.Ctrpanel16;
            this.btnSetenv.Location = new System.Drawing.Point(4, 335);
            this.btnSetenv.Name = "btnSetenv";
            this.btnSetenv.Size = new System.Drawing.Size(34, 23);
            this.btnSetenv.TabIndex = 6;
            this.toolTip.SetToolTip(this.btnSetenv, "Setting...");
            this.btnSetenv.UseVisualStyleBackColor = true;
            this.btnSetenv.Click += new System.EventHandler(this.btnSetenv_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdate.Image = global::MutterLauncher.Properties.Resources.Refresh;
            this.btnUpdate.Location = new System.Drawing.Point(43, 335);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(33, 23);
            this.btnUpdate.TabIndex = 7;
            this.toolTip.SetToolTip(this.btnUpdate, "Update");
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Image = global::MutterLauncher.Properties.Resources.Close;
            this.btnExit.Location = new System.Drawing.Point(80, 335);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(34, 23);
            this.btnExit.TabIndex = 8;
            this.toolTip.SetToolTip(this.btnExit, "Exit");
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtViewPath
            // 
            this.txtViewPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtViewPath.Location = new System.Drawing.Point(4, 310);
            this.txtViewPath.Name = "txtViewPath";
            this.txtViewPath.ReadOnly = true;
            this.txtViewPath.Size = new System.Drawing.Size(295, 19);
            this.txtViewPath.TabIndex = 3;
            this.toolTip.SetToolTip(this.txtViewPath, "Path");
            // 
            // timerInput
            // 
            this.timerInput.Interval = 250;
            this.timerInput.Tick += new System.EventHandler(this.timerInput_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "&S";
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnExec;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 362);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExec);
            this.Controls.Add(this.txtViewPath);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSetenv);
            this.Controls.Add(this.cmbbxSearcText);
            this.Controls.Add(this.lsvFileList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Mutter Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.VisibleChanged += new System.EventHandler(this.MainForm_VisibleChanged);
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


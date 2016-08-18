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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lsvFileList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnExec = new System.Windows.Forms.Button();
            this.cmbbxSearcText = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSetenv = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
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
            this.lsvFileList.Location = new System.Drawing.Point(12, 40);
            this.lsvFileList.MultiSelect = false;
            this.lsvFileList.Name = "lsvFileList";
            this.lsvFileList.Size = new System.Drawing.Size(361, 268);
            this.lsvFileList.TabIndex = 1;
            this.lsvFileList.UseCompatibleStateImageBehavior = false;
            this.lsvFileList.View = System.Windows.Forms.View.Details;
            this.lsvFileList.DoubleClick += new System.EventHandler(this.lsvFileList_DoubleClick);
            this.lsvFileList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvFileList_KeyDown);
            this.lsvFileList.Resize += new System.EventHandler(this.lsvFileList_Resize);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 357;
            // 
            // btnExec
            // 
            this.btnExec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExec.Location = new System.Drawing.Point(218, 314);
            this.btnExec.Name = "btnExec";
            this.btnExec.Size = new System.Drawing.Size(75, 23);
            this.btnExec.TabIndex = 2;
            this.btnExec.Text = "Exec";
            this.btnExec.UseVisualStyleBackColor = true;
            this.btnExec.Click += new System.EventHandler(this.btnExec_Click);
            // 
            // cmbbxSearcText
            // 
            this.cmbbxSearcText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbbxSearcText.FormattingEnabled = true;
            this.cmbbxSearcText.Location = new System.Drawing.Point(13, 13);
            this.cmbbxSearcText.Name = "cmbbxSearcText";
            this.cmbbxSearcText.Size = new System.Drawing.Size(360, 20);
            this.cmbbxSearcText.TabIndex = 0;
            this.cmbbxSearcText.TextUpdate += new System.EventHandler(this.cmbbxSearcText_TextUpdate);
            this.cmbbxSearcText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbbxSearcText_KeyDown);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(298, 314);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSetenv
            // 
            this.btnSetenv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetenv.Location = new System.Drawing.Point(12, 314);
            this.btnSetenv.Name = "btnSetenv";
            this.btnSetenv.Size = new System.Drawing.Size(45, 23);
            this.btnSetenv.TabIndex = 4;
            this.btnSetenv.Text = "Env";
            this.btnSetenv.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdate.Location = new System.Drawing.Point(63, 314);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(51, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Location = new System.Drawing.Point(120, 314);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(51, 23);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 349);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSetenv);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cmbbxSearcText);
            this.Controls.Add(this.btnExec);
            this.Controls.Add(this.lsvFileList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Mutter Launcher";
            this.Load += new System.EventHandler(this.frmForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsvFileList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnExec;
        private System.Windows.Forms.ComboBox cmbbxSearcText;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSetenv;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnExit;
    }
}


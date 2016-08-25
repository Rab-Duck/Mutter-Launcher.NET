namespace MutterLauncher
{
    partial class BackgroundForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackgroundForm));
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.ContextMenuStrip = this.cmsMain;
            this.notifyIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")));
            this.notifyIconMain.Text = "Mutter Launcher";
            this.notifyIconMain.Visible = true;
            this.notifyIconMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconMain_MouseClick);
            // 
            // timerUpdate
            // 
            this.timerUpdate.Interval = 300;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // cmsMain
            // 
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miUpdate,
            this.miExit});
            this.cmsMain.Name = "cmsMain";
            this.cmsMain.Size = new System.Drawing.Size(149, 48);
            this.cmsMain.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.cmsMain_Closing);
            this.cmsMain.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmsMain_PreviewKeyDown);
            // 
            // miUpdate
            // 
            this.miUpdate.Name = "miUpdate";
            this.miUpdate.Size = new System.Drawing.Size(148, 22);
            this.miUpdate.Text = "リスト再取得";
            this.miUpdate.Click += new System.EventHandler(this.miUpdate_Click);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(148, 22);
            this.miExit.Text = "終了";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // BackgroundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BackgroundForm";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.Text = "BackgroundForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Activated += new System.EventHandler(this.BackgroundForm_Activated);
            this.Deactivate += new System.EventHandler(this.BackgroundForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BackgroundForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BackgroundForm_FormClosed);
            this.Load += new System.EventHandler(this.BackgroundForm_Load);
            this.cmsMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.ContextMenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem miUpdate;
        private System.Windows.Forms.ToolStripMenuItem miExit;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MutterLauncher
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // ToDo: 前バージョンの復元
            Properties.Settings.Default.Upgrade();

            mc = new MainCollector();
            mc.cachedCollect();

            runCollectTask();

        }

        private void runCollectTask()
        {
            try
            {
                collectTask = Task.Run(() =>
                {
                    mc.collect();
                });
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }

        private static IntPtr SmallImageListHandle;
        private static IntPtr LargeImageListHandle;
        private MainCollector mc;
        List<Item> itemList = new List<Item>();
        private EnvManager envmngr = EnvManager.getInstance();
        private Task collectTask = null;

        private async void MainForm_Load(object sender, EventArgs e)
        {
            Trace.WriteLine("form loaded!");

            // initial position
            int MainWinHeight = Properties.Settings.Default.MainWinHeight;
            if(MainWinHeight > 0)
            {
                this.Size = new Size(Properties.Settings.Default.MainWinWidth, MainWinHeight);
                this.Location = new Point(Properties.Settings.Default.MainWinPosX, Properties.Settings.Default.MainWinPosY);
            }


            // prepare LSV
            // lsvFileList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lsvFileList.Columns[0].Width = lsvFileList.ClientSize.Width;

            // reference: http://acha-ya.cocolog-nifty.com/blog/2010/11/2-f06c.html
            SHFILEINFO shFileInfo = new SHFILEINFO();
            SmallImageListHandle = NativeMethods.SHGetFileInfo(String.Empty, 0,
                out shFileInfo, (uint)Marshal.SizeOf(shFileInfo),
                NativeMethods.SHGFI_SMALLICON | NativeMethods.SHGFI_SYSICONINDEX);
            LargeImageListHandle = NativeMethods.SHGetFileInfo(String.Empty, 0,
                out shFileInfo, (uint)Marshal.SizeOf(shFileInfo),
                NativeMethods.SHGFI_LARGEICON | NativeMethods.SHGFI_SYSICONINDEX);
            NativeMethods.SendMessage(lsvFileList.Handle, NativeMethods.LVM_SETIMAGELIST,
                new IntPtr(NativeMethods.LVSIL_SMALL), SmallImageListHandle);
            NativeMethods.SendMessage(lsvFileList.Handle, NativeMethods.LVM_SETIMAGELIST,
                new IntPtr(NativeMethods.LVSIL_NORMAL), LargeImageListHandle);



            // show cached list
            updateView("");
            btnUpdate.Enabled = false;

            // show collected list
            await collectTask;
            updateView(null);
            timerUpdate.Interval = Properties.Settings.Default.updateInterval * 60 * 1000;
            timerUpdate.Enabled = true;
        }

        private void updateView(String searchStr)
        {
            if (searchStr == null)
            {
                searchStr = cmbbxSearcText.Text;
            }
            if (mc != null)
            {
                // itemList.Clear();
                // itemList.AddRange(mc.grep(searchStr));
                putFileListView(mc.grep(searchStr));
                btnUpdate.Enabled = true;
            }

        }

        private void putFileListView(List<Item> itemList)
        {
            lsvFileList.BeginUpdate();
            lsvFileList.Items.Clear();
            int i = 0;
            foreach (Item item in itemList)
            {
                if (i++ >= Properties.Settings.Default.ListNumMax)
                {
                    break;
                }
                ListViewItem lvi = new ListViewItem(item.getItemName());

                // オブジェクトを 1対1 でリストにひも付け
                lvi.Tag = item;

                // reference: http://acha-ya.cocolog-nifty.com/blog/2010/11/2-f06c.html
                // 最上位8ビットを除いた値をアイコンインデックス値とする
                int iconIndex = (item.getIconIndex() & 0xFFFFFF);
                lvi.ImageIndex = iconIndex;
                
                lsvFileList.Items.Add(lvi);
                LVITEM lvitem = new LVITEM();
                lvitem.stateMask = NativeMethods.LVIS_OVERLAYMASK;
                // 最上位8ビットの値を、8-11ビット目に格納、それ以外のビットは 0 にする
                lvitem.state = ((item.getIconIndex() >> 16) & 0x0F00);
                // NativeMethods.SendMessage(lsvFileList.Handle,
                    // NativeMethods.LVM_SETITEMSTATE, lvi.Index, ref lvitem);
            }
            lsvFileList.EndUpdate();
            txtViewPath.Text = "";
            if (lsvFileList.Items.Count > 0)
            {
                lsvFileList.Items[0].Selected = true;
            }
        }

        private void lsvFileList_Resize(object sender, EventArgs e)
        {
            lsvFileList.Columns[0].Width = lsvFileList.ClientSize.Width;
        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            execSelectedItem();

        }

        private void execSelectedItem()
        {
            if (lsvFileList.SelectedItems.Count > 0)
            {
                ListViewItem lvi = (ListViewItem)lsvFileList.Items[lsvFileList.SelectedItems[0].Index];
                Item item = (Item)lvi.Tag;
                try
                {
                    Keys modifiers = 0;
                    byte[] KeyState = new Byte[256];
                    if(NativeMethods.GetKeyboardState(KeyState) != 0) 
                    {
                        if(KeyState[(int)Keys.ShiftKey] >= 0x80)
                        {
                            modifiers |= Keys.Shift;
                        }
                        if (KeyState[(int)Keys.ControlKey] >= 0x80)
                        {
                            modifiers |= Keys.Control;
                        }
                    }

                    item.execute("", modifiers);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void cmbbxSearcText_TextUpdate(object sender, EventArgs e)
        {
            if (mc != null)
            {
                // itemList = mc.grep(cmbbxSearcText.Text);
                putFileListView(mc.grep(cmbbxSearcText.Text));
            }

        }

        private void lsvFileList_DoubleClick(object sender, EventArgs e)
        {
            execSelectedItem();
        }

        private void cmbbxSearcText_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.PageUp:
                case Keys.PageDown:
                    NativeMethods.SendMessage(lsvFileList.Handle, 0x0100, (IntPtr)e.KeyCode, IntPtr.Zero);
                    break;

                case Keys.Enter:
                    execSelectedItem();
                    break;
                     
                default:
                    break;
            }
        }

        private void lsvFileList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    execSelectedItem();
                    break;

                default:
                    break;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Trace.WriteLine("form Closed!");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Trace.WriteLine("form Closing!");

            SavePos();

            // reference: http://stackoverflow.com/questions/2021681/hide-form-instead-of-closing-when-close-button-clicked
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void notifyIconMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Visible = !this.Visible;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void MainForm_VisibleChanged(object sender, EventArgs e)
        {
            Trace.WriteLine("form VisibleChanged: " + this.Visible);
            if (!this.Visible)
            {
                SavePos();
            }
        }
        private void SavePos()
        {
            // 実装場所は要検討
            Properties.Settings.Default.MainWinWidth = this.Size.Width;
            Properties.Settings.Default.MainWinHeight = this.Size.Height;
            Properties.Settings.Default.MainWinPosX = this.Location.X;
            Properties.Settings.Default.MainWinPosY = this.Location.Y;

            // 実装場所は要検討
            Properties.Settings.Default.Save();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
            }

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            await updateListItem();
        }
        private async Task updateListItem()
        {
            btnUpdate.Enabled = false;
            runCollectTask();
            await collectTask;
            updateView(null);
            btnUpdate.Enabled = true;
        }

        private async void timerUpdate_Tick(object sender, EventArgs e)
        {
            await updateListItem();
        }

        private void lsvFileList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lsvFileList.SelectedItems.Count > 0)
            {
                ListViewItem lvi = (ListViewItem)lsvFileList.Items[lsvFileList.SelectedItems[0].Index];
                Item item = (Item)lvi.Tag;
                txtViewPath.Text = item.getItemPath();
            }
            else
            {
                txtViewPath.Text = "";
            }

        }
    }
  
}

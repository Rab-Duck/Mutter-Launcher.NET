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
    public partial class frmMainForm : Form
    {
        public frmMainForm()
        {
            InitializeComponent();

            // ToDo: 前バージョンの復元
            Properties.Settings.Default.Upgrade();
        }

        private static IntPtr SmallImageListHandle;
        private static IntPtr LargeImageListHandle;
        private MainCollector mc;
        List<Item> itemList = new List<Item>();
        private EnvManager envmngr = EnvManager.getInstance();

        private async void frmForm_Load(object sender, EventArgs e)
        {
            Trace.WriteLine("form loaded!");

            int MainWinHeight = Properties.Settings.Default.MainWinHeight;
            if(MainWinHeight > 0)
            {
                this.Size = new Size(Properties.Settings.Default.MainWinWidth, MainWinHeight);
                this.Location = new Point(Properties.Settings.Default.MainWinPosX, Properties.Settings.Default.MainWinPosY);
            }


            lsvFileList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

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

            mc = new MainCollector();

            btnUpdate.Enabled = false;
            mc.cachedCollect();
            updateView("");
            try
            {
                Task task = Task.Run(() =>
                {
                    mc.collect();
                });
                await task;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }

            updateView(null);
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
            if(lsvFileList.Items.Count > 0)
            {
                lsvFileList.Items[0].Selected = true;
            }
        }

        private void lsvFileList_Resize(object sender, EventArgs e)
        {
            lsvFileList.Columns[0].Width = lsvFileList.ClientSize.Width-1;
        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            execSelectedItem();

        }

        private void execSelectedItem()
        {
            if (lsvFileList.SelectedItems.Count == 1)
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

        private void frmMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 実装場所は要検討
            Properties.Settings.Default.Save();
        }

        private void frmMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 実装場所は要検討
            Properties.Settings.Default.MainWinWidth = this.Size.Width;
            Properties.Settings.Default.MainWinHeight = this.Size.Height;
            Properties.Settings.Default.MainWinPosX = this.Location.X;
            Properties.Settings.Default.MainWinPosY = this.Location.Y;

        }
    }
  
}

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
        }

        private static IntPtr SmallImageListHandle;
        private static IntPtr LargeImageListHandle;
        private MainCollector mc;
        List<Item> itemList = new List<Item>();

        private async void frmForm_Load(object sender, EventArgs e)
        {
            Trace.WriteLine("form loaded!");
            
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

            itemList = new List<Item>();
            AppCollector ac;
            try
            {
                mc  = new MainCollector();
                await Task.Run(() =>
                {
                    mc.collect();
                });
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
            itemList.AddRange(mc.grep(""));
            putFileListView(itemList);
        }
        private void putFileListView(List<Item> itemList)
        {
            lsvFileList.BeginUpdate();
            lsvFileList.Items.Clear();
            foreach (Item item in itemList)
            {
                ListViewItem lvi = new ListViewItem(item.getItemName());

                lvi.Tag = item;

                // 最上位8ビットを除いた値をアイコンインデックス値とする
                int iconIndex = (item.getIconIndex() & 0xFFFFFF);
                lvi.ImageIndex = iconIndex;
                
                lsvFileList.Items.Add(lvi);
                LVITEM lvitem = new LVITEM();
                lvitem.stateMask = NativeMethods.LVIS_OVERLAYMASK;
                // 最上位8ビットの値を、8-11ビット目に格納、それ以外のビットは 0 にする
                lvitem.state = ((item.getIconIndex() >> 16) & 0x0F00);
                NativeMethods.SendMessage(lsvFileList.Handle,
                    NativeMethods.LVM_SETITEMSTATE, lvi.Index, ref lvitem);
            }
            lsvFileList.EndUpdate();

        }

        private void lsvFileList_Resize(object sender, EventArgs e)
        {
            lsvFileList.Columns[0].Width = lsvFileList.ClientSize.Width-1;
        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            if (lsvFileList.SelectedItems.Count == 1)
            {
                ListViewItem lvi = (ListViewItem)lsvFileList.Items[lsvFileList.SelectedItems[0].Index];
                Item item = (Item)lvi.Tag;
                item.execute("", Keys.None);
            }

        }

        private void cmbbxSearcText_TextUpdate(object sender, EventArgs e)
        {
            if (mc != null)
            {
                itemList = mc.grep(cmbbxSearcText.Text);
                putFileListView(itemList);
            }

        }

        private void lsvFileList_DoubleClick(object sender, EventArgs e)
        {
            if (cmbbxSearcText.SelectedIndex >= 0)
            {
                ListViewItem lvi = (ListViewItem)cmbbxSearcText.Items[cmbbxSearcText.SelectedIndex];
                Item item = (Item)lvi.Tag;
                item.execute("", Keys.None);
            }

        }
    }
  
}

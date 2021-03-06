﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MutterLauncher
{
    public partial class MainForm : Form
    {
        public MainForm(MainCollector mc)
        {
            InitializeComponent();
            this.mc = mc;
        }

        private MainCollector _mc;
        public MainCollector mc
        {
            get { return _mc; }
            set
            {
                _mc = value;
                _mc.setInvoker(collectStateHandler);
                if (_mc.state == CollectState.RUNNING)
                {
                    btnUpdate.Enabled = false;
                }
                
            }
        }

        private void collectStateHandler(CollectState state, string msg)
        {
            Debug.WriteLine("called MainForm.collectStateHandler():" + state + ", " + msg);
            switch (state)
            {
                case CollectState.START:
                    btnUpdate.Enabled = false;
                    break;
                case CollectState.END:
                    updateView(null, true);
                    btnUpdate.Enabled = true;
                    break;
                case CollectState.FAILED:
                    btnUpdate.Enabled = true;
                    break;
                default:
                    btnUpdate.Enabled = true;
                    break;
            }
        }

        private static IntPtr SmallImageListHandle;
        private static IntPtr LargeImageListHandle;
        List<Item> itemList = new List<Item>();
        private EnvManager envmngr = EnvManager.getInstance();

        private void MainForm_Load(object sender, EventArgs e)
        {
            Trace.WriteLine("form loaded!");

            int interval = 0;
            if (NativeMethods.SystemParametersInfo(22, 0, ref interval, 0)) // 22=SPI_GETKEYBOARDDELAY
            {
                timerInput.Interval = (interval + 1) * 250; // /* 1unit = approximately 250 */
            }
            timerInput.Enabled = true;
            timerInput.Stop();

            // initial position
            int MainWinHeight = Properties.Settings.Default.MainWinHeight;
            if (MainWinHeight > 0)
            {
                this.Size = new Size(Properties.Settings.Default.MainWinWidth, MainWinHeight);
                this.Location = new Point(Properties.Settings.Default.MainWinPosX, Properties.Settings.Default.MainWinPosY);
            }
            else
            {
                this.CenterToScreen();
            }

            cmbbxSearcText.Items.AddRange(envmngr.getSearchHistory());

            SetFontAndColor();

            // prepare LSV
            // lsvFileList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

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

            updateView("", true);

            envmngr.setNotifyFinished(EnvFinished);
        }

        private void SetFontAndColor()
        {
            // default value
            int cmbbxHeight = cmbbxSearcText.Size.Height;
            int txtHeight = txtViewPath.Height;
            int lsvY = lsvFileList.Location.Y;
            int lsvHeight = lsvFileList.Size.Height;
            int txtY = txtViewPath.Location.Y;

            // Font & Color
            cmbbxSearcText.Font = Properties.Settings.Default.Font;
            cmbbxSearcText.ForeColor = Properties.Settings.Default.FontColor;
            cmbbxSearcText.BackColor = Properties.Settings.Default.BackColorText;

            lsvFileList.Font = Properties.Settings.Default.Font;
            lsvFileList.ForeColor = Properties.Settings.Default.FontColor;
            lsvFileList.BackColor = Properties.Settings.Default.BackColorText;

            txtViewPath.Font = Properties.Settings.Default.Font;
            txtViewPath.ForeColor = Properties.Settings.Default.FontColor;
            txtViewPath.BackColor = Properties.Settings.Default.BackColorText;

            BackColor = Properties.Settings.Default.BackColorForm;
            btnExec.BackColor = Properties.Settings.Default.BackColorForm;
            btnClose.BackColor = Properties.Settings.Default.BackColorForm;
            btnSetenv.BackColor = Properties.Settings.Default.BackColorForm;
            btnUpdate.BackColor = Properties.Settings.Default.BackColorForm;

            Opacity = Properties.Settings.Default.OpacityForm * 0.01;

            // Adjust component's location and size
            int top = cmbbxSearcText.Size.Height - cmbbxHeight;
            int bottom = txtViewPath.Size.Height - txtHeight;

            lsvFileList.Location = new Point(lsvFileList.Location.X, lsvY + top);
            lsvFileList.Size = new Size(lsvFileList.Width, lsvHeight - top - bottom);
            txtViewPath.Location = new Point(txtViewPath.Location.X, txtY - bottom);
        }

        private void EnvFinished(bool bReCollect)
        {
            SetFontAndColor();

            updateView(null, true);

            if (cmbbxSearcText.Items.Count > Properties.Settings.Default.SearchHistoryMax)
            {
                // cut off over max
                for (int i = cmbbxSearcText.Items.Count - 1; i >= Properties.Settings.Default.SearchHistoryMax; i--)
                {
                    cmbbxSearcText.Items.RemoveAt(i);
                }
            }
        }

        private SearchCmd prevSearchCmd;
        private void updateView(String searchStr, bool forced)
        {

            if (searchStr == null)
            {
                searchStr = cmbbxSearcText.Text;
            }
            if (mc != null)
            {
                SearchCmd sc = Util.analyzeSearchCmd(searchStr);
                if (forced ||
                    !(string.IsNullOrEmpty(sc.strSearch) && string.IsNullOrEmpty(prevSearchCmd.strSearch)) &&
                    (sc.matchingType != prevSearchCmd.matchingType || sc.strSearch != prevSearchCmd.strSearch))
                {
                    putFileListView(mc.grep(searchStr));
                }
                prevSearchCmd = sc;
            }

        }

        private void putFileListView(List<Item> itemList)
        {
            lsvFileList.BeginUpdate();
            lsvFileList.Items.Clear();
            int i = 0;
            foreach (Item item in itemList)
            {
                if (i++ >= Properties.Settings.Default.DisplayItemMax)
                {
                    break;
                }
                ListViewItem lvi = new ListViewItem(item.getItemName());

                // a ListViewItem have a Item-object
                lvi.Tag = item;

                // reference: http://acha-ya.cocolog-nifty.com/blog/2010/11/2-f06c.html
                // 最上位8ビットを除いた値をアイコンインデックス値とする
                int iconIndex = (item.getIconIndex() & 0xFFFFFF);
                lvi.ImageIndex = iconIndex;
                
                lsvFileList.Items.Add(lvi);
                /*
                 * 
                // for overlaing shotcut arrow icon 
                LVITEM lvitem = new LVITEM();
                lvitem.stateMask = NativeMethods.LVIS_OVERLAYMASK;
                // 最上位8ビットの値を、8-11ビット目に格納、それ以外のビットは 0 にする
                lvitem.state = ((item.getIconIndex() >> 16) & 0x0F00);
                NativeMethods.SendMessage(lsvFileList.Handle,
                    NativeMethods.LVM_SETITEMSTATE, lvi.Index, ref lvitem);
                 * 
                 */
            }
            lsvFileList.EndUpdate();

            // hack code: stop to display a horizontal scrollbar
            lsvFileList.Columns[0].Width = lsvFileList.ClientSize.Width - 1;
            lsvFileList.Columns[0].Width = lsvFileList.ClientSize.Width;

            txtViewPath.Text = "";
            if (lsvFileList.Items.Count > 0)
            {
                lsvFileList.Items[0].Selected = true;
                for (i = 0; i < lsvFileList.Items.Count; i++)
                {
                    Item item = (Item)lsvFileList.Items[i].Tag;
                    if (item.getItemType() != ItemType.TYPE_FIX)
                    {
                        lsvFileList.Items[i].Selected = true;
                        lsvFileList.FocusedItem = lsvFileList.Items[i];
                        break;
                    }
                }
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

        /// <summary>
        /// exec selected item in lsv
        /// </summary>
        private void execSelectedItem()
        {
            // for waiting search / too fast-input to exec
            updateView(null, false);

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

                    if(item.execute(cmbbxSearcText.Text, modifiers))
                    {
                        SetSearchTextHistory();
                        mc.setExecHistory(item);
                        this.Close();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Trace.WriteLine(e.Message + "\n" + e.StackTrace);
                }
            }
        }

        private void SetSearchTextHistory()
        {
            int index;

            if (string.IsNullOrEmpty(cmbbxSearcText.Text))
            {
                return;
            }

            string searchText = cmbbxSearcText.Text;
            if ((index=cmbbxSearcText.FindStringExact(searchText)) >= 0)
            {
                // remove same item
                cmbbxSearcText.Items.RemoveAt(index);
            }

            // add new item
            cmbbxSearcText.Items.Insert(0, searchText);

            if (cmbbxSearcText.Items.Count > Properties.Settings.Default.SearchHistoryMax)
            {
                // cut off over max
                for (int i = cmbbxSearcText.Items.Count-1; i >= Properties.Settings.Default.SearchHistoryMax; i--)
                {
                    cmbbxSearcText.Items.RemoveAt(i);
                }
            }

            string[] history = new string[cmbbxSearcText.Items.Count];
            
            for (int i = 0; i < cmbbxSearcText.Items.Count; i++)
            {
                history[i] = cmbbxSearcText.Items[i].ToString();
            }
            
            envmngr.setSearchHistory(history);
        }

        private void cmbbxSearcText_TextUpdate(object sender, EventArgs e)
        {
            // move to TextChanged
            // timerInput.Stop();
            // timerInput.Start();

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
                    if (e.Modifiers == Keys.None && !cmbbxSearcText.DroppedDown)
                    {
                        NativeMethods.SendMessage(lsvFileList.Handle, 0x0100, (IntPtr)e.KeyCode, IntPtr.Zero);
                        e.Handled = true;
                    }
                    break;
                default:
                    break;
            }
        }

        private void lsvFileList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

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
            mc.removeInvoker(collectStateHandler);
            envmngr.removeNotifyFinished(EnvFinished);
            timerInput.Stop();
            timerInput.Tick -= new EventHandler(this.timerInput_Tick);

            // reference: http://stackoverflow.com/questions/2021681/hide-form-instead-of-closing-when-close-button-clicked
            /*
             * if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
            */
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            Properties.Settings.Default.MainWinWidth = this.Size.Width;
            Properties.Settings.Default.MainWinHeight = this.Size.Height;
            Properties.Settings.Default.MainWinPosX = this.Location.X;
            Properties.Settings.Default.MainWinPosY = this.Location.Y;

            Properties.Settings.Default.Save();
        }

        /* move to CancelButton Property of Form
        /* 
        // To capture the "Esc" key
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                btnClose.PerformClick();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
        */

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateListItem();
        }
        private void updateListItem()
        {
            mc.setEvent();
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

        private void timerInput_Tick(object sender, EventArgs e)
        {
            if (this.IsDisposed)
            {
                return;
            }

            if (Properties.Settings.Default.bAutoCompleteSourceChange)
            {
                string str = cmbbxSearcText.Text;

                if ((str.StartsWith(@"\\") ||
                    Regex.IsMatch(str, @"^[a-zA-Z]:.*")))
                {
                    if (cmbbxSearcText.AutoCompleteSource != AutoCompleteSource.FileSystem)
                    {
                        cmbbxSearcText.AutoCompleteSource = AutoCompleteSource.FileSystem;
                        cmbbxSearcText.Select(cmbbxSearcText.Text.Length, 0);
                    }
                }
                else if (Regex.IsMatch(str, @"^[a-z]+:.*"))
                {
                    if (cmbbxSearcText.AutoCompleteSource != AutoCompleteSource.AllUrl)
                    {
                        cmbbxSearcText.AutoCompleteSource = AutoCompleteSource.AllUrl;
                        cmbbxSearcText.Select(cmbbxSearcText.Text.Length, 0);
                    }
                }
                else
                {
                    if (cmbbxSearcText.AutoCompleteSource != AutoCompleteSource.ListItems)
                    {
                        cmbbxSearcText.AutoCompleteSource = AutoCompleteSource.ListItems;
                        cmbbxSearcText.Select(cmbbxSearcText.Text.Length, 0);
                    }
                }
            }

            // timerInput.Enabled = false;
            timerInput.Stop();

            if (mc != null)
            {
                updateView(null, false);
            }
        }

        private void btnSetenv_Click(object sender, EventArgs e)
        {
            SettingForm.ShowSettingForm();
        }

        private void cmbbxSearcText_TextChanged(object sender, EventArgs e)
        {
            timerInput.Stop();
            timerInput.Start();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                // reference: http://dobon.net/vb/dotnet/system/displayshieldicon.html
                btnExec.FlatStyle = System.Windows.Forms.FlatStyle.System;
                NativeMethods.SendMessage((IntPtr)btnExec.Handle,
                    0x160C, // BCM_SETSHIELD
                    IntPtr.Zero,
                    (IntPtr)1);
            }
            if (e.KeyCode == Keys.Enter && e.Control)
            {
                NativeMethods.SendMessage((IntPtr)btnExec.Handle,
                    0x160C, // BCM_SETSHIELD
                    IntPtr.Zero,
                    (IntPtr)0);
                btnExec.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
                btnExec.PerformClick();
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                NativeMethods.SendMessage((IntPtr)btnExec.Handle,
                    0x160C, // BCM_SETSHIELD
                    IntPtr.Zero,
                    (IntPtr)0);
                btnExec.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            }
        }
    }
  
}

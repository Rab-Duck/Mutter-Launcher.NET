using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MutterLauncher
{
    public partial class SettingForm : Form
    {

        private static SettingForm frmSettingForm = null;
        public static void ShowSettingForm()
        {
            if(frmSettingForm != null && !frmSettingForm.IsDisposed)
            {
                frmSettingForm.Activate();
                return;
            }

            frmSettingForm = new SettingForm();
            frmSettingForm.Show();
            frmSettingForm.Activate();

        }

        public SettingForm()
        {
            InitializeComponent();
        }


        private void txtbxHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            Keys[] ignorekeys = {
                Keys.ShiftKey, Keys.LShiftKey, Keys.RShiftKey,
                Keys.ControlKey, Keys.LControlKey, Keys.RControlKey,
                Keys.Alt,
                Keys.LWin, Keys.RWin,
                Keys.None,
                Keys.NoName
            };

            foreach (Keys ignorekey in ignorekeys)
            {
                if (e.KeyCode == ignorekey)
                {
                    txtbxHotkey.Text = "";
                    return;
                }
            }

            txtbxHotkey.Text = e.KeyCode.ToString() + "(code=" + (int)e.KeyCode + ")";
            txtbxHotkey.Tag = e.KeyCode;

            e.Handled = true;

        }

        private void txtbxHotkey_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {

            this.CenterToScreen();

            // value -> dialog
            cbAlt.Checked = Properties.Settings.Default.HotKeyAlt;
            cbCtrl.Checked = Properties.Settings.Default.HotKeyCtrl;
            cbShift.Checked = Properties.Settings.Default.HotKeyShift;
            cbWin.Checked = Properties.Settings.Default.HotKeyWin;
            KeysConverter kc = new KeysConverter();
            txtbxHotkey.Text = kc.ConvertToString(Properties.Settings.Default.HotKeyCode);
            txtbxHotkey.Tag = Properties.Settings.Default.HotKeyCode;

            tbStartWith.Text = new string((char)Properties.Settings.Default.ChrStartWith, 1);
            tbEndWith.Text = new string(new char[] { (char)Properties.Settings.Default.ChrEndWith });
            tbSkipMatching.Text = new string((char)Properties.Settings.Default.ChrSkipMatching, 1);
            tbEqual.Text = new string((char)Properties.Settings.Default.ChrEqual, 1);

            EnvManager em = EnvManager.getInstance();
            tbAnyFolder.Text = string.Join("\r\n", em.getAnyFolderList());


            // lsvUserItem.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            
            foreach (Item item in em.getUserItemList())
            {
                ListViewItem lvi = new ListViewItem(item.getItemName());
                lvi.Tag = item;
                lsvUserItem.Items.Add(lvi);
            }
            lsvUserItem.Columns[0].Width = lsvUserItem.ClientSize.Width;

            tbUpdateInterval.Text = Properties.Settings.Default.updateInterval.ToString();
            tbSearchHistoryMax.Text = Properties.Settings.Default.SearchHistoryMax.ToString();
            tbExecHistoryMax.Text = Properties.Settings.Default.ExecHistoryMax.ToString();
            tbDisplayItemMax.Text = Properties.Settings.Default.DisplayItemMax.ToString();

            fontDialog.Font = Properties.Settings.Default.Font;
            fontDialog.Color = Properties.Settings.Default.FontColor;
            colorDialog.Color = Properties.Settings.Default.BackColor;

        }

        private void txtbxHotkey_Validating(object sender, CancelEventArgs e)
        {
            if (txtbxHotkey.Text == "")
            {
                ShowErrMsg(txtbxHotkey, Properties.Resources.ErrSettingHotkey);
                e.Cancel = true;
            }
        }

        private void ShowErrMsg(Control control, string msg)
        {
            MessageBox.Show(msg, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            errorProvider1.SetError(control, msg);
        }

        private void txtbxHotkey_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtbxHotkey, "");
        }

        private void btnUserItemAdd_Click(object sender, EventArgs e)
        {
            SettingFormUserItem frmUserItem = new SettingFormUserItem();
            frmUserItem.ShowDialog(this);
            if (frmUserItem.userItem != null)
            {
                ListViewItem lvi = new ListViewItem(frmUserItem.userItem.getItemName());
                lvi.Tag = frmUserItem.userItem;
                lsvUserItem.Items.Add(lvi);

                lsvUserItem.Columns[0].Width = lsvUserItem.ClientSize.Width;

                int index = lsvUserItem.Items.Count - 1;
                lsvUserItem.Items[index].Selected = true;
                lsvUserItem.FocusedItem = lsvUserItem.Items[index];
            }
            frmUserItem = null;
        }

        private void tbStartWith_Validating(object sender, CancelEventArgs e)
        {
            CheckAsciiChar(tbStartWith, e);
        }

        private void CheckAsciiChar(TextBox tbTarget, CancelEventArgs e)
        {
            if ((new Regex("^[\u0020-\u007E]$")).IsMatch(tbTarget.Text))
            {
                return;
            }

            // error
            ShowErrMsg(tbTarget, Properties.Resources.ErrNotAscii);
            e.Cancel = true;
        }

        private void tbEndWith_Validating(object sender, CancelEventArgs e)
        {
            if (tbEndWith.Text == " ")
            {
                ShowErrMsg(tbEndWith, Properties.Resources.ErrEndWithSpace);
                e.Cancel = true;
                return;
            }
            CheckAsciiChar(tbEndWith, e);
        }

        private void tbStartWith_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tbStartWith, "");
        }

        private void tbEndWith_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tbEndWith, "");
        }

        private void tbSkipMatching_Validating(object sender, CancelEventArgs e)
        {
            CheckAsciiChar(tbSkipMatching, e);
        }

        private void tbSkipMatching_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tbSkipMatching, "");
        }

        private void tbEqual_Validating(object sender, CancelEventArgs e)
        {
            CheckAsciiChar(tbEqual, e);
        }

        private void tbEqual_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tbEqual, "");
        }

        private void tbUpdateInterval_Validating(object sender, CancelEventArgs e)
        {
            CheckMinMaxNum(tbUpdateInterval, 10, 9999, e);
        }

        private void CheckMinMaxNum(TextBox tbTarget, int min, int max, CancelEventArgs e)
        {
            int value;

            try
            {
                value = int.Parse(tbTarget.Text);
            }
            catch (Exception)
            {
                ShowErrMsg(tbTarget, Properties.Resources.ErrNumericVal);
                e.Cancel = true;
                return;
            }

            if (value < min || value > max)
            {
                ShowErrMsg(tbTarget, Properties.Resources.ErrNumericRange + " [" + min + "-" + max + "]");
                e.Cancel = true;
                return;
            }
        }

        private void tbUpdateInterval_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tbUpdateInterval, "");
        }

        private void tbSearchHistoryMax_Validating(object sender, CancelEventArgs e)
        {
            CheckMinMaxNum(tbSearchHistoryMax, 0, 100, e);
        }

        private void tbSearchHistoryMax_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tbSearchHistoryMax, "");
        }

        private void tbExecHistoryMax_Validating(object sender, CancelEventArgs e)
        {
            CheckMinMaxNum(tbExecHistoryMax, 0, 100, e);
        }

        private void tbExecHistoryMax_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tbExecHistoryMax, "");
        }

        private void tbDisplayItemMax_Validating(object sender, CancelEventArgs e)
        {
            CheckMinMaxNum(tbDisplayItemMax, 0, 100, e);
        }

        private void tbDisplayItemMax_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tbDisplayItemMax, "");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                // dialog -> value + save
                Properties.Settings.Default.HotKeyAlt = cbAlt.Checked;
                Properties.Settings.Default.HotKeyCtrl = cbCtrl.Checked;
                Properties.Settings.Default.HotKeyShift = cbShift.Checked;
                Properties.Settings.Default.HotKeyWin = cbWin.Checked;
                Properties.Settings.Default.HotKeyCode = (int)txtbxHotkey.Tag;

                Properties.Settings.Default.ChrStartWith = tbStartWith.Text[0];
                Properties.Settings.Default.ChrEndWith = tbEndWith.Text[0];
                Properties.Settings.Default.ChrSkipMatching = tbSkipMatching.Text[0];
                Properties.Settings.Default.ChrEqual = tbEqual.Text[0];

                EnvManager em = EnvManager.getInstance();
                em.setAnyFolderList(tbAnyFolder.Text);

                // Store lsvUserItem -> UserItemList.bin
                List<Item> listItem = new List<Item>();
                foreach (ListViewItem lvi in lsvUserItem.Items)
                {
                    listItem.Add((Item)lvi.Tag);
                }
                em.setUerItemlist(listItem);

                Properties.Settings.Default.updateInterval = int.Parse(tbUpdateInterval.Text);
                Properties.Settings.Default.SearchHistoryMax = int.Parse(tbSearchHistoryMax.Text);
                Properties.Settings.Default.ExecHistoryMax = int.Parse(tbExecHistoryMax.Text);
                Properties.Settings.Default.DisplayItemMax = int.Parse(tbDisplayItemMax.Text);

                Properties.Settings.Default.Font = fontDialog.Font;
                Properties.Settings.Default.FontColor = fontDialog.Color;
                Properties.Settings.Default.BackColor = colorDialog.Color;

                Properties.Settings.Default.Save();

                em.notifyAll();
                em.notifyFinishedAll();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Save Setting Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            AutoValidate = AutoValidate.Disable;
            this.Close();
        }

        // reference: http://stackoverflow.com/questions/15920770/closing-the-c-sharp-windows-form-by-avoiding-textbox-validation
        // To capture the Upper right "X" click
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x10) // The upper right "X" was clicked
            {
                AutoValidate = AutoValidate.Disable; //Deactivate all validations
            }
            base.WndProc(ref m);
        }

        /* move to CancelButton Property of Form
        // To capture the "Esc" key
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                // AutoValidate = AutoValidate.Disable;
                btnCancel.PerformClick();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
        */


        private void btnUserItemUp_Click(object sender, EventArgs e)
        {
            int index;
            if (lsvUserItem.SelectedItems.Count <= 0 ||
                (index = lsvUserItem.SelectedItems[0].Index) <= 0)
            {
                return;
            }

            Item moveItem = (Item)lsvUserItem.Items[index].Tag;

            lsvUserItem.Items[index].Remove();

            ListViewItem lvi = new ListViewItem(moveItem.getItemName());
            lvi.Tag = moveItem;

            index--;
            lsvUserItem.Items.Insert(index, lvi);
            lsvUserItem.Items[index].Selected = true;
            lsvUserItem.FocusedItem = lsvUserItem.Items[index];

        }

        private void btnUserItemDown_Click(object sender, EventArgs e)
        {
            int index;
            if (lsvUserItem.SelectedItems.Count <= 0 ||
                (index = lsvUserItem.SelectedItems[0].Index) >= lsvUserItem.Items.Count - 1)
            {
                return;
            }

            Item moveItem = (Item)lsvUserItem.Items[index].Tag;

            lsvUserItem.Items[index].Remove();

            ListViewItem lvi = new ListViewItem(moveItem.getItemName());
            lvi.Tag = moveItem;

            index++;
            lsvUserItem.Items.Insert(index, lvi);
            lsvUserItem.Items[index].Selected = true;
            lsvUserItem.FocusedItem = lsvUserItem.Items[index];
        }

        private void btnUserItemDel_Click(object sender, EventArgs e)
        {
            int index;
            if (lsvUserItem.SelectedItems.Count <= 0)
            {
                return;
            }

            index = lsvUserItem.SelectedItems[0].Index;

            lsvUserItem.Items[index].Remove();
            lsvUserItem.Columns[0].Width = lsvUserItem.ClientSize.Width;

            int count;
            if ((count=lsvUserItem.Items.Count) <= 0)
            {
                return;
            }
            else if (index >= count)
            {
                index--;
            }

            lsvUserItem.Items[index].Selected = true;
            lsvUserItem.FocusedItem = lsvUserItem.Items[index];

        }

        private void btnUserItemUpdate_Click(object sender, EventArgs e)
        {
            int index;
            if (lsvUserItem.SelectedItems.Count <= 0)
            {
                return;
            }

            index = lsvUserItem.SelectedItems[0].Index;
            UserItem moveItem = (UserItem)lsvUserItem.Items[index].Tag;


            SettingFormUserItem frmUserItem = new SettingFormUserItem(moveItem);
            frmUserItem.ShowDialog(this);
            if (frmUserItem.userItem != null)
            {
                lsvUserItem.Items[index].Remove();

                ListViewItem lvi = new ListViewItem(frmUserItem.userItem.getItemName());
                lvi.Tag = frmUserItem.userItem;
                lsvUserItem.Items.Insert(index, lvi);

                lsvUserItem.Columns[0].Width = lsvUserItem.ClientSize.Width;

                lsvUserItem.Items[index].Selected = true;
                lsvUserItem.FocusedItem = lsvUserItem.Items[index];
            }
            frmUserItem = null;

        }

        private void btnFontChange_Click(object sender, EventArgs e)
        {
            fontDialog.ShowDialog(this);
            Debug.WriteLine(fontDialog.Font);
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog(this);
            Debug.WriteLine(colorDialog.Color);
        }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            lsvUserItem.Columns[0].Width = lsvUserItem.ClientSize.Width;
            foreach (Item item in em.getUserItemList())
            {
                ListViewItem lvi = new ListViewItem(item.getItemName());
                lvi.Tag = item;
                lsvUserItem.Items.Add(lvi);
            }

            tbUpdateInterval.Text = Properties.Settings.Default.updateInterval.ToString();
            tbSearchHistoryMax.Text = Properties.Settings.Default.SearchHistoryMax.ToString();
            tbExecHistoryMax.Text = Properties.Settings.Default.ExecHistoryMax.ToString();
            tbDisplayItemMax.Text = Properties.Settings.Default.DisplayItemMax.ToString();


        }

        private void txtbxHotkey_Validating(object sender, CancelEventArgs e)
        {
            if (txtbxHotkey.Text == "")
            {
                ShowErrMsg(txtbxHotkey, "Please set a valid key.");
                e.Cancel = true;
            }
        }

        private void ShowErrMsg(Control control, string msg)
        {
            MessageBox.Show(msg);
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
            }
            frmUserItem = null;
        }

        private void tbStartWith_Validating(object sender, CancelEventArgs e)
        {
            CheckAsciiChar(tbStartWith, e);
        }

        private void CheckAsciiChar(TextBox tbTarget, CancelEventArgs e)
        {
            if (ActiveControl == tbTarget)
                return;

            if ((new Regex("^[\u0020-\u007E]$")).IsMatch(tbTarget.Text))
            {
                return;
            }

            // error
            ShowErrMsg(tbTarget, "Please set a ascii char.");
            e.Cancel = true;
        }

        private void tbEndWith_Validating(object sender, CancelEventArgs e)
        {
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
                ShowErrMsg(tbTarget, "Please set a numeric value.");
                e.Cancel = true;
                return;
            }

            if (value < min || value > max)
            {
                ShowErrMsg(tbTarget, "Please set " + min + "-" + max + " value");
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

            // Not Implimented
            // Store lsvUserItem -> UserItemList.bin

            Properties.Settings.Default.updateInterval = int.Parse(tbUpdateInterval.Text);
            Properties.Settings.Default.SearchHistoryMax = int.Parse(tbSearchHistoryMax.Text);
            Properties.Settings.Default.ExecHistoryMax = int.Parse(tbExecHistoryMax.Text);
            Properties.Settings.Default.DisplayItemMax = int.Parse(tbDisplayItemMax.Text);
            Properties.Settings.Default.Save();

            em.notifyAll();
            em.notifyFinishedAll();
            
            this.Close();
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
    }
}


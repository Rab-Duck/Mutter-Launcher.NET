using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MutterLauncher
{
    public partial class SettingFormUserItem : Form
    {
        private UserItem _userItem;
        public UserItem userItem { get { return _userItem; } }

        public SettingFormUserItem()
        {
            InitializeComponent();
        }

        public SettingFormUserItem(UserItem userItem)
        {
            InitializeComponent();
            this._userItem = userItem;
        }

        private void SettingFormUserItem_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            if (userItem == null)
            {
                return;
            }

            SetDialogValue();
        }
        private void SetDialogValue()
        {
            cbName.Text = _userItem.getItemName();
            txtCmd.Text = _userItem.getItemPath();

            chkFixedItem.Checked = _userItem.getItemType() == ItemType.TYPE_FIX ? true : false;
            chkUseCmdOption.Checked = _userItem.bCmdOption;
            chkUseUrlEncode.Checked = _userItem.bUrlEncode;
            txtEncoding.Text = _userItem.encoding;

            _userItem = null;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _userItem = new UserItem(
                cbName.Text, 
                txtCmd.Text,
                chkFixedItem.Checked,
                chkUseCmdOption.Checked,
                chkUseUrlEncode.Checked, txtEncoding.Text
                );
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _userItem = null;
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

        private void chkUseUrlEncode_CheckedChanged(object sender, EventArgs e)
        {
            txtEncoding.Enabled = chkUseUrlEncode.Checked;
            if (txtEncoding.Enabled)
            {
                txtEncoding.Focus();
            }
        }

        private void ShowErrMsg(Control control, string msg)
        {
            MessageBox.Show(msg);
            errorProvider.SetError(control, msg);
        }

        private void cbName_Validating(object sender, CancelEventArgs e)
        {
            if (cbName.Text == "")
            {
                ShowErrMsg(cbName, "Set a valid name.");
                e.Cancel = true;
                return;
            }
        }

        private void txtCmd_Validating(object sender, CancelEventArgs e)
        {
            if (txtCmd.Text == "")
            {
                ShowErrMsg(txtCmd, "Set a valid command.");
                e.Cancel = true;
                return;
            }
        }

        private void cbName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (cbName.SelectedIndex)
            {
                case 0:
                    _userItem = new UserItem("Run", "%1", true, true, false, null);
                    break;
                case 1:
                    _userItem = new UserItem("Google Search", "http://www.google.com/search?hl=ja&ie=UTF-8&q=%1", true, false, true, "UTF-8");
                    break;
                case 2:
                    _userItem = new UserItem("netstat", "netstat -rn %1", false, true, false, null);
                    break;
                default:
                    return;
            }
            SetDialogValue();
        }

        private void cbName_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(cbName, "");
        }

        private void txtCmd_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(txtCmd, "");
        }

        private void txtEncoding_Validating(object sender, CancelEventArgs e)
        {
            if (chkUseUrlEncode.Checked)
            {
                try
                {
                    System.Text.Encoding enc = System.Text.Encoding.GetEncoding(txtEncoding.Text);
                }
                catch (ArgumentException)
                {
                    ShowErrMsg(txtEncoding, "Set a valid encoding.");
                    e.Cancel = true;
                    return;
                }
            }


        }

        private void txtEncoding_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(txtEncoding, "");
        }
    }
}

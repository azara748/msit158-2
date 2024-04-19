using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 期中專案;

namespace SelectShop.Views
{
    public partial class FrmRegister : Form
	{
        private DialogResult _confm;
		private tMember _member;
		public tMember member
		{
			get 
			{
				if(_member == null)
				{
					_member = new tMember();
				}
				_member.MemberID = 0; // Convert.ToInt32(fbMembeID.fieldValue);
				_member.MemberName = fbMName.fieldValue.Trim();
				_member.Cellphone = fbMCellphone.fieldValue.Trim();
				_member.Birthday = MBirthday.Value.Date;
				_member.E_mail = fbMEmail.fieldValue.Trim();
				_member.Address = fbMAddress.fieldValue.Trim();
				_member.Password = funMD5(tbxMPassword.Text.Trim());

				return _member; }
			set { _member = value; 
				//fbMembeID.fieldName = _member.MemberID.ToString();
				fbMName.fieldValue = _member.MemberName;
				fbMCellphone.fieldValue = _member.Cellphone;
				fbMAddress.fieldValue = _member.Address;
				fbMEmail.fieldValue = _member.E_mail;
				tbxMPassword.Text = _member.Password;
				MBirthday.Value = Convert.ToDateTime(_member.Birthday); 
			}
		}

		public string funMD5(string txtPassword)
		{
			return string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(txtPassword)).Select(s => s.ToString("x2")));
		}

		public DialogResult confm
		{
			get { return _confm; }
		}

		private void btnConfirm_Click(object sender, EventArgs e)
		{
			if (tbxMPassword.Text.Equals(tbxMPassConfirm.Text))
			{
				_confm = DialogResult.OK;
				Close();
			} else
			{
				MessageBox.Show("請再次確認密碼檢核相同！");
				return;
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			_confm = DialogResult.Cancel;
			Close();
		}


		public FrmRegister()
		{
			InitializeComponent();

			//fbMembeID.fieldValue = "自動給號";
			//fbMembeID.Enabled = false;
			tbxMPassword.PasswordChar = '*';
			tbxMPassConfirm.PasswordChar = '*';
		}
	}
}

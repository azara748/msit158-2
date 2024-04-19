using SelectShop.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 期中專案;


namespace SelectShop
{
    public partial class FrmLogin : Form
    {      
        bool _register = false;
		private DialogResult _confm;
	
		private List<tMember> _member;
        //public tMembers member;
        public FrmLogin()
        {
            InitializeComponent();

            //txtEmail.Text = "e-MAIL";
            //txtPassword.Text = "Password";
            this.Text = "User Login";
        }

		public string funMD5(string txtPassword)
		{
			return string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(txtPassword)).Select(s => s.ToString("x2")));
		}

		public DialogResult confm
		{
			get { return _confm; }
		}

        public List<tMember> member
        {
            get { return _member; }
        }

		private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
            //txtPassword.PasswordChar = '*';
        }

        private void txtEmail_Click(object sender, EventArgs e)
        {
            txtEmail.Clear();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string E_mail = txtEmail.Text.Trim();
                string hashPassword;
                if (_register == false)
                {
                    hashPassword = funMD5(txtPassword.Text.Trim());
                } else
                {
                    hashPassword = txtPassword.Text;
				}

                SelectShopEntities db = new SelectShopEntities();
                var admin = from r in db.tMembers
                            where r.E_mail.Equals(E_mail) && r.Password.Equals(hashPassword)
                            select r;
                List<tMember> member = admin.ToList();
                //MessageBox.Show(member.Count.ToString());
				if (member.Count > 0)
				{
					_confm = DialogResult.OK;
                    _member = member;
					MessageBox.Show("會員 " + member[0].MemberName + " 已登入！");

                    ////////////////////////////////////////
                    首頁.登入會員= member[0].MemberID;
                    ///////////////////////////////////////
                    this.Close();
				}
				else
				{
				    MessageBox.Show("登入失敗！");
                    this.txtPassword.Clear();
				}
			}
            catch (Exception ex)
            {
            }
        }

		private void linkReg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
            _register = true;
            FrmRegister FrmReg = new FrmRegister();
            FrmReg.ShowDialog();
            if (FrmReg.confm != DialogResult.OK)
                return;
            tMember x = FrmReg.member;

			SelectShopEntities db = new SelectShopEntities();
            db.tMembers.Add(x);
            db.SaveChanges();

            txtEmail.Text = x.E_mail;
            txtPassword.Text = x.Password;

            MessageBox.Show("會員註冊已完成，將直接直接導向登入！");
            btnLogin_Click(this,e);
            //this.Close();
		}
        ////////////////////////////////////////
        public bool 直接註冊 = false;
        private void FrmLogin_Load(object sender, EventArgs e)
        { if (直接註冊) { linkReg_LinkClicked(null, null); }
        ////////////////////////////////////////
        }
    }
}

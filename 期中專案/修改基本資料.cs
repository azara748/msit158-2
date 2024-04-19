using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 期中專案
{
    public partial class 修改基本資料 : Form
    {
        public 首頁D 更新;
        public string 會員名稱 { get { return textBox1.Text; } set { textBox1.Text = value; } }
        public string 電子信箱 { get { return textBox2.Text; } set { textBox2.Text = value; } }
        public string 手機 { get { return textBox3.Text; } set { textBox3.Text = value; } }
        public string 地址 { get { return textBox4.Text; } set { textBox4.Text = value; } }
        public string 生日 { get { return dateTimePicker1.Text; } set { dateTimePicker1.Value = DateTime.Parse(value); } }

        public 修改基本資料()
        {
            InitializeComponent();         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectShopEntities db = new SelectShopEntities();
            tMember room3 = db.tMembers.FirstOrDefault(x => x.MemberID == 首頁.登入會員);
            room3.MemberName = 會員名稱;
            room3.E_mail = 電子信箱;
            room3.Cellphone= 手機;
            room3.Address = 地址;
            room3.Birthday = DateTime.Parse(生日);
            db.SaveChanges();
            MessageBox.Show("更改會員資料成功!");
            更新();
            this.Close();
        }
    }
}

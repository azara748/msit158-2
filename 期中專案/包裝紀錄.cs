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
    public partial class 包裝紀錄 : UserControl
    {
        public string 標題 { get { return label1.Text; } set { label1.Text = value; } }
        public int 價格 { get { return Convert.ToInt32(label5.Text); } set { label5.Text = value.ToString(); } }
        public int 數量 { get { return Convert.ToInt32(label4.Text); } set { label4.Text = value.ToString(); } }
        public Image 商品圖片 { get { return pictureBox1.Image; } set { pictureBox1.Image = value; } }
        public int 編號 = 0;
        public 包裝紀錄()
        {
            InitializeComponent();
        }

        private void 包裝紀錄_Load(object sender, EventArgs e)
        {
            label6.Text = 價格 * 數量 + "";
        }
    }
}

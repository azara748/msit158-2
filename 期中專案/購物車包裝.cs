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
    public partial class 購物車包裝 : UserControl
    {
        public 首頁D 加減;
        public string 標題 { get { return label1.Text; } set { label1.Text = value; } }
        public int 價格 { get { return Convert.ToInt32(label2.Text); } set { label2.Text = value.ToString(); } }
        public Image 商品圖片 { get { return pictureBox1.Image; } set { pictureBox1.Image = value; } }
        public int 數量 { get { return Convert.ToInt32(label5.Text); } set { label5.Text = value.ToString(); } }
        public int 包裝ID;
        public bool 選取 { get { return checkBox1.Checked; } set { checkBox1.Checked = value; } }
        public 購物車包裝()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            商品資訊格式 b = 購物車頁.加入包裝.FirstOrDefault(t => t.包裝編號 == 包裝ID);
            b.加入購物車數量++;
            label5.Text = b.加入購物車數量.ToString();
            加減();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            商品資訊格式 b = 購物車頁.加入包裝.FirstOrDefault(t => t.包裝編號 == 包裝ID);
            if (b.加入購物車數量 < 2) return;
            b.加入購物車數量--;
            label5.Text = b.加入購物車數量.ToString();
            加減();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            商品資訊格式 b = 購物車頁.加入包裝.FirstOrDefault(t => t.包裝編號 == 包裝ID);
            b.勾選 = 選取;
            if(加減!=null) 加減();
        }
    }
}

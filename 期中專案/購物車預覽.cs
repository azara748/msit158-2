using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace 期中專案
{
    public partial class 購物車預覽 : UserControl
    {
        public 首頁D 更新;
        public 首頁D 加減;
        public 購物車預覽()
        {
            InitializeComponent();
        }
        public string 標題 { get { return label1.Text; } set { label1.Text = value; } }
        public int 價格 { get { return Convert.ToInt32(label2.Text); } set { label2.Text = value.ToString(); } }
        public Image 商品圖片 { get { return pictureBox1.Image; } set { pictureBox1.Image = value; } }
        public int 數量 { get { return Convert.ToInt32(label5.Text); } set { label5.Text = value.ToString(); } }
        public int 庫存 { get { return Convert.ToInt32(label6.Text); } set { label6.Text = value.ToString(); } }
        public bool 選取 { get { return checkBox1.Checked; } set { checkBox1.Checked = value; } }

        public int 編號;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            商品資訊格式 b = 購物車頁.加入購物車商品.FirstOrDefault(t => t.商品編號 == 編號);
            b.勾選 = 選取;
            if (加減 != null) 加減();
        }
             
        private void button3_Click(object sender, EventArgs e)
        {
            商品資訊格式 b = 購物車頁.加入購物車商品.FirstOrDefault(t => t.商品編號 == 編號);
            b.加入購物車數量 ++;
            label5.Text = b.加入購物車數量.ToString();
            加減();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            商品資訊格式 b = 購物車頁.加入購物車商品.FirstOrDefault(t => t.商品編號 == 編號);
            if (b.加入購物車數量 < 2) return;
            b.加入購物車數量 -- ;
            label5.Text = b.加入購物車數量.ToString();
            加減();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
             商品詳細 a = new 商品詳細();
            a.poid = 編號;
            a.更新 = 更新;
            a.ShowDialog();
        }
        public int 特價
        {
            get { return (int)(Convert.ToInt32(label8.Text) * 0.8); }
            set { label8.Text = ((int)(Convert.ToInt32(value) * 0.8)).ToString(); ; label8.ForeColor = Color.Red; }
        }

        private void 購物車預覽_Load(object sender, EventArgs e)
        {
            特價 = 價格;
        }
    }
}

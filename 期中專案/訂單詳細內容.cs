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
    public partial class 訂單詳細內容 : UserControl
    {
        public string 標題 { get { return label1.Text; } set { label1.Text = value; } }
        public int 價格 { get { return Convert.ToInt32(label5.Text); } set { label5.Text = value.ToString(); } }
        public int 數量 { get { return Convert.ToInt32(label4.Text); } set { label4.Text = value.ToString(); } }
        public Image 商品圖片 { get { return pictureBox1.Image; } set { pictureBox1.Image = value; } }
        public int 狀態 = 0;
        public int 編號 = 0;
        public int oid = 0;
        public int puid = 0;
        public bool 可評= false;
        public 首頁D 重整;
        public 訂單詳細內容()
        {
            InitializeComponent();
        }

        private void 訂單詳細內容_Load(object sender, EventArgs e)
        {
            label8.Visible = false;
            label6.Text = (價格 * 數量).ToString();
            if (狀態 == 1) { button1.Text="查看商品"; }
            if (!可評) { button2.Visible = false; }
            if (狀態 == 2 && !可評) { label8.Visible = true ; }
            label9.Text = Convert.ToInt32(價格 * 0.8) + "";
            label10.Text = Convert.ToInt32(價格 * 0.8* 數量) + "";
        }
        public void 無用 (){ }
        private void button1_Click(object sender, EventArgs e)
        {
            商品詳細 a = new 商品詳細();
            a.poid = 編號;
            a.更新 = 無用;
            a.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            評分頁 a = new 評分頁();
            a.編號 = 編號;
            a.oid = oid; 
            a.puid = puid;
            a.ShowDialog();
            重整();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            商品詳細 a = new 商品詳細();
            a.poid = 編號;
            a.更新 = 無用;
            a.ShowDialog();
        }
    }
}

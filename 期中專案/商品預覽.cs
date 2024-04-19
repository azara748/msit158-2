using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 期中專案
{
    public delegate void 預覽D();
    public partial class 商品預覽 : UserControl
    {
        SelectShopEntities db = new SelectShopEntities();
        public 首頁D 更新;
        public 商品預覽()
        {
            InitializeComponent();
        }
        public string 標題 { get { return label1.Text; } set { label1.Text = value; } }
        public int 價格 { get { return Convert.ToInt32(label2.Text); } set { label2.Text = value.ToString(); } }
        public int 庫存; //{ get { return Convert.ToInt32(label3.Text); } set { label3.Text = value.ToString(); } }
        public int 顯示庫存
        {
            get { return Convert.ToInt32(label3.Text); }
            set
            {
                if (value > 5) { label3.Text = "尚有庫存"; }
                else if (value > 0) { label3.Text = "即將售罄"; label3.ForeColor = Color.Blue; } else { label3.Text = "銷售一空!!"; label3.ForeColor = Color.Red; }
            }
        }
        public int 特價
        {
            get { return (int)(Convert.ToInt32(label8.Text) * 0.8); }
            set { label8.Text = ((int)(Convert.ToInt32(value) * 0.8)).ToString(); ; label8.ForeColor = Color.Red; }
        }



        public Image 商品圖片 { get { return pictureBox2.Image; } set { pictureBox2.Image = value; } }

        public int 編號;
        public int 數量 = 1;

        商品資訊格式 a;

        private void button1_Click(object sender, EventArgs e)
        {
            a = new 商品資訊格式();
            a.商品名稱 = 標題;
            a.商品編號 = 編號;
            a.商品價格 = 價格;
            if (購物車頁.加入購物車商品.Exists(t => t.商品編號 == a.商品編號))
            {
                商品資訊格式 b = 購物車頁.加入購物車商品.FirstOrDefault(t => t.商品編號 == a.商品編號);
                b.加入購物車數量 += 數量;
            }
            else
            {
                購物車頁.加入購物車商品.Add(a);
                a.加入購物車數量 = 數量;
            }
            MessageBox.Show("「" + 標題 + "」數量+" + 數量);
            更新();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            數量++;
            label6.Text = 數量.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (數量 < 2) return;
            數量--;
            label6.Text = 數量.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            商品詳細 a = new 商品詳細();
            a.poid = 編號;
            a.更新 = 更新;
            a.ShowDialog();
        }
    }
}

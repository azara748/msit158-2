using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 期中專案.付帳;

namespace 期中專案
{
    public partial class 訂單預覽 : UserControl
    {
        public 首頁D 重整;
        public int 訂單裝況編號 = 0;
        public int 訂單編號 = 0;
        public bool 可評 = false;
        public int 總商品數 { get { return Convert.ToInt32(label5.Text); } set { label5.Text = value.ToString(); } }
        public int 總價 { get { return Convert.ToInt32(label4.Text); } set { label4.Text = value.ToString(); } }
        public string 下單日期 { get { return label7.Text; } set { label7.Text = value; } }
        public string 標題 { get { return label9.Text; } set { label9.Text = value; } }
        public Image 代表圖片 { get { return pictureBox1.Image; } set { pictureBox1.Image = value; } }

        public 訂單預覽()
        {
            InitializeComponent();
        }

        private void 訂單預覽_Load(object sender, EventArgs e)
        {
            label10.Visible = false;
            if (訂單裝況編號 == 1) label6.Text = "未結帳";
            else if (訂單裝況編號 == 2)
            {
                label6.Text = "已完成"; button1.Visible = false; button3.Visible = false;
                label10.Visible = true;
                if (!可評) { label10.Text = "已評價"; }
                else { button2.Text += "/評論"; button2.Left = 199; }
            }
            else if (訂單裝況編號 == 3) { label6.Text = "不成立"; button1.Visible = false; button3.Visible = false; }
            label9.Text += "...";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            購物車頁.orderid = 訂單編號;
            FrmPayWay f = new FrmPayWay();
            f.ShowDialog();
            if (購物車頁.orderid == 0)
            {
                SelectShopEntities db = new SelectShopEntities();
                var o = db.tOrders.FirstOrDefault(x => x.OrderID == 訂單編號);
                o.OrderDate = DateTime.Now;
                o.StatusID = 2;

                var p = db.tPurchases.Where(x => x.OrderID == 訂單編號);
                foreach (var item in p)
                {
                    int g = (int)item.ProductID;
                    tProduct 庫存 = db.tProducts.FirstOrDefault(x => x.ProductID == g);
                    庫存.Stocks -= item.Qty;
                }
                db.SaveChanges();
                MessageBox.Show("謝謝光臨");
                重整();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SelectShopEntities db = new SelectShopEntities();
            var o = db.tOrders.FirstOrDefault(x => x.OrderID == 訂單編號);
            o.OrderDate = DateTime.Now;
            o.StatusID = 3;
            db.SaveChanges();
            MessageBox.Show("已取消訂單");
            重整();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            訂單詳細 a = new 訂單詳細();
            a.訂單編號 = 訂單編號;
            a.ShowDialog();
            重整();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            訂單詳細 a = new 訂單詳細();
            a.訂單編號 = 訂單編號;
            a.ShowDialog();
            重整();
        }
    }
}


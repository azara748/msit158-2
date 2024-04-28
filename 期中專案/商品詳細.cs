using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 期中專案
{
    public partial class 商品詳細 : Form
    {
        public 首頁D 更新;
        public int poid;
        public int 數量 = 1;
        public 商品詳細()
        {
            InitializeComponent();
        }
        商品資訊格式 a;
        private void button1_Click(object sender, EventArgs e)
        {
            a = new 商品資訊格式();
            a.商品名稱 = label1.Text;
            a.商品編號 = poid;
            a.商品價格 = Convert.ToInt32(label2.Text);
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
            MessageBox.Show("「" + label1.Text + "」數量+" + 數量);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            大圖 a = new 大圖();
            a.商品圖片 = pictureBox1.Image;
            a.Show();
        }

        private void 商品詳細_Load(object sender, EventArgs e)
        {
            載入商品資訊();
            SelectShopEntities db = new SelectShopEntities();
            var v =
            from r in db.tReviews
            where r.ProductID == poid
            orderby r.ReviewDate descending
            select r;
            int 去除預設 = 0; 
            foreach (var r in v)
            {
                if (去除預設 < 1) { flowLayoutPanel1.Controls.Clear(); 去除預設++; }
                商品評價 p = new 商品評價();
                p.會員ID = r.tMember.MemberName;
                p.評論 = r.Comment;
                p.時間 = Convert.ToDateTime(r.ReviewDate).ToString("yyyy/MM/dd"); ;
                p.評價 = (int)r.RankID;
                if (r.tMember.MemberPhoto != null)
                {
                    MemoryStream ms = new MemoryStream(r.tMember.MemberPhoto);
                    p.商品圖片 = Image.FromStream(ms);
                }
                flowLayoutPanel1.Controls.Add(p);
            }
        }

        private void 載入商品資訊()
        {
            SelectShopEntities db = new SelectShopEntities();
            var b = db.tProducts.FirstOrDefault(t => t.ProductID == poid);
            label1.Text = b.ProductName;
            if (b.UnitPrice == null) { label2.Text = "9999"; }
            else label2.Text = (int)b.UnitPrice + "";
            label11.Text = (int)(Convert.ToInt32(b.UnitPrice) * 0.8) + "";
            label11.ForeColor = Color.Red;
            if (b.Stocks == null) { label3.Text = "0"; } 
            else label3.Text = b.Stocks.ToString();
            if (b.ProductPhoto != null)
            {
                MemoryStream ms = new MemoryStream(b.ProductPhoto);
                pictureBox1.Image = Image.FromStream(ms);
            }
            var c = db.tLabels.FirstOrDefault(t => t.LabelID == b.LabelID);
            if (c.SupplierPhoto != null)
            {
                MemoryStream ms = new MemoryStream(c.SupplierPhoto);
                pictureBox2.Image = Image.FromStream(ms);
            }
            label7.Text = c.LabelName;
            string D = Regex.Replace(c.Description, @"[ ]", "");
            D= Regex.Replace(D, @"[""]", "");
            label8.Text = D;
            if (label8.Text == "N/A") label8.Text = "";
            else label8.Text += "\r\n";
            label8.Text += "__________________________________________________________________________________________________"
                +"\r\n"+ "\r\n" + b.Description;
        }
    }
}

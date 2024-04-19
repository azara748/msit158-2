using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 期中專案
{
    public partial class 評分頁 : Form
    {
        public 評分頁()
        {
            InitializeComponent();
        }
        public int 編號;
        public int oid;
        public int puid ;
        private void 評分頁_Load(object sender, EventArgs e)
        {
            SelectShopEntities db = new SelectShopEntities();
            var b = db.tProducts.FirstOrDefault(t => t.ProductID == 編號);
            label1.Text = b.ProductName;
            var c = db.tOrders.FirstOrDefault(t => t.OrderID== oid);
            label3.Text = Convert.ToDateTime(c.OrderDate).ToString("yyyy/MM/dd  hh:mm");
            if (b.ProductPhoto != null)
            {
                MemoryStream ms = new MemoryStream(b.ProductPhoto);
                pictureBox1.Image = Image.FromStream(ms);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectShopEntities db = new SelectShopEntities();
            tReview ta = new tReview();
            ta.Comment =richTextBox1.Text;
            ta.ReviewDate = DateTime.Now.ToString();
            ta.ProductID = 編號;
            ta.MemberID = 首頁.登入會員;
            ta.RankID = comboBox1.Text.Length ;
            ta.PurchaseID = puid;
            db.tReviews.Add(ta);
            db.SaveChanges();
            MessageBox.Show("已送出評價");
            this.Close();
        }
    }
}

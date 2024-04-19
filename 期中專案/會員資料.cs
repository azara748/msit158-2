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
    public partial class 會員資料 : Form
    {
        public 會員資料()
        {
            InitializeComponent();
            載入會員();
            重整();
        }

        private void 全部訂單()
        {
            SelectShopEntities db = new SelectShopEntities();
            flowLayoutPanel1.Controls.Clear();
            var v =
                from o in db.tOrders
                join p in db.tPurchases
                on o.OrderID equals p.OrderID
                join pro in db.tProducts
                on p.ProductID equals pro.ProductID
                where o.MemberID == 首頁.登入會員
                group new { o, pro, p } by new { o.OrderID, o.OrderDate, o.StatusID }
                into A
                orderby A.Key.OrderDate descending
                select new
                {
                    ID = A.Key.OrderID,
                    時間 = A.Key.OrderDate,
                    狀態 = A.Key.StatusID,
                    總量 = A.Sum(x => x.p.Qty),
                    總價 = A.Sum(x => x.pro.UnitPrice * x.p.Qty),
                };


            foreach (var f in v)
            {
                var v2 = db.tPurchases.FirstOrDefault(x => x.OrderID == f.ID);
                訂單預覽 a = new 訂單預覽();
                if (f.總價 == null) { a.總價 = 0; }
                else a.總價 = (int)f.總價;
                a.總商品數 = (int)f.總量;
                a.訂單裝況編號 = (int)f.狀態;
                a.下單日期 = Convert.ToDateTime(f.時間).ToString("yyyy/MM/dd  hh:mm");;
                a.訂單編號 = f.ID;
                a.重整 = 重整;
                a.標題 = v2.tProduct.ProductName;
                if (v2.tProduct.ProductPhoto != null)
                {
                    MemoryStream ms = new MemoryStream(v2.tProduct.ProductPhoto);
                    a.代表圖片 = Image.FromStream(ms);
                }

                if (f.狀態 == 2)
                {
                    var 已評數 =
                     from o in db.tOrders
                     join p in db.tPurchases
                     on o.OrderID equals p.OrderID
                     join r in db.tReviews
                     on p.PurchaseID equals r.PurchaseID
                     where o.OrderID == f.ID
                     select o;

                    var 訂單數 =
                    from p2 in db.tPurchases
                    where p2.OrderID == f.ID
                    select p2;

                    if (已評數.Count() < 訂單數.Count()) a.可評 = true;

                }
                flowLayoutPanel1.Controls.Add(a);

                var 包裝 =
                from pw in db.tPackageWayDetails
                join p in db.tAllPackages
                on pw.PackageID equals p.PackageID
                where pw.OrderID == f.ID
                group new { pw, p } by new { pw.OrderID }
                into B
                select new
                {
                    oid = B.Key.OrderID,
                    總數 = B.Sum(x => x.pw.PackQty),
                    總價 = B.Sum(x => x.pw.PackQty * x.p.Price)
                };
                var v4 = 包裝.FirstOrDefault();
                if (v4 != null)
                {
                    if (f.總價 == null) { a.總價 = 0; }
                    else a.總價 = Convert.ToInt32(a.總價 * 0.8) + (int)v4.總價;
                    a.總商品數 += (int)v4.總數;
                    flowLayoutPanel1.Controls.Add(a);
                }
                else a.總價 = Convert.ToInt32(a.總價 * 0.8);
            }
        }
        private void 訂單分類(int s)
        {
            SelectShopEntities db = new SelectShopEntities();
            if (s == 1) { flowLayoutPanel2.Controls.Clear(); }
            else if (s == 2) { flowLayoutPanel3.Controls.Clear(); }
            else if (s == 3) { flowLayoutPanel4.Controls.Clear(); }
            var v =
               from o in db.tOrders
               join p in db.tPurchases
               on o.OrderID equals p.OrderID
               join pro in db.tProducts
               on p.ProductID equals pro.ProductID
               where o.MemberID == 首頁.登入會員 && o.StatusID == s
               group new { o, pro, p } by new { o.OrderID, o.OrderDate, o.StatusID }
               into A
               orderby A.Key.OrderDate descending
               select new
               {
                   ID = A.Key.OrderID,
                   時間 = A.Key.OrderDate,
                   狀態 = A.Key.StatusID,
                   總量 = A.Sum(x => x.p.Qty),
                   總價 = A.Sum(x => x.pro.UnitPrice * x.p.Qty),
               };
            foreach (var f in v)
            {
                var v2 = db.tPurchases.FirstOrDefault(x => x.OrderID == f.ID);
                訂單預覽 a = new 訂單預覽();
                if (f.總價 == null) { a.總價 = 0; }
                else a.總價 = (int)f.總價;
                a.總商品數 = (int)f.總量;
                a.訂單裝況編號 = (int)f.狀態;
                a.下單日期 = Convert.ToDateTime(f.時間).ToString("yyyy/MM/dd  hh:mm"); ;
                a.訂單編號 = f.ID;
                a.重整 = 重整;
                a.標題 = v2.tProduct.ProductName;
                if (v2.tProduct.ProductPhoto != null)
                {
                    MemoryStream ms = new MemoryStream(v2.tProduct.ProductPhoto);
                    a.代表圖片 = Image.FromStream(ms);
                }
                var 包裝 =
                from pw in db.tPackageWayDetails
                join p in db.tAllPackages
                on pw.PackageID equals p.PackageID
                where pw.OrderID == f.ID
                group new { pw, p } by new { pw.OrderID }
                into B
                select new { oid = B.Key.OrderID, 總數 = B.Sum(x => x.pw.PackQty), 總價 = B.Sum(x => x.pw.PackQty * x.p.Price) };
                var v4 = 包裝.FirstOrDefault();
                if (v4 != null)
                {
                    if (f.總價 == null) { a.總價 = 0; }
                    else a.總價 = Convert.ToInt32(a.總價 * 0.8) + (int)v4.總價;
                    a.總商品數 += (int)v4.總數;
                }
                else a.總價 = Convert.ToInt32(a.總價 * 0.8);

                if (s == 1) { flowLayoutPanel2.Controls.Add(a); }
                else if (s == 2)
                {
                    var 已評數 =
                    from o in db.tOrders
                    join p in db.tPurchases
                    on o.OrderID equals p.OrderID
                    join r in db.tReviews
                    on p.PurchaseID equals r.PurchaseID
                    where o.OrderID == f.ID
                    select o;

                    var 訂單數 =
                    from p2 in db.tPurchases
                    where p2.OrderID == f.ID
                    select p2;

                    if (已評數.Count() < 訂單數.Count()) a.可評 = true;

                    flowLayoutPanel3.Controls.Add(a);
                }
                else if (s == 3) { flowLayoutPanel4.Controls.Add(a); }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SelectShopEntities db = new SelectShopEntities();
            修改基本資料 a = new 修改基本資料();
            a.會員名稱 = label2.Text;
            a.電子信箱 = label3.Text;
            a.手機 = label5.Text;
            a.地址 = label7.Text;
            a.生日 = label9.Text;
            a.更新 = 載入會員;
            a.ShowDialog();
        }
        private void 載入會員()
        {
            SelectShopEntities db = new SelectShopEntities();
            tMember room3 = db.tMembers.FirstOrDefault(x => x.MemberID == 首頁.登入會員);
            label2.Text = room3.MemberName;
            label3.Text = room3.E_mail;
            label5.Text = room3.Cellphone;
            label7.Text = room3.Address;
            label9.Text = Convert.ToDateTime(room3.Birthday).ToString("yyyy/MM/dd");
            if (room3.MemberPhoto != null)
            {
                MemoryStream ms = new MemoryStream(room3.MemberPhoto);
                pictureBox1.Image = Image.FromStream(ms);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] bt = ms.GetBuffer();


            SelectShopEntities db = new SelectShopEntities();
            tMember room3 = db.tMembers.FirstOrDefault(x => x.MemberID == 首頁.登入會員);
            room3.MemberPhoto = bt;
            db.SaveChanges();
            MessageBox.Show("上傳照片成功");
        }

        private void 會員資料_Load(object sender, EventArgs e)
        {
            全部訂單();
        }
        private void 重整()
        {
            int index = tabControl1.SelectedIndex;
            if (index == 0) 全部訂單();
            else { 訂單分類(index); }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            重整();
        }
    }
}

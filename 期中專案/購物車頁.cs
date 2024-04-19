using Package2;
using SelectShop;
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
using 期中專案.付帳;

namespace 期中專案
{
    public partial class 購物車頁 : Form
    {
        static public List<商品資訊格式> 加入購物車商品 = new List<商品資訊格式>();
        static public List<商品資訊格式> 加入包裝 = new List<商品資訊格式>();     
        public 首頁D 是否結帳;
        static public int orderid = 0;
        public 購物車頁()
        {
            InitializeComponent();
            載入();
            載入包裝();
            更新總價();
        }
        private void 載入()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (商品資訊格式 p in 加入購物車商品)
            {
                SelectShopEntities db = new SelectShopEntities();
                tProduct TP = db.tProducts.FirstOrDefault(x => x.ProductID == p.商品編號);
                購物車預覽 a = new 購物車預覽();
                a.編號 = p.商品編號;
                a.數量 = p.加入購物車數量;
                a.選取 = p.勾選;
                a.標題 = TP.ProductName;
                a.價格 = (int)TP.UnitPrice;
                if (TP.ProductPhoto != null)
                {
                    MemoryStream ms = new MemoryStream(TP.ProductPhoto);
                    a.商品圖片 = Image.FromStream(ms);
                }
                a.庫存 = Convert.ToInt32(TP.Stocks);
                a.更新 = 載入;
                a.加減 = 更新總價;
                flowLayoutPanel1.Controls.Add(a);
                更新總價();
            }
        }
        private void 載入包裝()
        {
            foreach (商品資訊格式 p in 加入包裝)
            {
                SelectShopEntities db = new SelectShopEntities();
                tAllPackage TP = db.tAllPackages.FirstOrDefault(x => x.PackageID == p.包裝編號);
                購物車包裝 a = new 購物車包裝();
                a.包裝ID = p.包裝編號;
                a.標題 = TP.PackName;
                a.價格 = (int)TP.Price;
                a.商品圖片 = new Bitmap(Application.StartupPath + "\\packageImages\\" + TP.Picture);
                a.數量 = p.加入購物車數量;
                a.選取 = p.勾選;
                a.加減 = 更新總價;
                flowLayoutPanel1.Controls.Add(a);
            }
        }
        private void 商品勾()
        {
            foreach (商品資訊格式 p in 加入購物車商品)
            {
                p.勾選 = true;
            }
        }
        private void 商品不勾()
        {
            foreach (商品資訊格式 p in 加入購物車商品)
            {
                p.勾選 = false;
            }
        }
        private void 包裝不勾()
        {
            foreach (商品資訊格式 p in 加入包裝)
            {
                p.勾選 = false;
            }
        }
        private void 包裝勾()
        {
            foreach (商品資訊格式 p in 加入包裝)
            {
                p.勾選 = true;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (首頁.登入會員 == 0) { new FrmLogin().ShowDialog(); }
            else if (加入購物車商品.Count < 1)
            {
                if (加入包裝.FirstOrDefault(x => x.勾選 == true) != null) MessageBox.Show("不能單買包裝");
                else MessageBox.Show("購物車沒有任何商品");
            }
            else if (加入購物車商品.FirstOrDefault(x => x.勾選 == true) == null) 
            {
                if (加入包裝.FirstOrDefault(x => x.勾選 == true) != null) MessageBox.Show("不能單買包裝");
                else MessageBox.Show("未選取商品");
            }
            else { 結帳(); }
        }

        private void 結帳()
        {
            SelectShopEntities db = new SelectShopEntities();
            tOrder o = new tOrder();
            o.OrderDate = DateTime.Now;
            o.MemberID = 首頁.登入會員;
            o.StatusID = 1;
            db.tOrders.Add(o);
            db.SaveChanges();
            var v = db.tOrders.OrderByDescending(x => x.OrderID);
            o.OrderID = v.First().OrderID;

            var v2 = 加入購物車商品.Where(x=>x.勾選 == true);
            foreach(var q  in v2)
            {
                tPurchase a = new tPurchase();
                a.OrderID = o.OrderID;
                a.ProductID = q.商品編號;
                a.Qty = q.加入購物車數量;
                db.tPurchases.Add(a);
            }
            ////////////////
            var c = 加入包裝.Where(x => x.勾選 == true);
            foreach (var x in c)
            {
                tPackageWayDetail a = new tPackageWayDetail();
                a.PackQty = x.加入購物車數量;
                a.OrderID = o.OrderID;
                a.PackageID = x.包裝編號;
                db.tPackageWayDetails.Add(a);
            }
            加入購物車商品.RemoveAll(x => x.勾選 == true);
            加入包裝.RemoveAll(x => x.勾選 == true);
            ///////////////////

            db.SaveChanges();

            ////////////////////////////////
            orderid = o.OrderID;
            FrmPayWay f = new FrmPayWay();
            f.ShowDialog();
            ////////////////////////////////
            if (orderid == 0)
            {
                var p = db.tPurchases.Where(x => x.OrderID == o.OrderID);
                o.OrderDate = DateTime.Now;
                o.StatusID = 2;
                foreach (var item in p)
                {
                    int g = (int)item.ProductID;
                    tProduct 庫存 = db.tProducts.FirstOrDefault(x => x.ProductID == g);
                    庫存.Stocks -= item.Qty;
                }
                db.SaveChanges();
                MessageBox.Show("謝謝光臨");
            }
            else MessageBox.Show("已取消結帳");          
            載入();
            是否結帳();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            加入購物車商品.RemoveAll(x => x.勾選 == true);
            加入包裝.RemoveAll(x => x.勾選 == true);
            載入();
            載入包裝();
            更新總價();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            商品勾();
            載入();
            包裝勾();
            載入包裝();
            更新總價();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            商品不勾();
            載入();
            包裝不勾();
            載入包裝();
            更新總價();
        }
        void 更新總價()
        {
            var a1 = 加入購物車商品.Where(x => x.勾選 == true).Sum(x => x.商品價格 * x.加入購物車數量);
            var a = 加入購物車商品.Where(x => x.勾選 == true);
            int a2 = 0;
            foreach (var item in a)
            {
                a2 += Convert.ToInt32(item.商品價格* 0.8)* item.加入購物車數量;
            }
            var b = 加入包裝.Where(x => x.勾選 == true).Sum(x => x.商品價格 * x.加入購物車數量);
            label2.Text = (a1 + b).ToString();
            label3.Text = a2 + b + "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmSelectTheme packageTheme = new FrmSelectTheme();
            packageTheme.ShowDialog();
            載入();
            載入包裝();
            更新總價();
        }
    }
}

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
    public partial class 訂單詳細 : Form
    {
        public int 訂單編號 = 0;
        int 狀態 = 0;
        public 訂單詳細()
        {
            InitializeComponent();
        }
        private void 訂單詳細_Load(object sender, EventArgs e)
        {
            取得order();
            載入訂單();
        }

        private void 載入訂單()
        {
            SelectShopEntities db = new SelectShopEntities();
            flowLayoutPanel1.Controls.Clear();
            var v =
             from p in db.tPurchases
             join pro in db.tProducts
             on p.ProductID equals pro.ProductID
             where p.OrderID == 訂單編號
             select new
             {
                 ID = pro.ProductID,
                 puid = p.PurchaseID,
                 商品名 = pro.ProductName,
                 圖片 = pro.ProductPhoto,
                 價錢 = pro.UnitPrice,
                 數量 = p.Qty
             };
            foreach (var item in v)
            {
                訂單詳細內容 a = new 訂單詳細內容();
                if (label6.Text == "已完成")
                {
                    var r = db.tReviews.FirstOrDefault(t => t.PurchaseID == item.puid && t.MemberID == 首頁.登入會員);
                    if (r == null) { a.可評 = true; }
                }
                if (item.圖片 != null)
                {
                    MemoryStream ms = new MemoryStream(item.圖片);
                    a.商品圖片 = Image.FromStream(ms);
                }
                a.標題 = item.商品名;
                a.數量 = Convert.ToInt32(item.數量);
                a.價格 = Convert.ToInt32(item.價錢);
                a.狀態 = 狀態;
                a.編號 = item.ID;
                a.oid = 訂單編號;
                a.重整 = 載入訂單;
                a.puid = item.puid;
                flowLayoutPanel1.Controls.Add(a);
            }


            var v3 =
         from p in db.tPackageWayDetails
         join tall in db.tAllPackages
         on p.PackageID equals tall.PackageID
         where p.OrderID == 訂單編號
         select new
         {
             ID = p.PackageID,
             商品名 = tall.PackName,
             圖片 = tall.Picture,
             價錢 = tall.Price,
             數量 = p.PackQty,
         };
            foreach (var c in v3)
            {
                包裝紀錄 a2 = new 包裝紀錄();
                a2.商品圖片 = new Bitmap(Application.StartupPath + "\\packageImages\\" + c.圖片);
                a2.價格 = (int)c.價錢;
                a2.標題 = c.商品名;
                a2.數量 = (int)c.數量;
                flowLayoutPanel1.Controls.Add(a2);
            }
        }

        private void 取得order()
        {
            SelectShopEntities db = new SelectShopEntities();
            var v =
             from o in db.tOrders
             join p in db.tPurchases
             on o.OrderID equals p.OrderID
             join pro in db.tProducts
             on p.ProductID equals pro.ProductID
             where p.OrderID == 訂單編號
             group new { o, pro, p } by new
             {
                 o.OrderDate,
                 o.StatusID,
             }
             into A
             select new
             {
                 狀態 = A.Key.StatusID,
                 時間 = A.Key.OrderDate,
                 總量 = A.Sum(x => x.p.Qty),
                 總價 = A.Sum(x => x.pro.UnitPrice * x.p.Qty),
             };
            foreach (var item in v)
            {
                if (item.總價 == null) { label4.Text = "99"; }
                else { label4.Text = (int)item.總價 + ""; }
                label5.Text = item.總量.ToString();
                label7.Text = Convert.ToDateTime(item.時間).ToString("yyyy/MM/dd  hh:mm");
                狀態 = (int)item.狀態;
                if (item.狀態 == 1) label6.Text = "未結帳";
                if (item.狀態 == 2) label6.Text = "已完成";
                if (item.狀態 == 3) label6.Text = "不成立";
            }
            var v3 =
                 from pw in db.tPackageWayDetails
                 join p in db.tAllPackages
                 on pw.PackageID equals p.PackageID
                 where pw.OrderID == 訂單編號
                 group new { pw, p } by new { pw.OrderID }
                 into B
                 select new { oid = B.Key.OrderID, 總數 = B.Sum(x => x.pw.PackQty), 總價 = B.Sum(x => x.pw.PackQty * x.p.Price) };
           
                var v4 = v3.FirstOrDefault();
                if (v4 != null)
                {
                    label5.Text = Convert.ToInt32(label5.Text) + (int)v4.總數 + "";
            label4.Text = Convert.ToInt32(Convert.ToInt32(label4.Text) * 0.8) + (int)v4.總價 + "";
        }
        }
    }
}

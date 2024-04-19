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
    public partial class 消費紀錄 : Form
    {
        public 消費紀錄()
        {
            InitializeComponent();
            SelectShopEntities db = new SelectShopEntities();
            var v =
                from o in db.tOrder
                join p in db.tPurchase
                on o.OrderID equals p.OrderID
                join pro in db.tProduct
                on p.ProductID equals pro.ProductID
                where o.OrderID == 首頁.登入會員
                group new { o, pro } by new { o.OrderID, pro.ProductPhoto, o.OrderDate, o.Status }
                into A
                select new
                {
                    A.Key.OrderID,
                    時間 = A.Key.OrderDate,
                    狀態 = A.Key.Status,
                    照片 = A.Key.ProductPhoto,
                    數量 = A.Count(),
                    總價 = A.Sum(x => x.pro.UnitPrice)
                };
            dataGridView1.DataSource = v.ToList();   
            //select o
            //List<int> ids = new List<int>();
            //foreach (tOrder p in v)
            //{ ids.Add(p.OrderID); }


        }
    }
}

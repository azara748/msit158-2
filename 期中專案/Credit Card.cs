using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 期中專案;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 期中專案.付帳
{
    public delegate void DMemberConfirm(Credit_Card p);

    public partial class Credit_Card : Form
    {
        public event DMemberConfirm memberConfirm;
        private DialogResult _isOk;
        private tOrder _order;
        public tOrder order { get { return _order; } }
        private tMember _member;
        public tMember member { get { return _member; } }
        private tStatu _state;
        public tStatu state { get { return _state; } }

        public DialogResult isOk { get { return _isOk; } }

        public Credit_Card()
        {
            InitializeComponent();
        }

        private void Credit_Card_Load(object sender, EventArgs e)
        {
            //1.包裝+2.活動*
            string str = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "!注意!活動優惠：總價X";
            double activity2 = 0.8;
            int activity = 8;
            int unitprice = 0;
            int qty = 0;
            int packageprice = 0;
            int total = 0;
            int totalpp = 0;
            int points = 0;
            int moneys = 0;
            int stateid = 0;
            this.label1.Text =首頁.登入會員+"";

            SelectShopEntities db = new SelectShopEntities();
            var orders = from r in db.tPurchases
                         where r.OrderID == 購物車頁.orderid
                         select new
                         {
                             R = r.tOrder,
                             P = r.tOrder.tMember,
                             K = r.tOrder.tStatu,
                             L = r.tProduct,
                             M = r
                         };
            foreach (var x in orders)
            {
                unitprice = (int)x.L.UnitPrice;
                qty = (int)x.M.Qty;
                total += unitprice * qty;
                totalpp = total + packageprice;
                total = totalpp;
                str = x.L.ProductName + "$" + x.L.UnitPrice + "X";
                str3 = x.M.Qty + ",";
                str4 += str + str3;
                if (x.P.Points == null) points = 0;
                else points = (int)x.P.Points;
                if (x.P.Wallet == null) moneys = 0;
                else moneys = (int)x.P.Wallet;
                str2 = x.K.StatusName;
                stateid = (int)x.R.StatusID;
            }
            total = total * activity / 10;
            str4 += str5 + activity2;
            fbTotalPrice.fieldValue = total.ToString();
            fbPoint.fieldValue = (total / 10).ToString();
            fbUsePoint.fieldValue = (total / 10 + 10).ToString();
            fbName.fieldValue = str4;
            fbAllPoint.fieldValue = points.ToString();
            fbExpectedPoint.fieldValue = ((total / 10) + points - (total / 10 + 10)).ToString();
            fbPrice.fieldValue = (total - (total / 10 + 10)).ToString();
            fbDeposit.fieldValue = (moneys - (total - (total / 10 + 10))).ToString();
            fbState.fieldValue = str2;
            fbStateId.fieldValue = stateid.ToString();            
            //=====================新增資料語法


        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            int j = 0;
            int m = 0;
            int n = 0;
            try
            {
                if (this.memberConfirm != null)
                    this.memberConfirm(this);
                _isOk = DialogResult.OK;

                SelectShopEntities db = new SelectShopEntities();
                var orders = from r in db.tPurchases
                             where r.OrderID == 購物車頁.orderid
                             select new
                             {
                                 R = r.tOrder,
                                 P = r.tOrder.tMember,
                                 K = r.tOrder.tStatu,
                                 L = r.tProduct,
                                 M = r
                             };

                bool aa = int.TryParse(fbExpectedPoint.fieldValue, out i);
                bool bb = int.TryParse(fbDeposit.fieldValue, out j);
                bool cc = int.TryParse(fbStateId.fieldValue, out m);
                foreach (var x in orders)
                {
                    if (!aa && bb && cc) return;
                    x.P.Points = i;
                    x.P.Wallet = j;
                    if (m >= 2)
                    { MessageBox.Show("結帳失敗");this.Close(); return;} 
                    x.R.StatusID = m + 1;
                }
                

                db.SaveChanges();
                MessageBox.Show("結帳成功");//結帳成功後訂單編號歸0
                購物車頁.orderid = 0;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _isOk = DialogResult.Cancel;
            this.Close();
        }
    }
}

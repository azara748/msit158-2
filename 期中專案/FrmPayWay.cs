using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 期中專案.付帳
{
    public partial class FrmPayWay : Form
    {
        public FrmPayWay()
        {
            InitializeComponent();

            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;

            SelectShopEntities db = new SelectShopEntities();
            var pays = from r in db.tPayTypes
                       select r;

            flowLayoutPanel1.Controls.Clear();
            foreach (var r in pays) 
            {
                //bool isOrdered = false;
                //string s = r.fPayWay.ToString();
                PayBox pb = new PayBox();
                pb.payway = r;
                pb.orderConfirm += this.confirm;//1.新增一個事件：先處理 confirm
                //2.事件 => delegate；3.DConfirm(RoomBox p);4. 宣告一個事件 => public event DConfirm orderConfirm

                this.flowLayoutPanel1.Controls.Add(pb);                                
            }            
        }

        private void confirm(PayBox p)
        {            
            //queryAll();            
            if (p.payway.PayTypeID != 1)
                return;
            //MessageBox.Show(p.payway.fPayID.ToString());
            //MessageBox.Show(p.payway.fPayWay);
            Credit_Card f = new Credit_Card();
            //f.MdiParent = this; //this 是 FrmC_Second
            //.WindowState = FormWindowState.Maximized; //最大化視窗
            f.ShowDialog();

            tOrder x = f.order;
            //db.tOrder2.Add(x);


            f.memberConfirm += this.confirm2;
            if(購物車頁.orderid==0)this.Close();//結帳成功關閉表單
        }

        private void confirm2(Credit_Card p)
        {            
            //MessageBox.Show("已結帳");
        }

        private static void queryAll()
        {
            SelectShopEntities db = new SelectShopEntities();
            var pays = from r in db.tPayTypes
                       select r;
        }
    }
}

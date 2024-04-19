using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 期中專案;

namespace 期中專案.付帳
{
    public delegate void DConfirm(PayBox p);

    public partial class PayBox : UserControl
    {
        public event DConfirm orderConfirm;

        private tPayType _payway;

        public tPayType payway
        {
            get { return _payway; }
            set
            {
                _payway = value;
                lblName.Text = _payway.PayTypeName;

                if (!string.IsNullOrEmpty(_payway.PayTypeImagePath)) 
                {
                    string path = Application.StartupPath + "\\payImages";
                    pictureBox1.Image = new Bitmap(path + "\\" + _payway.PayTypeImagePath);
                }
            }
        }


        public PayBox()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.orderConfirm != null)
                this.orderConfirm(this);            
        }
    }
}

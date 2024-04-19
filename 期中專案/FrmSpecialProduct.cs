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
using static 期中專案.FrmActive;
using static 期中專案.FrmSpecialProduct;

namespace 期中專案
{
    public partial class FrmSpecialProduct : Form
    {

        public delegate void findProduct(string y);
        public findProduct GOfindProduct;
        SelectShopEntities db = new SelectShopEntities();
        private List<tProduct> productList;
        private int _position = 0;


        public FrmSpecialProduct()
        {
            InitializeComponent();
            button1.Visible = false;
            button2.Visible = false;
        }




        private void FrmSpecialProduct_Load(object sender, EventArgs e)
        {
            productList = db.tProducts.OrderByDescending(x => x.Stocks).Take(5).ToList();
            ShowSpecialPrice();
        }


        private void ShowSpecialPrice()
        {

                var product = productList[_position];
                using (MemoryStream ms = new MemoryStream(product.ProductPhoto))
                {
                    Image image = Image.FromStream(ms);
                    pictureBox1.Image = image;
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                label2.Text = product.ProductName;

                label3.Text = product.Description;
                string c = productList.Count.ToString();
                 label4.Text = _position + 1 + "/" + c;
                if (productList.Count > 1 && _position != productList.Count - 1)
                { button2.Visible = true; }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _position--;
            if (_position == 0)
            { button1.Visible = false; }
            ShowSpecialPrice();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            _position++;
            if (_position == productList.Count - 1)
            {
                button2.Visible = false;
            }
            ShowSpecialPrice();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_position >= 0 && _position < productList.Count)
            {
                var topfive = productList[_position];
                string productName = topfive.ProductName;
                GOfindProduct?.Invoke(productName);
            }
            this.Close();




        }
    }
}

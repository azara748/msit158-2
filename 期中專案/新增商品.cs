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

    public partial class 新增商品 : Form
    {
        public 首頁D dd;
        public 新增商品()
        {
            InitializeComponent();
            textBox7.Text = DateTime.Now.ToString("yyyy/MM/dd");
            textBox7.KeyPress += TextBox7_KeyPress;
            textBox8.KeyPress += TextBox8_KeyPress;
            textBox6.KeyPress += TextBox6_KeyPress;
            textBox5.KeyPress += TextBox5_KeyPress;
            textBox4.KeyPress += TextBox4_KeyPress;
            textBox3.KeyPress += TextBox3_KeyPress;
        }
        public void 限制數字(KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8)
                e.Handled = true;
        }
        public void 限制時間格式(KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && e.KeyChar != 45 && e.KeyChar != 47)
                e.Handled = true;
        }
        private void TextBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            限制時間格式(e);
        }
    
        private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            限制數字(e);
        }      
        private void TextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            限制數字(e);
        }

        private void TextBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            限制數字(e);
        }

        private void TextBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            限制數字(e);
        }

        private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            限制數字(e);
        }

        public string 商品名;
        public string 商品價格;
        public Image 商品圖片;
        private tProduct _商品資料輸入;
        public tProduct 商品資料輸入
        {
            get
            {
                if (_商品資料輸入 == null) { _商品資料輸入 = new tProduct(); }
                _商品資料輸入.ProductName = textBox1.Text;
                _商品資料輸入.UnitPrice = Convert.ToInt32(textBox2.Text);
                _商品資料輸入.Stocks = Convert.ToInt32(textBox3.Text);
                _商品資料輸入.LaunchTime = textBox7.Text;
                _商品資料輸入.Description = textBox9.Text;
                //TODO 新增產品部分尚未啟用
                //_商品資料輸入.SupplierID = Convert.ToInt32(textBox6.Text);
                //_商品資料輸入.SubCategoryID = Convert.ToInt32(textBox5.Text);
                //_商品資料輸入.ActiveID = Convert.ToInt32(textBox4.Text);
                //_商品資料輸入.PackageID = Convert.ToInt32(textBox8.Text);     
                if (bt != null) _商品資料輸入.ProductPhoto = bt;
                return _商品資料輸入;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SelectShopEntities db = new SelectShopEntities();
            tProduct x = 商品資料輸入;
            db.tProducts.Add(x);
            db.SaveChanges();
            dd();
            MessageBox.Show("加入「" + x.ProductName + "」成功!");
        }

        byte[] bt;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            bt = ms.GetBuffer();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            限制數字(e);
        }
    }
}

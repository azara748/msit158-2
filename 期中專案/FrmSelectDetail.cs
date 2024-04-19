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
using 期中專案;

namespace Package2
{
    public partial class FrmSelectDetail : Form
    {
        public FrmSelectDetail()
        {
            InitializeComponent();         
        }

        private decimal price = 0;

        public void setSelectedItemInfo(string Itext, string ThemeText)
        {
            // pictureBox1.Image = ;
            label3.Text = Itext;
            label2.Text = ThemeText;
            SelectShopEntities DB = new SelectShopEntities();
            if (ThemeText == "Boxes")
            {
                var bigImage = (from bi in DB.Boxes
                                where bi.BoxType == Itext
                                select bi).FirstOrDefault();

                if (bigImage != null)
                {
                    string path = Application.StartupPath + "\\packageImages";
                    // MessageBox.Show(path);
                    pictureBox1.Image = new Bitmap(path + "\\" + bigImage.Picture);


                    price = (decimal)bigImage.Price;
                    string formattedPrice = price.ToString("F0");
                    this.label4.Text = "單價: NT." + formattedPrice;
                }


                var color = from b in DB.Boxes
                            join ma in DB.packageMaterials on b.MaterialID equals ma.MaterialID
                            join co in DB.MaterialColors on ma.ColorID equals co.ColorID
                            where b.BoxType == Itext
                            select new
                            {
                                //BoxID = b.BoxID,
                                co.ColorName
                            };

                var colorResult = color.ToList();
                //MessageBox.Show(colorResult.ToString());
                this.comboBox1.Items.Clear();
                foreach (var item in colorResult)
                {
                    comboBox1.Items.Add(item);
                }

            }
            else if (ThemeText == "Bags")
            {
                var bigImage = (from bi in DB.Bags
                                where bi.BagType == Itext
                                select bi).FirstOrDefault();

                if (bigImage != null)
                {
                    string path = Application.StartupPath + "\\packageImages";
                    pictureBox1.Image = new Bitmap(path + "\\" + bigImage.Picture);

                    price = (decimal)bigImage.Price;
                    string formattedPrice = price.ToString("F0");
                    this.label4.Text = "單價: NT." + formattedPrice;

                }

                var color = from b in DB.Bags
                            join ma in DB.packageMaterials on b.MaterialID equals ma.MaterialID
                            join co in DB.MaterialColors on ma.ColorID equals co.ColorID
                            where b.BagType == Itext
                            select new
                            {
                                //BoxID = b.BoxID,
                                co.ColorName
                            };

                var colorResult = color.ToList();
                //MessageBox.Show(colorResult.ToString());
                this.comboBox1.Items.Clear();
                foreach (var item in colorResult)
                {
                    comboBox1.Items.Add(item);
                }
            }
            else if (ThemeText == "Cards")
            {
                var bigImage = (from bi in DB.Cards
                                where bi.CardType == Itext
                                select bi).FirstOrDefault();

                if (bigImage != null)
                {
                    string path = Application.StartupPath + "\\packageImages";
                    pictureBox1.Image = new Bitmap(path + "\\" + bigImage.Picture);

                    price = (decimal)bigImage.Price;
                    string formattedPrice = price.ToString("F0");
                    this.label4.Text = "單價: NT." + formattedPrice;

                }

                this.comboBox1.Items.Clear();
                this.comboBox1.Items.Add("卡片不用選擇顏色");
            }

            comboBox1.SelectedIndex = 0;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value < 2) numericUpDown1.Value=1;
            if (comboBox1.SelectedIndex == -1) { MessageBox.Show("請選擇顏色"); }
            else
            {

                string totalPrice = (price * this.numericUpDown1.Value).ToString("F0");
                this.label5.Text = "包裝總價: " + totalPrice;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectShopEntities db = new SelectShopEntities();
            tAllPackage tall = db.tAllPackages.FirstOrDefault(x => x.PackName == label3.Text);       
            if (購物車頁.加入包裝.Exists(t => t.包裝編號 == tall.PackageID))
            {
                商品資訊格式 b = 購物車頁.加入包裝.FirstOrDefault(t => t.包裝編號 == tall.PackageID);
                b.加入購物車數量 += (int)numericUpDown1.Value;
            }
            else
            {
                商品資訊格式 a = new 商品資訊格式();
                a.加入購物車數量 = (int)numericUpDown1.Value;
                a.包裝編號 = tall.PackageID;
                a.商品價格 = (int)tall.Price;
                購物車頁.加入包裝.Add(a);
            }
            MessageBox.Show("「" + label3.Text + "」數量+" + Convert.ToInt32(numericUpDown1.Text));
        }

        private void FrmSelectDetail_Load(object sender, EventArgs e)
        {
            string totalPrice = (price * this.numericUpDown1.Value).ToString("F0");
            this.label5.Text = "包裝總價: " + totalPrice;
            this.label4.Text = "單價: NT." + (int)price;
        }
    }
}

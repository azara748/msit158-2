using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 期中專案
{
    public partial class 商品評價 : UserControl
    {
        public string 會員ID { get { return label1.Text; } set { label1.Text = value; } }
        public int 評價;
        public string 時間 { get { return label5.Text; } set { label5.Text = value; } }
        public string 評論 { get { return label6.Text; } set { label6.Text = value; } }


        public Image 商品圖片 { get { return pictureBox1.Image; } set { pictureBox1.Image = value; } }
 
        public int 編號;
        public 商品評價()
        {
            InitializeComponent();            
        }

        private void 商品評價_Load(object sender, EventArgs e)
        {
            label4.Text = "";
            for (int i = 0; i < 評價; i++) { label4.Text += "★"; }
            int r = new Random().Next(5, 11);
            //if (label1.Text.Length > 0) 
            label1.Text = label1.Text.Substring(label1.Text.Length - label1.Text.Length, 1);
            for (int i = 0; i < r; i++) { label1.Text += "*"; }
            if (評論 == "") {this.AutoSize=false; this.Height = 98; }
            //label6.Text += "\r\n___________________________________________________________________________________________________\r\n";
        }
    }
}

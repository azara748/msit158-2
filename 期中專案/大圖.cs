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
    public partial class 大圖 : Form
    {
        public Image 商品圖片 { get { return pictureBox1.Image; } set { pictureBox1.Image = value; } }
        public 大圖()
        {
            InitializeComponent();
        }
    }
}

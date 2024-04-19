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

namespace Package2.View
{
    public delegate void DshowDetails(imageText p);

    public partial class imageText : UserControl
    {

        public event DshowDetails show;
        private GiftPackageStyle _GiftStyle;

        public imageText()
        {
            InitializeComponent();
        }

        //public string TextName
        //{
        //    get { return label1.Text; }
        //    set { label1.Text = value; }
        //}

        public GiftPackageStyle GiftStyle
        {
            get { return _GiftStyle; }

            set
            {
                _GiftStyle = value;
                label1.Text = _GiftStyle.StyleName;
                if (!string.IsNullOrEmpty(_GiftStyle.Picture))
                {
                    string path = Application.StartupPath + "\\packageImages";
                    pictureBox1.Image = new Bitmap(path + "\\" + _GiftStyle.Picture);
                }
            }
        }

        public string LabelText
        {
            get { return label1.Text; }
        }

        public string GetLabelText()
        {
            return label1.Text;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(this.show != null) { 
                this.show(this);
            }
        }
    }
}

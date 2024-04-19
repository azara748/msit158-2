using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 期中專案
{
    public partial class FrmActive : Form
    {
        public delegate void findActive(string x);
        public findActive GOfindActive;
        SelectShopEntities db = new SelectShopEntities();

        private int _position = 0;
        private List<tActive> _activeList;

        public FrmActive()
        {
            InitializeComponent();
            button1.Visible = false;
            button2.Visible = false;

        }



        private void FrmActive_Load(object sender, EventArgs e)
        {

            _activeList = db.tActives.Where(a => a.ActiveID == 3).ToList();
            ShowCurrentActive();


        }

        private void ShowCurrentActive()
        {
                var active = _activeList[_position];
                using (MemoryStream ms = new MemoryStream(active.ActiveImage))
                {
                    Image image = Image.FromStream(ms);
                    pictureBox1.Image = image;
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                label1.Text = active.Description;

                if (_activeList.Count >1 &&  _position != _activeList.Count-1)
                 {button2.Visible = true; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _position--;
            if (_position == 0)
            { button1.Visible = false; }

            ShowCurrentActive();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            _position++;
            if (_position == _activeList.Count - 1)
            {
                button2.Visible = false;
            }

            ShowCurrentActive();
        }

    }
}










   


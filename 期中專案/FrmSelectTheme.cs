using Package2.View;
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
    public partial class FrmSelectTheme : Form
    {
        public FrmSelectTheme()
        {
            InitializeComponent();
            themePackageLoad();
        }
        string ThemeText=null;
        private void themePackageLoad()
        {
            SelectShopEntities DB = new SelectShopEntities();
            var themePackage = from tp in DB.GiftPackageStyles
                               select tp;

            foreach (var tp in themePackage)
            {
                //bool isSelected= false;
                if (tp != null)
                {
                    imageText it = new imageText();
                    it.GiftStyle = tp;
                    flowLayoutPanel1.Controls.Add(it);
                    it.show += this.show;
                    //isSelected = true;
                }
                //if (!isSelected)
                //{

                //}
            }
        }
        //ImageList imgs = new ImageList();
        
        private void show(imageText p)
        {
            ThemeText = p.LabelText;
          //  MessageBox.Show(ThemeText);
            // MessageBox.Show(p.TabIndex.ToString());
            this.listView1.Items.Clear();
            SelectShopEntities DB = new SelectShopEntities();

            if (p.TabIndex == 0)
            {
                var selectDetails = from d in DB.Boxes
                                    select d;

                ImageList imgs = new ImageList();
                imgs.ImageSize = new Size(50, 50);
                List <string> imgsName = new List<string>();

                foreach (var i in selectDetails)
                {
                    if (i.Picture != null)
                    {
                        
                        string path = Path.Combine(Application.StartupPath, "packageImages", i.Picture);
                        //MessageBox.Show(path);
                        Image DBimage = Image.FromFile(path);
                        imgs.Images.Add(DBimage);

                        imgsName.Add(i.BoxType.ToString());
                       
                        //this.listView1.Items.Add(i.ToString());
                    }
                }
                listView1.LargeImageList = imgs;
                for(int j = 0; j<imgs.Images.Count; j++)
                {
                    listView1.Items.Add(new ListViewItem { ImageIndex = j, Text = imgsName[j] });
                }
            } else if (p.TabIndex == 1)
            {
                var selectDetails = from d in DB.Bags
                                    select d;

                ImageList imgs = new ImageList();
                imgs.ImageSize = new Size(50, 50);
                List<string> imgsName = new List<string>();

                foreach (var i in selectDetails)
                {
                    if (i.Picture != null)
                    {

                        string path = Path.Combine(Application.StartupPath, "packageImages", i.Picture);
                        //MessageBox.Show(path);
                        Image DBimage = Image.FromFile(path);
                        imgs.Images.Add(DBimage);

                        imgsName.Add(i.BagType.ToString());

                        //this.listView1.Items.Add(i.ToString());
                    }
                }
                listView1.LargeImageList = imgs;
                for (int j = 0; j < imgs.Images.Count; j++)
                {
                    listView1.Items.Add(new ListViewItem { ImageIndex = j, Text = imgsName[j] });
                }
            }
            else if (p.TabIndex == 2)
            {
                var selectDetails = from d in DB.Cards
                                    select d;

                ImageList imgs = new ImageList();
                imgs.ImageSize = new Size(50, 50);
                List<string> imgsName = new List<string>();

                foreach (var i in selectDetails)
                {
                    if (i.Picture != null)
                    {

                        string path = Path.Combine(Application.StartupPath, "packageImages", i.Picture);
                        //MessageBox.Show(path);
                        Image DBimage = Image.FromFile(path);
                        imgs.Images.Add(DBimage);

                        imgsName.Add(i.CardType.ToString());

                        //this.listView1.Items.Add(i.ToString());
                    }
                }
                listView1.LargeImageList = imgs;
                for (int j = 0; j < imgs.Images.Count; j++)
                {
                    listView1.Items.Add(new ListViewItem { ImageIndex = j, Text = imgsName[j] });
                }
            }
            else { MessageBox.Show("查無此項，請重新選擇"); }
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count>0)
            {
                
                string selectedItemText = listView1.SelectedItems[0].Text;
                //Image selectedImageImage = listView1.LargeImageList.Images[listView1.SelectedItems[0].ImageIndex];

                FrmSelectDetail sDetail = new FrmSelectDetail();
                sDetail.Text = "Selected Package Item Information";

                sDetail.setSelectedItemInfo(selectedItemText, ThemeText);

                sDetail.ShowDialog();
            }
        }
    }
}

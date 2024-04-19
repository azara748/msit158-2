using SelectShop;
using SelectShop.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static 期中專案.FrmSpecialProduct;

namespace 期中專案
{

    public delegate void 首頁D();
     
    public partial class 首頁 : Form
    {
        SelectShopEntities db = new SelectShopEntities();
        首頁D 登入鍵;
        首頁D 註冊鍵;

        static public int 登入會員 = 0;
        public decimal _grandOpeningSales = 0.8M;
        public void 更新商品數() { 我的購物車ToolStripMenuItem.Text = "我的購物車(" + 購物車頁.加入購物車商品.Count.ToString() + ")"; }
        public int HowManyItems
        {
            get
            {
                string showHowMany = comboBox1.Text;
                string[] parts = showHowMany.Split(':');
                int parsedValue;
                if (int.TryParse(parts[1], out parsedValue))
                { return parsedValue; }
                return 0;
            }
            set
            {
                comboBox1.Text = "商品顯示數量:" + value.ToString();
            }
        }
        private string _searchText;
        public string SearchText
        {
            get
            {
                string s = searchBox.Text.ToString().Trim();
                return s;

            }
            set
            {
                _searchText = value;
            }
        }
        


        public 首頁()
        {
            InitializeComponent();
            更新會員資料();
            AddTreeView();
            ShowRandom();
            AddTreeView2();
        }




        private void AddTreeView2()
        {
            var sn = from c in db.tLabels
                     select new { sN = c.LabelName, sID = c.LabelID };
            foreach (var SupplierName in sn)
            {
                TreeNode SupplierNameNode = new TreeNode(SupplierName.sN.ToString());
                treeView2.Nodes.Add(SupplierNameNode);
                SupplierNameNode.Tag = SupplierName.sID;
            }
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            TreeNode clickedSNode = e.Node;

            int SupplierID = (int)clickedSNode.Tag;
            var sNode = from p in db.tProducts
                        where SupplierID == p.tLabel.LabelID
                        select p;

            QueryAndShow(sNode);
            searchBox.Text = clickedSNode.Text;
            searchBox.ForeColor = Color.Gray;
            label10.Text = sNode.Count().ToString();

        }


        private void ShowRandom()
        {

            Random random = new Random();
            int productCount = db.tProducts.Count();
            for (int i = 0; i < 50; i++)
            {
                int randomProductId = random.Next(1, productCount + 1); // 產品ID是從 1 開始的
                var randomProduct = from p in db.tProducts
                                    where p.ProductID == randomProductId
                                    select p;

                QueryAndShow(randomProduct);
            }
        }

        public void GofindActive (string x)
        {
            searchBox.Text = x;
            SearchText=x;
            button1.PerformClick();
        }

        public void GofindProduct(string y) //TODO
        {
            searchBox.Text = y;
            SearchText = y;
            button1.PerformClick();
        }

        public void 首頁_Load(object sender, EventArgs e)
        {     
                FrmActive fa = new FrmActive();
                fa.GOfindActive = new FrmActive.findActive(GofindActive);
                FrmSpecialProduct fs = new FrmSpecialProduct();
            fs.GOfindProduct = new FrmSpecialProduct.findProduct(GofindProduct);

            fa.StartPosition = FormStartPosition.CenterScreen;
            fs.StartPosition = FormStartPosition.CenterScreen;
            fa.ShowDialog();
            fs.ShowDialog();


            minBox.Text = "1";
            var hightestPrice = ((int?)(from r in db.tProducts
                                        select r.UnitPrice).Max());
            maxBox.Text = $"{hightestPrice}";
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(SearchText))
            {
                flowLayoutPanel1.Controls.Clear();
                searchBox.ForeColor = Color.Black;
                searchPrice();

            }
            else
            {
                flowLayoutPanel1.Controls.Clear();
                searchPrice();
            }
        }

        private void searchPrice()
        {
            int _min = int.Parse(minBox.Text);
            int _max = int.Parse(maxBox.Text);
            if (!string.IsNullOrEmpty(SearchText))
            {

                var query = from p in db.tProducts
                            where p.ProductName.ToUpper().Contains(SearchText.ToUpper()) || p.tLabel.LabelName.ToUpper().Contains(SearchText.ToUpper()) || p.tActive.ActiveName.Contains(SearchText)
                            || p.tSubCategory.SubCategoryCName.ToUpper().Contains(SearchText.ToUpper()) || p.tSubCategory.SubCategoryName.ToUpper().Contains(SearchText.ToUpper())
                            || p.tSubCategory.tCategory.CategoryName.ToUpper().Contains(SearchText.ToUpper()) || p.tSubCategory.tCategory.CategoryCName.ToUpper().Contains(SearchText.ToUpper())
                            || p.Description.ToUpper().Contains(SearchText.ToUpper()) || p.tActive.ActiveName.ToUpper().Contains(SearchText.ToUpper())
                            select p;
                if (_min < _max)
                {
                    query = query.Where(p => p.UnitPrice*_grandOpeningSales >= _min && p.UnitPrice * _grandOpeningSales < _max).OrderByDescending(p => p.UnitPrice);
                    QueryAndShow(query);
                }
                else if (_min > _max)
                {
                    int tempmin = _max;
                    int tempmax = _min;
                    _max = tempmax;
                    _min = tempmin;
                    query = query.Where(p => p.UnitPrice * _grandOpeningSales >= _min && p.UnitPrice * _grandOpeningSales < _max).OrderByDescending(p => p.UnitPrice);
                    QueryAndShow(query);
                }
                else
                {
                    query = query.Where(p => p.UnitPrice * _grandOpeningSales == _min || p.UnitPrice * _grandOpeningSales == _max).OrderByDescending(p => p.UnitPrice);
                    QueryAndShow(query);
                    string sameprice = _min.ToString();
                }

                int Countquery = (int)query.Count();
                if (Countquery == 0)
                {
                    MessageBox.Show("很抱歉沒有相關結果><" + "\r\n" + "為您推薦其他商品!!");
                    ShowRandom();
                }

                label10.Text = query.Count().ToString();
            }
            else 
            {
                var query = from p in db.tProducts
                            select p;
                if (_min < _max)
                {
                    query = query.Where(p => p.UnitPrice * _grandOpeningSales >= _min && p.UnitPrice * _grandOpeningSales < _max).OrderByDescending(p => p.UnitPrice);
                    QueryAndShow(query);
                }
                else if (_min > _max)
                {
                    int tempmin = _max;
                    int tempmax = _min;
                    _max = tempmax;
                    _min = tempmin;
                    query = query.Where(p => p.UnitPrice * _grandOpeningSales >= _min && p.UnitPrice * _grandOpeningSales < _max).OrderByDescending(p => p.UnitPrice);
                    QueryAndShow(query);
                }
                else
                {
                    query = query.Where(p => p.UnitPrice * _grandOpeningSales == _min || p.UnitPrice * _grandOpeningSales == _max).OrderByDescending(p => p.UnitPrice);
                    QueryAndShow(query);
                    string sameprice = _min.ToString();
                }
                label10.Text = query.Count().ToString();
            }
        }
        public void QueryAndShow(IQueryable<tProduct> query)
        {
            int count = 0;
            if (checkBoxHP.Checked)
            {
                query = query.OrderBy(p => p.UnitPrice);
                foreach (tProduct p in query)
                {
                    if (count >= HowManyItems)
                        break;
                    商品預覽 a = new 商品預覽();
                    a.編號 = p.ProductID;
                    a.標題 = p.ProductName;                  

                    if (checkBox1.Checked && p.Stocks == 0)
                    {
                        continue;
                    }
                    else
                    {
                        a.顯示庫存 = (int)p.Stocks;
                    }

                    if ((p.UnitPrice == null)) a.價格 = 77777;
                    else
                    {
                        a.價格 = (int)p.UnitPrice;
                        a.特價 = (int)p.UnitPrice;

                    }
                    if (p.ProductPhoto != null)
                    {
                        MemoryStream ms = new MemoryStream(p.ProductPhoto);
                        a.商品圖片 = Image.FromStream(ms);
                    }

                   

                    a.更新 = 更新商品數;
                    flowLayoutPanel1.Controls.Add(a);
                    count++;
                }

            }
            else
            {
                if (checkBoxHS.Checked)
                {
                    var query2 = (from p in query
                                  join s in db.tPurchases
                                  on p.ProductID equals s.ProductID
                                  group p by p into g
                                  orderby g.Count() descending
                                  select g.Key).ToList();

                    foreach (tProduct p in query2)
                    {
                        if (count >= HowManyItems)
                            break;
                        商品預覽 a = new 商品預覽();
                        a.編號 = p.ProductID;
                        a.標題 = p.ProductName;
                        if (checkBox1.Checked && p.Stocks == 0)
                        {
                            continue;
                        }
                        else
                        {
                            a.顯示庫存 = (int)p.Stocks;
                        }

                        if ((p.UnitPrice == null)) a.價格 = 77777;
                        else
                            {
                            a.價格 = (int)p.UnitPrice;
                            a.特價 = (int)p.UnitPrice;



                        }
                        if (p.ProductPhoto != null)
                        {
                            MemoryStream ms = new MemoryStream(p.ProductPhoto);
                            a.商品圖片 = Image.FromStream(ms);
                        }
                        a.更新 = 更新商品數;
                        flowLayoutPanel1.Controls.Add(a);
                        count++;
                    }


                }
                else
                {
                    foreach (tProduct p in query)
                    {
                        if (count >= HowManyItems)
                            break;
                        商品預覽 a = new 商品預覽();
                        a.編號 = p.ProductID;
                        a.標題 = p.ProductName;
                        if (checkBox1.Checked && p.Stocks == 0)
                        {
                            continue;
                        }
                        else
                        {
                            a.顯示庫存 = (int)p.Stocks;
                        }

                        if ((p.UnitPrice == null)) a.價格 = 77777;
                        else
                        {
                            a.價格 = (int)p.UnitPrice;
                            a.特價 = (int)p.UnitPrice;


                        }
                        if (p.ProductPhoto != null)
                        {
                            MemoryStream ms = new MemoryStream(p.ProductPhoto);
                            a.商品圖片 = Image.FromStream(ms);
                        }
                        a.更新 = 更新商品數;
                        flowLayoutPanel1.Controls.Add(a);
                        count++;

                    }

                }


            }
        }



        private void 載入()
        {
            var b = from r in db.tProducts
                    orderby r.ProductID descending
                    select r;
            //搜尋(b);
        }
        private void 搜尋(IQueryable<tProduct> b) 
        {
            // flowLayoutPanel1.Controls.Clear();

            foreach (tProduct p in b)
            {

                商品預覽 a = new 商品預覽();
                a.編號 = p.ProductID;
                a.標題 = p.ProductName;
                if ((p.Stocks == null)) a.庫存 = 0;
                else a.庫存 = (int)p.Stocks;
                //if ((p.UnitPrice == null)) a.價格 = 999999;
                //else a.價格 = (int)p.UnitPrice;
                if (p.ProductPhoto != null)
                {
                    MemoryStream ms = new MemoryStream(p.ProductPhoto);
                    a.商品圖片 = Image.FromStream(ms);
                }
                a.更新 = 更新商品數;
                flowLayoutPanel1.Controls.Add(a);
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            新增商品 a = new 新增商品();
            a.dd = 載入;
            a.ShowDialog();
        }




        private void 更新會員資料()
        {
            if (登入會員 == 0)
            {
                toolStripMenuItem1.Text = "登入";
                toolStripMenuItem2.Text = "註冊";
                toolStripMenuItem2.Image = new Bitmap(Application.StartupPath + "\\img\\logAdd.png");
                登入鍵 = 登入;
                註冊鍵 = 註冊;
            }
            else
            {
                SelectShopEntities db = new SelectShopEntities();
                tMember room3 = db.tMembers.FirstOrDefault(x => x.MemberID == 登入會員);
                toolStripMenuItem1.Text = "VVIP會員," + room3.MemberName + "您好";
                toolStripMenuItem2.Text = "登出";
                toolStripMenuItem2.Image = new Bitmap(Application.StartupPath + "\\img\\logOut.png");

                註冊鍵 = 登出;
                登入鍵 = 查看會員;
            }
        }
        private void 登入()
        {
            FrmLogin a = new FrmLogin();
            a.ShowDialog();
            更新會員資料();
        }
        private void 註冊()
        {
            FrmLogin a = new FrmLogin();
            a.直接註冊 = true;
            a.ShowDialog();
            更新會員資料();
        }
        private void 登出() { 登入會員 = 0; 更新會員資料(); }
        private void 查看會員()
        {
            會員資料 a = new 會員資料();
            a.ShowDialog();
            更新會員資料();
            更新商品數();
            載入();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            登入鍵();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            註冊鍵();
        }

        private void AddTreeView() 
        {

            var level1 = from c in db.tCategories
                         select new { cCN = c.CategoryCName, cID = c.CategoryID };
            foreach (var CategoryCName in level1)
            {
                TreeNode CategoryTreeNode = new TreeNode(CategoryCName.cCN.ToString());
                treeView1.Nodes.Add(CategoryTreeNode);
                var level2 = (from c in db.tProducts
                              where c.tSubCategory.tCategory.CategoryCName == CategoryCName.cCN
                              select new { sCN = c.tSubCategory.SubCategoryCName, sID = c.tSubCategory.SubCategoryID }).Distinct();
                CategoryTreeNode.Tag = CategoryCName.cID;

                foreach (var subCategory in level2)
                {
                    TreeNode SubCategoryTreeNode = new TreeNode(subCategory.sCN.ToString());
                    SubCategoryTreeNode.Tag = subCategory.sID;
                    CategoryTreeNode.Nodes.Add(SubCategoryTreeNode);
                }

            }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            TreeNode clickedNode = e.Node;
            if (clickedNode.Parent == null)
            {
                int categoryID = (int)clickedNode.Tag;
                var cnode = (from p in db.tProducts
                             where categoryID == p.tSubCategory.tCategory.CategoryID
                             select p);

                QueryAndShow(cnode);
                searchBox.Text = clickedNode.Text;
                searchBox.ForeColor = Color.Gray;
                label10.Text = cnode.Count().ToString();
            }
            else
            {
                int subCategoryID = (int)clickedNode.Tag;
                var subnode = (from p in db.tProducts
                               where p.SubCategoryID == subCategoryID
                               select p);
                QueryAndShow(subnode);
                searchBox.Text = clickedNode.Text;
                searchBox.ForeColor = Color.Gray;
                label10.Text = subnode.Count().ToString();
            }
        }
        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            searchBox.Text = "2024 Select Shop 開幕慶";
            searchBox.ForeColor = Color.Gray;
            button1_Click(sender, e);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            searchBox.ForeColor = Color.Black;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //商品顯示數量
        {
            button1_Click(sender, e);
        }



        private bool isFirstClick = true;
        private void textBox1_Leave(object sender, EventArgs e)
        {
            isFirstClick = true;
        }
        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (isFirstClick)
                {
                    searchBox.SelectAll();
                    isFirstClick = false;
                }
            }
        }
        private void checkBoxHP_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHP.Checked)
            {
                checkBoxHS.Checked = false;
            }
            button1_Click(sender, e);
        }
        private void checkBoxHS_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHS.Checked)
            {
                checkBoxHP.Checked = false;
            }
            button1_Click(sender, e);
        }
        private void minBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                minBox.Clear();
                MessageBox.Show("請輸入正整數謝謝~");
                e.Handled = true;

            }
        }
        private void maxBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                maxBox.Clear();
                MessageBox.Show("請輸入正整數謝謝~");
                e.Handled = true;

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            登入鍵();
        }

        private void 我的購物車ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            購物車頁 a = new 購物車頁();
            bool 結帳 = false;
            void 已結帳() { 結帳 = true; }
            a.是否結帳 = 已結帳;
            a.ShowDialog();
            if (結帳)
            { 更新會員資料(); 查看會員(); }
            else
            {
                更新會員資料();
                載入();
                更新商品數();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            註冊鍵();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (comboBox2.SelectedItem.ToString() == "依商品類別:")
            {
                treeView1.Visible = true;
                treeView2.Visible = false;
            }
            else if (comboBox2.SelectedItem.ToString() == "依供應商名稱:")
            {
                treeView1.Visible = false;
                treeView2.Visible = true;
            }

            //TODO依照其他分類
        }

        private void 活動資訊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmActive fa = new FrmActive();
            fa.StartPosition = FormStartPosition.CenterScreen;
            fa.GOfindActive += GofindActive;
            fa.Show();

        }

        private void 焦點商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSpecialProduct fs = new FrmSpecialProduct();
            fs.StartPosition = FormStartPosition.CenterScreen;
            fs.GOfindProduct += GofindProduct; //TODO
            fs.Show();
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Q)) { 新增商品 a = new 新增商品(); a.ShowDialog(); }
        }
    }
}


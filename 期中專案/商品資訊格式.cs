using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 期中專案
{
    public class 商品資訊格式
    {
        public int 商品編號;
        public int 包裝編號;
        public string 商品名稱;
        public int 商品價格;
        public Image 商品圖片;
        public int 商品庫存;
        public int 加入購物車數量 = 0;
        public bool 勾選=true;
    }
}

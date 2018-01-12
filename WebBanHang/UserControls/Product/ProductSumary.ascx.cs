using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUS;
using Entities;

namespace WebBanHang.UserControls
{
    public partial class ProductSumary : System.Web.UI.UserControl
    {
        string productid;
        public string ProductID
        {
            get
            {
                return productid;
            }
            set
            {
                productid = value;
                ProductEntity Product = ProductBus.Instance.GetProductById(productid);
                LoadProduct(Product);
            }
        }
        public ProductEntity Product;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Product == null)
                Product = ProductBus.Instance.GetProductById(ProductID);
            if (Product == null)
                return;
            LoadProduct(Product);
        }

        void LoadProduct(ProductEntity p)
        {
            ProductHeader.InnerText = p.ProductName;
            ProductHeader.HRef = "/detail.aspx?id=" + p.ID;
            imgproduct.Src = ResolveUrl(p.DisplayImage);
            hfinalprice.InnerText = p.FinalPrice.ToString();
            pfeature.InnerText = p.ShortDescription;
        }
    }
}
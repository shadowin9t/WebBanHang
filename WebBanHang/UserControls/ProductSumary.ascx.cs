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
        public ProductEntity Product;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Product == null)
                return;

                ProductHeader.InnerText = Product.ProductName;
                imgproduct.Src = ResolveUrl("~/images/products/" + Product.DisplayImage);
                hfinalprice.InnerText = Product.FinalPrice.ToString();
                pfeature.InnerText = Product.ShortDescription;

        }
    }
}
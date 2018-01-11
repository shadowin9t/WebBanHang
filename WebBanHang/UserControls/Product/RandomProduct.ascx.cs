using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BUS;
using Entities;
namespace WebBanHang.UserControls
{
    public partial class RandomProduct : System.Web.UI.UserControl
    {
        public int Number = 10;
        protected void Page_Load(object sender, EventArgs e)
        {
            var ls = ProductBus.Instance.GetRandomProducts(Number);
            foreach(var p in ls)
            {
                var div = new HtmlGenericControl("div");
                div.Attributes["class"] = "col-lg-4 col-md-6 mb-4";
                var child = Page.LoadControl("~/UserControls/Product/ProductSumary.ascx") as ProductSumary;
                child.Product = p;
                div.Controls.Add(child);
                randomproductcontainer.Controls.Add(div);
            }
        }
    }
}
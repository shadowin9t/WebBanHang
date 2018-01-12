using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Entities;
namespace WebBanHang.UserControls
{
    public partial class CategoryNavbar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                var ls = BUS.CategoryBus.Instance.GetCategories();
                foreach(ProductEntity.Category cate in ls)
                {
                    var li = new HtmlGenericControl("li");
                    var a = new HtmlAnchor();
                    a.HRef = "/product.aspx?cate=" + cate.ID;
                    a.InnerText = cate.Name;
                    a.Attributes["class"] = "nav-link";
                    li.Attributes["class"] = "nav-item";
                    li.Controls.Add(a);
                    ulnavbar.Controls.Add(li);
                }
            }
        }
    }
}
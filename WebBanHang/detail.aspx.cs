using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Entities;
using BUS;
namespace WebBanHang
{
    public partial class detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string querystring = Request.QueryString["id"];
            if(String.IsNullOrEmpty(querystring))
            {
                Response.Redirect("Default.aspx");
                return;
            }
            var p = ProductBus.Instance.GetProductById(querystring);
            if(p==null)
            {
                Response.Redirect("Default.aspx");
                return;
            }
            productheader.InnerText = p.ProductName;
            productprice.InnerText = p.FinalPrice.ToString("0") + "đ";
            string[] fields = p.ShortDescription.Split('\n');
            foreach(string s in fields)
            {
                var li = new HtmlGenericControl("li");
                li.Attributes["class"] = "list-group-item";
                li.InnerText = s;
                shortdescription.Controls.Add(li);
            }
            discription.InnerText = p.Discription;
            productimage.Src = p.DisplayImage;
        }

        protected void addtocart_ServerClick(object sender, EventArgs e)
        {

        }
    }
}
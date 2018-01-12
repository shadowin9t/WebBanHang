using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Entities;
using BUS;
namespace WebBanHang.UserControls
{
    public partial class PromotionSlider : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                var ls = PromotionBus.Instance.GetPromotions();
                int count = 0;
                foreach (PromotionEntity promotion in ls)
                {
                    var i = new HtmlGenericControl("li");
                    i.Attributes["data-target"] = "#myCarousel";
                    i.Attributes["data-slide-to"] = count.ToString();

                    var inner = new HtmlGenericControl("div");
                    var img = new HtmlImage();
                    img.Src = promotion.Image;
                    img.Alt = promotion.Title;
                    if(count==0)
                    {
                        inner.Attributes["class"] = "carousel-item active";
                        i.Attributes["class"] = "active";
                    }
                    else
                    {
                        inner.Attributes["class"] = "carousel-item";
                    }
                    inner.Controls.Add(img);
                    Inners.Controls.Add(inner);
                    Indicators.Controls.Add(i);
                    count++;
                }
            }
        }
    }
}
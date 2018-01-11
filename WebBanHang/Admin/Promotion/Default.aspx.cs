using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBanHang.Admin.Promotion
{
    public partial class PromotionList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                gridView.DataSource = BUS.PromotionBus.Instance.GetPromotions();
                gridView.DataBind();
            }
        }
    }
}
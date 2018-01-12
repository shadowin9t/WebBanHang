using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUS;
namespace WebBanHang
{
    public partial class product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string cate = Request.QueryString["cate"];
                if(String.IsNullOrEmpty(cate))
                {
                    Response.Redirect("Default.aspx");
                    return;
                }
                BindListView(cate);
            }
        }

        void BindListView(string cate)
        {
            listview.DataSource = ProductBus.Instance.GetProductsByCategory(cate);
            listview.DataBind();
        }

        protected void listview_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (listview.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.BindListView(Request.QueryString["cate"]);
        }
    }
}
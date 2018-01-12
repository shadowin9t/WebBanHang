using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using BUS;
using Entities;
namespace WebBanHang.UserControls
{
    public partial class UserPanelUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadControl();
        }

        public void LoadControl()
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                divLogin.Visible = false;
                divUserinfo.Visible = true;
                if (Context.User.IsInRole("admin"))
                {
                    var user = BUS.UserBus.Instance.GetUser(Context.User.Identity.Name);
                    if (user == null)
                    {
                        Response.Redirect("login.aspx");
                        return;
                    }
                    dropdownMenuButton.InnerText = user.Firstname;
                }
                else
                {
                    int cusid = -1;
                    int.TryParse(Context.User.Identity.Name, out cusid);
                    var cus = BUS.CustomerBus.Instance.GetCustomer(cusid);
                    if(cus==null)
                    {
                        Response.Redirect("login.aspx");
                        return;
                    }
                    dropdownMenuButton.InnerText = cus.FirstName;
                }                
            }
            else
            {
                divLogin.Visible = true;
                divUserinfo.Visible = false;
            }
        }

        protected void btnlogin_ServerClick(object sender, EventArgs e)
        {
            if (!AuthenticateHelper.Login(inputusername.Value, inputpwd.Value, false, Response))
            {
                Response.Redirect("~/login.aspx");
            }
            else
            {
                LoadControl();
            }
        }
    }
}
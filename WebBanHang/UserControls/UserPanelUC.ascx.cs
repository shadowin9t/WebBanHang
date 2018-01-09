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
                var user = BUS.UserBus.Instance.GetUser(Context.User.Identity.Name);
                dropdownMenuButton.InnerText = user.Firstname;
            }
            else
            {
                divLogin.Visible = true;
                divUserinfo.Visible = false;
            }
        }

        protected void btnlogin_ServerClick(object sender, EventArgs e)
        {
            UserEntity user = BUS.UserBus.Instance.GetUser(inputusername.Value, inputpwd.Value);
            if (user == null)
            {
                Response.Redirect("~/login.aspx");
            }
            else
            {
                string roles = BUS.UserBus.Instance.GetPermissionStr(user.Username);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, inputusername.Value, DateTime.Now, DateTime.Now.AddMinutes(60 * 24 * 10), false, roles);
                string hashString = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashString);
                if (ticket.IsPersistent)
                {
                    cookie.Expires = ticket.Expiration;
                }
                Response.Cookies.Add(cookie);
                FormsAuthentication.RedirectFromLoginPage(user.Username, true);
            }
            LoadControl();
        }
    }
}
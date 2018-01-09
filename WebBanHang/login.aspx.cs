using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Entities;
namespace WebBanHang
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Page.User.Identity.IsAuthenticated)
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect("login.aspx");
                }
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            UserEntity user = BUS.UserBus.Instance.GetUser(txtUsername.Text, txtPassword.Text);
            if (user == null)
            {
                pMessage.InnerText = "Tên tài khoản hoặc mật khẩu không đúng";
                txtPassword.Text = "";
            }
            else
            {
                string roles = BUS.UserBus.Instance.GetPermissionStr(user.Username);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, txtUsername.Text, DateTime.Now, DateTime.Now.AddMinutes(60*24*10), RememberMe.Checked, roles);
                string hashString = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashString);
                if (ticket.IsPersistent)
                {
                    cookie.Expires = ticket.Expiration;
                }
                Response.Cookies.Add(cookie);
                FormsAuthentication.RedirectFromLoginPage(user.Username, true);
            }
        }
    }
}
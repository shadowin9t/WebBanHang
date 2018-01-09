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
            if (!AuthenticateHelper.Login(txtUsername.Text, txtPassword.Text, RememberMe.Checked, Response))
            {
                pMessage.InnerText = "Tên tài khoản hoặc mật khẩu không đúng";
                txtPassword.Text = "";
            }else
            {
                string str = Request.QueryString["returnURL"];
                if (str != null)
                    Response.Redirect(str);
                else
                    Response.Redirect("~/Default.aspx");
            }
        }
    }
}
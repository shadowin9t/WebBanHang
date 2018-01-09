using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Entities;
namespace WebBanHang.Admin
{
    public partial class dangnhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                Session["User"] = user;
                FormsAuthentication.RedirectFromLoginPage(user.Username, true);
            }
        }
    }
}
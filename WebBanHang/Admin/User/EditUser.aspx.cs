using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Entities;
using System.Web.UI.HtmlControls;
using System.Web.Security;

namespace WebBanHang.Admin.User
{
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string querystring = Request.QueryString["username"];
                if (String.IsNullOrEmpty(querystring))
                    Response.Redirect("UserList.aspx");
                var edituser = BUS.UserBus.Instance.GetUser(querystring);
                if (edituser == null)
                    Response.Redirect("UserList.aspx");
               // Binding(user);
            }
        }

        void Binding(UserEntity user)
        {
            cblPermissions.DataSource = BUS.PermissionBus.Instance.GetPermissions();
            cblPermissions.DataBind();
            username.Value = user.Username;
            firstname.Value = user.Firstname;
            lastname.Value = user.Lastname;
            email.Value = user.Email;
        }

        UserEntity GetUser()
        {
            try
            {
                UserEntity user = new UserEntity();
                user.Username = username.Value;
                user.Firstname = firstname.Value;
                user.Lastname = lastname.Value;
                user.Email = email.Value;
                List<ValidationResult> rs = new List<ValidationResult>();

                bool valid = user.IsValidEditedUser(rs);
                if (!valid)
                {
                    foreach(ValidationResult result in rs)
                    {
                        var message = new HtmlGenericControl();
                        message.TagName = "li";
                        message.InnerText = result.ErrorMessage;
                        error_messages.Controls.Add(message);
                    }
                    return null;
                }
                return user;
            } catch(Exception e)
            {
                throw e;
            }
        }
       
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var user = GetUser();
                if(user!=null)
                {
                    BUS.UserBus.Instance.UpdateUser(user);
                }
                else
                {
                    var message = new HtmlGenericControl();
                    message.TagName = "li";
                    message.InnerText = "CREATE_USER_SUCCESS";
                    success_messages.Controls.Add(message);
                }
            } catch(Exception ex)
            {

            }

        }

        protected void btnSaveNClose_Click(object sender, EventArgs e)
        {
            var user = GetUser();
            if (user != null)
            {
                BUS.UserBus.Instance.UpdateUser(user);
                Response.Redirect(Page.ResolveUrl("UserList.aspx"));
            }
            else
            {
                var message = new HtmlGenericControl();
                message.TagName = "li";
                success_messages.Controls.Add(message);
            }
        }

        protected void btnSaveNNew_Click(object sender, EventArgs e)
        {
            var user = GetUser();
            if (user != null)
            {
                BUS.UserBus.Instance.UpdateUser(user);
                Response.Redirect("CreateUser.aspx");
            }
            else
            {
                var message = new HtmlGenericControl();
                message.TagName = "li";
                message.InnerText = "CREATE_USER_SUCCESS";
                success_messages.Controls.Add(message);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Entities;
using BUS;
using System.Web.UI.HtmlControls;

namespace WebBanHang.Admin.User
{
    public partial class CreateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cblPermissions.DataSource = BUS.PermissionBus.Instance.GetPermissions();
            cblPermissions.DataBind();
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
                user.Password = pwd.Value;
                user.ConfirmPassword = confirm_pwd.Value;
                ValidationContext context = new ValidationContext(user);
                List<ValidationResult> rs = new List<ValidationResult>();
                
                bool valid = Validator.TryValidateObject(user, context, rs,true);
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
                    BUS.UserBus.Instance.AddUser(user);
                else
                {
                    var message = new HtmlGenericControl();
                    message.TagName = "li";
                    message.InnerText = "CREATE_USER_SUCCESS";
                    success_messages.Controls.Add(message);
                }
            } catch(Exception)
            {
                
            }

        }

        protected void btnSaveNClose_Click(object sender, EventArgs e)
        {
            var user = GetUser();
            if (user != null)
            {
                BUS.UserBus.Instance.AddUser(user);
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
                BUS.UserBus.Instance.AddUser(user);
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
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
                {
                    Response.Redirect("UserList.aspx");
                    return;
                }
                Binding(edituser);
            }
        }

        void Binding(UserEntity user)
        {
            var ls = BUS.UserBus.Instance.GetPermission(user.Username);
            
            cblPermissions.DataSource = BUS.PermissionBus.Instance.GetPermissions();
            cblPermissions.DataBind();

            foreach (ListItem item in cblPermissions.Items)
            {
                foreach(var p in ls)
                {
                    if (p.ID == item.Value)
                        item.Selected = true;
                }
            }

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
                success_messages.Controls.Clear();
                error_messages.Controls.Clear();
                var user = GetUser();
                var ps = GetPermissions();
                if(user!=null)
                {
                    BUS.UserBus.Instance.UpdateUser(user);
                    BUS.UserBus.Instance.UpdatePermission(user, ps);
                    Binding(user);
                    AddSucessMessage("Cập nhật người dùng thành công");
                }
                else
                {
                    AddErrorMessage("Không tìm thấy người dùng");
                }
            } catch(Exception ex)
            {
                AddErrorMessage(ex.Message);
            }

        }

        public List<PermissionEntity> GetPermissions()
        {
            var ls = new List<PermissionEntity>();
            foreach(ListItem item in cblPermissions.Items)
            {
                if(item.Selected)
                {
                    var p = new PermissionEntity();
                    p.ID = item.Value;
                    ls.Add(p);
                }
                
            }
            return ls;
        }

        protected void btnSaveNClose_Click(object sender, EventArgs e)
        {
            error_messages.Controls.Clear();
            success_messages.Controls.Clear();
            var user = GetUser();
            var ps = GetPermissions();
            if (user != null)
            {
                BUS.UserBus.Instance.UpdateUser(user);
                BUS.UserBus.Instance.UpdatePermission(user, ps);
                Response.Redirect(Page.ResolveUrl("UserList.aspx"));
            }
            else
            {
                AddErrorMessage("Cập nhật người dùng thất bại");
            }
        }

        protected void btnSaveNNew_Click(object sender, EventArgs e)
        {
            success_messages.Controls.Clear();
            error_messages.Controls.Clear();
            var user = GetUser();
            var ps = GetPermissions();
            if (user != null)
            {
                BUS.UserBus.Instance.UpdateUser(user);
                BUS.UserBus.Instance.UpdatePermission(user, ps);
                Response.Redirect("CreateUser.aspx");
            }
            else
            {
                AddErrorMessage("Cập nhật người dùng thất bại");
            }
        }

        public void AddErrorMessage(string value)
        {
            var message = new HtmlGenericControl();
            message.TagName = "li";
            message.InnerText = value;
            error_messages.Controls.Add(message);
        }

        public void AddSucessMessage(string value)
        {
            var message = new HtmlGenericControl();
            message.TagName = "li";
            message.InnerText = value;
            success_messages.Controls.Add(message);
        }

        protected void changepassword_ServerClick(object sender, EventArgs e)
        {
            error_messages.Controls.Clear();

            if(newpassword.Value != confirmpassword.Value)
            {
                AddErrorMessage("Mật khẩu xác nhận không khớp");
            }
            else
            {
                if (BUS.UserBus.Instance.UpdatePassword(username.Value, newpassword.Value))
                {
                    success_messages.Controls.Clear();
                    AddSucessMessage("Đổi mật khẩu thành công");
                }
            }
            
        }
    }
}
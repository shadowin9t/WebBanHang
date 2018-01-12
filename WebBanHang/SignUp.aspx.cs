using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using System.ComponentModel.DataAnnotations;
using BUS;
using System.Web.UI.HtmlControls;
namespace WebBanHang
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void AddError(string err)
        {
            var li = new HtmlGenericControl("li");
            li.InnerText = err;
            ULError.Visible = true;
            ULError.Controls.Add(li);
        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            CustomerEntity cus = new CustomerEntity();
            cus.Adress = txtAddress.Value;
            cus.CreatedDate = DateTime.Now;
            cus.Email = txtemail.Value;
            cus.FirstName = txtFirstname.Value;
            cus.LastName = txtLastname.Value;
            cus.Pass = txtConfirmPass.Value;
            cus.Phone = txtPhone.Value;
            List<ValidationResult> ls = new List<ValidationResult>();

            if (cus.IsValidNewUser(ls))
            {
                if (txtPass.Value != txtConfirmPass.Value)
                {
                    AddError("Mật khẩu xác nhận không khớp!");
                    return;
                }
                   
                if(CustomerBus.Instance.HasCustomer(cus.Email))
                {
                    AddError("Email đã đăng ký!");
                    return;
                }
                else
                {
                    if (CustomerBus.Instance.AddCustomer(cus))
                        Response.Redirect("Default.aspx");
                    else
                        AddError("Thêm không thành công!");
                }
            }
            else
            {
                foreach (ValidationResult item in ls)
                {
                    AddError(item.ErrorMessage);
                }
            }

        }
    }
}
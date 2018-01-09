using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using System.Web.UI.HtmlControls;

namespace WebBanHang.UserControls
{
    public partial class UserManagementControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //DataTable dt = BUS.UserBus.Instance.GetTable();
            if(!IsPostBack)
            {
                LoadData();
            }
        }

        public void LoadData()
        {
            GridView1.DataSource = BUS.UserBus.Instance.GetUsers();//dt
            GridView1.DataBind();
        }

        protected void addBtn_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/User/CreateUser.aspx");
        }

        protected void deleteBtn_ServerClick(object sender, EventArgs e)
        {
            try
            {
                int count = 0;
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox cb = (CheckBox) row.Cells[0].FindControl("chbox");
                    if (cb != null && cb.Checked)
                    {
                        string usname = GridView1.DataKeys[row.RowIndex].Value.ToString();
                        UserEntity entity = new UserEntity();
                        entity.Username = usname;
                        BUS.UserBus.Instance.DeleteUser(entity.Username);
                        count++;
                    }
                }

                HtmlGenericControl div = new HtmlGenericControl();
                div.TagName = "div";
                div.Attributes["class"] = "alert alert-success";
                div.InnerText = "Đã xóa " + count.ToString() + " người dùng";
                message.Controls.Add(div);
                LoadData();
            } catch(Exception exception)
            {
                HtmlGenericControl div = new HtmlGenericControl();
                div.TagName = "div";
                div.Attributes["class"] = "alert alert-danger";
                div.InnerText = exception.Message;
                message.Controls.Add(div);
                LoadData();
            }
            
        }
    }
}
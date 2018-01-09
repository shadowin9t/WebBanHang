using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BUS;
using Entities;
namespace WebBanHang.Admin.User
{
    public partial class CategoryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadData();
        }

        void LoadData()
        {
            GridView1.DataSource = CategoryBus.Instance.GetCategories();
            GridView1.DataBind();
        }

        protected void addBtn_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("AddCategory.aspx");
        }

        protected void deleteBtn_ServerClick(object sender, EventArgs e)
        {
            try
            {
                int count = 0;
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox cb = (CheckBox)row.Cells[0].FindControl("chbox");
                    if (cb != null && cb.Checked)
                    {
                        string id = GridView1.DataKeys[row.RowIndex].Value.ToString();
                        CategoryBus.Instance.DeleteCategory(id);
                        count++;
                    }
                }

                HtmlGenericControl div = new HtmlGenericControl();
                div.TagName = "div";
                div.Attributes["class"] = "alert alert-success";
                div.InnerText = "Đã xóa " + count.ToString() + " người dùng";
                message.Controls.Add(div);
                LoadData();
            }
            catch (Exception exception)
            {
                HtmlGenericControl div = new HtmlGenericControl();
                div.TagName = "div";
                div.Attributes["class"] = "alert alert-danger";
                div.InnerText = exception.Message;
                message.Controls.Add(div);
                LoadData();
            }
        }

        void UpdateStatuses(int value)
        {
            try
            {
                int count = 0;
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox cb = (CheckBox)row.Cells[0].FindControl("chbox");
                    if (cb != null && cb.Checked)
                    {
                        string id = GridView1.DataKeys[row.RowIndex].Value.ToString();
                        CategoryBus.Instance.UpdateStatus(value, id);
                        count++;
                    }
                }

                HtmlGenericControl div = new HtmlGenericControl();
                div.TagName = "div";
                div.Attributes["class"] = "alert alert-success";
                div.InnerText = "Da cap nhat trang thai " + count.ToString() + " loai san pham";
                message.Controls.Add(div);
                LoadData();
            }
            catch (Exception exception)
            {
                HtmlGenericControl div = new HtmlGenericControl();
                div.TagName = "div";
                div.Attributes["class"] = "alert alert-danger";
                div.InnerText = exception.Message;
                message.Controls.Add(div);
                LoadData();
            }
        }

        protected void Publish_ServerClick(object sender, EventArgs e)
        {
            UpdateStatuses(2);
        }

        protected void Unpublish_ServerClick(object sender, EventArgs e)
        {
            UpdateStatuses(1);
        }
    }
}
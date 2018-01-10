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
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadData();
        }

        void LoadData()
        {
            GridView1.DataSource = ProductBus.Instance.GetProducts();
            GridView1.DataBind();
        }

        void CreateErrorMessage(string message)
        {
            error_message.Controls.Clear();
            HtmlGenericControl div = new HtmlGenericControl();
            div.TagName = "div";
            div.Attributes["class"] = "alert alert-danger";
            div.InnerText = message;
            error_message.Controls.Add(div);
        }

        void CreateSuccessMessage(string message)
        {
            succ_message.Controls.Clear();
            HtmlGenericControl div = new HtmlGenericControl();
            div.TagName = "div";
            div.Attributes["class"] = "alert alert-success";
            div.InnerText = message;
            succ_message.Controls.Add(div);
        }

        void AddErrorMessage()
        {

        }

        //Redirect to addproduct page
        protected void addBtn_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("AddProduct.aspx");
        }

        //Delete selected products
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
                        ProductBus.Instance.DeleteProduct(id);
                        count++;
                    }
                }

                CreateSuccessMessage("Đã xóa " + count.ToString() + " người dùng");
                LoadData();
            }
            catch (Exception exception)
            {
                CreateErrorMessage(exception.Message);
                LoadData();
            }
        }

        //Update product status by his value passing
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
                        ProductBus.Instance.UpdateStatus(value, id);
                        count++;
                    }
                }

                CreateSuccessMessage("Đã cập nhật trạng thái " + count.ToString() + " sản phẩm");
                LoadData();
            }
            catch (Exception exception)
            {
                CreateErrorMessage(exception.Message);
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

        void UpdateFeature(bool value)
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
                        ProductBus.Instance.UpdateFeature(value, id);
                        count++;
                    }
                }

                CreateSuccessMessage("Đã cập nhật trạng thái " + count.ToString() + " sản phẩm");
                LoadData();
            }
            catch (Exception exception)
            {
                CreateErrorMessage(exception.Message);
                LoadData();
            }

        }

        protected void SetFeature_ServerClick(object sender, EventArgs e)
        {
            UpdateFeature(true);
        }

        protected void SetNotFeature_ServerClick(object sender, EventArgs e)
        {
            UpdateFeature(false);
        }
    }
}
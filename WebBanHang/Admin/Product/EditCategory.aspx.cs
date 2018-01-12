using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using BUS;
using Entities;

namespace WebBanHang.Admin.Product
{
    public partial class EditCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string query = Request.QueryString["cate"];
                if (String.IsNullOrEmpty(query))
                {
                    Response.Redirect("CategoryList.aspx");
                    return;
                }
                ProductEntity.Category category = CategoryBus.Instance.GetBasicCategoryById(query);
                if(category == null)
                {
                    Response.Redirect("CategoryList.aspx");
                    return;
                }
                BindData();
                BindCategory(category);
            }
        }

        void BindData()
        {
            var ls = StatusBus.Instance.GetStatuses();
            ddlStatus.DataSource = ls;
            ddlStatus.DataBind();
        }

        void BindCategory(ProductEntity.Category category)
        {
            categoryid.Value = category.ID;
            categoryname.Value = category.Name;
            discription.Value = discription.Value;
            ddlStatus.SelectedValue = category.StatusId.ToString();
        }

        public ProductEntity.Category GetCategory()
        {
            var v = new ProductEntity.Category();
            v.ID = categoryid.Value;
            v.Name = categoryname.Value;
            v.CreatedBy = Session["User"] as UserEntity;
            v.CreatedDate = DateTime.Now;
            v.Discription = discription.Value;
            v.Status = StatusBus.Instance.GetStatus(int.Parse(ddlStatus.SelectedValue));
            v.CreatedBy = UserBus.Instance.GetUser(User.Identity.Name);
            return v;
        }

        bool UploadImage(ProductEntity.Category v, out string message)
        {
            if (imagefile.HasFile)
            {
                if (imagefile.PostedFile.ContentType == "image/png")
                {
                    if (imagefile.PostedFile.ContentLength < 1024000)
                    {
                        string filename = Hash.getHashSha256(v.ID) + System.IO.Path.GetExtension(imagefile.FileName);
                        imagefile.SaveAs(Server.MapPath("~/images/categories/") + filename);
                        message = "FILE_UPLOAD_SUCCESS";
                        v.CategoryImage = filename;
                        return true;
                    }
                    else
                        message = "FILE_UPLOAD_TOO_BIG";
                }
                else
                    message = "INVALID_IMAGE_FORMAT";
                return false;
            }
            message = "NO_FILE_UPLOADED";
            return true;
        }

        void AddSuccessMessage(string message)
        {
            var li = new HtmlGenericControl("li");
            li.InnerText = message;
            success_messages.Controls.Add(li);
        }

        void AddErrorMessage(string message)
        {
            var li = new HtmlGenericControl("li");
            li.InnerText = message;
            error_messages.Controls.Add(li);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                error_messages.Controls.Clear();
                var cg = GetCategory();
                var ls = new List<string>();
                var valid = cg.IsValidUpdatingCategory(ls);
                if (valid)
                {
                    string message;
                    var upload = UploadImage(cg, out message);
                    if (upload)
                    {
                        string query = Request.QueryString["cate"];
                        int r = CategoryBus.Instance.UpdateCategory(cg, query);
                        if (r > 0)
                        {
                            success_messages.Controls.Clear();
                            AddSuccessMessage("Cập nhật thành công");
                        }
                    }
                }
                else
                {
                    foreach(var m in ls)
                    {
                        AddErrorMessage(m);
                    }
                }
            } catch(Exception ex)
            {
                AddErrorMessage(ex.Message);
            }
        }

        protected void btnSaveNClose_Click(object sender, EventArgs e)
        {
            try
            {
                error_messages.Controls.Clear();
                var cg = GetCategory();
                var ls = new List<string>();
                var valid = cg.IsValidUpdatingCategory(ls);
                if (valid)
                {
                    string message;
                    var upload = UploadImage(cg, out message);
                    if (upload)
                    {
                        string query = Request.QueryString["cate"];
                        int r = CategoryBus.Instance.UpdateCategory(cg, query);
                        if (r > 0)
                        {
                            success_messages.Controls.Clear();
                            AddSuccessMessage("Cập nhật thành công");
                            Response.Redirect("ListCategory.aspx");
                        }
                    }
                }
                else
                {
                    foreach (var m in ls)
                    {
                        AddErrorMessage(m);
                    }
                }
            }
            catch (Exception ex)
            {
                AddErrorMessage(ex.Message);
            }
        }

        protected void btnSaveNNew_Click(object sender, EventArgs e)
        {
            try
            {
                error_messages.Controls.Clear();
                var cg = GetCategory();
                var ls = new List<string>();
                var valid = cg.IsValidUpdatingCategory(ls);
                if (valid)
                {
                    string message;
                    var upload = UploadImage(cg, out message);
                    if (upload)
                    {
                        string query = Request.QueryString["cate"];
                        int r = CategoryBus.Instance.UpdateCategory(cg, query);
                        if (r > 0)
                        {
                            success_messages.Controls.Clear();
                            AddSuccessMessage("Cập nhật thành công");
                            Response.Redirect("AddCategory.aspx");
                        }
                    }
                }
                else
                {
                    foreach (var m in ls)
                    {
                        AddErrorMessage(m);
                    }
                }
            }
            catch (Exception ex)
            {
                AddErrorMessage(ex.Message);
            }

        }
    }
}
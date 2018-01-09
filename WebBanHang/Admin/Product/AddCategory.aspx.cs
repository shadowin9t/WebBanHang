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
    public partial class AddCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        void BindData()
        {
            var ls = StatusBus.Instance.GetStatuses();
            ddlStatus.DataSource = ls;
            ddlStatus.DataBind();
        }

        public ProductEntity.Category GetCategory()
        {
            var v = new ProductEntity.Category();
            v.ID = categoryid.Value;
            v.Name = categoryname.Value;
            v.CreatedBy = Session["User"] as UserEntity;
            v.CreatedDate = DateTime.Now;
            v.Discription = discription.Value;
            v.StatusId = int.Parse(ddlStatus.SelectedValue);
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var cg = GetCategory();
            var ls = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var valid = cg.IsValidNewCategory(ls);
            if(valid)
            {
                string message;
                var upload = UploadImage(cg, out message);
                if (upload)
                {
                    CategoryBus.Instance.AddCategory(cg);
                }
            }
        }

        protected void btnSaveNClose_Click(object sender, EventArgs e)
        {

        }

        protected void btnSaveNNew_Click(object sender, EventArgs e)
        {

        }
    }
}
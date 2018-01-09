using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.ComponentModel.DataAnnotations;
using BUS;
using Entities;

namespace WebBanHang.Admin.Product
{
    public partial class AddProduct : System.Web.UI.Page
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
            var cate = CategoryBus.Instance.GetCategories();
            ddlCategory.DataSource = cate;
            ddlCategory.DataBind();
        }

        public ProductEntity GetProduct()
        {
            var v = new ProductEntity();
            v.ID = productid.Value;
            v.ProductName = productname.Value;
            v.Feature = feature.Value;
            v.Discription = discription.Value;
            v.Price = float.Parse(price.Value);
            v.FinalPrice = float.Parse(finalprice.Value);
            v.Quantity = int.Parse(quantity.Value);
            v.Status = StatusBus.Instance.GetStatus(int.Parse(ddlStatus.SelectedValue));
            v.CreatedBy = Session["User"] as UserEntity;
            v.CreatedDate = DateTime.Now;
            v.ProductCategory = CategoryBus.Instance.GetBasicCategoryById(ddlCategory.SelectedValue);
            return v;
        }

        bool UploadImage(ProductEntity v, out string message)
        {
            if (imagefile.HasFile)
            {
                if (imagefile.PostedFile.ContentType == "image/png")
                {
                    if (imagefile.PostedFile.ContentLength < 1024000)
                    {
                        string filename = Hash.getHashSha256(v.ID) + System.IO.Path.GetExtension(imagefile.FileName);
                        imagefile.SaveAs(Server.MapPath("~/images/products/") + filename);
                        message = "FILE_UPLOAD_SUCCESS";
                        v.DisplayImage = filename;
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
            return false;
        }

        void ClearMessage()
        {
            error_messages.InnerText = "";
        }

        void AddMessage(string value)
        {
            var message = new HtmlGenericControl();
            message.TagName = "li";
            message.InnerText = value;
            error_messages.Controls.Add(message);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ClearMessage();
                var p = GetProduct();
                var ls = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
                var valid = p.IsValidNewProdcut(ls);
                if (valid)
                {
                    string message;
                    var upload = UploadImage(p, out message);
                    if (upload)
                    {
                        ProductBus.Instance.InsertProduct(p);
                    }
                    else
                        AddMessage(message);
                }
                else
                {
                    foreach(var re in ls)
                    {
                        AddMessage(re.ErrorMessage);
                    }
                }
            } catch(Exception ex)
            {
                AddMessage(ex.Message);
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
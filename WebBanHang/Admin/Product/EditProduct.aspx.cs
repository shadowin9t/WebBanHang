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
    public partial class EditProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string querystring = Request.QueryString["id"];
                if (String.IsNullOrEmpty(querystring))
                    Response.Redirect("ProductList.aspx");
                var editproduct = BUS.ProductBus.Instance.GetProductById(querystring);

                if (editproduct == null)
                {
                    Response.Redirect("ProductList.aspx");
                    return;
                }
                Binding(editproduct);
                var ls = StatusBus.Instance.GetStatuses();
                ddlStatus.DataSource = ls;
                ddlStatus.DataBind();
                var cate = CategoryBus.Instance.GetCategories();
                ddlCategory.DataSource = cate;
                ddlCategory.DataBind();
            }
        }

        void Binding(ProductEntity v)
        {
            productid.Value = v.ID;
            productname.Value = v.ProductName;
            cbFeature.Checked = v.Feature;
            shordescription.Value = v.ShortDescription;
            discription.Value = v.Discription;
            price.Value = v.Price.ToString();
            finalprice.Value = v.FinalPrice.ToString();
            quantity.Value = v.Quantity.ToString();
            ddlStatus.SelectedValue = v.StatusId.ToString();
            ddlCategory.SelectedValue = v.ProductCategory.ID;
        }

        public ProductEntity GetProduct()
        {
            var v = new ProductEntity();
            v.ID = productid.Value;
            v.ProductName = productname.Value;
            v.Feature = cbFeature.Checked;
            v.ShortDescription = shordescription.Value;
            v.Discription = discription.Value;
            v.Price = float.Parse(price.Value);
            v.FinalPrice = float.Parse(finalprice.Value);
            v.Quantity = int.Parse(quantity.Value);
            v.Status = StatusBus.Instance.GetStatus(int.Parse(ddlStatus.SelectedValue));
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
            error_messages.Controls.Clear();
            success_messages.Controls.Clear();
        }

        void AddErrorMessage(string value)
        {
            var message = new HtmlGenericControl();
            message.TagName = "li";
            message.InnerText = value;
            error_messages.Controls.Add(message);
        }

        void CreateSuccessMessage(string value)
        {
            var message = new HtmlGenericControl();
            message.TagName = "li";
            message.InnerText = value;
            success_messages.Controls.Add(message);
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
                        ProductBus.Instance.UpdateProduct(p,p.ID);
                        CreateSuccessMessage("Cập nhật sản phẩm thành công");
                    }
                    else
                        AddErrorMessage(message);
                }
                else
                {
                    foreach(var re in ls)
                    {
                        AddErrorMessage(re.ErrorMessage);
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
                        ProductBus.Instance.UpdateProduct(p, p.ID);
                        Response.Redirect("~/Admin/Product/ProductList.aspx");
                    }
                    else
                        AddErrorMessage(message);
                }
                else
                {
                    foreach (var re in ls)
                    {
                        AddErrorMessage(re.ErrorMessage);
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
                        ProductBus.Instance.UpdateProduct(p, p.ID);
                        Response.Redirect("~/Admin/Product/AddProduct.aspx");
                    }
                    else
                        AddErrorMessage(message);
                }
                else
                {
                    foreach (var re in ls)
                    {
                        AddErrorMessage(re.ErrorMessage);
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
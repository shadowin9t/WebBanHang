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
            v.Feature = cbFeature.Checked;
            v.ShortDescription = shordescription.Value;
            v.Discription = discription.Value;
            v.Price = float.Parse(price.Value);
            v.FinalPrice = float.Parse(finalprice.Value);
            v.Quantity = int.Parse(quantity.Value);
            v.Status = StatusBus.Instance.GetStatus(int.Parse(ddlStatus.SelectedValue));
            v.CreatedBy = BUS.UserBus.Instance.GetUser(User.Identity.Name);
            v.CreatedDate = DateTime.Now;
            v.ProductCategory = CategoryBus.Instance.GetBasicCategoryById(ddlCategory.SelectedValue);
            v.DisplayImage = imageupload.GetUrl();
            return v;
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
                    if (ProductBus.Instance.InsertProduct(p) >= 1)
                        Response.Redirect("~/Admin/Product/EditProduct.aspx?ID=" + p.ID);
                }
                else
                {
                    foreach (var re in ls)
                    {
                        AddMessage(re.ErrorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
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
                    if (ProductBus.Instance.InsertProduct(p) >= 1)
                        Response.Redirect("~/Admin/Product/ProductList.aspx");
                }
                else
                {
                    foreach (var re in ls)
                    {
                        AddMessage(re.ErrorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
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
                    if (ProductBus.Instance.InsertProduct(p) >= 1)
                        Response.Redirect("~/Admin/Product/AddProduct.aspx");
                }
                else
                {
                    foreach (var re in ls)
                    {
                        AddMessage(re.ErrorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message);
            }
        }

        protected void imageupload_GetError(object sender, EventArgs e)
        {
            AddMessage("Tập tin upload không hợp lệ!");
        }
    }
}
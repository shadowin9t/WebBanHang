using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Entities;
using BUS;
namespace WebBanHang.Admin.Promotion
{
    public partial class EditPromotion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ddlStatus.DataSource = StatusBus.Instance.GetStatuses();
                ddlStatus.DataBind();
                string querystring = Request.QueryString["id"];
                if (String.IsNullOrEmpty(querystring))
                {
                    Response.Redirect("Default.aspx");
                    return;
                }
                var p = PromotionBus.Instance.GetPromotion(querystring);
                if (p == null)
                {
                    Response.Redirect("Default.aspx");
                    return;
                }
                    
                LoadData(p);
            }
        }

        public void LoadData(PromotionEntity p)
        {
            if (!IsPostBack)
            {
                promotionID.Value = p.ID;
                title.Value = p.Title;
                shortdescription.Value = p.ShortDiscription;
                discription.Value = p.Discription;
                ddlStatus.SelectedValue = p.StatusID.ToString();
                UploadedImage.DefaultUrl = p.Image;
                UploadedImage.DataBind();
            }
        }

        PromotionEntity GetPromotion()
        {
            PromotionEntity p = new PromotionEntity();
            p.ID = promotionID.Value;
            p.Title = title.Value;
            p.ShortDiscription = shortdescription.Value;
            p.Discription = discription.Value;
            p.Image = UploadedImage.GetUrl();
            p.Status = StatusBus.Instance.GetStatus(int.Parse(ddlStatus.SelectedValue));
            p.CreatedDate = DateTime.Now;
            p.CreatedBy = UserBus.Instance.GetUser(User.Identity.Name);
            return p;
        }

        void AddErrorMessage(string value)
        {
            var li = new HtmlGenericControl("li");
            li.InnerText = value;
            error_message.Controls.Add(li);
        }

        void AddSuccessMessage(string value)
        {
            var li = new HtmlGenericControl("li");
            li.InnerText = value;
            success_message.Controls.Add(li);
        }

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            try
            {
                error_message.Controls.Clear();
                success_message.Controls.Clear();
                var p = GetPromotion();
                if (!BUS.PromotionBus.Instance.HasPromotion(p.ID))
                {
                    AddErrorMessage("Quảng cáo này tồn tại");
                    return;
                }
                List<string> messages = new List<string>();
                if (p.ValidUpdatePromotion(messages))
                {
                    string querystring = Request.QueryString["id"];
                    PromotionBus.Instance.UpdatePromotion(p, querystring);                    
                    AddSuccessMessage("Lưu thành công");
                }
            } catch(Exception ex)
            {
                AddErrorMessage(ex.Message);
            }
        }

        protected void btnSaveNew_ServerClick(object sender, EventArgs e)
        {
            try
            {
                error_message.Controls.Clear();
                success_message.Controls.Clear();
                var p = GetPromotion();
                if (!BUS.PromotionBus.Instance.HasPromotion(p.ID))
                {
                    AddErrorMessage("Quảng cáo này không tồn tại");
                    return;
                }
                List<string> messages = new List<string>();
                if (p.ValidUpdatePromotion(messages))
                {
                    string querystring = Request.QueryString["id"];
                    PromotionBus.Instance.UpdatePromotion(p, querystring);
                    Response.Redirect("AddPromotion.aspx");
                    AddSuccessMessage("Lưu thành công");
                }
            }
            catch (Exception ex)
            {
                AddErrorMessage(ex.Message);
            }
        }

        protected void btnSaveClose_ServerClick(object sender, EventArgs e)
        {
            try
            {
                error_message.Controls.Clear();
                success_message.Controls.Clear();
                var p = GetPromotion();
                if (!BUS.PromotionBus.Instance.HasPromotion(p.ID))
                {
                    AddErrorMessage("Quảng cáo này không tồn tại");
                    return;
                }
                List<string> messages = new List<string>();
                if (p.ValidUpdatePromotion(messages))
                {
                    string querystring = Request.QueryString["id"];
                    PromotionBus.Instance.UpdatePromotion(p,querystring);
                    Response.Redirect("Default.aspx");
                    AddSuccessMessage("Lưu thành công");
                }
            }
            catch (Exception ex)
            {
                AddErrorMessage(ex.Message);
            }
        }
    }
}
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
    public partial class AddPromotion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ddlStatus.DataSource = StatusBus.Instance.GetStatuses();
                ddlStatus.DataBind();
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
                if (BUS.PromotionBus.Instance.HasPromotion(p.ID))
                {
                    AddErrorMessage("Mã quảng cáo đã có sẵn");
                    return;
                }
                List<string> messages = new List<string>();
                if (p.ValidNewPromotion(messages))
                {
                    PromotionBus.Instance.InsertPromotion(p);
                    Response.Redirect("EditPromotion.aspx?id=" + p.ID);
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
                if (BUS.PromotionBus.Instance.HasPromotion(p.ID))
                {
                    AddErrorMessage("Mã quảng cáo đã có sẵn");
                    return;
                }
                List<string> messages = new List<string>();
                if (p.ValidNewPromotion(messages))
                {
                    PromotionBus.Instance.InsertPromotion(p);
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
                if (BUS.PromotionBus.Instance.HasPromotion(p.ID))
                {
                    AddErrorMessage("Mã quảng cáo đã có sẵn");
                    return;
                }
                List<string> messages = new List<string>();
                if (p.ValidNewPromotion(messages))
                {
                    PromotionBus.Instance.InsertPromotion(p);
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
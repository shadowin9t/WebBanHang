<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddPromotion.aspx.cs" Inherits="WebBanHang.Admin.Promotion.AddPromotion" %>
<%@ Register Src="~/UserControls/ImageUploadUC.ascx" TagName="ImageUpload" TagPrefix="My" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Thêm quảng cáo</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="btn-group">
        <button class="btn btn-primary" runat="server" id="btnSave" onserverclick="btnSave_ServerClick">Lưu</button>
        <button class="btn btn-primary" runat="server" id="btnSaveNew" onserverclick="btnSaveNew_ServerClick">Lưu và Thêm</button>
        <button class="btn btn-primary" runat ="server" id="btnSaveClose" onserverclick="btnSaveClose_ServerClick">Lưu và Đóng</button>
        <a class="btn btn-primary" href="Default.aspx">Đóng</a>
    </div>
    <div class="container-fluid">
        <ul class="container" runat="server" id="error_message">

        </ul>
    </div>
    <div class="container-fluid">
        <ul class="container" runat="server" id="success_message">

        </ul>
    </div>
    <div class="container-fluid">
        <div class="form-row">
            <div class="col">
                <div class="form-group">
                    <label for="promotionID">Mã quảng cáo</label>
                    <input id="promotionID" runat="server" class="form-control" required="required" />
                </div>
                <div class="form-group">
                    <label for="title">Tiêu đề</label>
                    <input id="title" runat="server" class="form-control" required="required" />
                </div>
                <div class="form-group">
                    <label for="shortdescription">Mô tả ngắn</label>
                    <textarea runat="server" rows="3" id="shortdescription" class="form-control" />
                </div>
                <div class="form-group">
                    <label for="ddlStatus">Trạng thái</label>
                    <asp:DropDownList runat="server" CssClass="form-control" id="ddlStatus" DataValueField="Id" DataTextField="Name" />
                </div>
            </div>
            <div class="col">
                <My:ImageUpload ID="UploadedImage" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <label for="discription">Mô tả</label>
            <textarea runat="server" id="discription" rows="5" class="form-control" />
        </div>
    </div>
</asp:Content>

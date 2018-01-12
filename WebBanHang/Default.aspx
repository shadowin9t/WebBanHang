<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebBanHang.Default" %>
<%@ Register Src="~/UserControls/Product/RandomProduct.ascx" TagName="RandomProduct" TagPrefix="My" %>
<%@ Register Src="~/UserControls/PromotionSlider.ascx" TagName="PromotionSlider" TagPrefix="My" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container-fluid">
        <My:PromotionSlider runat="server" />
    </div>
    <div class="container-fluid">
        <My:RandomProduct runat="server" Number="20" />
    </div>
    
</asp:Content>

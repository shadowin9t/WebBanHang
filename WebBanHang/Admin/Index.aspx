<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebBanHang.Admin.Index" %>
<%@ Register TagPrefix="My" Src="~/UserControls/UserManagementControl.ascx" TagName="ProductsControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Trang quản trị bán hàng</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <My:ProductsControl runat="server"/>
</asp:Content>

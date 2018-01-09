<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebBanHang.Default" %>
<%@ Register Src="~/UserControls/RandomProduct.ascx" TagName="RandomProduct" TagPrefix="My" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <My:RandomProduct runat="server" Number="20" />
</asp:Content>

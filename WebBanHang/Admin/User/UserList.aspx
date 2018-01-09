<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="WebBanHang.Admin.User.UserList" %>
<%@ Register TagPrefix="My" Src="~/UserControls/UserManagementControl.ascx" TagName="UserManagementControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Danh sách sinh viên</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <My:UserManagementControl runat="server"/>
</asp:Content>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminSideMenuUC.ascx.cs" Inherits="WebBanHang.UserControls.AdminSideMenuUC" %>
<h1 class="my-4">Shop Name</h1>
<div class="list-group">
    <a href="<%=Page.ResolveUrl("~/Admin/User/UserList.aspx") %>" class="list-group-item">Người dùng</a>
    <a href="<%=Page.ResolveUrl("~/Admin/Product/CategoryList.aspx") %>" class="list-group-item">Loại sản phẩm</a>
    <a href="<%=Page.ResolveUrl("~/Admin/Product/ProductList.aspx") %>" class="list-group-item">Sản phẩm</a>
</div>

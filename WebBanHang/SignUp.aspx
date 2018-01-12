<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="WebBanHang.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container">
        <ul runat="server" id="ULError" class="alert alert-danger" visible="false">
        </ul>

        <div class="form-group">
            <label for="txtemail">Email</label>
            <input type="email" class="form-control" id="txtemail" runat="server" />
        </div>
        <div class="form-row">
            <div class="form-group col">
                <label>Họ</label>
                <input type="text" class="form-control" id="txtLastname" runat="server" />
            </div>
            <div class="form-group col">
                <label>Tên</label>
                <input type="text" class="form-control" id="txtFirstname" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <label>Mật khẩu</label>
            <input type="password" class="form-control" id="txtPass" runat="server" />
        </div>
        <div class="form-group">
            <label>Xác nhận mật khẩu</label>
            <input type="password" class="form-control" id="txtConfirmPass" runat="server" />
        </div>
        <div class="form-group">
            <label>Địa chỉ</label>
            <input type="text" class="form-control" id="txtAddress" runat="server" />
        </div>
        <div class="form-group">
            <label>Số điện thoại</label>
            <input type="text" class="form-control" id="txtPhone" runat="server" />
        </div>
        <button id="btnSubmit" runat="server" onserverclick="btnSubmit_ServerClick">Đăng ký</button>
    </div>
</asp:Content>

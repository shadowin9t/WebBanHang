<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dangnhap.aspx.cs" Inherits="WebBanHang.Admin.dangnhap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <span>Tên đăng nhập: </span>
        <asp:TextBox runat ="server" ID ="txtUsername"></asp:TextBox>
    </div>
    <div>
        <span>Mật khẩu</span>
        <asp:TextBox runat="server" TextMode="Password" ID="txtPassword"></asp:TextBox>
    </div>
        <asp:CheckBox runat="server" Text="Ghi nhớ đăng nhập"/>
    <div>
        <p id="pMessage" runat ="server"></p>
    </div>
    <asp:Button runat="server" Text="Đăng nhập" OnClick="Unnamed1_Click"/>
    </form>
</body>
</html>

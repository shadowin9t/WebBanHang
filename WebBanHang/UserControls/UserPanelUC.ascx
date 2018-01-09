<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="true" CodeBehind="UserPanelUC.ascx.cs" Inherits="WebBanHang.UserControls.UserPanelUC" %>
<div ID="divLogin" runat="server">

    <div class="form-row align-items-center">
        <div class="col-auto">
            <label class="sr-only" for="inputusername">Tên đăng nhập</label>
        <input type="text" id="inputusername" class="form-control" placeholder="Tên đăng nhập" runat="server"/>
        </div>
        <div class="col-auto">
            <label class="sr-only" for="inputpwd">Mật khẩu</label>
        <input type="password" id="inputpwd" class="form-control" placeholder="Mật khẩu" runat="server"/>
        </div>
        <div class="col-auto">
            <button type="submit" ID="btnlogin" class="btn" runat="server" onserverclick="btnlogin_ServerClick">Đăng nhập</button>
        </div>
    </div>
</div>
<div class="dropdown" ID="divUserinfo" runat="server">
  <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" runat="server">
  </button>
  <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
    <a class="dropdown-item" href="#">Thông tin cá nhân</a>
    <a class="dropdown-item" href="#">Đổi mật khẩu</a>
    <a class="dropdown-item" href="login.aspx">Đăng xuất</a>
  </div>
</div>

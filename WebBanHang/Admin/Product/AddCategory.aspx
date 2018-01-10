<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="WebBanHang.Admin.Product.AddCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div class="container-fluid">
        
        <div class="button-group">
            <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Lưu" OnClick="btnSave_Click"/>
            <asp:Button ID="btnSaveNClose" CssClass="btn btn-primary" runat="server" Text="Lưu và đóng" OnClick="btnSaveNClose_Click" />
            <asp:Button ID="btnSaveNNew" CssClass="btn btn-primary" runat="server" Text="Lưu và tạo mới" OnClick="btnSaveNNew_Click"/>
            <a href="CategoryList.aspx" class="btn btn-primary">Đóng</a>
        </div>
        <div class="container">
            <ul id="error_messages" runat="server">

            </ul>
        </div>
        <div class="container">
            <ul id="success_messages" runat="server">

            </ul>
        </div>
        </div>
        <div class="container-fluid" >
        <div class="form-group">
            <label for="categoryid">Mã loại</label>
            <input id="categoryid" class="form-control" runat="server" />
        </div>
        <div class="form-group">
            <label for="categoryname">Tên loại</label>
            <input type="text" class="form-control" id="categoryname" runat="server" required="required"/>
        </div>
            <div class="form-group">
            <label for ="ddlStatus">Trạng Thái</label>
            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" DataTextField="Name" DataValueField="Id">

            </asp:DropDownList>
        </div>
            <div class="custom-file">
                <asp:FileUpload ID="imagefile" runat="server" />

            </div>

        
        <div class="form-group">
            <label for="discription">Mô tả</label>
            <textarea class="form-control" rows="3" runat="server" id="discription"></textarea>
        </div>
        </div>
        </form>

</asp:Content>

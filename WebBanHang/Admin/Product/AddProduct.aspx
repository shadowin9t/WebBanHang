<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="WebBanHang.Admin.Product.AddProduct" %>

<%@ Register Src="~/UserControls/ImageUploadUC.ascx" TagName="ImageUpload" TagPrefix="My" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container-fluid">
        <div class="button-group">
            <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Lưu" OnClick="btnSave_Click" />
            <asp:Button ID="btnSaveNClose" CssClass="btn btn-primary" runat="server" Text="Lưu và đóng" OnClick="btnSaveNClose_Click" />
            <asp:Button ID="btnSaveNNew" CssClass="btn btn-primary" runat="server" Text="Lưu và tạo mới" OnClick="btnSaveNNew_Click" />
            <a href="ProductList.aspx" class="btn btn-primary">Đóng</a>
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
    <div class="container-fluid">
        <div class="form-row">
            <div class="col">
                <div class="form-row">
                    <div class="col">
                        <label for="productid">Mã sản phẩm</label>
                        <input id="productid" class="form-control" runat="server" required="required" />
                    </div>
                    <div class="col">
                        <label for="productname">Tên sản phẩm</label>
                        <input type="text" class="form-control" id="productname" runat="server" required="required" />
                    </div>

                </div>
                <div class="form-group">
                    <label for="ddlCategory">Loại sản phẩm</label>
                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" DataTextField="Name" DataValueField="Id">
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="cbFeature">Sản phẩm đặc trưng</label>
                    <div>
                        <label class="switch form-control">
                            <input type="checkbox" checked="checked" id="cbFeature" runat="server" />
                            <span class="slider round"></span>
                        </label>
                    </div>
                </div>
                
            </div>
            <div class="col">
                <My:ImageUpload runat="server" ID="imageupload" OnGetError="imageupload_GetError" />
            </div>
        </div>

        <div class="form-row">
            <div class="col">
                <label for="price">Giá bán</label>
                <input type="text" class="form-control" id="price" runat="server" required="required" />
            </div>

            <div class="col">
                <label for="finalprice">Giá hiện tại</label>
                <input type="text" class="form-control" id="finalprice" runat="server" required="required" />
            </div>
            <div class="col">
                <label for="quantity">Số lượng</label>
                <input type="text" class="form-control" id="quantity" runat="server" required="required" />
            </div>
        </div>

        <div class="form-group">
            <label for="shortdescription">Mô tả ngắn </label>
            <textarea class="form-control" rows="3" runat="server" id="shordescription"></textarea>
        </div>
        <div class="form-group">
            <label for="ddlStatus">Trạng Thái</label>
            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" DataTextField="Name" DataValueField="Id">
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="discription">Mô tả</label>
            <textarea class="form-control" rows="5" runat="server" id="discription"></textarea>
        </div>
    </div>
</asp:Content>

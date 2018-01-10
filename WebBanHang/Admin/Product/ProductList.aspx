<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="WebBanHang.Admin.User.ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
    <div class="btn-group">
        <button type="button" class="btn btn-primary" id="addBtn" runat="server" onserverclick="addBtn_ServerClick">Thêm</button>
        <button type="button" class="btn btn-primary" id="deleteBtn" runat="server" onserverclick="deleteBtn_ServerClick">Xóa</button>
        <button type="button" class="btn btn-primary" id="Publish" runat="server" onserverclick="Publish_ServerClick">Khóa</button>
        <button type="button" class="btn btn-primary" id="Unpublish" runat="server" onserverclick="Unpublish_ServerClick">Mở khóa</button>
        <button type="button" class="btn btn-primary" id="SetFeature" runat="server" onserverclick="SetFeature_ServerClick">Đặc trưng</button>
        <button type="button" class="btn btn-primary" id="SetNotFeature" runat="server" onserverclick="SetNotFeature_ServerClick">Bình thường</button>
    </div>
    <div class="container" id="succ_message" runat="server">

    </div>
    <div class="container" id="error_message" runat="server">

    </div>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table" GridLines="None" DataKeyNames="ID">
        <PagerSettings Mode="Numeric" PageButtonCount="10" FirstPageText="First" LastPageText="Last"/>
        <Columns>
            <asp:TemplateField HeaderText="#">
                <ItemTemplate>
                    <asp:CheckBox ID="chbox" runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="~/Admin/Product/EditProduct.aspx?ID={0}"  DataTextField="ID" HeaderText="ID" SortExpression="Username" runat="server"/>
            <asp:BoundField DataField="ProductName" HeaderText="Tên sản phẩm" SortExpression="firstname" runat="server"/>
            <asp:BoundField DataField="CategoryName" HeaderText="Loại" runat="server"/>
            <asp:BoundField DataField="FinalPrice" HeaderText="Giá" runat="server"/>
            <asp:CheckBoxField DataField="Feature" HeaderText="Đặc trưng" />
            <asp:ImageField DataImageUrlField="DisplayImage" HeaderText="Hình ảnh" runat="server" ControlStyle-CssClass="image-fit"/>
            <asp:BoundField DataField="StatusName" HeaderText="Trạng Thái" runat="server" />
        </Columns>
    </asp:GridView>

</form>
</asp:Content>

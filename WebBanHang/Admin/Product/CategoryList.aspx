<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="WebBanHang.Admin.User.CategoryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <form runat="server">
    <div class="btn-group">
        <button type="button" class="btn btn-primary" id="addBtn" runat="server" onserverclick="addBtn_ServerClick">Thêm</button>
        <button type="button" class="btn btn-primary" id="deleteBtn" runat="server" onserverclick="deleteBtn_ServerClick">Xóa</button>
        <button type="button" class="btn btn-primary" id="Publish" runat="server" onserverclick="Publish_ServerClick">Khóa</button>
        <button type="button" class="btn btn-primary" id="Unpublish" runat="server" onserverclick="Unpublish_ServerClick">Mở khóa</button>
    </div>
    <div class="container" id="message" runat="server">

    </div>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table" GridLines="None" DataKeyNames="ID">
        <PagerSettings Mode="Numeric" PageButtonCount="10" FirstPageText="First" LastPageText="Last"/>
        <Columns>
            <asp:TemplateField HeaderText="#">
                <ItemTemplate>
                    <asp:CheckBox ID="chbox" runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="Username" />
            <asp:BoundField DataField="Name" HeaderText="Ten Loai" SortExpression="firstname" />
            <asp:BoundField DataField="CreatedDate" HeaderText="Ngày Tạo"  />
            <asp:BoundField DataField="Username" HeaderText="Người Tạo" />
            <asp:BoundField DataField="StatusName" HeaderText="Trạng Thái" runat="server" />
        </Columns>
    </asp:GridView>

</form>
</asp:Content>

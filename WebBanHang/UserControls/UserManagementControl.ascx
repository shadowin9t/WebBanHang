<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserManagementControl.ascx.cs" Inherits="WebBanHang.UserControls.UserManagementControl" %>
    <div class="btn-group">
        <button type="button" class="btn btn-primary" id="addBtn" runat="server" onserverclick="addBtn_ServerClick">Thêm</button>
        <button type="button" class="btn btn-primary" id="deleteBtn" runat="server" onserverclick="deleteBtn_ServerClick">Xóa</button>
        <button type="button" class="btn btn-primary" id="Publish">Khóa</button>
        <button type="button" class="btn btn-primary" id="Unpublish">Mở khóa</button>
    </div>
    <div class="container" id="message" runat="server">

    </div>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table" GridLines="None" DataKeyNames="username">
        <PagerSettings Mode="Numeric" PageButtonCount="10" FirstPageText="First" LastPageText="Last"/>
        <Columns>
            <asp:TemplateField HeaderText="#">
                <ItemTemplate>
                    <asp:CheckBox ID="chbox" runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:HyperLinkField DataTextField="username" 
                DataNavigateUrlFields ="username"
                DataNavigateUrlFormatString="~/Admin/User/EditUser.aspx?username={0}" 
                HeaderText="Tên tài khoản" SortExpression="Username" />
            <asp:BoundField DataField="firstname" HeaderText="Họ" SortExpression="firstname" />
            <asp:BoundField DataField="lastname" HeaderText="Tên"  />
            <asp:BoundField DataField="email" HeaderText="Email" />
        </Columns>
    </asp:GridView>
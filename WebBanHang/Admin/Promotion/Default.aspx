<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebBanHang.Admin.Promotion.PromotionList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Khuyến mãi</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <h3>Danh sách quảng cáo</h3>
    <div class="btn-group">
        <button class="btn btn-primary">Thêm</button>
        <button class="btn btn-primary">Xóa</button>
        <button class="btn btn-primary">Khóa</button>
        <button class="btn btn-primary">Mở khóa</button>
    </div>
    <div class="container">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" CssClass="table" GridLines="None">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbPromotion" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="/Admin/Promotion/EditPromotion.aspx?id={0}" DataTextField="ID" HeaderText="Mã" runat="server"/>
                <asp:BoundField DataField="Title" HeaderText="Tiêu đề" runat="server"/>
                <asp:BoundField DataField="StatusName" HeaderText="Trạng thái" runat="server"/>                
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

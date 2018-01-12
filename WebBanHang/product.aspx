<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="WebBanHang.product" %>

<%@ Register Src="~/UserControls/Product/ProductSumary.ascx" TagName="ProductSumary" TagPrefix="My" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <asp:ListView runat="server" ID="listview" OnPagePropertiesChanging="listview_PagePropertiesChanging">
        <EmptyDataTemplate>
            <div class="container" runat="server">Hiện chưa có sản phẩm nào</div>
        </EmptyDataTemplate>
        <LayoutTemplate>
            <div class="container-fluid">
                <div class="form-inline">
                    <label for="selectprice">Giá</label>
                    <select class="form-control" id="selectprice">
                        <option>Tất cả</option>
                        <option>Dưới 2 triệu</option>
                        <option>Từ 2-5 triệu</option>
                        <option>Từ 5-10 triệu</option>
                        <option>Trên 10 triệu</option>
                    </select>

                    <label for="selectpriceorder">Giá</label>
                    <select class="form-control" id="selectpriceorder">
                        <option>Tăng dần</option>
                        <option>Giảm dần</option>
                    </select>


                    <label for="createddate">Ngày ra mắt</label>
                    <select class="form-control" id="createddate">
                        <option>Tăng dần</option>
                        <option>Giảm dần</option>
                    </select>


                    <div class="form-group">
                        <label for="keywordproduct">Giá</label>
                        <input type="text" class="form-control" id="keywordproduct" />
                    </div>

                    <button class="btn">Lọc</button>


                    <label>Trang </label>
                    <asp:DataPager runat="server" PageSize="8" ID="DataPager1" PagedControlID="listview">
                        <Fields>
                            <asp:NumericPagerField ButtonType="Link" />
                        </Fields>
                    </asp:DataPager>

                </div>

            </div>

            <div class="row">
                <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="col-lg-3 col-md-6 mb-4" id="itemPlaceholder" runat="server">
                <My:ProductSumary runat="server" ProductID='<%#Eval("ID") %>' />
            </div>

        </ItemTemplate>
    </asp:ListView>

</asp:Content>

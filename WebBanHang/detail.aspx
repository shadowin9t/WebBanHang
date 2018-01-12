<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="WebBanHang.detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="row">
        <div class="col-lg-6">
            <div style="width: 100%">
                <img src="images/products/default.png" style="display: block; margin-left: auto; margin-right: auto" runat="server" id="productimage"/>
            </div>
        </div>
        <div class="col-lg-6">
            <div class="card text-center" style="margin:5px">
                <div class="card-block">
                    <h4 class="card-title" id="productheader" runat="server">Card title</h4>
                    <p class="card-text" id="productprice" runat="server">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                </div>
                <ul class="list-group list-group-flush" id="shortdescription" runat="server">
                </ul>
                <div class="card-block" >
                    <button id="addtocart" class="btn btn-primary btn-sm btn-block" runat="server" onserverclick="addtocart_ServerClick">Mua hàng</button>
                </div>
            </div>
        </div>
        <div class="container-fluid" id="discription" runat="server">

        </div>
    </div>
</asp:Content>

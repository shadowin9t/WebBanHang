<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductSumary.ascx.cs" Inherits="WebBanHang.UserControls.ProductSumary" %>

<div class="card h-100">
    <div style="height: 67%; display: inline-block">
        <img runat="server" id="imgproduct" class="card-img-top" style="max-height: 100%; max-width: 100%;" />
    </div>
    <div class="card-body">
        <h4 class="card-title">
            <a id="ProductHeader" runat="server" href="#"></a>
        </h4>
        <h5 runat="server" id="hfinalprice">$24.99</h5>
        <p runat="server" id="pfeature" class="card-text">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!</p>
    </div>
    <div class="card-footer">
        <button class="btn">Mua</button>
    </div>
</div>

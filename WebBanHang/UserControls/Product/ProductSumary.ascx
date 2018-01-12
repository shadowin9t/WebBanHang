<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductSumary.ascx.cs" Inherits="WebBanHang.UserControls.ProductSumary" %>

    <div class="card h-100">
        <div style="height:67%; display:inline-block">
        <img runat="server" ID="imgproduct" class="card-img-top" style="max-height:100%; max-width:100%;" />
            </div>
        <div class="card-body">
            <h4 class="card-title">                
                <a ID="ProductHeader" runat="server" href="#"></a>
            </h4>

            <h5 runat="server" ID="hfinalprice">$24.99</h5>
            <p runat="server" ID="pfeature" class="card-text">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!</p>
        </div>
        <div class="card-footer">
            <small class="text-muted">&#9733; &#9733; &#9733; &#9733; &#9734;</small>
        </div>
    </div>

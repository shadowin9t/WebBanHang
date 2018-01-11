<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductSumary.ascx.cs" Inherits="WebBanHang.UserControls.ProductSumary" %>

    <div class="card h-100">
        <img runat="server" ID="imgproduct" style="width:100%; height:auto;" class="card-img-top" />
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

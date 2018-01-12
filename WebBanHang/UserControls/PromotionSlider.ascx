<%@ Control Language="C#" AutoEventWireup="true" ClientIDMode="Static" CodeBehind="PromotionSlider.ascx.cs" Inherits="WebBanHang.UserControls.PromotionSlider" %>
<div id="myCarousel" class="carousel slide" data-ride="carousel" style="width:100%; max-height:400px; overflow:hidden;">
  <!-- Indicators -->
  <ol class="carousel-indicators" runat="server" id="Indicators">
  </ol>

  <!-- Wrapper for slides -->
  <div class="carousel-inner" role="listbox" runat="server" id="Inners">
   
  </div>

  <!-- Left and right controls -->
  <a class="carousel-control-prev" href="#myCarousel" data-slide="prev" role="button">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="carousel-control-next" href="#myCarousel" data-slide="next" role="button">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>
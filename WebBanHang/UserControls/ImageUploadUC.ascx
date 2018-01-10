<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImageUploadUC.ascx.cs" Inherits="WebBanHang.UserControls.ImageUploadUC" %>
    <div>
        <asp:FileUpload runat="server" ID="fileupload"/>
        <button class="btn" runat="server" onserverclick="Unnamed_ServerClick">Upload</button>
    </div>
    <asp:Image style="width:100%;height:auto;" id="image" runat="server"/>

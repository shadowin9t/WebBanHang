<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImageUploadUC.ascx.cs" Inherits="WebBanHang.UserControls.ImageUploadUC" %>
<div class="form-row form-group align-items-center">
    <div class="col-auto">
        <div>
            <input type="file" class="form-control-file" id="UploadedFile" itemid="UploadedFile" runat="server" />
        </div>
    </div>
    <div class="col-auto">
        <button class="btn btn-sm" runat="server" onserverclick="Unnamed_ServerClick">Upload</button>
    </div>
</div>
<div class="form-group">
    <asp:Image Style="width: 100%; height: auto;" ID="image" runat="server" />
</div>

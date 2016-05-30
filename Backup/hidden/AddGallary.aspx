<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddGallary.aspx.cs" Inherits="ChatME.hidden.AddGallary" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function fileUploaded(sender, args) {
            var filename = args.get_fileName();
            window.parent.removeGallaryUpload();
        }  
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="scriptManager" runat="server">
        </asp:ScriptManager>
        <asp:HiddenField ID="hdnFileName" runat="server" />
        <ajaxToolkit:AsyncFileUpload runat="server" ID="AsyncFileUpload1" Width="400px" UploaderStyle="Modern"
            UploadingBackColor="#CCFFFF" ThrobberID="myThrobber" OnUploadedComplete="UploadComplete"
            OnClientUploadComplete="fileUploaded" ClientIDMode="Static" />
    </div>
    </form>
</body>
</html>

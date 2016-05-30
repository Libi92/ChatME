﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fileupload.aspx.cs" Inherits="ChatME.hidden.fileupload" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function fileUploaded(sender, args) {
            var filename = args.get_fileName();
            var btnSubmit = window.parent.document.getElementById("btnPost");
            btnSubmit.removeAttribute("disabled"); ;
            window.parent.document.getElementById("ImageName").value = filename;
            window.parent.removeFileUpload();
        }
        function disablePostButton(sender, args) {
            window.parent.document.getElementById("btnPost").setAttribute("disabled", "disabled");
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
            OnClientUploadComplete="fileUploaded" ClientIDMode="Static" OnClientUploadStarted="disablePostButton" />
    </div>
    </form>
</body>
</html>
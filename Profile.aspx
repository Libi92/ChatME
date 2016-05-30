<%@ Page Title="" Language="C#" MasterPageFile="~/ChatME.Master" AutoEventWireup="true"
    CodeBehind="Profile.aspx.cs" Inherits="ChatME.Profile" %>

<%@ Register TagPrefix="uc" TagName="EditProfile" Src="~/UserControls/EditProfile.ascx" %>
<%@ Register TagPrefix="uc" TagName="ViewProfile" Src="~/UserControls/ViewProfile.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="style/style.css" rel="stylesheet" type="text/css" />
    <script src="Script/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="Script/Home/friends.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divShare" style="margin-left: 0%; margin-right: auto; width: 85%; margin-top: 0px;
        border: 1px solid gray; box-shadow: -5px -5px 5px gray; background-color: #F0ECF0;
        overflow: scroll; height:700px;">
        <div style="width: 800px; margin-left: auto; margin-right: auto;">
            <div style="text-align: right; width: 100%; padding: 10px;">
                <asp:Panel ID="pnlSendFriendRequest" runat="server">
                    <span class="GlobalFontB">Select Privacy:</span>
                    <select id="ddlPrivacy" runat="server" clientidmode="Static" class="GlobalFontB">
                        <option value="1" selected="selected">Friend</option>
                        <option value="2">Family</option>
                        <option value="3">Private</option>
                    </select><br />
                    <asp:LinkButton ID="lnkSendRequest" runat="server" Text="Send Request" CssClass="Messages"></asp:LinkButton></asp:Panel>
                <asp:Label ID="lblStatus" runat="server" CssClass="GlobalFontB"></asp:Label>
                <asp:LinkButton ID="lnkEditProfile" runat="server" OnClick="btnEditProfile_Click"
                    Text="Edit Profile" Visible="false"></asp:LinkButton>
            </div>
        </div>
        <uc:EditProfile ID="editProfile" runat="server" Visible="false" />
        <uc:ViewProfile ID="ViewProfile" runat="server" />
    </div>
</asp:Content>

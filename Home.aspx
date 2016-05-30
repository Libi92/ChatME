<%@ Page Title="" Language="C#" MasterPageFile="~/ChatME.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="ChatME.Home" ViewStateMode="Disabled" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Script/Home/Post.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divContent">
        <div id="divShare" style="margin-left: 0%; margin-right: auto; width: 85%; margin-top: 0px;
            border: 1px solid gray; box-shadow: -5px -5px 5px gray; background-color: #F0ECF0;">
            <div style="width: 90%; text-align: left; margin-left: 20px; font-size: 25px;">
                <div style="margin-left: auto; margin-right: auto; width: 100%; padding: 20px; border-radius: 0;">
                    <table cellpadding="0" cellspacing="15" width="100%">
                        <tr>
                            <td valign="top" align="center" class="tdUserImg">
                                <img style="width: 50px; height: 50px;" id="usrImg" runat="server" clientidmode="Static" />
                            </td>
                            <td class="tdUserMessage" style="height: 20px; padding-top: 5px; padding-left: 0px;
                                background-color: White;" onclick='animateHeight(this);'>
                                <div id="divPost0" style="background-color: Silver; margin-top: -5px; background-color: White;">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td style="width: 20%">
                                                <img src="../style/Images/liveChat.jpg" height="50px" width="100px" />
                                            </td>
                                            <td>
                                                What's running in your head?
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="divPost" style="background-color: White; margin-top: -5px; display: none;">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td style="width: 20%">
                                                <img src="../style/Images/liveChat.jpg" height="50px" width="100px" />
                                            </td>
                                            <td>
                                                What's running in your head?
                                            </td>
                                        </tr>
                                    </table>
                                    <div style="padding-bottom: 10px; padding-left: 5px; background-color: #006699;">
                                        <asp:LinkButton ID="lnkButton" runat="server" Text="Add Photo" OnClientClick="return addPhoto(this);"
                                            Style="font-size: 12px;" CssClass="button"></asp:LinkButton>
                                        <div style="display: none; padding-bottom: 5px;" id="divUploadImage">
                                        </div>
                                        <asp:TextBox ID="txtShare" TextMode="MultiLine" ClientIDMode="Static" runat="server"
                                            Width="97%" Height="20px">
                                        </asp:TextBox>
                                        <asp:DropDownList ID="ddlWhom" runat="server">
                                            <asp:ListItem Text="Public" Value="0">
                                            </asp:ListItem>
                                            <asp:ListItem Text="Friend" Value="1" Selected="True">
                                            </asp:ListItem>
                                            <asp:ListItem Text="Private" Value="2">
                                            </asp:ListItem>
                                            <asp:ListItem Text="Family" Value="3">
                                            </asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:HiddenField ID="ImageName" runat="server" ClientIDMode="Static" />
                                        <input type="button" id="btnPost" value="Post" onclick="submitPost(this);" class="button" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <table id="tbltable" cellpadding="0" cellspacing="15" width="100%">
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

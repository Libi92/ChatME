<%@ Page Title="" Language="C#" MasterPageFile="~/ChatME.Master" AutoEventWireup="true"
    CodeBehind="RequestNotification.aspx.cs" Inherits="ChatME.RequestNotification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Script/Home/friends.js" type="text/javascript"></script>
    <script src="Script/jquery-1.7.1.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divContent">
        <div id="divShare" style="margin-left: 0%; margin-right: auto; width: 85%; margin-top: 0px;
            border: 1px solid gray; box-shadow: -5px -5px 5px gray; background-color: #F0ECF0;">
            <div style="width: 800px; margin-left: auto; margin-right: auto;" id="Notifiction" runat="server">
                <asp:Repeater ID="rptRequestNotification" runat="server">
                    <ItemTemplate>
                        <div style="margin: 10px; border: 1px solid gray; border-radius: 10px; background-color: White;
                            padding: 5px;">
                            <table cellpadding="0" width="80%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td valign="top" align="center" class="tdUserImg" style="width: 10%;">
                                        <img style="width: 50px; height: 50px;" id="usrImg" runat="server" clientidmode="Static"
                                            src=' <%# "UserImages/"+ DataBinder.Eval(Container.DataItem, "UserImage") %>'
                                            onclick='<%# GetOnclick(DataBinder.Eval(Container.DataItem,"FromID")) %>' />
                                    </td>
                                    <td style="height: 20px; padding-top: 5px; font-weight: bold;">
                                        <span class="GlobalFontB">
                                            <%# DataBinder.Eval(Container.DataItem, "FromName")%>&nbsp; wants to be your friend</span><br />
                                        <div class="GlobalFontB">
                                            Privacy Label:
                                            <%# GetPrivacyLable(DataBinder.Eval(Container.DataItem, "Privacy"))%></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="Messages">
                                        <a id='<%# "lnkRequestApprove"+DataBinder.Eval(Container.DataItem,"RowNumber") %>'
                                            href="#" onclick='<%# "return ApproveRejectRequest(" + DataBinder.Eval(Container.DataItem, "NotificationID")%> <%# ",1,"+ DataBinder.Eval(Container.DataItem, "RowNumber") +");"%>'>
                                            Accept</a>&nbsp;&nbsp;&nbsp;<a id='<%# "lnkRequestReject"+ DataBinder.Eval(Container.DataItem,"RowNumber") %>'
                                                href="#" onclick='<%# "return ApproveRejectRequest(" + DataBinder.Eval(Container.DataItem, "NotificationID")%> <%# ",2,"+ DataBinder.Eval(Container.DataItem, "RowNumber") +");"%>'>
                                                Reject</a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater ID="rptResponseNotification" runat="server">
                    <ItemTemplate>
                        <div style="margin: 10px; border: 1px solid gray; border-radius: 10px; background-color: White;
                            padding: 5px;">
                            <table cellpadding="0" width="80%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td valign="top" align="center" class="tdUserImg" style="width: 10%;">
                                        <img style="width: 50px; height: 50px;" id="usrImg" runat="server" clientidmode="Static"
                                            src=' <%# "UserImages/"+ DataBinder.Eval(Container.DataItem, "UserImage") %>'
                                            onclick='<%# GetOnclick(DataBinder.Eval(Container.DataItem,"FromID")) %>' />
                                    </td>
                                    <td style="height: 20px; padding-top: 5px; font-weight: bold;">
                                        <div class="GlobalFontB">
                                            <span><b>
                                                <%#DataBinder.Eval(Container.DataItem, "FromName") %></b></span>&nbsp;&nbsp;
                                            <%# GetResponseMessage(DataBinder.Eval(Container.DataItem, "FriendRequestStatus"))%></div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>

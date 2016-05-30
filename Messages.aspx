<%@ Page Title="" Language="C#" MasterPageFile="~/ChatME.Master" AutoEventWireup="true"
    CodeBehind="Messages.aspx.cs" Inherits="ChatME.Messages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Script/Home/Messages.js" type="text/javascript"></script>
    <style type="text/css">
        #messages td
        {
            padding-top: 3px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divContent">
        <div id="divShare" style="margin-left: 0%; margin-right: auto; width: 85%; margin-top: 0px;
            border: 1px solid gray; box-shadow: -5px -5px 5px gray; background-color: #F0ECF0;">
            <asp:Repeater ID="rptMessages" runat="server">
                <ItemTemplate>
                    <div style="margin: 10px; padding: 8px;">
                        <table cellpadding="0" width="100%" cellpadding="0" cellspacing="0" id="messages">
                            <tr>
                                <td valign="top" align="center" class="tdUserImg" style="width: 15%;">
                                    <img style="width: 50px; height: 50px; border-radius: 5px; box-shadow: 0 0 10px white;"
                                        id="usrImg" runat="server" clientidmode="Static" src=' <%# "UserImages/"+ DataBinder.Eval(Container.DataItem, "UserImage") %>' />
                                </td>
                                <td style="height: 20px; padding-top: 5px;">
                                    <div <%# IsUnReadMessage(DataBinder.Eval(Container.DataItem,"Status")) %> class="Messages">
                                        <asp:LinkButton ID="lnkSender" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserName") %>'
                                            OnClientClick='<%# "redirectToMessages("+DataBinder.Eval(Container.DataItem, "ChatFrom")+");" %>'
                                            href="#"></asp:LinkButton><br />
                                        <asp:Label ID="lblMessage" runat="server"> <%# DataBinder.Eval(Container.DataItem, "Message") %></asp:Label><br />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>

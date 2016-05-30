<%@ Page Title="" Language="C#" MasterPageFile="~/ChatME.Master" AutoEventWireup="true"
    CodeBehind="SearchFriend.aspx.cs" Inherits="ChatME.SearchFriend" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="utPanel" runat="server">
        <ContentTemplate>
            <asp:TextBox ID="txtFriendSearch" runat="server" Width="300"></asp:TextBox>&nbsp;&nbsp;
            <asp:Button ID="btnFriendSearcg" runat="server" OnClick="btnFriendSearch_Click" Text="Search" />
            <asp:Panel ID="pnlResult" runat="server" Width="50%">
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

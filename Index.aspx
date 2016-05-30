<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ChatME.Index"
    ViewStateMode="Disabled" EnableEventValidation="false" %>

<%@ Register TagName="Chat" TagPrefix="uc" Src="~/UserControls/chatControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="mainHeader">
    <title>Chat ME</title>
    <script src="Script/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="Script/Home/MultiChat.js" type="text/javascript"></script>
    <script src="Script/Home/friends.js" type="text/javascript"></script>
    <link href="style/style.css" rel="stylesheet" type="text/css" />
    <link href="style/colorbox.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #toDiv a
        {
            color: White;
        }
        .disabled
        {
            opacity: 0.4;
            filter: alpha(opacity=40);
        }
        .enabled
        {
            opacity: 1.0;
            filter: alpha(opacity=40);
        }
        body
        {
            background-repeat: no-repeat;
            background-attachment: fixed;
        }
        .rotate
        {
            transform: rotate(-90deg);
            -ms-transform: rotate(-90deg); /* IE 9 */
            -webkit-transform: rotate(-90deg); /* Safari and Chrome */
            -o-transform: rotate(-90deg); /* Opera */
            -moz-transform: rotate(-90deg);
        }
        div#divAddTask:hover
        {
            left: 0px;
        }
        .background
        {
            /* IE9 SVG, needs conditional override of 'filter' to 'none' */
            background: url(data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiA/Pgo8c3ZnIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgd2lkdGg9IjEwMCUiIGhlaWdodD0iMTAwJSIgdmlld0JveD0iMCAwIDEgMSIgcHJlc2VydmVBc3BlY3RSYXRpbz0ibm9uZSI+CiAgPGxpbmVhckdyYWRpZW50IGlkPSJncmFkLXVjZ2ctZ2VuZXJhdGVkIiBncmFkaWVudFVuaXRzPSJ1c2VyU3BhY2VPblVzZSIgeDE9IjAlIiB5MT0iMCUiIHgyPSIwJSIgeTI9IjEwMCUiPgogICAgPHN0b3Agb2Zmc2V0PSIwJSIgc3RvcC1jb2xvcj0iIzdlY2ZlOCIgc3RvcC1vcGFjaXR5PSIwIi8+CiAgICA8c3RvcCBvZmZzZXQ9IjkwJSIgc3RvcC1jb2xvcj0iIzI1NzhhMCIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgICA8c3RvcCBvZmZzZXQ9Ijk3JSIgc3RvcC1jb2xvcj0iIzFlNzE5YSIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgPC9saW5lYXJHcmFkaWVudD4KICA8cmVjdCB4PSIwIiB5PSIwIiB3aWR0aD0iMSIgaGVpZ2h0PSIxIiBmaWxsPSJ1cmwoI2dyYWQtdWNnZy1nZW5lcmF0ZWQpIiAvPgo8L3N2Zz4=);
            background: -moz-linear-gradient(top,  rgba(126,207,232,0) 0%, rgba(37,120,160,1) 90%, rgba(30,113,154,1) 97%); /* FF3.6+ */
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,rgba(126,207,232,0)), color-stop(90%,rgba(37,120,160,1)), color-stop(97%,rgba(30,113,154,1))); /* Chrome,Safari4+ */
            background: -webkit-linear-gradient(top,  rgba(126,207,232,0) 0%,rgba(37,120,160,1) 90%,rgba(30,113,154,1) 97%); /* Chrome10+,Safari5.1+ */
            background: -o-linear-gradient(top,  rgba(126,207,232,0) 0%,rgba(37,120,160,1) 90%,rgba(30,113,154,1) 97%); /* Opera 11.10+ */
            background: -ms-linear-gradient(top,  rgba(126,207,232,0) 0%,rgba(37,120,160,1) 90%,rgba(30,113,154,1) 97%); /* IE10+ */
            background: linear-gradient(to bottom,  rgba(126,207,232,0) 0%,rgba(37,120,160,1) 90%,rgba(30,113,154,1) 97%); /* W3C */
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#007ecfe8', endColorstr='#1e719a',GradientType=0 ); /* IE6-8 */
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#divAddTask").mouseenter(function () {
                $("#divAddTask").animate({ "left": "0px" });
            })
            $("#divAddTask").mouseleave(function () {
                $("#divAddTask").animate({ "left": "-100px" });
            })
        });
        function RepairModel() {
            $(".inline").colorbox({ inline: true, width: "50%", overlayClose: 0, escKey: 0 });
        }
    </script>
</head>
<body style="margin: 0px; overflow-x: hidden;" class="background">
    <form method="post" runat="server">
    <div id="divheaderContent" style="display: none;">
    </div>
    <div style='display: none'>
        <div id="divAddReminder" style='padding: 10px; background: #fff; height: 200px;'>
            Add Reminder
            <hr />
            Select Time When you want to be inform&nbsp;&nbsp;&nbsp;<select id="ddlTime">
                <option value="1">1</option>
                <option value="10">10</option>
                <option value="15">15</option>
                <option value="20">20</option>
                <option value="25">25</option>
                <option value="30">30</option>
                <option value="35">35</option>
                <option value="40">40</option>
                <option value="60">60</option>
            </select><br />
            <span id="add" style="color: Blue;" onclick="addReminder(this);"><u>Add</u></span>
            <br />
            <h3 id="h3Reminder" style="display: none;">
                Reminder Added</h3>
        </div>
        <div id='ReminderAlert' style='padding: 10px; background: #fff;'>
            <center>
                <div style="text-align: left;">
                    <h3>
                        You have reached your time Limit</h3>
                    <br />
                    <a href="Logout.aspx">Logout..</a><br />
                    <a href="#" class="close">Continue..</a>
                </div>
            </center>
        </div>
        <a class='inline' href="#ReminderAlert" id="aReminderAlert">Add Reminder</a></div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="box-shadow: 0 0 10px gray;">
                <div style="float: left; vertical-align: top; width: 10%; font-size: 20px; font-family: Verdana;
                    vertical-align: top; height: 35px; color: White; background-color: DarkGreen;
                    cursor: pointer;" onclick="setIUrl('Home.aspx');">
                    CHAT ME
                </div>
                <div style="height: 35px; float: right; text-align: right; vertical-align: top; width: 90%;
                    background-color: #006699;" id="toDiv">
                    <table width="100%">
                        <tr>
                            <td style="width: 50%;">
                            </td>
                            <td align="left">
                                <input id="txtCountry" onkeyup="javascript:searchFrindList(this);" type="text" />
                                <div id="divSearch" style="position: absolute; width: 300px; background-color: #006699;
                                    color: White;">
                                </div>
                            </td>
                            <td>
                                <asp:LinkButton ID="lblUser" runat="server"></asp:LinkButton>
                            </td>
                            <td>
                                <asp:Image runat="server" ID="imgUser" Width="25" Height="25" Style="margin-top: -2px;"
                                    ToolTip="Profile" />
                            </td>
                            <td>
                                <a id="lnkNewMessages" onclick="setIUrl('Messages.aspx');" href="#">
                                    <asp:Image runat="server" ID="imgMessage" ImageUrl="~/style/Images/images.jpg" Width="20"
                                        Height="20" Style="margin-top: -2px;" ToolTip="New Massage" /></a>
                            </td>
                            <td>
                                <a id="lnkNewNotifications" onclick="setIUrl('RequestNotification.aspx');">
                                    <asp:Image runat="server" ID="imgNotification" ImageUrl="~/style/Images/Apps-preferences-desktop-notification-icon.png"
                                        Width="20" Height="20" Style="margin-top: -2px;" ToolTip="Notifications" /></a>
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkLogout" runat="server" OnClick="lnkLogout_Click" Text="Logout"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div id="divAddTask" style="position: absolute; top: 40px; left: -100px; max-width: 120px;
                    height: 150px; background-color: Green;">
                    <table width="100%" style="height: 150px;" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width: 110px; color: green; background-color: White; font-size: 14px;
                                font-weight: bold; padding-top: 20px;" valign="top">
                                <div>
                                    <a class='inline' href="#divAddReminder" onclick="RepairModel();">Add Reminder</a></div>
                                <br />
                                <div>
                                    <a href="#Private" name="modal">Go Private</a></div>
                                <br />
                                <div>
                                    <a href="#" onclick="setIUrl('gallary.aspx');">Gallary</a></div>
                            </td>
                            <td style="max-width: 25px; border: 1px solid black; background-color: green; padding-bottom: 0px;
                                color: white; font-weight: bold; height: 100px;">
                                <div style="margin-left: 0px; margin-bottom: -20px" class="rotate">
                                    Task</div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="divIframe" style="display: none;">
                </div>
                <div id="divNoIframe" style="overflow: scroll; overflow-x: hidden; min-height: 800px;
                    width: 100%; margin-top: 20px; margin-left: 40px; right: 0px; bottom: 50px;">
                </div>
            </td>
        </tr>
    </table>
    <uc:Chat ID="ucChat" runat="server"></uc:Chat>
    </form>
</body>
</html>

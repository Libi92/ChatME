<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="ChatME._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        input[type="text"], input[type="password"]
        {
            background-color: white;
        }
        body
        {
            color: White;
            font-family: Verdana;
            font-size: 14px;
        }
        #tdRegister
        {
            line-height: 25px;
         }
    </style>
</head>
<body style="margin: 0px; background-color: green;">
    <div style="width: 100%; height: 900px; overflow: hidden; background-color: blue;
        opacity: .4;">
    </div>
    <div style="position: fixed; top: 0px; width: 100%;">
        <form id="form1" runat="server">
        <table width="100%" height="640px" cellpadding="0" cellspacing="0" style="margin: 0px;">
            <tr>
                <td style="width: 70%; height: 70px;" colspan="2">
                    <table width="100%">
                        <tr>
                            <td width="60%">
                                <font size="6" color="White">Chat Online</font>
                            </td>
                            <td width="15%">
                                User Name
                                <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                            </td>
                            <td width="15%">
                                Password
                                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
                            </td>
                            <td width="10%">
                                <br />
                                <asp:Button ID="btnLogin" Text="Login" type="submit" runat="server" OnClick="btnLogin_Click"
                                    ForeColor="Black" BorderStyle="Outset"></asp:Button>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1">
                                &nbsp;
                            </td>
                            <td colspan="3">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 70%; height: 570px; background-color: White;" valign="middle" align="center">
                    <div style="border: 1px solid white; border-radius: 0px 30px 0px 0px; opacity: .9;">
                        <img src="style/Images/rainDrop.jpg" style="height: 570px; border-radius: 0px 20px 0px 0px;" />
                    </div>
                </td>
                <td id="tdRegister" style="width: 30%; height: 570px; padding-left: 20px;" valign="top">
                    <br />
                    <font size="5">Register</font>
                    <div>
                        First Name</div>
                    <div>
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></div>
                    <div>
                        Last Name</div>
                    <div>
                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></div>
                    <div>
                        User Name</div>
                    <div>
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></div>
                    <div>
                        Password</div>
                    <div>
                        <asp:TextBox ID="txtPassword2" runat="server" TextMode="Password"></asp:TextBox></div>
                    <div>
                        Email
                    </div>
                    <div>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></div>
                    <div>
                        Cell Number</div>
                    <div>
                        <asp:TextBox ID="txtCellNumber" runat="server"></asp:TextBox></div>
                    <div>
                        City</div>
                    <div>
                        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox></div>
                    <div>
                        State</div>
                    <div>
                        <asp:TextBox ID="txtState" runat="server"></asp:TextBox></div>
                    <div>
                        Country</div>
                    <div>
                        <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox></div>
                    <div>
                        Sex</div>
                    <div>
                        <asp:RadioButtonList ID="rdlSexList" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Male" Value="M" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div>
                        <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register" />
                    </div>
                    <div>
                        <asp:Label ID="lblError" runat="server" Visible="false" Text="Register"></asp:Label>
                    </div>
                </td>
            </tr>
        </table>
        </form>
    </div>
</body>
</html>

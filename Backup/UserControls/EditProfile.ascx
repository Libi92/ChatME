<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditProfile.ascx.cs"
    Inherits="ChatME.UserControls.EditProfile1" %>
<table id="tblProfile" cellpadding="0" cellpadding="0" width="100%" style="margin:0px;">
    <tr>
        <td valign="middle">
            <div style="height: 100px; background-color: #006699; width: 100%;">
                <asp:Label ID="userName" runat="server" Text="Vijay Tanwar" ClientIDMode="Static"
                    CssClass='userName' Style="margin-left: 400px;"></asp:Label>
            </div>
            <asp:Image Height="200px" Width="200px" ImageUrl="~/UserImages/photo.jpg" ID="imgUser"
                runat="server" Style="margin-top: -150px; margin-left: 120px; border: 2px solid gray;
                background-color: Gray;" />
            <asp:FileUpload ID="fileUpload" runat="server" />
            <asp:HiddenField ID="imgName" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="padding-left: 90px;">
            <span class="tag">OLine Description</span>
            <br />
            <asp:TextBox ID="txtDescritpion" runat="server" Width="400" MaxLength="100"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="padding-left: 90px;">
            <span class="tag">About</span>
            <br />
            <asp:TextBox ID="txtAbout" runat="server" TextMode="MultiLine" Height="40px" Width="400"
                MaxLength="600"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="padding-left: 90px;">
            <span class="tag">Something Special About You</span>
            <br />
            <asp:TextBox ID="txtSpecial" runat="server" Width="400" MaxLength="100"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="padding-left: 90px;">
            <fieldset>
                <legend><b>Occupation</b></legend>
                <table>
                    <tr>
                        <td>
                            <span class="tag">Occupation</span>
                            <br />
                            <asp:TextBox ID="txtOccupation" runat="server" Width="300" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="tag">Role</span>
                            <br />
                            <asp:TextBox ID="txtRole" runat="server" Width="400" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="tag">Company</span>
                            <br />
                            <asp:TextBox ID="txtCompany" runat="server" Width="400" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </td>
    </tr>
    <tr>
        <td style="padding-left: 90px;">
            <fieldset>
                <legend><b>Study</b></legend>
                <table>
                    <tr>
                        <td>
                            <span class="tag">Collage</span>
                            <br />
                            <asp:TextBox ID="txtCollage" runat="server" Width="400" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="tag">Schooling</span>
                            <br />
                            <asp:TextBox ID="txtSchool" runat="server" Width="400" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </td>
    </tr>
    <tr>
        <td style="padding-left: 90px;">
            <fieldset>
                <legend><b>Contact</b></legend>
                <table>
                    <tr>
                        <td>
                            <span class="tag">Cell</span>
                            <br />
                            <asp:TextBox ID="txtCell" runat="server" Width="400" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="tag">Email</span>
                            <br />
                            <asp:TextBox ID="txtEmail" runat="server" Width="400" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="tag">IM</span>
                            <br />
                            <asp:TextBox ID="txtIM" runat="server" Width="400" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </td>
    </tr>
    <tr>
        <td style="padding-left: 90px;">
            <fieldset>
                <legend><b>Address</b></legend>
                <table>
                    <tr>
                        <td>
                            <span class="tag">City</span>
                            <br />
                            <asp:TextBox ID="txtCity" runat="server" Width="400" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="tag">State</span>
                            <br />
                            <asp:TextBox ID="txtState" runat="server" Width="400" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="tag">Country</span>
                            <br />
                            <asp:TextBox ID="txtCountry" runat="server" Width="400" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="tag">Postal code</span>
                            <br />
                            <asp:TextBox ID="txtPostalCode" runat="server" Width="400" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </td>
    </tr>
    <tr>
        <td style="padding-left: 120px;">
            <span class="tag">Current Status</span>
            <br />
            <asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Text="Single" Value="0"></asp:ListItem>
                <asp:ListItem Text="Married" Value="1"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td style="padding-left: 120px;">
            <span class="tag">Here For</span>
            <br />
            <asp:CheckBoxList ID="chlHereFor" runat="server">
                <asp:ListItem Text="Friends" Value="Friends"></asp:ListItem>
                <asp:ListItem Text="Dating" Value="Dating"></asp:ListItem>
                <asp:ListItem Text="Relationship" Value="Relationship"></asp:ListItem>
                <asp:ListItem Text="Networking" Value="Networking"></asp:ListItem>
            </asp:CheckBoxList>
        </td>
    </tr>
    <tr>
        <td style="padding-left: 90px;">
            <fieldset>
                <legend><b>Online Profile</b></legend>
                <table>
                    <tr>
                        <td>
                            <span class="tag">Link 1</span>
                            <br />
                            <asp:TextBox ID="txtOnlineLink" runat="server" Width="300" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </td>
    </tr>
    <tr>
        <td style="padding-left: 120px;">
            <fieldset style="background-color: White;">
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" Text="Save Profile" OnClick="btnSave_ProfileClicked">
                            </asp:Button>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </td>
    </tr>
</table>

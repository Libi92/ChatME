<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewProfile.ascx.cs"
    Inherits="ChatME.UserControls.ViewProfile1" %>
<div>
    <table id="tblProfile" cellpadding="0" cellpadding="0" width="104%" style="margin-top: 50px;
        margin-left: -4%;">
        <tr>
            <td valign="middle">
                <div style="height: 100px; background-color: #006699; width: 100%;">
                    <asp:Label ID="userName" runat="server" Text="Vijay Tanwar" ClientIDMode="Static"
                        CssClass='userName' Style="margin-left: 400px;" Enabled="false"></asp:Label>
                </div>
                <asp:Image Height="200px" Width="200px" ID="imgUser" runat="server" Style="margin-top: -150px;
                    margin-left: 120px; border: 2px solid gray; background-color: Gray;" Enabled="false" />
            </td>
        </tr>
        <tr>
            <td style="padding-left: 120px;">
                <span class="tag">OLine Description</span>
                <br />
                <asp:Label ID="txtDescritpion" runat="server" Width="400" MaxLength="100" CssClass="tagData"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 120px;">
                <span class="tag">About</span>
                <br />
                <asp:Label ID="txtAbout" runat="server" Height="40px" Width="400" CssClass="tagData"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 120px;">
                <span class="tag">Something Special About You</span>
                <br />
                <asp:Label ID="txtSpecial" runat="server" Width="400" MaxLength="100" CssClass="tagData"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 120px;">
                <fieldset>
                    <legend><b>Occupation</b></legend>
                    <table>
                        <tr>
                            <td>
                                <span class="tag">Occupation</span>
                                <br />
                                <asp:Label ID="txtOccupation" runat="server" Width="400" MaxLength="100" CssClass="tagData"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="tag">Role</span>
                                <br />
                                <asp:Label ID="txtRole" runat="server" Width="400" MaxLength="100" CssClass="tagData"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="tag">Company</span>
                                <br />
                                <asp:Label ID="txtCompany" runat="server" Width="400" MaxLength="100" CssClass="tagData"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 120px;">
                <fieldset>
                    <legend><b>Study</b></legend>
                    <table>
                        <tr>
                            <td>
                                <span class="tag">Collage</span>
                                <br />
                                <asp:Label ID="txtCollage" runat="server" Width="400" MaxLength="100" CssClass="tagData"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="tag">Schooling</span>
                                <br />
                                <asp:Label ID="txtSchool" runat="server" Width="400" MaxLength="100" CssClass="tagData"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 120px;">
                <fieldset>
                    <legend><b>Contact</b></legend>
                    <table>
                        <tr>
                            <td>
                                <span class="tag">Cell</span>
                                <br />
                                <asp:Label ID="txtCell" runat="server" Width="400" MaxLength="100" CssClass="tagData"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="tag">Email</span>
                                <br />
                                <asp:Label ID="txtEmail" runat="server" Width="400" MaxLength="100" CssClass="tagData"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="tag">IM</span>
                                <br />
                                <asp:Label ID="txtIM" runat="server" Width="400" MaxLength="100" CssClass="tagData"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 120px;">
                <fieldset>
                    <legend><b>Address</b></legend>
                    <table>
                        <tr>
                            <td>
                                <span class="tag">City</span>
                                <br />
                                <asp:Label ID="txtCity" runat="server" Width="400" MaxLength="100" CssClass="tagData"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="tag">State</span>
                                <br />
                                <asp:Label ID="txtState" runat="server" Width="400" MaxLength="100" CssClass="tagData"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="tag">Country</span>
                                <br />
                                <asp:Label ID="txtCountry" runat="server" Width="400" MaxLength="100" CssClass="tagData"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="tag">Postal code</span>
                                <br />
                                <asp:Label ID="txtPostalCode" runat="server" Width="400" MaxLength="100" CssClass="tagData"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 160px;">
                <span class="tag">Current Status</span>
                <br />
                <asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal" Enabled="false">
                    <asp:ListItem Selected="True" Text="Single" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Married" Value="1"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 160px;">
                <span class="tag">Here For</span>
                <br />
                <asp:CheckBoxList ID="chlHereFor" runat="server" Enabled="false">
                    <asp:ListItem Text="Friends" Value="Friends"></asp:ListItem>
                    <asp:ListItem Text="Dating" Value="Dating"></asp:ListItem>
                    <asp:ListItem Text="Relationship" Value="Relationship"></asp:ListItem>
                    <asp:ListItem Text="Networking" Value="Networking"></asp:ListItem>
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 120px;">
                <fieldset>
                    <legend><b>Online Profile</b></legend>
                    <table>
                        <tr>
                            <td>
                                <span class="tag">Link 1</span>
                                <br />
                                <asp:Label ID="txtOnlineLink" runat="server" Width="400" MaxLength="100" CssClass="tagData"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
    </table>
</div>

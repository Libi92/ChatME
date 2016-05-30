<%@ Page Title="" Language="C#" MasterPageFile="~/ChatME.Master" AutoEventWireup="true"
    CodeBehind="Gallary.aspx.cs" Inherits="ChatME.Gallary" EnableEventValidation="false"
    EnableViewState="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Script/Home/Gallary.js" type="text/javascript"></script>
    <script type="text/javascript">
        function fileUploaded(sender, args) {
            window.location.reload(false);
        }
        function showImageInPopUp(obj) {
            $(".inline").colorbox({ inline: true, width: "820", height: "600", overlayClose: 0, escKey: 0 });
            document.getElementById("imgPopUp").src = obj.src;
            document.getElementById("imgPopUp").alt = obj.alt;
            document.getElementById("aImagePopUp").click();
            LoadGallaryCaption(obj.alt);
        }
    </script>
    <style type="text/css">
        #boxes #ImagePopUp
        {
            width: 850px;
            height: 500px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divContent">
        <div id="divShare" style="margin-left: 0%; margin-right: auto; width: 85%; margin-top: 0px;
            border: 1px solid gray; box-shadow: -5px -5px 5px gray; background-color: #F0ECF0;">
            <div style='display: none'>
                <div id="divTestDiv" style='padding: 10px; background: #fff; height: 200px;'>
                    <asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox>
                    <asp:DropDownList ID="ddlPrivacyC" runat="server">
                        <asp:ListItem Text="Public" Value="0">
                        </asp:ListItem>
                        <asp:ListItem Text="Friend" Value="1" Selected="True">
                        </asp:ListItem>
                        <asp:ListItem Text="Private" Value="2">
                        </asp:ListItem>
                        <asp:ListItem Text="Family" Value="3">
                        </asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="btnAddGallary" runat="server" Text="Add Category" OnClientClick="return addCategory();" />
                </div>
            </div>
            <div style="width: 100%; margin-left: 80%;">
                <div style="border: 3px solid green; background-color: Green; color: White; width: 150px;
                    text-align: center; font-size: 15px;">
                    <a class='inline' href="#divTestDiv" style="color: White; text-decoration: none;">Add
                        Category</a></div>
            </div>
            <div id="divImgCategory" style="width: 90%" runat="server">
                <h1>
                    &nbsp;&nbsp;&nbsp;Images Categories</h1>
                <asp:DataList ID="dlGallaryCategories" runat="server" RepeatColumns="4">
                    <ItemTemplate>
                        <div style="margin-left: 30px;">
                            <asp:Image ID="img" runat="server" ImageUrl='<%#  GetCategoryImageUrl(Eval("Image")) %>'
                                AlternateText='<%#  Eval("CategoriesID") %>' Height="100" Width="100" Style="border: 2px solid gray;
                                box-shadow: 0 0 10px green;" onclick='<%# "loadGallary("+Eval("CategoriesID")+");" %>' /><br />
                            <span class="GlobalFontB">
                                <h4>
                                    <%#Eval("CategoryName") %></h4>
                            </span>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div style='display: none'>
                <div id="ImagePopUp" style='padding: 1px; height: 400px; width: 600px;'>
                    <center>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 75%;">
                                    <img id="imgPopUp" src="" style="border: 1px solid green; box-shadow: 0 0 10px green;"
                                        width="600px" height="500px" />
                                </td>
                                <td style="width: 25%;" valign="middle">
                                    <div style="background-color: Green; width: 100%; height: 400px;" id="tblShare">
                                        <table width="100%">
                                            <tr>
                                                <td align="left" style="border-bottom: 1px solid white;">
                                                    <span class="HeaderImage" id="HeaderImage">Test Image</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <span class="GlobalFontW">Share</span>
                                                    <br />
                                                    <select id="ddlTo" class="GlobalFontB" style="width: 150px;">
                                                        <option value="0">To Home Screen</option>
                                                        <option value="1">To Email</option>
                                                    </select><br />
                                                    <span class="GlobalFontW">Message</span><br />
                                                    <textarea id="txtMessage" style="width: 180px; height: 40px;"></textarea><br />
                                                    <span class="GlobalFontW">Privacy</span>
                                                    <br />
                                                    <select id="ddlPrivacy" class="GlobalFontB" style="width: 150px;">
                                                        <option value="1">Friend</option>
                                                        <option value="2">Family</option>
                                                        <option value="3">Private</option>
                                                        <option value="4">Public</option>
                                                    </select><br />
                                                    <a href="#" class="GloablAW" onclick="return ShareUserGallary();">Share</a>
                                                    <hr />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <span class="GlobalFontW">Edit Caption</span>
                                                    <br />
                                                    <input id="txtImageCaption" type="text" style="width: 150px;" /><br />
                                                    <a href="#" class="GloablAW" onclick="return saveCaption();">Save</a>
                                                    <hr />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <span class="GlobalFontW">Edit Description</span>
                                                    <br />
                                                    <textarea id="txtImageDescription" style="width: 150px; height: 40px;" rows="3"></textarea><br />
                                                    <a href="#" class="GloablAW" onclick="return SaveDescription();">Save</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </center>
                </div>
            </div>
            <a href="#ImagePopUp" class='inline' id="aImagePopUp" style="display: none;"></a>
            <a href="#divAddGallary" class='inline' id="aAddGallary" style="display: none;">
            </a>
            <div id="divAddGallary">
            </div>
            <div style="width: 100%; text-align: left; margin-top: 20px; background-color: #006699;">
                <input type="hidden" id="hdnCategoryID" />
                <h1>
                    &nbsp;&nbsp;&nbsp;Images Gallary</h1>
                <div style="margin-left: auto; margin-right: auto; width: 100%;" id="divGallary">
                </div>
                <br />
                <div style="width: 100%; margin-left: 80%;">
                    <div style="border: 3px solid green; background-color: Green; color: White; width: 150px;
                        text-align: center; font-size: 15px; display: none;" onclick="return addGallary(this);"
                        id="divAddGallaryLnk">
                        Add Gallary</div>
                </div>
            </div>
        </div>
</asp:Content>

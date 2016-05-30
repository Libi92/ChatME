
window.onload = function () {
    try {
        GetOnlineUsers();
        readReminder();
        RemoveHrefAttribute();
        loadFirstPage();
        setInterval("GetOnlineUsers()", 5000);
        setInterval("GetChatMessages()", 2000);
        setInterval("readReminder()", 5000);
    } catch (ex) {
    }
};
var currentChatCount = 0;
function RemoveHrefAttribute() {

    var a = document.getElementsByTagName("a");
    for (var i = 0; i < a.length; i++) {
        if (a[i].className != "inline") {
            try {
                if (a[i].getAttribute("href").toLowerCase().indexOf("logout") == -1) {
                    a[i].removeAttribute("href");
                }
            }
            catch (ex) {
            }
        }
    }
}
function GetOnlineUsers() {
    try {
        $.ajax({
            type: "POST",
            url: "OnlineUserHandler.asmx/GetOnlineUsers",
            contentType: "application/json; charset=utf-8",
            datatype: "JSON",
            success: SetOnlineUsers
        });
    } catch (ex) {
    }
}

var ChatStatus = 1;
function SetOnlineUsers(respose) {
    try {
        var divUsers = document.getElementById('divUsers');
        if (respose.d.length > 0) {
            divUsers.innerHTML = "";
            if (ChatStatus == 1) {
                $("#divUsers").animate({ height: 200 }, "slow");
            } else {
                $("#divUsers").animate({ height: 10 }, "slow");
            }
            $("#divUsers").css({ "background-color": "white" });
            $("#divUsers").html("<div style='width:100%; height:20px; color:green;' onclick='hideChat(this);'>ChatME</div>");
        }
        else {
            divUsers.innerHTML = "<center>No Friend online</center>";
            $("#divUsers").animate({ height: 15 }, "slow");
            $("#divUsers").css({ "background-color": "gray" });
        }
        for (var i = 0; i < respose.d.length; i++) {
            var a = document.createElement('a');
            var img = document.createElement('img');
            if (respose.d[i].UserStatus == "1") {
                img.setAttribute("src", respose.d[i].UserImage);
                img.style.height = "20px";
                img.style.width = "20px";

                a.appendChild(img);
                a.innerHTML = a.innerHTML + respose.d[i].UserName + " <i> Online</i>";
                a.href = "javascript:void(0);";
                a.setAttribute("onclick", "javascript:CreateChat('" + respose.d[i].UserID + "','" + respose.d[i].UserName + "','" + respose.d[i].UserStatus + "','" + respose.d[i].UserImage + "')");

                divUsers.appendChild(a);
                divUsers.innerHTML += "<br/><br/>";
            } else {
                img.setAttribute("src", respose.d[i].UserImage);
                img.style.height = "20px";
                img.style.width = "20px";

                a.appendChild(img);
                a.innerHTML = a.innerHTML + "&nbsp;&nbsp;" + respose.d[i].UserName + " <i> Offline</i>";
                a.href = "javascript:void(0);";
                a.setAttribute("onclick", "javascript:CreateChat('" + respose.d[i].UserID + "','" + respose.d[i].UserName + "','" + respose.d[i].UserStatus + "','" + respose.d[i].UserImage + "')");

                divUsers.appendChild(a);
                divUsers.innerHTML += "<br/><br/>";
            }

        }
    } catch (ex) {
    }
}
function hideChat(object) {
    var _parent = object.parentNode;
    if (_parent.style.height == "10px") {
        $(_parent).animate({ height: 200 }, "slow");
        $(object).css({ "color": "Green" });
        ChatStatus = 1;
    } else {
        $(_parent).animate({ height: 10 }, "slow");
        $(object).css({ "color": "Red" });
        ChatStatus = 0
    }
}

function CreateChat(UserID, UserName, UserStatus, UserImage) {
    try {
        var child = document.getElementById("div" + UserID);
        if (child == null) {
            currentChatCount++;
            if (currentChatCount == 4) {
                return;
            }
            var div = document.createElement('div');
            div.id = "div" + UserID;
            div.style.position = 'fixed';
            div.style.border = "1px solid black";
            div.style.overflow = "hidden";
            div.style.padding = "0px";
            div.style.height = "300px";
            div.style.width = "20%";
            div.style.bottom = "0px";
            div.style.backgroundColor = "White";
            div.style.right = (currentChatCount * 23) + "%";
            var html = "";
            if (UserStatus == 0) {
                html = "<table style='margin:0px; padding:0px; table-layout:fixed;' cellspacing='0' cellpadding='0' height='300px' width='100%'><tr  onclick='toggleThis(" + UserID + ");'><td style='background-color:#006699; color:white; hight:25px; width:90%;' class='chatWindowTitle'>&nbsp;<img src='" + UserImage + "' alt='usImg' style='width:23px; height:23px;'/>&nbsp;&nbsp;<a>" + UserName + "</a> <i>&nbsp;Offline</i></td><td class='chatWindowTitle' style='font-size:12px; width:10%; background-color:#006699; color:Red;' ><a onclick='javascript:removeElement(" + UserID + ")'>[X]</a></td></tr>";
            }
            else {
                html = "<table style='margin:0px; padding:0px;' cellspacing='0' cellpadding='0' height='300px' width='100%'><tr><td style='background-color:Green; color:white; hight:25px; width:90%;' class='chatWindowTitle'>&nbsp;<img src='" + UserImage + "' alt='usImg' style='width:23px; height:23px;'/>&nbsp;&nbsp;<a  onclick='toggleThis(" + UserID + ");'>" + UserName + "</a></td><td class='chatWindowTitle' style='font-size:12px; width:10%; background-color:green; color:Red;' ><a onclick='javascript:removeElement(" + UserID + ")'>[X]</a></td></tr>";
            }
            html = html + "<tr><td style='padding:5px; height:235px; max-width:100%;' valign='top' colspan='2'>";
            html = html + " <div style='max-width:100%; height:235px; overflow:auto; overflow-x:hidden;' id='td" + UserID + "' class='chatWindow'></div></td></tr>";
            html = html + "<tr><td colspan='2' style='border:1px solid green;'>";
            html = html + "<input type='text' style='bottom:0px; width:100%; height:20px;' onkeypress='return isEnterKeyPress(event," + UserID + ");' id='txtPost" + UserID + "'>";
            html = html + "</td></tr></table>";
            div.innerHTML = (div.innerHTML + html);

            var form = document.getElementsByTagName("form")[0];
            form.appendChild(div);
        }
    } catch (ex) {
    }
}


function postChildData(obj) {

    try {
        $.ajax({
            type: "POST",
            url: "OnlineUserHandler.asmx/PostChildChat", // Default.page is your page and GetData is Your public Method inside code behind file which will return some response.
            data: "{'value': '" + obj.value + "','to':'" + obj.id.toString().replace("txtPost", "") + "'" + "}",
            contentType: "application/json; charset=utf-8",
            datatype: "JSON"
        });
    } catch (ex) {
    }
}

function isEnterKeyPress(e, UserID) {
    try {
        var unicode = e.charCode ? e.charCode : e.keyCode;
        if (unicode == 13) {
            var td = document.getElementById("td" + UserID);
            var input = document.getElementById("txtPost" + UserID);
            td.innerHTML = td.innerHTML + input.value + "<hr/>";
            td.scrollTop = td.scrollHeight;
            postChildData(input);
            input.value = "";
            return false;
        }
    } catch (ex) {
    }
}


function GetChatMessages() {
    try {
        $.ajax({
            type: "POST",
            url: "OnlineUserHandler.asmx/GetChildMessages", // Default.page is your page and GetData is Your public Method inside code behind file which will return some response.
            contentType: "application/json; charset=utf-8",
            datatype: "JSON",
            success: ChangeContent
        });
    } catch (ex) {
    }
}

function ChangeContent(response) {
    try {
        for (var i = 0; i < response.d.length; i++) {
            //Check whether user chat window exists
            var userChatWindow = document.getElementById("div" + response.d[i].From);
            if (userChatWindow) {
                //Append the text to td
                var tdChat = document.getElementById("td" + response.d[i].From);
                tdChat.innerHTML = (tdChat.innerHTML + response.d[i].Message + "<hr/>");
                tdChat.scrollTop = tdChat.scrollHeight;
            }
            else {
                //Create new Child Window and append the text
                CreateChat(response.d[i].From, response.d[i].FromName);
                var tdChat = document.getElementById("td" + response.d[i].From);
                tdChat.innerHTML = (tdChat.innerHTML + response.d[i].Message + "<hr/>");
                tdChat.scrollTop = tdChat.scrollHeight;
            }

        }
    } catch (ex) {
    }
}

function toggleThis(userID) {
    try {
        var height = $("#div" + userID).height();
        if (height == 25) {
            $("#div" + userID).animate({ height: 300 }, "slow");
            $(this).css({ "background-color": "gray" });
        }
        else if (height == 300) {
            $("#div" + userID).animate({ height: 25 }, "slow");
            $(this).css({ "background-color": "green" });
        }
    } catch (ex) {
    }
}

function removeElement(childDiv) {
    try {
        if (document.getElementById("div" + childDiv)) {
            var child = document.getElementById("div" + childDiv);
            var parent = document.getElementsByTagName("form")[0];
            parent.removeChild(child);
            currentChatCount--;
        }
    } catch (ex) {
    }
}

function addReminder() {
    try {
        $.ajax({
            type: "POST",
            url: "OnlineUserHandler.asmx/AddReminder", // Default.page is your page and GetData is Your public Method inside code behind file which will return some response.
            contentType: "application/json; charset=utf-8",
            datatype: "JSON",
            success: ChangeContent
        });
    } catch (ex) {
    }
}

function assignSearchDivHideEvent() {
    $("#divSearch").click(function () { return false; });
    $("body").click(function () { $('#divSearch').hide(); });
}

function readReminder() {

    var time = parseInt(readCookie("reminder"));
    var d = new Date();
    var t = d.getTime();
    if (time == t || t > time) {
        document.getElementById("aReminderAlert").click();
        eraseCookie("reminder");
    }
}

function addReminder(obj) {
    eraseCookie("reminder");
    var min = parseInt($("#ddlTime").val());
    momentOfTime = new Date();
    momentOfTime.setTime(momentOfTime.getTime() + (min * 60 * 1000));

    createCookie("reminder", momentOfTime.getTime(), 0);
    readReminder();
    setInterval("readReminder()", 5000);
    obj.innerHTML = "close";
    $("#h3Reminder").css({ "display": "block" });
}
function createCookie(name, value, days) {
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        var expires = "; expires=" + date.toGMTString();
    }
    else var expires = "";
    document.cookie = name + "=" + value + expires + "; path=/";
}

function readCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

function eraseCookie(name) {
    createCookie(name, "", -1);
}



var mainHeaderContent = "";
function RemoveChildIFrame() {
    $.getScript('Script/PopUp.js');
    var myIFrame = document.getElementById("iframeChild");
    var bodyContent = myIFrame.contentWindow.document.getElementById("divContent").innerHTML;
    var headerContent = myIFrame.contentWindow.document.head.innerHTML;
    document.getElementById("divNoIframe").innerHTML = bodyContent;
    $("head").append(headerContent);
    $("#divIframe").html("");

    firePageEvents();
}

function firePageEvents() {
    url1 = url1.toLowerCase();
    if (url1 == "home.aspx") {
        FetchPost();
    }
}
function searchFLClick(url) {
    setIUrl(url);
    $("body").click();
}

var parentID1 = "";
function createFileUploader(ParentID) {
    parentID1 = ParentID;
    var newIframe = $('<iframe />', {
        name: 'iframeUpload',
        id: 'iframeUpload',
        src: "hidden/fileupload.aspx"
    });
    $(newIframe).attr("frameborder", "0");
    $(newIframe).width("100%");
    $(newIframe).height("100%");
    $(newIframe).css({ "overflow": "hidden", "height": "60px", "width": "600px" });
    $("#" + ParentID).html("");
    $("#" + ParentID).append(newIframe);
}

function removeFileUpload() {
    $("#" + parentID1).html("");
    $("#" + parentID1).append("<span class='GlobalFontW'>file uploaded successfully</span>");
}
function loadFirstPage() {
    if (window.location.href.indexOf("#") == -1) {
        window.location.hash = "#Home";
        setIUrl("Home.aspx");
    }
    else {
        var url = window.location.href.split("#")[1];
        url = url.replace("%%", ".");
        url = url.replace("QQ", "?");
        url = url.replace("EE", "=");
        setIUrl(url);
    }
}
var url1 = "";
function setIUrl(url) {
    ModifyURL(url);
    url1 = url.toLowerCase();

    var iframe = false;
    if (url1.indexOf("profile.aspx") != -1) {
        iframe = true;
    }
    url2 = window.location.hash;
    url1 = url;
    var newIframe = $('<iframe />', {
        name: 'iframeChild',
        id: 'iframeChild',
        src: url
    });
    newIframe.attr("frameborder", "0");
    newIframe.width("100%");
    newIframe.height("100%");
    newIframe.css({ "overflow": "hidden", "height": "700px", "width": "100%", "margin-top": "20px", "margin-left": "40px" });
    $("#divIframe").html("");
    if (iframe == false) {
        newIframe.attr("onload", "RemoveChildIFrame()");
        $("#divIframe").append(newIframe);
    }
    else {
        $("#divNoIframe").html("");
        $("#divNoIframe").append(newIframe);
        $.getScript('Script/PopUp.js');
    }
    return false;
}
function ModifyURL(url) {
    url = url.replace(".", "%%");
    url = url.replace("?", "QQ");
    url = url.replace("=", "EE");
    window.location.hash = ("#" + url);
}


function _parseQueryString(queryString) {
    var pairs = queryString.split('&');
    var params = {};
    for (var i = 0; i < pairs.length; ++i) {
        pairs[i] = pairs[i].trim();
        if (pairs[i] == '') continue;

        var parts = pairs[i].split('=');
        if (parts.length == 0) continue;
        var name = parts.shift();
        var value = '';
        while (parts.length) {
            value += parts.shift();
        }
        params[name] = value;
    }
    return params;
}

function _buildQueryString(params) {
    var queryString = "";
    for (var i in params) {
        if (queryString.length > 0) queryString += "&";
        queryString += (i + '=' + params[i]);
    }
    return queryString;
}


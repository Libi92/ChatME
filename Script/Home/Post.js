var postCount = 0;
function disableInput(obj) {
    try {
        var txtShare = document.getElementById("txtShare");
        if (txtShare.value == "") {
            return false;
        }
        txtShare.disabled = true;
    } catch (ex) {
    }
}

function FetchPost() {
    try {
        $.ajax({
            type: "POST",
            url: "OnlineUserHandler.asmx/FetchPost",
            data: "{'count': '" + postCount + "'}",
            contentType: "application/json; charset=utf-8",
            datatype: "JSON",
            success: addPostToPage
        });
    } catch (ex) {
    }
}

function addPostToPage(response) {
    try {
        postCount = postCount + response.d.length;
        var chatDiv = document.getElementById("divPost");

        for (var i = 0; i < response.d.length; i++) {
            createTable(response.d[i], i);
        }
    } catch (ex) {
    }
}

function createTable(response) {
    try {
        var tab = document.getElementById('tbltable');

        var row, cell;
        row = tab.insertRow(tab.childNodes.length - 1);

        cell = row.insertCell(0);
        cell.setAttribute("valign", "middle");
        cell.setAttribute("align", "center");
        cell.setAttribute("class", "tdUserImg");

        var img = document.createElement('img');
        img.setAttribute("src", response.UserImage);
        img.style.width = "50px";
        img.style.height = "50px";
        cell.setAttribute("valign", "top");
        cell.appendChild(img)
        row.appendChild(cell);


        cell = row.insertCell(1);
        cell.className = "tdUserMessage";
        cell.style.width = "70%;";
        var userName = document.createElement('div');
        userName.className = "userName2";
        userName.innerHTML = response.UserName;

        cell.appendChild(userName)
        var message = document.createElement('div');
        message.className = "userMessage";
        message.innerHTML = response.Message;
        cell.appendChild(message)

        var image = document.createElement('img');
        image.className = "postImg";
        image.setAttribute("src", response.Image);
        image.style.maxWidth = "550px";
        image.style.maxHeight = "300px";
        image.style.marginBottom = "10px";
        cell.appendChild(image);

        row.appendChild(cell);
    } catch (ex) {
    }
}

function animateHeight() {
    try {
        $("#divPost0").css({ "display": "none" });
        $("#divPost").css({ "display": "block" });
        $("#txtShare").animate({ height: 80 }, "slow");
    } catch (ex) {
    }
}

function addPhoto(obj) {
    $("#divUploadImage").css({ "display": "block" });
    $(obj).click = "";
    $(obj).css({ "color": "gray" });
    createFileUploader("divUploadImage");
    return false;
}

function submitPost(obj) {

    disableInput(obj);
    var message = $("#txtShare").val();
    var privacy = $("#ContentPlaceHolder1_ddlWhom").val();
    var imagename = $("#ImageName").val();
    $.ajax({
        type: "POST",
        url: "Home.aspx/PostToWall",
        data: "{'message': '" + message + "','imagename':'" + imagename + "','privacy':'" + privacy + "'}",
        contentType: "application/json; charset=utf-8",
        datatype: "JSON",
    });
    refreshPage();
}

function refreshPage() {
    setIUrl("Home.aspx");
}
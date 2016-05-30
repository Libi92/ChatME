function saveCaption() {
    var Caption = document.getElementById('txtImageCaption').value;
    var GallaryID = document.getElementById('imgPopUp').alt;

    try {
        $.ajax({
            type: "POST",
            url: "OnlineUserHandler.asmx/saveCaption",
            data: "{'GallaryID': '" + GallaryID + "','Caption': '" + Caption + "'}",
            contentType: "application/json; charset=utf-8",
            datatype: "JSON",
            success: EnableGallary
        });
    } catch (ex) {
    }
    return false;
}
function SaveDescription() {
    DisableGallary();
    var Description = document.getElementById('txtImageDescription').value;
    var GallaryID = document.getElementById('imgPopUp').alt;
    try {
        $.ajax({
            type: "POST",
            url: "OnlineUserHandler.asmx/SaveDescription",
            data: "{'GallaryID': '" + GallaryID + "','Description': '" + Description + "'}",
            contentType: "application/json; charset=utf-8",
            datatype: "JSON",
            success: EnableGallary
        });
    } catch (ex) {
    }
    return false;
}
function ShareGallary(GallaryID, Message, Privacy, ImageName) {
    DisableGallary();
    try {
        $.ajax({
            type: "POST",
            url: "OnlineUserHandler.asmx/ShareGallary",
            data: "{'GallaryID': '" + GallaryID + "','Message': '" + Message + "','Privacy': '" + Privacy + "','ImageName': '" + ImageName + "'}",
            contentType: "application/json; charset=utf-8",
            datatype: "JSON",
            success: EnableGallary
        });
    } catch (ex) {
    }
}
function EmailGallary(GallaryID, Message, ImageName) {
    DisableGallary();
    try {
        $.ajax({
            type: "POST",
            url: "OnlineUserHandler.asmx/EmailGallary",
            data: "{'GallaryID': '" + GallaryID + "','Message': '" + Message + "','ImageName': '" + ImageName + "'}",
            contentType: "application/json; charset=utf-8",
            datatype: "JSON",
            success: EnableGallary
        });
    } catch (ex) {
    }
}

function ShareUserGallary() {
    DisableGallary();
    var ShareOption = document.getElementById('ddlTo').value;
    var message = document.getElementById('txtMessage').value;
    var Image = document.getElementById('imgPopUp').src;
    var GallaryID = document.getElementById('imgPopUp').alt;
    var Privacy = document.getElementById('ddlPrivacy').value;

    if (ShareOption == "0") {
        ShareGallary(GallaryID, message, Privacy, Image);
    }
    else if (ShareOption == "1") {
        EmailGallary(GallaryID, message, Image);
    }
    return false;
}

function LoadGallaryCaption(GallaryID) {
    try {
        $.ajax({
            type: "POST",
            url: "OnlineUserHandler.asmx/LoadGallaryCaption",
            data: "{'GallaryID': '" + parseInt(GallaryID) + "'}",
            contentType: "application/json; charset=utf-8",
            datatype: "JSON",
            success: SetGallaryCaption
        });
    } catch (ex) {
    }
}

function SetGallaryCaption(response) {
    document.getElementById('ddlTo').value;
    var message = document.getElementById('txtImageCaption').value = response.d[0].Caption;
    var message = document.getElementById('txtImageDescription').value = response.d[0].Description;
}
function EnableGallary() {
    document.getElementById("tblShare").removeAttribute("disabled");
    document.getElementById("tblShare").style.opacity = "1";
    document.getElementById("tblShare").style.filter = "alpha(opacity=1)";
}
function DisableGallary() {
    document.getElementById("tblShare").setAttribute("disabled", "disabled");
    document.getElementById("tblShare").style.opacity = "0.8";
    document.getElementById("tblShare").style.filter = "alpha(opacity=80)";
}

function addCategory() {
    var GallaryName = document.getElementById('ContentPlaceHolder1_txtCategoryName').value;
    var privacy = document.getElementById('ContentPlaceHolder1_ddlPrivacyC').value;
    try {
        $.ajax({
            type: "POST",
            url: "OnlineUserHandler.asmx/AddGallaryCategory",
            data: "{'GallaryName': '" + GallaryName + "','privacy': '" + privacy + "'}",
            contentType: "application/json; charset=utf-8",
            datatype: "JSON",
            success: reloadGallary
        });
    } catch (ex) {
    }
}

function reloadGallary(response) {
    setIUrl("Gallary.aspx");
}

function loadGallary(categoryID) {
    document.getElementById("hdnCategoryID").value = categoryID;
    try {
        $.ajax({
            type: "POST",
            url: "OnlineUserHandler.asmx/LoadGallary",
            data: "{'CategoryID':'" + categoryID + "'}",
            contentType: "application/json; charset=utf-8",
            datatype: "JSON",
            success: addGallaryToPage
        });
    } catch (ex) {
    }
}

function addGallaryToPage(response) {
    if (response.d.length > 0) {
        var divGallary = document.getElementById("divGallary");
        divGallary.innerHTML = "";
        var table = document.createElement('table');
        table.setAttribute("cellspacing", "0");
        table.setAttribute("cellpadding", "0");
        table.setAttribute("width", "100%");

        var totalRow = parseInt(parseInt(response.d.length) / 5);
        var reminder = parseInt(parseInt(response.d.length) % 5);
        if (reminder > 0) {
            totalRow = totalRow + 1;
        }
        var k = 0;
        for (i = 0; i < totalRow; i++) {
            var row = table.insertRow(i);
            for (j = 0; j <= 5; j++) {
                if (k < response.d.length) {
                    document.getElementById("divAddGallaryLnk").style.display = "block";
                    var cell = row.insertCell(j);
                    var html = " <div style='margin-left: 30px;'>";
                    html = html + "<img height='100' width='100' style='border: 2px solid gray; box-shadow: 0 0 10px green;'";
                    html = html + "onclick='javascript:showImageInPopUp(this);' src='" + response.d[k].Image + "' alt='" + response.d[i].GallaryID + "' />";
                    html = html + "<br /><a id='delGallary' href='#'>delete</a>";
                    html = html + "</div>";
                    cell.innerHTML = html;
                    k++;
                } else {
                    break;
                }
            }
        }
        divGallary.appendChild(table);
    }
    else {
        var divGallary = document.getElementById("divGallary");
        divGallary.innerHTML = "<Center><h3>There Is no image to show!</h3></center>";
        document.getElementById("divAddGallaryLnk").style.display = "block";
    }
}

function addGallary(obj) {

    document.getElementById("divAddGallary").innerHTML = "";

    $(".inline").colorbox({ inline: true, width: "500", height: "500", overlayClose: 0, escKey: 0 });
    try {
        var CategoryID = document.getElementById("hdnCategoryID").value;
        var newIframe = document.createElement("iframe");
        newIframe.src = "hidden/AddGallary.aspx?CategoryID=" + CategoryID;
        newIframe.name = "iframeGallaryAdd";
        $(newIframe).attr("id", "iframeGallaryAdd");

        $(newIframe).attr("frameborder", "0");
        $(newIframe).width("100%");
        $(newIframe).height("100%");
        $(newIframe).css({ "overflow": "hidden", "height": "60px", "width": "600px" });
        document.getElementById("divAddGallary").appendChild(newIframe);
    } catch (ex) {
    }
}

function removeGallaryUpload() {
    $("divAddGallary").html("");
    $("divAddGallary").append("<span class='GlobalFontW'>file uploaded successfully</span>");
    setIUrl("Gallary.aspx");
}
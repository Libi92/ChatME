function sendFriendRequest(userID, obj) {
    var pri = document.getElementById("ddlPrivacy").value;
    var privacy = parseInt(pri);
    try {
        obj.innerHTML = "Friend Request Sent";
        obj.style.color = "Green";
        obj.onclick = "false;";
        obj.href = "javascript:void(0);";

        $.ajax({
            type: "POST",
            url: "OnlineUserHandler.asmx/SendFriendRequest", // Default.page is your page and GetData is Your public Method inside code behind file which will return some response.
            data: "{'userID': '" + userID + "','privacy': '" + privacy + "'}",
            contentType: "application/json; charset=utf-8",
            datatype: "JSON",
            fail: function () { alert("fail"); }
        });
        return false;
    } catch (ex) {
        alert(ex);
    }
}

function ApproveRejectRequest(notificationID, action, i) {
    alert("" + notificationID + " " + action + " " + i);
    try {
        var lnkApprove = document.getElementById("lnkRequestApprove" + i);
        var lnkReject = document.getElementById("lnkRequestReject" + i);
        if (action == 1) {
            lnkReject.style.display = 'none';
            lnkApprove.innerHTML = "Request Sent";
            lnkApprove.style.color = "Green";
            lnkApprove.onclick = "false;";
        } else {
            lnkApprove.style.display = 'none';
            lnkReject.innerHTML = "Request Rejected";
            lnkReject.style.color = "Green";
            lnkReject.onclick = "false;";
        }
        $.ajax({
            type: "POST",
            url: "OnlineUserHandler.asmx/ApproveRejectRequest", // Default.page is your page and GetData is Your public Method inside code behind file which will return some response.
            data: "{'notificationID': '" + notificationID + "','action':'" + action + "'}",
            contentType: "application/json; charset=utf-8",
            datatype: "JSON"
        });
        return false;
    } catch (ex) {
    }
}

function searchFrindList(obj) {
    assignSearchDivHideEvent();
    try {
        var div = document.getElementById("divSearch");
        div.style.display = 'block';
        div.innerHTML = "";

        $.ajax({
            type: "POST",
            url: "OnlineUserHandler.asmx/SearchFrindList", // Default.page is your page and GetData is Your public Method inside code behind file which will return some response.
            data: "{'searchTerm': '" + obj.value + "'}",
            contentType: "application/json; charset=utf-8",
            datatype: "JSON",
            success: showSearhedFriend
        });
    } catch (ex) {
    }
}

function showSearhedFriend(response) {
    try {
        var divSearch = document.getElementById("divSearch");
        if (document.getElementById("tblUserSearch")) {
            var tbl = document.getElementById("tblUserSearch");
            document.removeChild(tbl);
        }

        var table = document.createElement("table");
        table.setAttribute("width", "100%");
        table.setAttribute("id", "tblUserSearch");
        for (var i = 0; i < response.d.length; i++) {
            var row = table.insertRow(table.getElementsByTagName("TR").length);
            var cell = row.insertCell(0);
            var img = document.createElement('img');
            cell.setAttribute("onclick", "searchFLClick('Profile.aspx?UserID=" + response.d[i].UserID + "');");
            img.setAttribute("src", response.d[i].Image);
            img.style.width = '50px';
            img.style.height = '50px';
            cell.appendChild(img);

            var cell = row.insertCell(1);
            var span = document.createElement('span');
            span.innerHTML = response.d[i].UserName;
            cell.appendChild(span);

        }
        divSearch.appendChild(table);
    } catch (ex) {
    }
}
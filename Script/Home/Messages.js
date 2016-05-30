function showReplyBox(obj) {
    obj.parentNode.childNodes[14].style.display = '';
}
function replyMessage(id, obj) {
    var message = obj.parentNode.childNodes[1].value;
    try {
        $.ajax({
            type: "POST",
            url: "OnlineUserHandler.asmx/ReplyMessage",
            data: "{'to': '" + id + "','message': '" + message + "'}",
            contentType: "application/json; charset=utf-8",
            datatype: "JSON",
            success: RedirectURL
        });
    } catch (ex) {
    }
    // window.location.reload(false);
}

function deleteMessage(messageID) {
    try {
        $.ajax({
            type: "POST",
            url: "OnlineUserHandler.asmx/DeleteMessage",
            data: "{'messageID': '" + messageID + "'}",
            contentType: "application/json; charset=utf-8",
            datatype: "JSON",
            success: RedirectURL
        });
    } catch (ex) {
    }

}

function RedirectURL(response) {
    window.location.reload(false);
}
function redirectToMessages(id) {
    try {
        setIUrl('MessagesFrom.aspx?SenderID=' + id);
    }
    catch (ex) {
        alert(ex);
    }
}
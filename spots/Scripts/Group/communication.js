function GetContent(getContentResponse, url) {
    AjaxCall(url, "Get", null, null, getContentResponse, null);
}

function CreateGroup(callback, data) {
    AjaxCall("/Group/Create", "Post", data, null, callback, "#create-group-response");
}

function GetUsers(callback, url) {
    AjaxCall(url, "Post", null, null, callback, null);
}


function IsUserRegistered(callback, url) {
    AjaxCall(url, "Post", null, null, callback, null);
}

function PushUser(callback, url) {
    AjaxCall(url, "Post", null, null, callback, "#add-remove-user-response");
}

function RemoveUser(callback, url) {
    AjaxCall(url, "Post", null, null, callback, "#add-remove-user-response");
}

function GroupMembers(callback, url) {
    AjaxCall(url, "GET", null, null, callback, "#members");
}


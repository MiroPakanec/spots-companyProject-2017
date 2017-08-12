function CreateLocation(submitResponse, data) {
    AjaxCall("/User/PersonalDetailsUpdate", "Post", data, null, submitResponse, "#user-ajax-response");
}

function SubmitOne(submitOneResponse, data) {
    AjaxCall("/User/PersonalDetailsUpdate", "Post", data, null, submitOneResponse, "#user-ajax-response");
}

//friend group 
function IsUserYourFriend(callback, url) {
    AjaxCall(url, "Get", null, null, callback, null);
}

function GetGroupId(callback, url) {
    AjaxCall(url, "Get", null, null, callback, null);
}

function GetAddButton(callback) {
    AjaxCall("/User/GetAddFriendButton", "GET", null, null, callback, "#add-remove-btn");
}

function GetRemoveButton(callback) {
    AjaxCall("/User/GetRemoveFriendButton", "GET", null, null, callback, "#add-remove-btn");
}
function GetEventPosts(data, url) {

    AjaxCall(url, "Get", data, null, GetEventPostsResponse, "#posts");
}

function GetHistoryEventPosts(data, url) {

    AjaxCall(url, "Get", data, null, GetHistoryEventPostsResponse, "#posts");
}
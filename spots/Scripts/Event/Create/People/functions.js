function GetPeoplePartialContent() {
    AjaxCall("/User/InviteUsers", "GET", null, null, GetPeoplePartialContentResponse, "#people-response");
}

function GetPeoplePartialContentResponse(response, target) {
    $(target).html(response);
}
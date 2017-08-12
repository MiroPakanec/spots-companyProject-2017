$(function() {

    AjaxCall("/User/MyBusinesses", "Get", null, null, GetMyBusinesses, ".business-names");
    AjaxCall("/User/MyGroups", "Get", null, null, GetMyGroups, ".group-names");
    AjaxCall("/Feedback/Create", "Get", null, null, GetMyFeedback, ".feedback-partial");
});

function GetMyBusinesses(response, target) {
    $(target).html(response);
}

function GetMyGroups(response, target) {
    $(target).html(response);
}

function GetMyFeedback(response, target) {
    $(target).html(response);
}
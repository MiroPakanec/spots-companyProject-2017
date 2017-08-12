function CreateLocation(submitResponse, data) {

    AjaxCall("/User/ContactDetailsUpdate", "Post", data, null, submitResponse, "#user-ajax-response");
}

function SubmitOne(submitOneResponse, data) {

    AjaxCall("/User/ContactDetailsUpdate", "Post", data, null, submitOneResponse, "#user-ajax-response");
}
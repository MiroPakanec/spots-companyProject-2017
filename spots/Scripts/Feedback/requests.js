function Submit(submitOneResponse, data) {

    AjaxCall("/Feedback/Create", "Post", data, null, submitOneResponse, "#feedbackCreate-ajax-response");
}

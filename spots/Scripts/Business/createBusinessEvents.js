$("#createBusinessForm")
    .submit(
        function () {
            if ($(this).valid()) {
                AjaxCall(this.action, this.method, $(this).serialize(), null, createBusinessResponse, "#businessCreate-ajax-response");
            }
            return false;
        });

$(document)
    .on("keyup",
        ".get-users-input",
        function () {
            getUsers(this);
        });

$(document)
    .on("focus",
        ".get-users-input",
        function () {
            getUsers(this);
        });

function createBusinessResponse(response, target) {

    console.log("Responded to create business request.");

    $(target).html(response);
    viewModel.clearAllInputs();
}

function getUsers(element) {
    
    var data = {};
    var target = $(element).attr("target");
    var value = $(element).val();

    if (value.length > 0) {
        data["email"] = value;
        AjaxCall(Url(element), Method(element), data, null, getUsersResponse, target);
        return;
    }

    $(target).html("");
    
}

function getUsersResponse(response, target) {

    console.log("Responded to get users request.");

    $(target).html(response);
}
function AjaxCall(url, method, data, datatype, callback, callbackTarget) {

    $.ajax({
        url: url,
        type: method,
        data: data,
        datatype: datatype,
        success: function (response) {
            callback(response, callbackTarget);
        },
        error: function (response) {
            callback(response, callbackTarget);
        }
    });
}

function Url(element) {
    var action = $(element).attr("action");
    var controller = $(element).attr("controller");
    return "/" + controller + "/" + action;
}

function Method(element) {
    return $(element).attr("method");
}
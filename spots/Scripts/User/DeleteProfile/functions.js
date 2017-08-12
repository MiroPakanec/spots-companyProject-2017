function GetCode(getCodeResponse) {

    AjaxCall("/User/GenerateProfileDeleteCode", "POST", null, null, getCodeResponse, null);
}

function SendEmail(sendEmailResponse) {
    
    AjaxCall("/User/SendDeleteProfileEmail", "POST", null, null, sendEmailResponse, null);
}

function GetCodeResponse(response, target) {

    return response;
}

function SendEmailResponse(response, target) {

    return response;
}
/*load*/
$(function () {
    ManageSectionVisibility();
});

$(document)
    .on("click",
        "#btn-register",
        function () {
            $(".section-login").slideUp(800);
            $(".section-register").removeClass("invisible").delay(800).slideDown(800);
            EnableLoginButton();
        });

$(document)
    .on("click",
        "#btn-login",
        function () {
            $(".section-register").slideUp(800);
            $(".section-login").removeClass("invisible").delay(800).slideDown(800);
            EnableRegisterButton();
        });

/*functions*/
function ManageSectionVisibility() {

    var type = $("#visibleSection").val();
    Disable();

    if (type === "login") {
        EnableRegisterButton();
        ShowLogin();
    } else {
        EnableLoginButton();
        ShowRegister();
    }
}

function ShowLogin() {
    $(".section-login").show();
}

function ShowRegister() {
    $(".section-register").show();
}

function EnableRegisterButton() {

    $(".section-login").removeClass("invisible");
    $("#btn-register").attr("disabled", false);
    $("#btn-login").attr("disabled", true);
}

function EnableLoginButton() {

    $(".section-register").removeClass("invisible");
    $("#btn-register").attr("disabled", true);
    $("#btn-login").attr("disabled", false);
}

function Disable() {
    
    $(".section-register").addClass("invisible").hide();
    $(".section-login").addClass("invisible").hide();

    $("#btn-register").attr("disabled", true);
    $("#btn-login").attr("disabled", true);

}



$(function() {
    $(document).on("click", ".tracked", function () {

        var currentPage = window.location.pathname;
        var buttonName = $(this).attr("name");
        var buttonId = $(this).attr("id");
        var buttonLink = $(this).attr("href");
        var buttonText = $(this).val();


        var data = {};
        data["CurrentPage"] = currentPage;
        data["ButtonName"] = buttonName;
        data["ButtonId"] = buttonId;
        data["ButtonLink"] = buttonLink;
        data["ButtonText"] = buttonText;


        SendEvent(data);
    });
});

function SendEvent(data) {

    AjaxCall("/Track/Log", "Post", data, null, SendEventResponse, null);
}

function SendEventResponse() { }
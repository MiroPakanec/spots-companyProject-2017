$(function () {

    $("#future-button")
        .trigger("click");
});

function ToggleButton(id) {
    alert(id);

    $(id)
        .addClass("active")
        .siblings()
        .removeClass("active");
}

function ToggleHistoryButton() {

    $("#history-button").addClass("active");
    $("#future-button").removeClass("active");
}

function ToggleFutureButton() {

    $("#future-button").addClass("active");
    $("#history-button").removeClass("active");
}

function RemovePosts() {

    $("#posts").html("");
}
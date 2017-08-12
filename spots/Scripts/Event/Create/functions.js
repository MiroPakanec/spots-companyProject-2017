$(function() {
    GetUsersToInvite();
});

$("#getSpotsForm")
    .submit(function() {
        if ($(this).valid()) {
            AjaxCall(this.action, this.method, $(this).serialize(), null, getSpotsResponse, null);
        }
        return false;
    });



function getSpotsResponse(response) {
    viewModel.availableSpotsResponse(response);
}

$("#createEventForm")
    .submit(function() {
        if ($(this).valid()) {
            var data = $(this).serialize();
            AjaxCall(this.action, this.method, data, null, createEventResponse, "#create-evente-response");
        }
        return false;
    });

function createEventResponse(response, target) {

    console.log(response);
    $(target).html(response);
}

$(document)
    .on("click",
        ".search-box-button",
        function () {
            var val = $(this).find(".search-box-value").val();
            viewModel.sneakyUpdate(viewModel.locationInput, viewModel.locationNotify, val);
            $(this).parents(".search-box").slideUp(200);
        });

function GetCities(value) {
    var data = {};
    var target = "#location-response";

    if (value.length > 0) {
        data["city"] = value;
        AjaxCall("/Location/GetCities", "Post", data, null, GetCitiesResponse, target);
        return;
    }

    $(target).html("");
}

function GetCitiesResponse(response, target) {
    $(target).html(response);
}

function GetUsersToInvite() {
    AjaxCall("/User/InviteUsers", "GET", null, null, GetUsersToInviteResponse, null);
}

function GetUsersToInviteResponse(response) {

    viewModel.usersInvitationResponse(response);
}

//datepicker change
$(document).on("dp.change", ".datetimepicker", function() {

    //update view model
    var id = $(this).attr("id");
    var value = $(this).find(".form-control").val();

    if (id === "startDate") {
        viewModel.startDateInput(value);
    } else {
        viewModel.endDateInput(value);
    }
});
function AvailableSpots(callback, data) {
    AjaxCall("/Event/GetAvailableSpots", "Post", data, null, callback, "#spots-ajax-response");
}

function SubmitEvent(submitOneResponse, data) {
    AjaxCall("/Event/Create", "Post", data, null, submitOneResponse, "#create-event-response");
}

//datepicker change
$(document).on("dp.change", ".datepicker", function () {

    //update view model
    var id = $(this).attr("id");
    var value = $(this).find(".form-control").val();

    if (id === "startDate") {
        newViewModel.startDateInput(value);
    }
});

$(document)
    .on("click",
        ".search-box-button",
        function () {

            var val = $(this).find(".search-box-value").val();
            newViewModel.sneakyUpdate(newViewModel.locationInput, newViewModel.locationNotify, val);
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

$("#time-search").click(function () {
    $("#time-city").removeClass();
});

$(function () {

    $(document).on("click", ".btn-time", function () {

        var startTimeInput = $(this).text().trim().slice(11, 16);
        var endTimeInput = $(this).text().trim().slice(30, 35);

        newViewModel.startTime(startTimeInput);
        newViewModel.endTime(endTimeInput);
    });
});



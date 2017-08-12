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

function GetEvents(callback, data) {

    if ($("#event-search-form").valid()) {
        AjaxCall("/Event/Search", "Post", data, null, callback, "#search-response");
    }
}


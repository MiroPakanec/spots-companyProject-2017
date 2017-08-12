function GetBusinesses(callback, data) {

    AjaxCall("/Spot/GetBusinesses", "Post", data, null, callback, "#businessDropdownResponse");
}

function GetLocations(callback, data) {

    AjaxCall("/Spot/GetLocations", "Post", data, null, callback, "#locationDropdownResponse");
}

function GetAvailableHoursInterval(callback, data) {

    AjaxCall("/Spot/AvailableHoursInterval", "Post", data, null, callback, null);
}

function GetAvailableHoursIntervalWarning(callback) {
    
    AjaxCall("/Spot/AvailableHoursIntervalWarning", "Get", null, null, callback, null);
}
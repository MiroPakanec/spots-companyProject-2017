function GetDate(callback, data) {

    AjaxCall("/Calendar/Date", "Post", data, null, callback, null);
}

function GetCalendarContent(callback, data) {

    AjaxCall("/Calendar/CalendarResult", "Post", data, null, callback, "#calendar-response");
}

function GetEventsInDay(callback, data) {

    AjaxCall("/Calendar/CalendarFeatureEvents", "Post", data, null, callback, "#calendar-feature-events");
}

function GetEventDetails(callback, data) {

    AjaxCall("/Calendar/EventDetails", "Post", data, null, callback, "#calendar-feature-details");
}
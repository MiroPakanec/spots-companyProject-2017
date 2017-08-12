function GetTimeCityPartialContent(callback, data) {

    AjaxCall("/Event/GetCommonFreeTime", "Post", data, null, callback, "#timecity-response");
}
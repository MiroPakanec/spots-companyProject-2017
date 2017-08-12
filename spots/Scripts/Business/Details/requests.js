function GetFeatureEvents(callback, data) {

    AjaxCall("/Business/FeatureEvents/" + data, "Get", null, null, callback, "#feature-events-response");
}
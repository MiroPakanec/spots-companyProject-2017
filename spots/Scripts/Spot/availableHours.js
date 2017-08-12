$(document)
    .on("click",
        ".btn-remove-time-interval",
        function () {

            var day = $(this).closest(".day").attr("id");
            var counterObservable = GetCounterObservableFromDay(day);
            var intervalsObservable = GetIntervalObservableFromDay(day);

            //remove interval
            $(this).closest(".time-interval").remove();

            //update observables
            window.viewModel.availableHoursViewModel.removeTimeInterval(counterObservable, intervalsObservable);
        });

$(document)
    .on("click",
        ".btn-add-time-interval",
        function () {

            var day = $(this).closest(".day").attr("id");
            var counterObservable = GetCounterObservableFromDay(day);
            var intervalsObservable = GetIntervalObservableFromDay(day);

            window.viewModel.availableHoursViewModel.putTimeInterval(day, counterObservable, intervalsObservable);
        });

function GetTimeIntervalOrderId(input) {
    
    var id = $(input).closest(".time-interval").find(".btn-remove-time-interval").attr("id");
    var count = id.match(/\d+/)[0];

    return count;
}

function GetCounterObservableFromDay(day) {
    
    switch(day) {
        case "monday":
            return window.viewModel.availableHoursViewModel.mondayTimeIntervalCounter;
        case "tuesday":
            return window.viewModel.availableHoursViewModel.tuesdayTimeIntervalCounter;
        case "wednesday":
            return window.viewModel.availableHoursViewModel.wednesdayTimeIntervalCounter;
        case "thursday":
            return window.viewModel.availableHoursViewModel.thrursdayTimeIntervalCounter;
        case "friday":
            return window.viewModel.availableHoursViewModel.fridayTimeIntervalCounter;
        case "saturday":
            return window.viewModel.availableHoursViewModel.saturdayTimeIntervalCounter;
        case "sunday":
            return window.viewModel.availableHoursViewModel.sundayTimeIntervalCounter;
        default:
            throw "Unable to find counter.";
    }
}

function GetIntervalObservableFromDay(day) {

    switch (day) {
        case "monday":
            return window.viewModel.availableHoursViewModel.mondayTimeIntervals;
        case "tuesday":
            return window.viewModel.availableHoursViewModel.tuesdayTimeIntervals;
        case "wednesday":
            return window.viewModel.availableHoursViewModel.wednesdayTimeIntervals;
        case "thursday":
            return window.viewModel.availableHoursViewModel.thursdayTimeIntervals;
        case "friday":
            return window.viewModel.availableHoursViewModel.fridayTimeIntervals;
        case "saturday":
            return window.viewModel.availableHoursViewModel.saturdayTimeIntervals;
        case "sunday":
            return window.viewModel.availableHoursViewModel.sundayTimeIntervals;
        default:
            throw "Unable to find counter.";
    }
}

function LoadTimeIntervals() {

    $(".btn-add-time-interval")
        .each(function() {
            $(this).trigger("click");
        });
}

$(function () {

    $(document)
        .on("dp.change",
            ".timepicker",
            function() {

                var element = $(this);
                var result = ValidateTime(element);

                var localErrorTarget = $(element).find(".form-control").attr("error");
                var root = $(element).closest(".time-interval");
                $(root).find(localErrorTarget).text(result);

                window.viewModel.availableHoursViewModel.validateDates();
            });
});

function ValidateTime(element) {

    if (IsStartTime(element)) {

        return ValidateStartTime(element);
    }

    return ValidateEndTime(element);
}

function ValidateStartTime(element) {

    var startTime = $(element).find(".form-control").val();
    var endTime = $(element).closest(".time-interval").find(".time-interval-to").val();

    if (startTime === "" || endTime === "") {
        return "Dates cannot be empty.";
    }

    var startTimeMoment = moment(startTime, "HH:mm A");
    //if (endTime !== "") {

        var endTimeMoment = moment(endTime, "HH:mm A");
        return ValidateDates(startTimeMoment, endTimeMoment);

    //} 
        
    //return ValidateDate(startTimeMoment);
}

function ValidateEndTime(element) {
    
    var startTime = $(element).closest(".time-interval").find(".time-interval-from").val();
    var endTime = $(element).find(".form-control").val();

    if (startTime === "" || endTime === "") {
        return "Dates cannot be empty.";
    }

    var endTimeMoment = moment(endTime, "HH:mm A");
    //if (startTime !== "") {

        var startTimeMoment = moment(startTime, "HH:mm A");
        return ValidateDates(startTimeMoment, endTimeMoment);
    //}

    //return ValidateDate(endTimeMoment);
}

function IsStartTime(element) {

    return $(element).attr("id") === "from";
}

function ValidateDates(moment1, moment2) {
    
    //are valid
    if (moment1.isValid() === false) {
        return "Date is invalid.";
    }

    // do not compare if second date was not entered
    if (moment2.format('YYYY-MM-DD') === "") {
        return "";
    }

    //is after
    if (moment1.isAfter(moment2)) {
        return "Dates have incorrect order.";
    }

    //are equal
    if (moment1.diff(moment2) >= 0) {
        return "Dates cannot be equal";
    }

    return "";
}

function ValidateDate(moment) {
    
    //are valid
    if (moment.isValid() === false) {
        return "Date is invalid.";
    }

    return "";
}


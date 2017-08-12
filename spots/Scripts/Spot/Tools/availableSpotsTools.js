function GetAvailableSpotId() {

    var spotId = "";

    $(".available-spot").each(function () {

        var isSelected = $(this).hasClass("btn-selected");

        if (isSelected) {
            spotId = $(this).next().val();
        }
    });

    return spotId;
}

function GetAvailableBusinessId() {

    var businessId = "";

    $(".available-spot").each(function () {

        var isSelected = $(this).hasClass("btn-selected");

        if (isSelected) {
            businessId = $(this).next().next().val();
        }
    });

    return businessId;
}
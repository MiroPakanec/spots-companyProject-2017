$(".optionBusiness").on("click", function () {
    var id = $(this).next().val();
    viewModel.businessId(id);
    viewModel.isBusinessValid();
});

$(".optionLocation").on("click", function () {
    var id = $(this).next().val();
    viewModel.locationId(id);
    viewModel.isLocationValid();
});


function CreateSpot(submitOneResponse, data) {

    AjaxCall("/Spot/Create", "Post", data, null, submitOneResponse, "#spotCreate-ajax-response");
}


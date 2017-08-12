$(".optionBusiness").on("click", function () {

    var id = $(this).next().val();
    viewModel.businessId(id);
    viewModel.isBusinessValid();
});

function SubmitLocation(submitOneResponse, data) {
    AjaxCall("/Location/Create", "Post", data, null, submitOneResponse, "#locationCreate-ajax-response");
}


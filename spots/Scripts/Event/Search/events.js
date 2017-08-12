$(function () {

    //City Search box click
    $(document)
    .on("click",
        ".search-box-button",
        function () {
            var val = $(this).find(".search-box-value").val();
            viewModel.sneakyUpdate(viewModel.cityInput, viewModel.cityNotify, val);
            $(this).parents(".search-box").slideUp(200);

            $("#city-input").trigger("blur");
        });

    //datepicker change
    $(document).on("dp.change", ".datepicker", function () {

        //update view model
        var value = $(this).find(".form-control").val();
        viewModel.dateInput(value);
    });

    $(document).on("change", 'input:radio[id="orderBy-recent"]', function (event) {

        viewModel.orderBy("time");
        viewModel.LoadEvents();
    });

    $(document).on("change", 'input:radio[id="orderBy-popular"]', function (event) {
        viewModel.orderBy("popular");
        viewModel.LoadEvents();
    });
});

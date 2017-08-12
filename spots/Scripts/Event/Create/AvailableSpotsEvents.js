$(function() {
    $(document)
        .on("click",
            ".btn-spot",
            function () {
                //Deselect all
                $(".btn-spot")
                    .each(function() {
                        $(this).removeClass("btn-selected");
                    });

                //Select clicked
                $(this).addClass("btn-selected");
                //Save Spot id
                var spotId = $(this).next().val();
                var businessId = $(this).next().next().val();

                $("#selectedSpotId").val(spotId);
                $("#selectedBusinessId").val(businessId);
            });
});
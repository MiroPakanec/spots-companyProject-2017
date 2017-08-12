$(document)
    .on("click",
        ".search-box-button",
        function() {
            var val = $(this).find(".search-box-value").val();
            var searchBox = $(this).parents(".search-result-row").find("input");

            console.log(searchBox);
            $(searchBox).val(val);
            $(this).parents(".search-box").slideUp(200);
        });

$(document)
    .on("focusout",
        ".get-users-input",
        function () {
            $(".search-box").slideUp(200);
        });
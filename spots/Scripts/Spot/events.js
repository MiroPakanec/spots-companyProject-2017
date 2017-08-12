$(function () {

    $(document).on("click", ".dropdown-menu-business li a", function () {

        $("#dropdown-selected-business").text($(this).text());
    });
});

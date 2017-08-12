$(function () {
    var percent = 30;

    $(window)
        .scroll(function() {
            if ($(window).scrollTop() >= $(document).height() - $(window).height() - percent) {

                window.viewModel.LoadMoreEvents();
            }
        });
});
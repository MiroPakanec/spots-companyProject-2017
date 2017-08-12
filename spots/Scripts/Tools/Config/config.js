$(function () {

    $(".screen-height-60").css(
        "min-height", SetAttribute(60),
        "max-height", SetAttribute(60));

    $(".screen-height-80").css(
        "min-height", SetAttribute(80),
        "max-height", SetAttribute(80));


    $(".screen-height-100").css(
        "min-height", SetAttribute(100),
        "max-height", SetAttribute(100));
});

function SetAttribute(amount)
{
    return ((screen.availHeight) / 100) * amount;
}
$(function () {
    $(".datetimepicker").datetimepicker({
        ignoreReadonly: true,
        format: 'DD-MM-YYYY hh:mm A'
    });

    $(".datepicker").datetimepicker({
        ignoreReadonly: true,
        format: 'DD-MM-YYYY'
    });

    $(".timepicker").datetimepicker({
        ignoreReadonly: true,
        format: 'hh:mm A'
    });
});
﻿function GetForgeryToken() {
    var data = {};
    data.__RequestVerificationToken = $("input[name='__RequestVerificationToken']").val();
    return data;
};

function GetCurrentDay() {
    return (new Date().getDate()).toString();
}

function GetCurrentMonth() {
    return (new Date().getMonth() + 1).toString();
}

function GetCurrentYear() {
    return new Date().getFullYear().toString();
}

function GetCurrentHour() {
    return new Date().getHours().toString();
}

function GetCurrentMinute() {
    return new Date().getMinutes().toString();
}
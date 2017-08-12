var ViewModel = function() {
    var self = this;

    self.formModel = ko.observable(new FormModel());
    self.clear = function () {
        self.formModel(new FormModel());
        $.ajax({
            url: "ClearFormErrors"
        });
        $("#error-section").html("");
    }
}

var FormModel = function() {
    var self = this;

    self.email = ko.observable();
    self.firstName = ko.observable();
    self.lastName = ko.observable();
    self.password = ko.observable();
    self.confirmPassword = ko.observable();
}

ko.applyBindings(new ViewModel());
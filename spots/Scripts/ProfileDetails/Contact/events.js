$("#contactDetailsForm")
    .submit(
        function () {
            if ($(this).valid()) {
                CreateLocation(this.action, this.method, $(this).serialize(), null, SubmitResponse, "#user-ajax-response");
            }
            return false;
        });
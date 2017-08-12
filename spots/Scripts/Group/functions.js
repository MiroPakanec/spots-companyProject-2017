function SearchBoxUpdate(value, viewModel) {

    if (value.length <= 0 || viewModel.memberList.newMemberUpdate === false) {
        viewModel.emailResponse("");
        viewModel.memberList.newMemberUpdate = true;
        return;
    }

    var escaped = value.replace(/\./g, "(dot)");
    var url = "/Business/GetUsers/" + escaped;

    GetUsers(function (response) {
        viewModel.emailResponse(response);
    }, url);
}

function ConfirmUpdate(value, viewModel) {

    var existsInList = arrayFirstIndexOf(viewModel.memberList.items(),
        function (item) {
            return item.name === value;
        });

    if (value.length <= 0) {
        return;
    }

    if (existsInList !== -1) {
        viewModel.memberList.alreadyInList(true);
        return;
    }
    viewModel.memberList.alreadyInList(false);

    var escaped = value.replace(/\./g, "(dot)");
    var url = "/User/IsRegistered/" + escaped;

    IsUserRegistered(function (response) {

        if (response.toLowerCase() === "true") {
            viewModel.memberList.confirmed(true);
            return;
        }

        viewModel.memberList.confirmed(false);

    }, url);
}

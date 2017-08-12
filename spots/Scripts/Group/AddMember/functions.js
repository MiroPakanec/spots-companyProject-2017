function SearchBoxUpdate(value, addMemberViewModel) {

    if (value.length <= 0 || addMemberViewModel.addMemberList.newMemberUpdate === false) {

        addMemberViewModel.emailResponse("");
        addMemberViewModel.addMemberList.newMemberUpdate = true;
        return;
    }

    var escaped = value.replace(/\./g, "(dot)");
    var url = "/Business/GetUsers/" + escaped;

    GetUsers(function (response) {
        addMemberViewModel.emailResponse(response);
    }, url);
}

function ConfirmUpdate(value, addMemberViewModel) {

    var existsInList = arrayFirstIndexOf(addMemberViewModel.addMemberList.items(),
        function (item) {
            return item.name === value;
        });

    if (value.length <= 0) {
        return;
    }

    if (existsInList !== -1) {
        addMemberViewModel.addMemberList.alreadyInList(true);
        return;
    }

    addMemberViewModel.addMemberList.alreadyInList(false);

    var escaped = value.replace(/\./g, "(dot)");
    var url = "/User/IsRegistered/" + escaped;

    IsUserRegistered(function (response) {

        if (response.toLowerCase() === "true") {
            addMemberViewModel.addMemberList.confirmed(true);
            return;
        }

        addMemberViewModel.addMemberList.confirmed(false);

    }, url);
}
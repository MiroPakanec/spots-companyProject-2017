$(function () {
    $(document)
        .on("click",
            "#add-friend",
            function () {

                var url = "/Group/AddGroupMember?email=" + personalViewModel.email + "&groupId=" + personalViewModel.groupId();

                PushUser(function (response, target) {

                    $(target).html(response);
                    personalViewModel.getFriendButton();
                }, url);
            });

    $(document)
        .on("click",
            "#remove-friend",
            function () {

                var url = "/Group/RemoveGroupMember?email=" + personalViewModel.email + "&groupId=" + personalViewModel.groupId();

                RemoveUser(function (response, target) {

                    $(target).html(response);
                    personalViewModel.getFriendButton();
                }, url);
            });

});
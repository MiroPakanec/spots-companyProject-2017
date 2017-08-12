$(function () {

    $(document)
        .on("click",
            ".btn-add",
            function () {

                if (detailsViewModel.isLoaded()) {

                    $('.addmembers').load("/Group/AddGroupMembers");
                    $(".btn-remove-user").removeClass("invisible");
                    detailsViewModel.isLoaded(false);
                }
            });

    $(document)
        .on("click",
            ".search-box-button",
            function () {

                var val = $(this).find(".search-box-value").val();
                addMemberViewModel.sneakyUpdate(addMemberViewModel.addMemberList.newMember, addMemberViewModel.memberNotify, val);
                $(this).parents(".search-box").slideUp(200);
        });

    $(document)
        .on("click",
            ".btn-remove-user",
            function () {

                var email = $(this).next().attr("id");
                addMemberViewModel.removeUser(email);
        });


});

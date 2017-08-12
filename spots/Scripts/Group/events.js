$(function() {
    $(document)
        .on("click",
            ".search-box-button",
            function () {

                var value = $(".search-box-value").val();

                //How fix
                if (value === viewModel.memberList.newMember()) {
                    viewModel.memberList.newMember("");
                }

                viewModel.memberList.newMemberUpdate = false;
                viewModel.memberList.newMember(value);
            });

});
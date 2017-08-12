$(document)
    .on("click",
        ".btn-invite",
        function() {

            if ($(this).hasClass("btn-selected")) {

                $(this).removeClass("btn-selected");
                $(this).children(".invited").html("");
            } else {
                
                $(this).addClass("btn-selected");
                
                var element = $(this).children(".invited");
                var id = $(element).attr("id");
                var html = '<input type="hidden" name="invited" value="'+id+'">';
                $(element).html(html);
            }

            console.log($(this).children(".invited").html());
        });
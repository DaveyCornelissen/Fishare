$(document).on("click",
    "#SubitSearchBox",
    function(e) {
        event.preventDefault();
        var SearchVal = $('#FriendsSearchBox').val();
        var url = "Profile";

        $.ajax({
            type: 'POST',
            url: url,
            data: { SearchValue: SearchVal },
            success: function(data) {
                //$("#FriendsPage .modal-body").html(data);
                $("#ProfilePage").html(data);
                console.log(data);
            }
        })
    });
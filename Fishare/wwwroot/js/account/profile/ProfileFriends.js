$('.FriendModalButton').on('click',
    function(evt) {
        evt.preventDefault();
        evt.stopPropagation();

        var ProfileId = $(this).val();

        $.ajax({
            type: 'GET',
            url: 'ProfileFriends',
            data: { 'Id': ProfileId},
            success: function(data) {
                $('#LocationFriendsModalContainer').html(data);
                $('#FriendsPage').modal('show');
                console.log(data);
            }
        });
    });


$(document).on('click',
    ".FriendActionButton",
    function (evt) {
        var ButtonValue = $(this).val();

        //split the value of the button
        var res = ButtonValue.split("+");
        var type = res[1];
        var Id = res[0];

        GetAjaxRequest(type, Id, evt);
    });

function GetAjaxRequest(type, Id, evt) {
    evt.preventDefault();
    evt.stopPropagation();
    $.ajax({
        type: 'POST',
        url: 'ProfileFriends',
        data: { ButtonType: type, FriendID: Id },
        success: function(data) {
            $('#FriendsPage').modal('hide');
            $('#LocationFriendsModalContainer').html(data);
            $('#FriendsPage').modal('show');
        }
    })
}

//search ajax
$(document).on("click",
    "#SubitSearchBox",
        function (evt) {
        evt.preventDefault();
        evt.stopPropagation();
        var SearchVal = $('#FriendsSearchBox').val();
        var url = "ProfileFriends";

        $.ajax({
            type: 'POST',
            url: url,
            data: { SearchValue: SearchVal },
            success: function(data) {
                $('#FriendsPage').modal('hide');
                $('#LocationFriendsModalContainer').html(data);
                $('#FriendsPage').modal('show');
            }
        })
    });
$(function() {
    $('.post-using-ajax').each(function() {
        var $frm = $(this);
        $frm.submit(function(e) {
            e.preventDefault();

            $.ajax({
                type: $frm.attr('method'),
                url: $frm.attr('action'),
                data: $frm.serialize(),
                success: function(data) {
                    $('#AccountSettings').modal('hide');
                    $("#ProfilePage").html(data);
                }
            });
        });
    });
});

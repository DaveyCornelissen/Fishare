$(function () {
    $('.post-using-ajax').each(function() {
        var $frm = $(this);
        $frm.submit(function(e) {
            e.preventDefault();

            $.ajax({
                type: $frm.attr('method'),
                url: $frm.attr('action'),
                data: { $frm.serialize(), SettingsCall : true },
                dataType: 'html',
                success: function (data) {
                    $('#AccountSettings').modal('hide');
                    $("#ProfilePage").html(data);
                    $('#AccountSettings').modal('show');
                    console.log(data);
                }
            });
        });
    });
});

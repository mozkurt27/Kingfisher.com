/// <reference path="jquery-3.2.1.js" />
/// <reference path="bootstrap.js" />

$('.nav li').filter('.sidebar-menu').hover(MouseHoverIn, MouseHoverOut);


function MouseHoverIn() {
    var id = this.id;

    if (id != null) {
        if ($('#toggle').prop('checked')) {
        $.ajax({
            url: '/home/effect/' + id,
            method: 'get',
            success: function (response) {
                if (response.length > 0) {
                    $('#content-body').html(response);
                }
            }


        })

        }


    }

}

function MouseHoverOut() {
    //$.ajax({
    //    url: '/home/effect/',
    //    method: 'get',
    //    success: function (response) {
    //        if (response.length > 0) {
    //            $('#content-body').html(response);
    //        }
    //    }


    //})
}
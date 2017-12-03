/// <reference path="bootstrap.js" />
/// <reference path="jquery-3.2.1.js" />


$(document).ready(function () {
    $('.sidebar-menu').click(function () {
    
        if ($('#toggle').prop('checked')) {
            $('#toggle').prop('checked',false);
        }

    })

});




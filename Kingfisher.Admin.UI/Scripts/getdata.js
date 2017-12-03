/// <reference path="jquery-3.2.1.js" />


$('.book').on('click', function () {

    id = this.id;

    $.ajax({
        url: 'http://localhost:6834/book/'+id,
        method: 'get',
        success: function (res) {
            $('#content-body').html(res);
        },
        error: function (err) {
        }

    });

});


function getInsert() {
    $.ajax({
        url: 'http://localhost:6834/book/add',
        method: 'post',
        data:$('#insert-form').serialize(),
        success:function(res){
            console.log(res);
        },
        error:function(err){
        
        }

    });
}
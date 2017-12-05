/// <reference path="jquery-3.2.1.js" />

function bookUpdate(id) {
    if (id != null) {
        $.ajax({
            url: '/book/getonebook/' + id,
            method: 'get',
            success: function (response) {
                if (response != null) {
                    //$('#update-form').css('display', 'block');

                    //$('#form-id').val(response.Id);
                    //$('#form-name').val(response.Name);
                    //$('#form-price').val(response.Price);
                    //$('#form-stock').val(response.Stock);
                    //$('#form-quantity').val(response.Quantity);

                    $('#content-body').html(response);
                }

            },
            error: function (err) {
                console.log(err);
            }



        });
    }

}
function bookDelete(id) {
    if (id != null) {
        $.ajax({
            url: '/book/delete/'+id,
            method: 'get',
            success: function (res) {
                debugger;
                console.log(res);
            },
            error: function (err) {

                debugger;
            }

        });
    }
}

$('#update-form').submit(function (e) {
    e.preventDefault();

    $.ajax({
        url: '/book/update',
        method: 'post',
        data : $('#update-form').serialize(),
        success: function (resp) {

            debugger;
           
        },
        error: function (err) {
            console.log(err);
        }

    })
})

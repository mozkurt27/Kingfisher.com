function getChange(id) {
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



        })
    }

}

$(document).on('click', '#close', function (e) {
    e.preventDefault();

    $.ajax({
        type: "POST",
        url: "PanelGeneral.aspx/Logout",
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (response) {
            if (response.d == true) {
                window.location.href = "Login.aspx";
            }
        }
    });
});
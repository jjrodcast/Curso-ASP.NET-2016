var tabla, data;

function sendDataAjax() {
    $.ajax({
        type: "POST",
        url: "GestionarMenus.aspx/ListarMenu",
        data: {},
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            addRowDT(data.d);
        }
    });
}


function addRowDT(data) {
    tabla = null;
    tabla = $("#tbl_menus").DataTable({
        "aaSorting": [[0, 'desc']],
        "bSort": true,
        "bDestroy": true,
        "aoColumns": [
            null,
            null,
            null,
            null,
            { "bSortable": false },
            { "bSortable": false, "bVisible": false },
            { "bSortable": false }
        ]
    });

    //tabla = $("#tbl_menus").DataTable();
    tabla.fnClearTable();

    for (var i = 0; i < data.PMenu.length; i++) {
        tabla.fnAddData([
            data.PMenu[i].IdMenu,
            data.PMenu[i].Nombre,
            data.PMenu[i].Url,
            (data.PMenu[i].Estado) ? "Activo" : "Inactivo",
            (data.PMenu[i].IsSubMenu) ? "Si" : "No",
            data.PMenu[i].IdMenuParent,
            '<button type="button" value="Actualizar" title="Actualizar" class="btn btn-primary btn-edit" data-target="#imodal" data-toggle="modal"><i class="fa fa-check-square-o" aria-hidden="true"></i></button>&nbsp;' +
            '<button type="button" value="Eliminar" title="Desactivar" class="btn btn-danger btn-delete"><i class="fa fa-minus-square-o" aria-hidden="true"></i></button>'

        ]);
    }
}

// evento click para boton actualizar
$(document).on('click', '.btn-edit', function (e) {
    e.preventDefault();

    var row = $(this).parent().parent()[0];
    data = tabla.fnGetData(row);
    fillModalData();

});

// evento click para boton eliminar
$(document).on('click', '.btn-delete', function (e) {
    e.preventDefault();

    //primer método: eliminar la fila del datatble
    var row = $(this).parent().parent()[0];
    var dataRow = tabla.fnGetData(row);
    //segundo método: enviar el codigo del paciente al servidor y eliminarlo, renderizar el datatable
    // paso 1: enviar el id al servidor por medio de ajax
    deleteDataAjax(dataRow[0]);
    // paso 2: renderizar el datatable
    sendDataAjax();

});

function updateDataAjax() {

    var obj = JSON.stringify({
        id: JSON.stringify(data[0]),
        nombrePermiso: $("#txtANombrePermiso").val(),
        urlPermiso: $("#txtAUrlPermiso").val(),
        ymenuPrincipal: $("#ddlAMenuPrincipal").val(),
        zisActivo: $("#chkAActivo").is(':checked'),
        zisSubmenu: $("#chkAIsSubmenu").is(':checked')
    });

    $.ajax({
        type: "POST",
        url: "GestionarMenus.aspx/ActualizarDatosMenu",
        data: obj,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (response) {
            if (response.d) {
                alert("Registro actualizado de manera correcta.");
                sendDataAjax();
            } else {
                alert("No se pudo actualizar el registro.");
            }
        }
    });
}

function deleteDataAjax(data) {

    var obj = JSON.stringify({ id: JSON.stringify(data) });

    $.ajax({
        type: "POST",
        url: "GestionarMenus.aspx/EliminarDatosMenu",
        data: obj,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (response) {
            if (response.d) {
                alert("Registro eliminado de manera correcta.");
                sendDataAjax();
            } else {
                alert("No se pudo eliminar el registro.");
            }
        }
    });
}

// cargar datos en el modal
function fillModalData() {
    $("#txtANombrePermiso").val(data[1]);
    $("#txtAUrlPermiso").val(data[2]);
    if (data[3] == "Activo") {
        $("#chkAActivo").prop('checked', true);
        $('#chkAActivo').parent()[0].classList.add("checked");
    } else {
        $("#chkAActivo").prop('checked', false);
        $('#chkAActivo').parent()[0].classList.remove("checked");
    }
    if(data[4] == "Si") {
        $("#chkAIsSubmenu").prop('checked', true);
        $('#chkAIsSubmenu').parent()[0].classList.add("checked");
    } else {
        $("#chkAIsSubmenu").prop('checked', false);
        $('#chkAIsSubmenu').parent()[0].classList.remove("checked");
    }
    $("#ddlAMenuPrincipal").val(data[5]).change();
}

// enviar la informacion al servidor
$("#btnactualizar").click(function (e) {
    e.preventDefault();
    updateDataAjax();
});

sendDataAjax();
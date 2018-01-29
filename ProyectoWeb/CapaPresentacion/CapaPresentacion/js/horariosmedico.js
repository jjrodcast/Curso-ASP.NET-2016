//Configuracion de timepicker y date
$("[data-mask]").inputmask();
$(".timepicker").timepicker({ showInputs: false, showMeridian: false, minuteStep: 30 });

var tabla;

function initDataTable() {

    tabla = $("#tbl_horarios").DataTable({
        "aaSorting": [[0, 'desc']],
        "bSort": true,
        "aoColumns": [
            { "bSortable": false },
            { "bSortable": false },
            { "bSortable": false },
            null,
            null
        ]
    });

    tabla.fnSetColumnVis(2, false);
}

initDataTable();


$("#btnBuscar").on("click", function (event) {

    event.preventDefault();

    // obtener los datos del texto de dni
    var dni = $("#txtDni").val();

    var obj = JSON.stringify({ dni: dni });

    if (dni.length > 0) {
        // llamada a ajax
        $.ajax({
            type: "POST",
            url: "GestionarHorarioAtencion.aspx/BuscarMedico",
            data: obj,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                //console.log("éxito", data);
                if (data.d !== null) {
                    llenarDatosMedico(data.d);
                    listHorarios(data.d.IdMedico);
                } else {
                    llenarDatosMedicoDefault(data.d);
                }
            }
        });
    } else {
        console.log("No ha ingresado un dni.");
    }
});

function llenarDatosMedico(obj) {
    $("#lblNombres").text(obj.Nombre);
    $("#lblApellidos").text(obj.ApPaterno.concat(" ".concat(obj.ApMaterno)));
    $("#lblEspecialidad").text(obj.Especialidad.Descripcion);
    $("#txtMedico").val(obj.IdMedico);
}

function llenarDatosMedicoDefault() {
    alert("No existe médico con documento " + $("#txtDni").val());
    $("#lblNombres").text("");
    $("#lblApellidos").text("");
    $("#lblEspecialidad").text("");
    $("#txtMedico").val("0");
    $("#txtDni").val("");
}

function editarDatosMedico(obj) {
    $("#txtEditarFecha").val(obj[3]);
    $("#txtEditarHora").val(obj[4]);
    $("#txtIdHorarioAtencion").val(obj[2]);
}

// agregar un horario
$("#btnAgregar").on("click", function (event) {
    event.preventDefault();
    //obtener los valores de los campos
    var fecha, hora, idmedico;
    fecha = $("#txtFecha").val();
    hora = $("#txtHoraInicio").val();
    idmedico = $("#txtMedico").val();

    if (fecha.length > 0 && hora.length > 0 && idmedico > 0) {
        var obj = JSON.stringify({ fecha: fecha, hora: hora, idmedico: idmedico });
        // llamada a ajax
        $.ajax({
            type: "POST",
            url: "GestionarHorarioAtencion.aspx/AgregarHorario",
            data: obj,
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (data) {
                //console.log("éxito", data.d);
                // cerrar ventana modal usando jquery
                $("#AgregarHorario").modal('toggle');
                addRow(data.d);
            }
        });

    } else {
        if (parseInt(idmedico) < 1) {
            alert("Ingrese la información del médico.");
        } else {
            alert("Ingrese los datos requeridos.");
        }
    }
});

function addRow(obj) {

    var fecha = moment(obj.Fecha).toDate();

    tabla.fnAddData(
        ['<button type="button" value="Actualizar" title="Actualizar" class="btn btn-primary btn-edit" data-target="#imodal" data-toggle="modal"><i class="fa fa-check-square-o" aria-hidden="true"></i></button>&nbsp;',
          '<button type="button" value="Eliminar" title="Eliminar" class="btn btn-danger btn-delete"><i class="fa fa-minus-square-o" aria-hidden="true"></i></button>',
          obj.IdHorarioAtencion,
          fecha.format("dd/MM/yyyy"),
          obj.Hora.hora
        ]
    );
}

function formatDate(date) {
    var fecha = date.replace('/Date(', '');
    fecha = fecha.replace(')/', '');
    fecha = new Date(parseInt(fecha));
    //console.log(fecha.format("dd/MM/yyyy"));
}


function listHorarios(idmedico) {

    var obj = JSON.stringify({ idmedico: idmedico });

    $.ajax({
        type: "POST",
        url: "GestionarHorarioAtencion.aspx/ListarHorariosAtencion",
        data: obj,
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            //console.log("éxito", data);
            tabla.fnClearTable();
            for (var i = 0; i < data.d.length; i++) {
                addRow(data.d[i]);
            }
        }
    });

}

// evento click para boton eliminar
$(document).on('click', '.btn-delete', function (e) {
    e.preventDefault();

    var row = $(this).parent().parent()[0];
    var dataRow = tabla.fnGetData(row);

    var response = confirm("¿Está seguro que desea eliminar el horario?");
    if (response) {
        deleteDataAjax(dataRow[2]);
        listHorarios($("#txtMedico").val());
    }

});

// evento click para boton eliminar
$(document).on('click', '.btn-edit', function (e) {
    e.preventDefault();

    var row = $(this).parent().parent()[0];
    var dataRow = tabla.fnGetData(row);

    llenarDatosHorario(dataRow);


});

function llenarDatosHorario(data) {
    $("#txtEditarFecha").val(data[3]);
    $("#txtEditarHora").val(data[4]);
    $("#txtIdHorario").val(data[2]);
}

$("#btnEditar").click(function (e) {

    e.preventDefault();

    var obj = JSON.stringify({
        idmedico: $("#txtMedico").val(),
        idhorario: $("#txtIdHorario").val(),
        fecha: $("#txtEditarFecha").val(),
        hora: $("#txtEditarHora").val()
    });

    $.ajax({
        type: "POST",
        url: "GestionarHorarioAtencion.aspx/ActualizarHorarioAtencion",
        data: obj,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (response) {
            if (response.d) {
                listHorarios($("#txtMedico").val());
                alert("Registro actualizado de manera correcta.");
            } else {
                alert("No se pudo actualizar el registro.");
            }
        }
    });
});


function deleteDataAjax(data) {

    var obj = JSON.stringify({ id: JSON.stringify(data) });

    $.ajax({
        type: "POST",
        url: "GestionarHorarioAtencion.aspx/EliminarHorarioAtencion",
        data: obj,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (response) {
            if (response.d) {
                alert("Registro eliminado de manera correcta.");
            } else {
                alert("No se pudo eliminar el registro.");
            }
        }
    });
}
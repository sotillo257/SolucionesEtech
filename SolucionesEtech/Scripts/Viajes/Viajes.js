$(document).ready(function () {
    var _IdViaje = 0;
    var myTableViaje = $('#dt-Viajes').DataTable({
        fixedHeader: true,
        "ajax": {
            url: "/api/" + urlObtenerViajes,
            dataType: "json",
            method: "GET",
            contentType: 'application/json; charset=utf-8'
        },
        columns: [
            { data: "Codigo" },
            { data: "NumeroPlazas" },
            { data: "Origen.Nombre" },
            { data: "Destino.Nombre" },
            { data: "Precio" },
            { data: "null", "defaultContent": "" }
        ],
        "columnDefs": [{
            "className": "tdCentrado",
            "targets": -1,
            "createdCell": function (td, cellData, rowData, row, col) {
                $(td).prepend(
                    ` <div class="dropdown  btn-group m-r-xs m-b-xs">
                           <button type="button" class="btn btn-info dropdown-toggle btn-sm" style='width: 65px;padding: 0px;height: 28px;' data-toggle="dropdown" aria-expanded="false">Accion<span class="caret"></span></button>
                        <div class="dropdown-menu" role="menu">     
                                <a class="dropdown-item btn-verViajeros" data-toggle="modal" data-target=".bd-viajeros-modal"  >
                                    Ver viajeros
                                    </a>
                            <a class="dropdown-item btn-modificar" data-toggle="modal" data-target=".bd-new-modal" >
                                Modificar
                                    </a>                               
                            <a class="dropdown-item btn-eliminar"  >
                                Eliminar
                                    </a>
                           
                        </div>
                    </div>`
                );
            }
        }]
    });

    var myTableViajeros = CargarTablaViajes(0);

    $("#btGuardar").click(function () {
        if (ValidarCamposVacios()) {
            if (_IdViaje > 0) {
                ModificarViaje(_IdViaje);
            } else {
                InsertarViaje();
            }
            myTableViaje.ajax.reload();
        } else {
            swal({
                title: "Error!",
                text: "Debe llenar todos los campos.",
                type: 'warning',
            });
        }
    });

    $("#btNuevoViaje").click(function () {
        _IdViaje = 0;
        $("#myModalLabel").html("Agregar nuevo Viaje");
        VaciarCampos();
        $("#btSave").show();
    });

    $(document).on("click", ".btn-verViajeros", function () {
        var Viaje = myTableViaje.row($(this).parents('tr')).data();
        _IdViaje = Viaje.Id;
        myTableViajeros.destroy();
        myTableViajeros = CargarTablaViajes(_IdViaje);

    });

    $(document).on("click", ".btn-modificar", function () {
        var Viaje = myTableViaje.row($(this).parents('tr')).data();
        _IdViaje = Viaje.Id;
        $("#btSave").show();
        $("#myModalLabel").html("Editar Viaje");

        $("#txtCodigo").val(Viaje.Codigo);
        $("#txtNumeroPlazas").val(Viaje.NumeroPlazas);
        $("#cbOrigen").val(Viaje.Origen.Id);
        $("#cbDestino").val(Viaje.Destino.Id);
        $("#txtPrecio").val(Viaje.Precio);
    });

    $(document).on("click", ".btn-eliminar", function () {
        var Viaje = myTableViaje.row($(this).parents('tr')).data();
        _IdViaje = Viaje.Id;

        swal({
            title: 'Estas seguro de querer eliminar este Viaje?',
            text: 'No podrás recuperar esta información!',
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#DD6B55',
            confirmButtonText: 'Sí, eliminar!',
            closeOnConfirm: false,
            showLoaderOnConfirm: true,
        }, function () {
            setTimeout(function () {
                EliminarViaje(_IdViaje);
                myTableViaje.ajax.reload();
            }, 2000);
        });
    });
});

function ValidarCamposVacios() {
    var aux = true;
    // saveButton begin
    if ($('#txtCodigo').val() == "") {
        $('#txtCodigo').addClass("invalid");
        aux = false;
    } else {
        $('#txtCodigo').removeClass("invalid");
    }

    if ($('#txtNumeroPlazas').val() == "") {
        $('#txtNumeroPlazas').addClass("invalid");
        aux = false;
    } else {
        $('#txtNumeroPlazas').removeClass("invalid");
    }

    if ($('#cbOrigen').val() == 0) {
        $('#cbOrigen').addClass("invalid");
        aux = false;
    } else {
        $('#cbOrigen').removeClass("invalid");
    }

    if ($('#cbDestino').val() == 0) {
        $('#cbDestino').addClass("invalid");
        aux = false;
    } else {
        $('#cbDestino').removeClass("invalid");
    }

    if ($('#txtPrecio').val() == "") {
        $('#txtPrecio').addClass("invalid");
        aux = false;
    } else {
        $('#txtPrecio').removeClass("invalid");
    }

    return aux;
}

function VaciarCampos() {
    $("#txtCodigo").val("");
    $("#txtNumeroPlazas").val("");
    $("#cbOrigen").val("");
    $("#cbDestino").val("");
    $("#txtPrecio").val("");
}

function InsertarViaje() {

    var pViaje =
    {
        Id: 0,
        Codigo: $("#txtCodigo").val(),
        NumeroPlazas: $("#txtNumeroPlazas").val(),
        Origen: { Id: $("#cbOrigen").val() },
        Destino: { Id: $("#cbDestino").val() },
        Precio: $("#txtPrecio").val()
    };

    $.ajax({
        type: 'POST',
        data: JSON.stringify(pViaje),
        url: '/api/' + urlInsertarViaje,
        async: false,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            if (response.Result == true) {
                swal('Excelente!', 'Viaje creado!', 'success');
                $("#modalViaje").trigger("click");
            } else {
                swal({
                    title: "Error",
                    text: "No se pudo crear el Viaje.",
                    type: 'warning',
                });
            }
        },
        error: function (err) {
            swal({
                title: "Error",
                text: "No se pudo crear el Viaje.",
                type: 'warning',
            });
        },

    });
}

function ModificarViaje(IdViaje) {

    var pViaje =
    {
        Id: IdViaje,
        Codigo: $("#txtCodigo").val(),
        NumeroPlazas: $("#txtNumeroPlazas").val(),
        Origen: { Id: $("#cbOrigen").val() },
        Destino: { Id: $("#cbDestino").val() },
        Precio: $("#txtPrecio").val()
    };

    $.ajax({
        type: 'PUT',
        data: JSON.stringify(pViaje),
        url: '/api' + urlModificarViaje,
        async: false,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            if (response.Result == true) {
                swal('Excelente!', 'Viaje modificado!', 'success');
                $("#modalViaje").trigger("click");
            } else {
                swal({
                    title: "Error",
                    text: "No se pudo modificar el Viaje.",
                    type: 'warning',
                });
            }
        },
        error: function (err) {
            swal({
                title: "Error",
                text: "No se pudo modificar el Viaje.",
                type: 'warning',
            });
        },

    });
}

function EliminarViaje(IdViaje) {

    var pViaje =
    {
        Id: IdViaje
    };

    $.ajax({
        type: 'DELETE',
        data: JSON.stringify(pViaje),
        url: '/api' + urlEliminarViaje,
        async: false,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            if (response.Result == true) {
                swal('Excelente!', 'Viaje eliminado!', 'success');
                $("#modalViaje").trigger("click");
            } else {
                swal({
                    title: "Error",
                    text: "No se pudo eliminar el Viaje.",
                    type: 'warning',
                });
            }
        },
        error: function (err) {
            console.log(err);
            swal({
                title: "Error",
                text: "No se pudo eliminar el Viaje.",
                type: 'warning',
            });
        },

    });
}

function CargarTablaViajes(pIdViaje) {
    var myTable = $('#dt-Viajeros').DataTable({
        fixedHeader: true,
        "ajax": {
            url: "/api" + urlObtenerViajerosxViaje,
            dataType: "json",
            method: "GET",
            async: false,
            data: { "pIdViaje": pIdViaje },
            contentType: 'application/json; charset=utf-8'
        },
        columns: [
            { data: "Viajero.Cedula" },
            { data: "Viajero.Nombre" },
            { data: "Viajero.Direccion" },
            { data: "Viajero.Telefono" }
        ]
    });
    return myTable;
}
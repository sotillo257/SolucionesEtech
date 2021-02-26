$(document).ready(function () {
    var _IdViajero = 0;
    var myTableViajero = $('#dt-Viajeros').DataTable({
        fixedHeader: true,
        "ajax": {
            url: "/api/" + urlObtenerViajeros,
            dataType: "json",
            method: "GET",
            contentType: 'application/json; charset=utf-8'
        },
        columns: [
            { data: "Cedula" },
            { data: "Nombre" },
            { data: "Direccion" },
            { data: "Telefono" },
            { data: "null", "defaultContent": "" }
        ],
        "columnDefs": [{
            "className": "tdCentrado",
            "targets": -1,
            "createdCell": function (td, cellData, rowData, row, col) {
                $(td).prepend(
                    ` <div class="dropdown  btn-group m-r-xs m-b-xs">
                           <button type="button" class="btn btn-info dropdown-toggle btn-sm" style='width: 65px;padding: 0px;height: 28px;' data-toggle="dropdown" aria-expanded="false">Accion<span class="caret"></span></button>
                        <div class="dropdown-menu"  role="menu">     
                                <a class="dropdown-item btn-verViajes" data-toggle="modal" data-target=".bd-viajes-modal"  >
                                    Ver viajes
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

    var myTableViajes = CargarTablaViajes(0);

    $("#btGuardar").click(function () {
        if (ValidarCamposVacios()) {
            if (_IdViajero > 0) {
                ModificarViajero(_IdViajero);
            } else {
                InsertarViajero();
            }
            myTableViajero.ajax.reload();
        } else {
            swal({
                title: "Error!",
                text: "Debe llenar todos los campos.",
                type: 'warning',
            });
        }
    });

    $("#btNuevoViajero").click(function () {
        _IdViajero = 0;
        $("#myModalLabel").html("Agregar nuevo Viajero");
        VaciarCampos();
        $("#btSave").show();
    });

    $("#btNuevoViaje").click(function () {
        if ($("#cbViajes").val() > 0) {
            InsertarViajeroaViaje(_IdViajero);
            LlenarComboViajes(_IdViajero);
            myTableViajes.ajax.reload();
        } else
        {
            swal({
                title: "Error!",
                text: "Debe seleccionar un viaje.",
                type: 'warning',
            });
        }
        
    });

    $(document).on("click", ".btn-verViajes", function () {
        var Viajero = myTableViajero.row($(this).parents('tr')).data();
        _IdViajero = Viajero.Id;
        myTableViajes.destroy();
        myTableViajes = CargarTablaViajes(_IdViajero);
        LlenarComboViajes(_IdViajero);
        
    });

    $(document).on("click", ".btn-eliminar", function () {
        var Viajero = myTableViajero.row($(this).parents('tr')).data();
        _IdViajero = Viajero.Id;

        swal({
            title: 'Estas seguro de querer eliminar este viajero?',
            text: 'No podrás recuperar esta información!',
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#DD6B55',
            confirmButtonText: 'Sí, eliminar!',
            closeOnConfirm: false,
            showLoaderOnConfirm: true,
        }, function () {
            setTimeout(function () {
                EliminarViajero(_IdViajero);
                myTableViajero.ajax.reload();
            }, 2000);
        });
    });
    $(document).on("click", ".btn-eliminar-viaje", function () {
        var Viaje = myTableViajes.row($(this).parents('tr')).data();
        swal({
            title: 'Estas seguro de querer eliminar este viaje realizado?',
            text: 'No podrás recuperar esta información!',
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#DD6B55',
            confirmButtonText: 'Sí, eliminar!',
            closeOnConfirm: false,
            showLoaderOnConfirm: true,
        }, function () {
                setTimeout(function () {
                    EliminarViajeRealizado(Viaje.Id, Viaje.Viaje.Id);
                    LlenarComboViajes(Viaje.Viaje.Id);
                myTableViajes.ajax.reload();
            }, 2000);
        });
    });

    $(document).on("click", ".btn-modificar", function () {
        var Viajero = myTableViajero.row($(this).parents('tr')).data();
        _IdViajero = Viajero.Id;
        $("#btSave").show();
        $("#myModalLabel").html("Editar Viajero");

        $("#txtCedula").val(Viajero.Cedula);
        $("#txtNombre").val(Viajero.Nombre);
        $("#txtDireccion").val(Viajero.Direccion);
        $("#txtTelefono").val(Viajero.Telefono);
    });
});

function ValidarCamposVacios() {
    var aux = true;
    // saveButton begin
    if ($('#txtCedula').val() == "") {
        $('#txtCedula').addClass("invalid");
        aux = false;
    } else {
        $('#txtCedula').removeClass("invalid");
    }

    if ($('#txtNombre').val() == "") {
        $('#txtNombre').addClass("invalid");
        aux = false;
    } else {
        $('#txtNombre').removeClass("invalid");
    }

    if ($('#txtDireccion').val() == "") {
        $('#txtDireccion').addClass("invalid");
        aux = false;
    } else {
        $('#txtDireccion').removeClass("invalid");
    }

    if ($('#txtTelefono').val() == "") {
        $('#txtTelefono').addClass("invalid");
        aux = false;
    } else {
        $('#txtTelefono').removeClass("invalid");
    }

    return aux;
}

function VaciarCampos() {
    $("#txtCedula").val("");
    $("#txtNombre").val("");
    $("#txtDireccion").val("");
    $("#txtTelefono").val("");
}

function InsertarViajero() {

    var pViajero =
    {
        Id: 0,
        Cedula: $("#txtCedula").val(),
        Nombre: $("#txtNombre").val(),
        Direccion: $("#txtDireccion").val(),
        Telefono: $("#txtTelefono").val(),
    };

    $.ajax({
        type: 'POST',
        data: JSON.stringify(pViajero),
        url: '/api/'+urlInsertarViajero,
        async: false,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            if (response.Result == true) {
                swal('Excelente!', 'Viajero creado!', 'success');
                $("#modalViajero").trigger("click");
            } else {
                swal({
                    title: "Error",
                    text: "No se pudo crear el viajero.",
                    type: 'warning',
                });
            }
        },
        error: function (err) {
            swal({
                title: "Error",
                text: "No se pudo crear el viajero.",
                type: 'warning',
            });
        },

    });
}

function ModificarViajero(IdViajero) {

    var pViajero =
    {
        Id: IdViajero,
        Cedula: $("#txtCedula").val(),
        Nombre: $("#txtNombre").val(),
        Direccion: $("#txtDireccion").val(),
        Telefono: $("#txtTelefono").val(),
    };

    $.ajax({
        type: 'PUT',
        data: JSON.stringify(pViajero),
        url: '/api' + urlModificarViajero,
        async: false,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            if (response.Result == true) {
                swal('Excelente!', 'Viajero modificado!', 'success');
                $("#modalViajero").trigger("click");
            } else {
                swal({
                    title: "Error",
                    text: "No se pudo modificar el viajero.",
                    type: 'warning',
                });
            }
        },
        error: function (err) {
            swal({
                title: "Error",
                text: "No se pudo modificar el viajero.",
                type: 'warning',
            });
        },

    });
}

function EliminarViajero(IdViajero) {

    var pViajero =
    {
        Id: IdViajero
    };

    $.ajax({
        type: 'DELETE',
        data: JSON.stringify(pViajero),
        url: '/api' + urlEliminarViajero,
        async: false,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            if (response.Result == true) {
                swal('Excelente!', 'Viajero eliminado!', 'success');
                $("#modalViajero").trigger("click");
            } else {
                swal({
                    title: "Error",
                    text: "No se pudo eliminar el viajero.",
                    type: 'warning',
                });
            }
        },
        error: function (err) {
            console.log(err);
            swal({
                title: "Error",
                text: "No se pudo eliminar el viajero.",
                type: 'warning',
            });
        },

    });
}

function LlenarComboViajes(IdViajero) {
     
    $.ajax({
        type: 'GET',
        data: { pIdViajero: IdViajero },
        url: '/api' + urlObtenerViajesExcluyendoViajero,
        async: false,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            if (response.Result == true) {
                var option = '';
                if (response.data.length > 0) {
                     option = '<option value="0">Seleccionar Viaje</option>';
                    for (var i = 0; i < response.data.length; i++) {
                        option += '<option value="' + response.data[i].Id + '">Origen: ' + response.data[i].Origen.Nombre + '/ Destino: ' + response.data[i].Destino.Nombre + ' (' + response.data[i].Precio + '$)' + '</option>';
                    }
                    $("#cbViajes").empty().append(option);
                } else
                {
                    option = '<option value="0">No hay viaje disponible</option>';
                    $("#cbViajes").empty().append(option);
                }
                
            } else {
                swal({
                    title: "Error",
                    text: "No se pudo eliminar el viajero.",
                    type: 'warning',
                });
            }
        },
        error: function (err) {
            console.log(err);
            swal({
                title: "Error",
                text: "No se pudo eliminar el viajero.",
                type: 'warning',
            });
        },

    });
}

function InsertarViajeroaViaje(IdViajero) {

    var pViajerosxViajes =
    {
        Viajero: { Id: IdViajero },
        Viaje: { Id: $("#cbViajes").val() },
    };

    $.ajax({
        type: 'POST',
        data: JSON.stringify(pViajerosxViajes),
        url: '/api' + urlInsertarViajerosxViajes,
        async: false,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            if (response.Result == true) {
                swal('Excelente!', 'Viaje realizado!', 'success');
            } else {
                swal({
                    title: "Error",
                    text: response.Mensaje,
                    type: 'warning',
                });
            }
        },
        error: function (err) {
            swal({
                title: "Error",
                text: "No se pudo realizar el viaje.",
                type: 'warning',
            });
        },

    });
}

function CargarTablaViajes(pIdViajero) {
    var myTableViajes = $('#dt-Viajes').DataTable({
        fixedHeader: true,
        "ajax": {
            url: "/api/" + urlObtenerViajesxViajeros,
            dataType: "json",
            method: "GET",
            async: false,
            data: { "pIdViajero": pIdViajero },
            contentType: 'application/json; charset=utf-8'
        },
        columns: [
            { data: "Viaje.Codigo" },
            { data: "Viaje.NumeroPlazas" },
            { data: "Viaje.Origen.Nombre" },
            { data: "Viaje.Destino.Nombre" },
            { data: "Viaje.Precio" },
            { data: "null", "defaultContent": "" }
        ],
        "columnDefs": [{
            "className": "tdCentrado",
            "targets": -1,
            "createdCell": function (td, cellData, rowData, row, col) {
                $(td).prepend(
                    ` <div class="dropdown  btn-group m-r-xs m-b-xs">
                           <button type="button" class="btn btn-info dropdown-toggle btn-sm" style='width: 65px;padding: 0px;height: 28px;' data-toggle="dropdown" aria-expanded="false">Accion<span class="caret"></span></button>
                        <div class="dropdown-menu"  role="menu">                                                      
                           <a class="dropdown-item btn-eliminar-viaje"  >
                                Eliminar
                                    </a>
                           
                        </div>
                    </div>`
                );
            }
        }]
    });
    return myTableViajes;
}

function EliminarViajeRealizado(pId, pIdViaje) {

    var pViajerosxViajes =
    {
        Id: pId,
        Viaje: { Id: pIdViaje }
    };

    $.ajax({
        type: 'DELETE',
        data: JSON.stringify(pViajerosxViajes),
        url: '/api' + urlEliminarViajeRealizado,
        async: false,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            if (response.Result == true) {
                swal('Excelente!', 'Viaje eliminado!', 'success');
                $("#modalViajero").trigger("click");
            } else {
                swal({
                    title: "Error",
                    text: "No se pudo eliminar el viaje realizado.",
                    type: 'warning',
                });
            }
        },
        error: function (err) {
            console.log(err);
            swal({
                title: "Error",
                text: "No se pudo eliminar el viaje realizado.",
                type: 'warning',
            });
        },

    });
}



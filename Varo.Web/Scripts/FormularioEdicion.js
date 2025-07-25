function consultarDepartamentosPorIdPais(id) {

    if (id !== "") {
        $.ajax({
            url: '/Base/ConsultarDepartamentosPorIdPais',
            type: "GET",
            data: { 'idPais': id },
            dataType: "json",
            traditional: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.success === true) {
                    $('#DropDownListDepartamentos').html('');
                    var options = '<option></option>';
                    for (var i = 0; i < data.listaDeDepartamentos.length; i++) {
                        options += '<option value="' + data.listaDeDepartamentos[i].Id + '">'
                            + data.listaDeDepartamentos[i].Name + '</option>';
                    }
                    $('#DropDownListDepartamentos').append(options);
                    $("#DropDownListDepartamentos").prop("disabled", false);

                    $('#DropDownListCiudades').html('');
                    $("#DropDownListCiudades").prop("disabled", true);

                } else {
                    alert("Error a nivel de la base de datos consultando departamentos!");
                }
            },
            error: function () {
                alert("Ocurrio un error consultando departamentos!!!");
            }
        });
    }
    else {
        $('#DropDownListDepartamentos').html('');
        $("#DropDownListDepartamentos").prop("disabled", true);
        $('#DropDownListCiudades').html('');
        $("#DropDownListCiudades").prop("disabled", true);
    }

    closeModal();
};

function consultarClientesPorIdPais(id) {
    if (id !== "") {
        $.ajax({
            url: '/Base/ConsultarClientes',
            type: "GET",
            data: { 'idPais': id },
            dataType: "json",
            traditional: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.success === true) {
                    $('#DropDownListClientes').html('');
                    var options = '<option></option>';
                    for (var i = 0; i < data.listaDeClientes.length; i++) {
                        options += '<option value="' + data.listaDeClientes[i].Id + '">'
                            + data.listaDeClientes[i].Name + '</option>';
                    }
                    $('#DropDownListClientes').append(options);
                    $("#DropDownListClientes").prop("disabled", false);
                } else {
                    alert("Error a nivel de la base de datos consultando clientes!");
                }
            },
            error: function () {
                alert("Ocurrio un error consultando clientes!!!");
            }
        });
    }
    else {
        $('#DropDownListClientes').html('');
        $("#DropDownListClientes").prop("disabled", true);
    }

    closeModal();
};

function consultarCiudadesPorIdDepartamento(id) {

    if (id !== "") {
        $.ajax({
            url: '/Base/ConsultarCiudadesPorIdDepartamento',
            type: "GET",
            data: { 'idDepartamento': id },
            dataType: "json",
            traditional: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.success == true) {
                    $('#DropDownListCiudades').html('');
                    var options = '<option></option>';
                    for (var i = 0; i < data.listaCiudades.length; i++) {
                        options += '<option value="' + data.listaCiudades[i].Id + '">'
                            + data.listaCiudades[i].Name + '</option>';
                    }
                    $('#DropDownListCiudades').append(options);
                    $("#DropDownListCiudades").prop("disabled", false);
                } else {
                    alert("Error a nivel de la base de datos consultando ciudades!");
                }
            },
            error: function () {
                alert("¡Ocurrio un error consultando ciudades!");
            }
        });
    }
    else {
        $('#DropDownListCiudades').html('');
        $("#DropDownListCiudades").prop("disabled", true);
    }

    closeModal();
};

function consultarTecnologiasPorIdTipoTecnologia(elemento, id) {

    if (id !== "") {
        $.ajax({
            url: '/Base/ConsultarTecnologiasPorIdTipoTecnologia',
            type: "GET",
            data: { 'idTipoTecnologia': id },
            dataType: "json",
            traditional: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.success === true) {
                    $(elemento).find('#DropDownListTecnologias').html('');
                    var options = '<option></option>';
                    for (var i = 0; i < data.listaTecnologia.length; i++) {
                        options += '<option value="' + data.listaTecnologia[i].Id + '">'
                            + data.listaTecnologia[i].Nombre + '</option>';
                    }
                    $(elemento).find('#DropDownListTecnologias').append(options);
                    $(elemento).find("#DropDownListTecnologias").prop("disabled", false);

                } else {
                    alert("Error a nivel de la base de datos consultando tecnologías!");
                }
            },
            error: function () {
                alert("Ocurrio un error consultando tecnologías!!!");
            }
        });
    }
    else {
        $(elemento).find('#DropDownListTecnologias').html('');
        $(elemento).find("#DropDownListTecnologias").prop("disabled", true);
    }

    closeModal();
};

function obtenerNombreResponsablePorUsuarioRed() {

    var usuarioRed = $('#UsuarioRedResponsable').val();

    if (usuarioRed !== "") {
        $.ajax({
            url: '/Base/ObtenerNombreResponsablePorUsuarioRed',
            type: "GET",
            data: { 'usuarioRed': usuarioRed },
            dataType: "json",
            traditional: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.success === true) {
                    $('#Rol').val('');
                    $('#NombreResponsable').val('');
                    var cargo = data.informacionUsuarioResponsable[0];
                    var nombre = data.informacionUsuarioResponsable[1];
                    $('#NombreResponsable').val(nombre);
                    $('#Rol').val(cargo);
                    if (cargo === null) {
                        alert("Usuario de red no encontrado por favor verifiquelo");
                    }
                } else {
                    alert("Error a nivel de la base de datos consultando Nombre Responsable Por UsuarioRed!");
                }
            },
            error: function () {
                $('#Rol').val('');
                $('#NombreResponsable').val('');
                alert("Ocurrio un error consultando Nombre Responsable Por UsuarioRed!!!");
            }
        });
    }
    else {
        $('#Rol').val('');
        $('#NombreResponsable').val('');
    }

    closeModal();
};

function obtenerNombreScrumMasterPorUsuarioRed() {

    var usuarioRed = $('#UsuarioRedScrumMaster').val();

    if (usuarioRed !== "") {
        $.ajax({
            url: '/Base/ObtenerNombreResponsablePorUsuarioRed',
            type: "GET",
            data: { 'usuarioRed': usuarioRed },
            dataType: "json",
            traditional: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.success === true) {
                    $('#RolScrumMaster').val('');
                    $('#NombreScrumMaster').val('');
                    var cargo = data.informacionUsuarioResponsable[0];
                    var nombre = data.informacionUsuarioResponsable[1];
                    $('#NombreScrumMaster').val(nombre);
                    $('#RolScrumMaster').val(cargo);
                    if (cargo === null) {
                        alert("Usuario de red no encontrado por favor verifiquelo");
                    }
                } else {
                    alert("Error a nivel de la base de datos consultando Nombre Scrum Master Por UsuarioRed!");
                }
            },
            error: function () {
                $('#RolScrumMaster').val('');
                $('#NombreScrumMaster').val('');
                alert("Ocurrio un error consultando Nombre Scrum Master Por UsuarioRed!!!");
            }
        });
    }
    else {
        $('#RolScrumMaster').val('');
        $('#NombreScrumMaster').val('');
    }

    closeModal();
};

function obtenerNombreGerentePorUsuarioRed() {

    var usuarioRed = $('#UsuarioRedGerente').val();

    if (usuarioRed !== "") {
        $.ajax({
            url: '/Base/ObtenerNombreResponsablePorUsuarioRed',
            type: "GET",
            data: { 'usuarioRed': usuarioRed },
            dataType: "json",
            traditional: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.success === true) {
                    $('#RolGerente').val('');
                    $('#NombreGerente').val('');
                    var cargo = data.informacionUsuarioResponsable[0];
                    var nombre = data.informacionUsuarioResponsable[1];
                    $('#NombreGerente').val(nombre);
                    $('#RolGerente').val(cargo);
                    if (cargo === null) {
                        alert("Usuario de red no encontrado por favor verifiquelo");
                    }
                } else {
                    alert("Error a nivel de la base de datos consultando Nombre Gerente Por UsuarioRed!");
                }
            },
            error: function () {
                $('#RolGerente').val('');
                $('#NombreGerente').val('');
                alert("Ocurrio un error consultando Nombre Gerente Por UsuarioRed!!!");
            }
        });
    }
    else {
        $('#RolScrumMaster').val('');
        $('#NombreScrumMaster').val('');
    }

    closeModal();
};

function consultarOficinasPorIdGsdc(id) {
    if (id !== "") {
        $.ajax({
            url: '/Base/ConsultarOficinasPorIdGsdc',
            type: "GET",
            data: { 'idGsdc': id },
            dataType: "json",
            traditional: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.success === true) {
                    $('#DropDownListaOficinas').html('');
                    var options = '<option></option>';
                    for (var i = 0; i < data.listaOficinas.length; i++) {
                        options += '<option value="' + data.listaOficinas[i].Id + '">'
                            + data.listaOficinas[i].Nombre + '</option>';
                    }
                    $('#DropDownListaOficinas').append(options);
                    $("#DropDownListaOficinas").prop("disabled", false);
                } else {
                    alert("Error a nivel de la base de datos consultando oficinas!");
                }
            },
            error: function () {
                alert("Ocurrio un error consultando oficinas!!!");
            }
        });
    }
    else {
        $('#DropDownListaOficinas').html('');
        $("#DropDownListaOficinas").prop("disabled", true);
    }

    closeModal();
};

function removeClaseButton(element) {
    $(element).removeClass('disabled');
}

function addClaseButton(element) {
    $(element).addClass('disabled');
}

function CambiarNombreListaTriEstado(tipoSolucion) {

    if (tipoSolucion == Constantes.CrearSolución) {
        $('select option:contains("False")').attr('selected', 'selected');
    }
    $('#practicas-tecnicas select [value=""]').text(Constantes.NoAplica);
    $('#practicas-tecnicas select [value="true"]').text(Constantes.Cumple);
    $('#practicas-tecnicas select [value="false"]').text(Constantes.NoCumple);
}

$(document).ready(function () {
    $(document).ajaxStart(function () {
        $('#wait').modal('show');
    });
    $(document).ajaxComplete(function () {
        closeModal();
    });
});

function closeModal() {
    $('#wait').on('shown.bs.modal', function (e) {
        $("#wait").modal("hide");
    });
}

function disableSubmitButton(idForm) {
    $(idForm).submit(function () {
        if ($(this).valid()) {
            $(':submit', this).attr('disabled', 'disabled');
            $('#cancelar', this).addClass('disabled')
        }
    });
}



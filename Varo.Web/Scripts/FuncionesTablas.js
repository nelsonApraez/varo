
function clearTextBox(idForm) {
    $(idForm).find('select, input, textArea').each(function () {
        $(this).val('');
        $(this).css('border-color', 'lightgrey');
    });
    inicializarEstiloTexBox(idForm);
    $('#fila').val('');
}

function inicializarEstiloTexBox(idForm) {
    $(idForm).find('select, input, textArea').each(function () {
        $(this).css('border-color', 'lightgrey');
    });
    $(idForm).find('.errorMsg').remove();
}

function validate(idForm) {
    var isValid = true;
    $(idForm).find('.errorMsg').remove();
    $(idForm).find('.requerido').each(function () {
        if (!$(this).val()) {
            $(this).closest('.form-group').append('<span class="errorMsg error" style="font-size: 12px; color: darkred;">' + textoRequerido + '</span>');
            isValid = false;
        }
    });

    return isValid;
}

function EliminarFila(elementoSeleccionado, tabla) {
    var filasDeTabla = $(tabla + ' tr').length;
    if (filasDeTabla > 2) {
        $(elementoSeleccionado).parents("tr").remove();
    }
}

function ValidarFechas() {
    var fechaCreacion = $('#FechaCreacion').val();
    var fechaCierre = $('#FechaCierre').val();
    var estado = $('#Estado_Id option:selected').val();
    var mensaje = document.getElementById("ErrorFechas");
    if (fechaCierre != "") {
        if (fechaCreacion >= fechaCierre && estado == '2') {
            mensaje.style.display = "block";
            $('#FechaCierre').val("");
            $('#Estado_Id').val('0');
            return false;
        }
    }
    else {
        if (fechaCreacion == "0001-01-01" || fechaCreacion == "") {
            $('#FechaCreacion').val("");
        }
        mensaje.style.display = "none";
    }
}

function ValidarFechaRequerida() {
    var fecha = $('#Fecha').val();
    if (fecha == "0001-01-01") {
        $('#Fecha').val("");
        return false;
    }
}

function consultarTecnologiasPorIdTipoTecnologiaModal(elemento, idTipo, idTecnologia, enableCampo) {
    if (idTipo !== "") {
        $.ajax({
            url: '/Base/ConsultarTecnologiasPorIdTipoTecnologia',
            type: "GET",
            data: { 'idTipoTecnologia': idTipo },
            dataType: "json",
            traditional: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.success === true) {
                    $(elemento).html('');
                    var options = '<option></option>';
                    for (var i = 0; i < data.listaTecnologia.length; i++) {
                        if (data.listaTecnologia[i].Id == idTecnologia) {
                            options += '<option value="' + data.listaTecnologia[i].Id + '" selected>'
                                + data.listaTecnologia[i].Nombre + '</option>';
                        } else {
                            options += '<option value="' + data.listaTecnologia[i].Id + '">'
                                + data.listaTecnologia[i].Nombre + '</option>';
                        }

                    }
                    $(elemento).append(options);
                    if (enableCampo == 1) {
                        $(elemento).prop("disabled", true);
                    }
                    else {
                        $(elemento).prop("disabled", false);
                        $('#ModalTecnologia').modal('show');
                    }


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
        $(elemento).html('');
        $(elemento).prop("disabled", true);
    }
};

function cargarFilaEditarTecnologia(elementoSeleccionado) {

    clearTextBox('#ModalTecnologia');
    var tecnologiaId = $(elementoSeleccionado).parents("tr").find('#itemIdTecnologia').val();
    if (tecnologiaId != null) {
        var tipoId = $(elementoSeleccionado).parents("tr").find('#itemIdTipo').val();
        $('#ListTipo').val(tipoId);
        var fila = $(elementoSeleccionado).closest('tr').index();
        $('#fila').val(fila);

        consultarTecnologiasPorIdTipoTecnologiaModal($('#ListTecnologias'), tipoId, tecnologiaId, 0);
    }
    else {
        $('#fila').val(-1);
        $('#ModalTecnologia').modal('show');
    }

}

function AgregarElementoTecnologia(idForm) {
    var res = validate(idForm);
    if (res == false) {
        return false;
    }

    var tipo = $('#ListTipo').val();
    var tipoTexto = $("#ListTipo option:selected").text();
    var tecnologiaTexto = $("#ListTecnologias option:selected").text();
    var tecnologia = $('#ListTecnologias').val();
    if ($('#fila').val().trim() == "" || $('#fila').val() == -1) {

        if ($('#fila').val() == -1) {
            $('#tablaTecnologia tr').eq(1).remove();
        }
        var htmlAcciones = document.getElementById('htmlAcciones').innerHTML;
        var row = '<tr>'
            + '<td style="display:none;"><input type="text" id="itemIdTecnologia" value= "' + tecnologia + '" name="itemIdTecnologia"></td>'
            + '<td style="display:none;"><input type="text" id="itemIdTipo" value= "' + tipo + '" name="itemIdTipo"></td>'
            + '<td><input type="text" value= "' + tipoTexto + '" readOnly class="form-control text-box" id="itemTipoNombre"></td>'
            + '<td><input type="text" value= "' + tecnologiaTexto + '" readOnly class="form-control text-box" id="itemTecnologiaNombre"></td>'
            + htmlAcciones
            + '</tr>';

        $("#tablaTecnologia").append(row);
    }
    else {

        var fila = parseInt($('#fila').val()) + 1;
        var tr = $('#tablaTecnologia tr').eq(fila);
        tr.find('#itemIdTecnologia').val(tecnologia);
        tr.find('#itemIdTipo').val(tipo);
        tr.find('#itemTipoNombre').val(tipoTexto);
        tr.find('#itemTecnologiaNombre').val(tecnologiaTexto);

        $('#fila').val('');
    }

    $(idForm).modal('hide');
}

function cargarFilaEditarIntegraciones(elementoSeleccionado) {

    clearTextBox('#ModalIntegracion');
    var nombre = $(elementoSeleccionado).parents("tr").find('#itemNombreCompilacion').val();
    if (nombre != null) {
        var inspeccionId = $(elementoSeleccionado).parents("tr").find('#itemIdProyectoInspeccion').val();
        var url = $(elementoSeleccionado).parents("tr").find('#itemUrlCompilacion').val();
        $('#NombreCompilacion').val(nombre);
        $('#UrlCompilacion').val(url);
        $('#ListProyectoSonar').val(inspeccionId);

        var fila = $(elementoSeleccionado).closest('tr').index();
        $('#fila').val(fila);
    }
    else {
        $('#fila').val(-1);
    }

    $('#ModalIntegracion').modal('show');

}

function AgregarElementoIntegracion(idForm) {
    var res = validate(idForm);
    if (res == false) {
        return false;
    }
   
    var idInspeccion = $('#ListProyectoSonar').val();
    if (idInspeccion == null) {
        idInspeccion = "";
    }
    var inspeccionNombre = $("#ListProyectoSonar option:selected").text();
    var url = $('#UrlCompilacion').val();
    var nombre = $('#NombreCompilacion').val();
    if ($('#fila').val().trim() == "" || $('#fila').val() == -1) {

        if ($('#fila').val() == -1) {
            $('#tablaIntegracionContinua tr').eq(1).remove();
        }
        var htmlAcciones = document.getElementById('htmlAccionesIntegracion').innerHTML;
        var row = '<tr>'
            + '<td style="display:none;"><input type="hidden" id="itemIdProyectoInspeccion" value= "' + idInspeccion + '" name="itemIdProyectoInspeccion"></td>'
            + '<td ><input type="text" value= "' + nombre + '" readOnly class="form-control text-box" id= "itemNombreCompilacion" name= "itemNombreCompilacion"></td>'
            + '<td><input type="text" value= "' + url + '" readOnly class="form-control text-box" id="itemUrlCompilacion"  name="itemUrlCompilacion"></td>'
            + '<td><input type="text" value= "' + inspeccionNombre + '" readOnly class="form-control text-box" id="itemProyectoInspeccionNombre"></td>'
            + htmlAcciones
            + '</tr>';

        $("#tablaIntegracionContinua").append(row);
    }
    else {

        var fila = parseInt($('#fila').val()) + 1;
        var tr = $('#tablaIntegracionContinua tr').eq(fila);
        tr.find('#itemIdProyectoInspeccion').val(idInspeccion);
        tr.find('#itemNombreCompilacion').val(nombre);
        tr.find('#itemUrlCompilacion').val(url);
        tr.find('#itemProyectoInspeccionNombre').val(inspeccionNombre);

        $('#fila').val('');
    }

    $(idForm).modal('hide');
}

function cargarFilaEditarDespliegues(elementoSeleccionado) {

    var nombre = $(elementoSeleccionado).parents("tr").find('#itemNombreDespliegue').val();
    var url = $(elementoSeleccionado).parents("tr").find('#itemUrlDespliegue').val();
    $('#NombreDespliegue').val(nombre);
    $('#UrlDespliegue').val(url);
    inicializarEstiloTexBox('#ModalIntegracion');

    var fila = $(elementoSeleccionado).closest('tr').index();
    $('#fila').val(fila);

    $('#ModalDespliegueContinuo').modal('show');

}

function AgregarElementoDespliegue(idForm) {

    var res = validate(idForm);
    if (res == false) {
        return false;
    }

    var url = $('#UrlDespliegue').val();
    var nombre = $('#NombreDespliegue').val();
    if ($('#fila').val().trim() == "") {

        var htmlAcciones = document.getElementById('htmlAccionesDespliegueContinuo').innerHTML;
        var row = '<tr>'
            + '<td><input type="text" value= "' + nombre + '" readOnly class="form-control text-box" id="itemNombreDespliegue"  name="itemNombreDespliegue"></td>'
            + '<td><input type="text" value= "' + url + '" readOnly class="form-control text-box" id="itemUrlDespliegue" name="itemUrlDespliegue"></td>'
            + htmlAcciones
            + '</tr>';

        $("#tablaDesplieguesContinuos").append(row);
    }
    else {

        var fila = parseInt($('#fila').val()) + 1;
        var tr = $('#tablaDesplieguesContinuos tr').eq(fila);
        tr.find('#itemNombreDespliegue').val(nombre);
        tr.find('#itemUrlDespliegue').val(url);

        $('#fila').val('');
    }

    $(idForm).modal('hide');
}

function cargarFilaEditarMonitoreos(elementoSeleccionado) {

    var nombre = $(elementoSeleccionado).parents("tr").find('#itemNombreMonitoreo').val();
    var url = $(elementoSeleccionado).parents("tr").find('#itemUrlMonitoreo').val();
    $('#NombreMonitoreo').val(nombre);
    $('#UrlMonitoreo').val(url);
    inicializarEstiloTexBox('#ModalIntegracion');

    var fila = $(elementoSeleccionado).closest('tr').index();
    $('#fila').val(fila);

    $('#ModalMonitoreo').modal('show');

}

function AgregarElementoMonitoreo(idForm) {

    var res = validate(idForm);
    if (res == false) {
        return false;
    }
    
    var url = $('#UrlMonitoreo').val();
    var nombre = $('#NombreMonitoreo').val();
    if ($('#fila').val().trim() == "") {

        var htmlAcciones = document.getElementById('htmlAccionesMonitoreo').innerHTML;
        var row = '<tr>'
            + '<td><input type="text" value= "' + nombre + '" readOnly class="form-control text-box" id="itemNombreMonitoreo"  name="itemNombreMonitoreo"></td>'
            + '<td><input type="text" value= "' + url + '" readOnly class="form-control text-box" id="itemUrlMonitoreo" name="itemUrlMonitoreo"></td>'
            + htmlAcciones
            + '</tr>';

        $("#tablaMonitoreosContinuos").append(row);
    }
    else {

        var fila = parseInt($('#fila').val()) + 1;
        var tr = $('#tablaMonitoreosContinuos tr').eq(fila);
        tr.find('#itemNombreMonitoreo').val(nombre);
        tr.find('#itemUrlMonitoreo').val(url);

        $('#fila').val('');
    }

    $(idForm).modal('hide');
}

function cargarFilaEditarEstimacionHoras(elementoSeleccionado) {

    var concepto = $(elementoSeleccionado).parents("tr").find('#itemConcepto').val();
    if (concepto != null) {
        var horasEstimadas = $(elementoSeleccionado).parents("tr").find('#itemHorasEstimadas').val();
        var horasEjecutadas = $(elementoSeleccionado).parents("tr").find('#itemHorasEjecutadas').val();
        $('#Concepto').val(concepto);
        $('#HorasEstimadas').val(horasEstimadas);
        $('#HorasEjecutadas').val(horasEjecutadas);
        inicializarEstiloTexBox('#ModalEstimacionHoras');

        var fila = $(elementoSeleccionado).closest('tr').index();
        $('#fila').val(fila);
    }
    else {
        $('#fila').val(-1);
    }

    $('#ModalEstimacionHoras').modal('show');

}

function AgregarElementoEstimacionHoras(idForm) {

    var res = validate(idForm);
    if (res == false) {
        return false;
    }

    var Concepto = $('#Concepto').val();
    var HorasEstimadas = $('#HorasEstimadas').val();
    var HorasEjecutadas = $('#HorasEjecutadas').val();
    if ($('#fila').val().trim() == "" || $('#fila').val() == -1) {

        if ($('#fila').val() == -1) {
            $('#tablaEstimacionHoras tr').eq(1).remove();
        }

        var htmlAcciones = document.getElementById('htmlAccionesEstimacionHoras').innerHTML;
        var row = '<tr>'
            + '<td><input type="text" value= "' + Concepto + '" readOnly class="form-control text-box" id="itemConcepto"  name="itemConcepto"></td>'
            + '<td><input type="text" value= "' + HorasEstimadas + '" readOnly class="form-control text-box" id="itemHorasEstimadas" name="itemHorasEstimadas"></td>'
            + '<td><input type="text" value= "' + HorasEjecutadas + '" readOnly class="form-control text-box" id="itemHorasEjecutadas" name="itemHorasEjecutadas"></td>'
            + htmlAcciones
            + '</tr>';

        $("#tablaEstimacionHoras").append(row);
    }
    else {

        var fila = parseInt($('#fila').val()) + 1;
        var tr = $('#tablaEstimacionHoras tr').eq(fila);
        tr.find('#itemConcepto').val(Concepto);
        tr.find('#itemHorasEstimadas').val(HorasEstimadas);
        tr.find('#itemHorasEjecutadas').val(HorasEjecutadas);

        $('#fila').val('');
    }

    $(idForm).modal('hide');
}

function cargarFilaEditarAmbientes(elementoSeleccionado, idModal) {

    clearTextBox(idModal);
    var idTipoAmbiente = $(elementoSeleccionado).parents("tr").find('#IdTipoAmbiente').val();
    var tipoAmbiente = $(elementoSeleccionado).parents("tr").find('#TipoAmbiente').text();
    if (tipoAmbiente != "" || idTipoAmbiente !== undefined) {
        var ubicacion = $(elementoSeleccionado).parents("tr").find('#Ubicacion').val();
        var responsable = $(elementoSeleccionado).parents("tr").find('#Responsable').val();
        $('#ListaTipoAmbiente').val(idTipoAmbiente);
        $('#itemUbicacion').val(ubicacion);
        $('#itemResponsable').val(responsable);

        var fila = $(elementoSeleccionado).closest('tr').index();
        $('#fila').val(fila);

    } else {
        $('#fila').val(-1);
    }

    $(idModal).modal('show');

}

function AgregarElementoAmbientes(idForm, idTabla) {

    var esValido = validate(idForm);
    if (!esValido) {
        return false;
    }

    var tipoAmbiente = $("#ListaTipoAmbiente option:selected").text();
    var idTipoAmbiente = $("#ListaTipoAmbiente option:selected").val();
    var ubicacion = $('#itemUbicacion').val();
    var responsable = $('#itemResponsable').val();
    if ($('#fila').val().trim() == "" || $('#fila').val() == -1) {

        if ($('#fila').val() == -1) {
            $(idTabla + ' tr').eq(1).remove();
        }

        var htmlAcciones = document.getElementById('htmlAccionesAmbientes').innerHTML;
        var row = '<tr>'
            + '<td><input type="text" value= "' + tipoAmbiente + '" readOnly class="form-control text-box" id="TipoAmbiente"  name="TipoAmbiente"></td>'
            + '<td style="display:none;"><input type="text" value= "' + idTipoAmbiente + '" readOnly class="form-control text-box" id="IdTipoAmbiente"  name="IdTipoAmbiente"></td>'
            + '<td><input type="text" value= "' + ubicacion + '" readOnly class="form-control text-box" id="Ubicacion" name="Ubicacion"></td>'
            + '<td><input type="text" value= "' + responsable + '" readOnly class="form-control text-box" id="Responsable" name="Responsable"></td>'
            + htmlAcciones
            + '</tr>';

        $(idTabla).append(row);
    }
    else {

        var fila = parseInt($('#fila').val()) + 1;
        var tr = $(idTabla + ' tr').eq(fila);
        tr.find('#TipoAmbiente').val(tipoAmbiente);
        tr.find('#IdTipoAmbiente').val(idTipoAmbiente);
        tr.find('#Ubicacion').val(ubicacion);
        tr.find('#Responsable').val(responsable);

        $('#fila').val('');
    }

    $(idForm).modal('hide');
}

function cargarFilaEditarHitos(elementoSeleccionado, idModal) {

    clearTextBox(idModal);
    var idTipo = $(elementoSeleccionado).parents("tr").find('#IdTipo').val();
    var tipo = $(elementoSeleccionado).parents("tr").find('#Tipo').text();
    if (tipo != "" || idTipo !== undefined) {
        var descripcion = $(elementoSeleccionado).parents("tr").find('#Descripcion').val();
        var fechaCierre = $(elementoSeleccionado).parents("tr").find('#FechaCierre').val();
        var idEstado = $(elementoSeleccionado).parents("tr").find('#IdEstado').val();
        var observaciones = $(elementoSeleccionado).parents("tr").find('#Observaciones').val();
        $('#ListaTipo').val(idTipo);
        $('#itemDescripcion').val(descripcion);
        $('#itemFechaCierre').val(fechaCierre);
        $('#ListaEstados').val(idEstado);
        $('#itemObservaciones').val(observaciones);

        var fila = $(elementoSeleccionado).closest('tr').index();
        $('#fila').val(fila);

    } else {
        $('#fila').val(-1);
    }

    $(idModal).modal('show');

}

function AgregarElementoHitos(idForm, idTabla) {

    var esValido = validate(idForm);
    if (!esValido) {
        return false;
    }

    var tipo = $("#ListaTipo option:selected").text();
    var idTipo = $("#ListaTipo option:selected").val();
    var descripcion = $('#itemDescripcion').val();
    var fechaCierre = $('#itemFechaCierre').val();
    var estado = $('#ListaEstados option:selected').text();
    var idEstado = $('#ListaEstados option:selected').val();
    var observaciones = $('#itemObservaciones').val();
    if ($('#fila').val().trim() == "" || $('#fila').val() == -1) {

        if ($('#fila').val() == -1) {
            $(idTabla + ' tr').eq(1).remove();
        }

        var htmlAcciones = document.getElementById('htmlAccionesHitos').innerHTML;
        var row = '<tr>'
            + '<td><input type="text" value= "' + tipo + '" readOnly class="form-control text-box" id="Tipo"  name="Tipo"></td>'
            + '<td hidden><input type="text" value= "' + idTipo + '" readOnly class="form-control text-box" id="IdTipo"  name="IdTipo"></td>'
            + '<td><input type="text" value= "' + descripcion + '" readOnly class="form-control text-box" id="Descripcion" name="Descripcion"></td>'
            + '<td><input type="text" value= "' + fechaCierre + '" readOnly class="form-control text-box" id="FechaCierre" name="FechaCierre"></td>'
            + '<td><input type="text" value= "' + estado + '" readOnly class="form-control text-box" id="Estado"  name="Estado"></td>'
            + '<td hidden><input type="text" value= "' + idEstado + '" readOnly class="form-control text-box" id="IdEstado"  name="IdEstado"></td>'
            + '<td><input type="text" value= "' + observaciones + '" readOnly class="form-control text-box" id="Observaciones" name="Observaciones"></td>'
            + htmlAcciones
            + '</tr>';

        $(idTabla).append(row);
    }
    else {

        var fila = parseInt($('#fila').val()) + 1;
        var tr = $(idTabla + ' tr').eq(fila);
        tr.find('#Tipo').val(tipo);
        tr.find('#IdTipo').val(idTipo);
        tr.find('#Descripcion').val(descripcion);
        tr.find('#FechaCierre').val(fechaCierre);
        tr.find('#Estado').val(estado);
        tr.find('#IdEstado').val(idEstado);
        tr.find('#Observaciones').val(observaciones);

        $('#fila').val('');
    }

    $(idForm).modal('hide');
}

function cargarFilaEditarCalificacionAuditoria(elementoSeleccionado, idModal) {

    clearTextBox(idModal);
    var url = $(elementoSeleccionado).parents("tr").find('#Url').val();
    if (url != "") {
        var calificacion = $(elementoSeleccionado).parents("tr").find('#Calificacion').val();
        var fecha = $(elementoSeleccionado).parents("tr").find('#Fecha').val();
        var proceso = $(elementoSeleccionado).parents("tr").find('#Proceso').val();
        var observacion = $(elementoSeleccionado).parents("tr").find('#Observacion').val();
        $('#itemUrl').val(url);
        $('#itemCalificacion').val(calificacion);
        $('#itemFecha').val(fecha);
        $('#itemProceso').val(proceso);
        $('#itemObservacion').val(observacion);

        var fila = $(elementoSeleccionado).closest('tr').index();
        $('#fila').val(fila);

    } else {
        $('#fila').val(-1);
    }

    $(idModal).modal('show');

}

function AgregarElementoCalificacionAuditoria(idForm, idTabla) {

    var esValido = validate(idForm);
    if (!esValido) {
        return false;
    }

    var url = $('#itemUrl').val();
    var calificacion = $('#itemCalificacion').val();
    var fecha = $('#itemFecha').val();
    var proceso = $('#itemProceso').val();
    var observacion = $('#itemObservacion').val();
    if ($('#fila').val().trim() == "" || $('#fila').val() == -1) {

        if ($('#fila').val() == -1) {
            $(idTabla + ' tr').eq(1).remove();
        }

        var htmlAcciones = document.getElementById('htmlAccionesCalificacion').innerHTML;
        var row = '<tr>'
            + '<td><input type="text" value= "' + url + '" readOnly class="form-control text-box" id="Url"  name="Url"></td>'
            + '<td><input type="text" value= "' + calificacion + '" readOnly class="form-control text-box" id="Calificacion" name="Calificacion"></td>'
            + '<td><input type="text" value= "' + fecha + '" readOnly class="form-control text-box" id="Fecha" name="Fecha"></td>'
            + '<td><input type="text" value= "' + proceso + '" readOnly class="form-control text-box" id="Proceso" name="Proceso"></td>'
            + '<td><input type="text" value= "' + observacion + '" readOnly class="form-control text-box" id="Observacion" name="Observacion"></td>'
            + htmlAcciones
            + '</tr>';

        $(idTabla).append(row);
    }
    else {

        var fila = parseInt($('#fila').val()) + 1;
        var tr = $(idTabla + ' tr').eq(fila);
        tr.find('#Url').val(url);
        tr.find('#Calificacion').val(calificacion);
        tr.find('#Fecha').val(fecha);
        tr.find('#Proceso').val(proceso);
        tr.find('#Observacion').val(observacion);

        $('#fila').val('');
    }

    $(idForm).modal('hide');
}

function cargarFilaEditarDetalleHistoria(elementoSeleccionado, idModal) {

    clearTextBox(idModal);
    var numero = $(elementoSeleccionado).parents("tr").find('#itemNumero').val();
    if (numero != null) {
        var nombre = $(elementoSeleccionado).parents("tr").find('#itemNombre').val();
        var esfuerzoEstimado = $(elementoSeleccionado).parents("tr").find('#itemEsfuerzoEstimado').val();
        var esfuerzoReal = $(elementoSeleccionado).parents("tr").find('#itemEsfuerzoReal').val();
        var observaciones = $(elementoSeleccionado).parents("tr").find('#itemObservaciones').val();

        $('#Numero').val(numero);
        $('#Nombre').val(nombre);
        $('#EsfuerzoEstimado').val(esfuerzoEstimado);
        $('#EsfuerzoReal').val(esfuerzoReal);
        $('#Observaciones').val(observaciones);

        var fila = $(elementoSeleccionado).closest('tr').index();
        $('#fila').val(fila);
    }
    else {
        $('#fila').val(-1);
    }
    
    $(idModal).modal('show');

}

function AgregarElementoDetalleHistoria(idForm, idTabla) {

    var res = validate(idForm);
    if (res == false) {
        return false;
    }

    var numero = $('#Numero').val();
    var nombre = $('#Nombre').val();
    var esfuerzoEstimado = $('#EsfuerzoEstimado').val();
    var esfuerzoReal = $('#EsfuerzoReal').val();
    var observaciones = $('#Observaciones').val();
    if ($('#fila').val().trim() == "" || $('#fila').val() == -1) {

        if ($('#fila').val() == -1) {
            $(idTabla+ ' tr').eq(1).remove();
        }

        var htmlAcciones = document.getElementById('htmlAccionesDetalleHistorias').innerHTML;
        var row = '<tr>'
            + '<td><input type="text" value= "' + numero + '" readOnly class="form-control text-box" id="itemNumero"  name="itemNumero"></td>'
            + '<td><input type="text" value= "' + nombre + '" readOnly class="form-control text-box" id="itemNombre" name="itemNombre"></td>'
            + '<td><input type="text" value= "' + esfuerzoEstimado + '" readOnly class="form-control text-box" id="itemEsfuerzoEstimado" name="itemEsfuerzoEstimado"></td>'
            + '<td><input type="text" value= "' + esfuerzoReal + '" readOnly class="form-control text-box" id="itemEsfuerzoReal" name="itemEsfuerzoReal"></td>'
            + '<td><input type="text" value= "' + observaciones + '" readOnly class="form-control text-box" id="itemObservaciones" name="itemObservaciones"></td>'
            + htmlAcciones
            + '</tr>';

        $(idTabla).append(row);
    }
    else {

        var fila = parseInt($('#fila').val()) + 1;
        var tr = $(idTabla + ' tr').eq(fila);
        tr.find('#itemNumero').val(numero);
        tr.find('#itemNombre').val(nombre);
        tr.find('#itemEsfuerzoEstimado').val(esfuerzoEstimado);
        tr.find('#itemEsfuerzoReal').val(esfuerzoReal);
        tr.find('#itemObservaciones').val(observaciones);

        $('#fila').val('');
    }

    $(idForm).modal('hide');
}

function cargarFilaEditarAccionMejora(elementoSeleccionado, idModal) {

    clearTextBox(idModal);
    var causa = $(elementoSeleccionado).parents("tr").find('#itemCausa').val();
    var accion = $(elementoSeleccionado).parents("tr").find('#itemAccionMejora').val();
    if (accion != null) {
        var responsable = $(elementoSeleccionado).parents("tr").find('#itemIdResponsable').val();
        var estado = $(elementoSeleccionado).parents("tr").find('#itemIdEstado').val();

        $('#AccionMejora').val(accion);
        $('#Causa').val(causa);
        $('#ListaResponsables').val(responsable);
        $('#ListaEstado').val(estado);

        var fila = $(elementoSeleccionado).closest('tr').index();
        $('#fila').val(fila);

    } else {
        $('#fila').val(-1);
    }
    
    $(idModal).modal('show');

}

function AgregarElementoAccionMejora(idForm, idTabla) {
    var esValido = validate(idForm);
    if (esValido == false) {
        return false;
    }

    var causa = $('#Causa').val();
    var accion = $('#AccionMejora').val();
    var idResponsable = $('#ListaResponsables').val();
    var responsable = $("#ListaResponsables option:selected").text();
    var estado = $("#ListaEstado option:selected").text();
    var idEstado = $('#ListaEstado').val();

    if ($('#fila').val().trim() == "" || $('#fila').val() == -1) {

        if ($('#fila').val() == -1) {
            $(idTabla + ' tr').eq(1).remove();
        }

        var htmlAcciones = document.getElementById('htmlAccionesAccionMejora').innerHTML;
        var row = '<tr>'
            + '<td style="display:none;"><input type="text" id="itemIdResponsable" value= "' + idResponsable + '" name="itemIdResponsable"></td>'
            + '<td style="display:none;"><input type="text" id="itemIdEstado" value= "' + idEstado + '" name="itemIdEstado"></td>'
            + '<td><input type="text" value= "' + causa + '" readOnly class="form-control text-box" id="itemCausa" name="itemCausa"></td>'
            + '<td><input type="text" value= "' + accion + '" readOnly class="form-control text-box" id="itemAccionMejora" name="itemAccionMejora"></td>'
            + '<td><input type="text" value= "' + responsable + '" readOnly class="form-control text-box" id="itemResponsable"></td>'
            + '<td><input type="text" value= "' + estado + '" readOnly class="form-control text-box" id="itemEstado"></td>'
            + htmlAcciones
            + '</tr>';

        $(idTabla).append(row);
    }
    else {

        var fila = parseInt($('#fila').val()) + 1;
        var tr = $(idTabla + ' tr').eq(fila);
        tr.find('#itemCausa').val(causa);
        tr.find('#itemAccionMejora').val(accion);
        tr.find('#itemIdResponsable').val(idResponsable);
        tr.find('#itemResponsable').val(responsable);
        tr.find('#itemIdEstado').val(idEstado);
        tr.find('#itemEstado').val(estado);

        $('#fila').val('');
    }

    $(idForm).modal('hide');
}

function cargarFilaEditarMetricaAgil(elementoSeleccionado, idModal)
{    
    clearTextBox(idModal);
    var sprint = $(elementoSeleccionado).parents("tr").find('#itemSprint').val();
    var fechaInicial = $(elementoSeleccionado).parents("tr").find('#itemFechaInicial').val();
    if (fechaInicial != "") {
        var fechaFinal = $(elementoSeleccionado).parents("tr").find('#itemFechaFinal').val();
        var idEquipo = $(elementoSeleccionado).parents("tr").find('#itemIdEquipo').val();

        $('#Sprint').val(sprint);
        $('#FechaInicial').val(fechaInicial);
        $('#FechaFinal').val(fechaFinal);
        $('#ListEquipos').val(idEquipo);
        
        var fila = $(elementoSeleccionado).closest('tr').index();
        $('#fila').val(fila);
    }
    else {
        $('#fila').val(-1);
    }

    $(idModal).modal('show');

}

function AgregarElementoMetricaAgil(idForm, idTabla) {

    var res = validate(idForm);
    if (res == false) {
        return false;
    }

    var sprint = $('#Sprint').val();
    var fechaInicial = $('#FechaInicial').val();
    var fechaFinal = $('#FechaFinal').val();
    var idEquipo = $('#ListEquipos').val();
    if (idEquipo == null) {
        idEquipo = '';
    }
    var nombreEquipo = $("#ListEquipos option:selected").text();

    if (fechaInicial > fechaFinal) {
        $('#FechaFinal').closest('.form-group').append('<label class="errorMsg error">La fecha final no puede ser menor a la fecha Inicial.</label>');
        return false;
    }

    if ($('#fila').val().trim() == "" || $('#fila').val() == -1) {

        if ($('#fila').val() == -1) {
            $(idTabla + ' tr').eq(1).remove();
        }

        var htmlAcciones = document.getElementById('htmlAccionesMetricaAgil').innerHTML;
        var row = '<tr>'
            + '<td style="display:none;"><input type="hidden" id="itemIdEquipo" value= "' + idEquipo + '" name="itemIdEquipo"></td>'
            + '<td><input type="text" value= "' + nombreEquipo + '" readOnly class="form-control text-box" id="itemEquipo"  name="itemEquipo"></td>'
            + '<td><input type="text" value= "' + sprint + '" readOnly class="form-control text-box" id="itemSprint"  name="itemSprint"></td>'
            + '<td><input type="text" value= "' + fechaInicial + '" readOnly class="form-control text-box" id="itemFechaInicial" name="itemFechaInicial"></td>'
            + '<td><input type="text" value= "' + fechaFinal + '" readOnly class="form-control text-box" id="itemFechaFinal" name="itemFechaFinal"></td>'
            + htmlAcciones
            + '</tr>';

        $(idTabla).append(row);
    }
    else {

        var fila = parseInt($('#fila').val()) + 1;
        var tr = $(idTabla + ' tr').eq(fila);
        tr.find('#itemIdEquipo').val(idEquipo);
        tr.find('#itemEquipo').val(nombreEquipo);
        tr.find('#itemSprint').val(sprint);
        tr.find('#itemFechaInicial').val(fechaInicial);
        tr.find('#itemFechaFinal').val(fechaFinal);

        $('#fila').val('');
    }

    $(idForm).modal('hide');
}

function cargarFilaEditaSeguimientoAcciones(elementoSeleccionado, idModal)
{   
    clearTextBox(idModal);
    var observacion = $(elementoSeleccionado).parents("tr").find('#itemObservacion').val();
    if (observacion != "") {
        var fecha = $(elementoSeleccionado).parents("tr").find('#itemFecha').val();
        var usuario = $(elementoSeleccionado).parents("tr").find('#itemUsuario').val();

        $('#Observacion').val(observacion);
        $('#Fecha').val(fecha);
        $('#Usuario').val(usuario);

        var fila = $(elementoSeleccionado).closest('tr').index();
        $('#fila').val(fila);
    } else {
        $('#fila').val(-1);
    }

    $(idModal).modal('show');

}

function AgregarElementoSeguimientoAcciones(idForm, idTabla) {

    var res = validate(idForm);
    if (res == false) {
        return false;
    }

    var observacion = $('#Observacion').val();
    var fecha = $('#Fecha').val();
    var usuario = $('#Usuario').val();

    if ($('#fila').val().trim() == "" || $('#fila').val() == -1) {

        if ($('#fila').val() == -1) {
            $(idTabla + ' tr').eq(1).remove();
        }

        var htmlAcciones = document.getElementById('htmlAccionesSeguimiento').innerHTML;
        var row = '<tr>'
            + '<td><input type="text" value= "' + observacion + '" readOnly class="form-control text-box" id="itemObservacion"  name="itemObservacion"></td>'
            + '<td><input type="text" value= "' + fecha + '" readOnly class="form-control text-box" id="itemFecha" name="itemFecha"></td>'
            + '<td><input type="text" value= "' + usuario + '" readOnly class="form-control text-box" id="itemUsuario" name="itemUsuario"></td>'
            + htmlAcciones
            + '</tr>';

        $(idTabla).append(row);
    }
    else {

        var fila = parseInt($('#fila').val()) + 1;
        var tr = $(idTabla + ' tr').eq(fila);
        tr.find('#itemObservacion').val(observacion);

        $('#fila').val('');
    }

    $(idForm).modal('hide');
}

function cargarFilaEditaEquipos(elementoSeleccionado, idModal) {
    clearTextBox(idModal);
    var nombre = $(elementoSeleccionado).parents("tr").find('#itemNombre').val();
    if (nombre != "") {
        $('#NombreEquipo').val(nombre);

        var fila = $(elementoSeleccionado).closest('tr').index();
        $('#fila').val(fila);
    } else {
        $('#fila').val(-1);
    }

    $(idModal).modal('show');

}

function AgregarElementoEquipos(idForm, idTabla) {

    var res = validate(idForm);
    if (res == false) {
        return false;
    }

    var nombre = $('#NombreEquipo').val();

    if ($('#fila').val().trim() == "" || $('#fila').val() == -1) {

        if ($('#fila').val() == -1) {
            $(idTabla + ' tr').eq(1).remove();
        }

        var htmlAcciones = document.getElementById('htmlAccionesEquipos').innerHTML;
        var row = '<tr>'
            + '<td style="display:none;"><input type="text" value= "" readOnly class="form-control text-box" id="itemId"  name="itemId"></td>'
            + '<td><input type="text" value= "' + nombre + '" readOnly class="form-control text-box" id="itemNombre"  name="itemNombre"></td>'
            + htmlAcciones
            + '</tr>';

        $(idTabla).append(row);
    }
    else {

        var fila = parseInt($('#fila').val()) + 1;
        var tr = $(idTabla + ' tr').eq(fila);
        tr.find('#itemNombre').val(nombre);

        $('#fila').val('');
    }

    $(idForm).modal('hide');
}

function cargarFilaEditaProyectoExterno(elementoSeleccionado, idModal) {
    clearTextBox(idModal);
    var nombre = $(elementoSeleccionado).parents("tr").find('#itemNombre').val();
    var id = $(elementoSeleccionado).parents("tr").find('#itemId').val();

    if (nombre != "") {
        $('#NombreProyectoExterno').val(nombre);
        $('#IdProyectoExterno').val(id);
        var fila = $(elementoSeleccionado).closest('tr').index();
        $('#fila').val(fila);
    } else {
        $('#fila').val(-1);
    }

    $(idModal).modal('show');

}

function AgregarElementoProyectoExterno(idForm, idTabla) {

    var res = validate(idForm);
    if (res == false) {
        return false;
    }

    var nombre = $('#NombreProyectoExterno').val();
    var id = $('#IdProyectoExterno').val();

    if ($('#fila').val().trim() == "" || $('#fila').val() == -1) {
        $.ajax({
            url: '../ProyectoExterno/Crear',
            type: "GET",
            data: { 'nombre': nombre },
            dataType: "json",
            beforeSend: function () {
                $('#wait').modal('show');
            },
            complete: function () {
                $('#wait').modal('hide');
            },
            traditional: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.success == true) {
                    Swal.fire({
                        position: "center",
                        icon: "success",
                        title: data.message,
                        showConfirmButton: true,
                    })
                }
                location.reload(true);
            }
        });

    }
    else {

        $.ajax({
            url: '../ProyectoExterno/Editar',
            type: "GET",
            data: { 'idProyecto': id, 'nombre': nombre },
            dataType: "json",
            beforeSend: function () {
                $('#wait').modal('show');
            },
            complete: function () {
                $('#wait').modal('hide');
            },
            traditional: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.success == true) {
                    Swal.fire({
                        position: "center",
                        icon: "success",
                        title: data.message,
                        showConfirmButton: true,
                    })
                }
                location.reload(true);
            }
        });
    }

    $(idForm).modal('hide');
}

function EliminarElementoProyectoExterno(idProyecto) {
    Swal.fire({
        title: "¿Estás seguro de eliminar el proyecto?",
        showDenyButton: true,
        showCancelButton: false,
        confirmButtonText: "Si, eliminar",
        denyButtonText: "Cancelar",
        icon: "question"
    }).then((result) => {
        if (result.value) {
            $.ajax({
                url: '../ProyectoExterno/Eliminar',
                type: "GET",
                data: { 'idProyecto': idProyecto },
                dataType: "json",
                beforeSend: function () {
                    $('#wait').modal('show');
                },
                complete: function () {
                    $('#wait').modal('hide');
                },
                traditional: true,
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.success == true) {
                        Swal.fire({
                            position: "center",
                            icon: "success",
                            title: data.message,
                            showConfirmButton: true,
                        })
                    }
                    location.reload(true);
                }
            });
        }
    })
}

function consultarSolucionesPorIdCliente(elemento, idCliente, idSolucion, enableCampo) {
    if (idCliente !== "") {
        $.ajax({
            url: '/Base/ConsultarSolucionPorIdCliente',
            type: "GET",
            data: { 'idCliente': idCliente },
            dataType: "json",
            traditional: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.success === true) {
                    $(elemento).html('');
                    var options = '<option></option>';
                    for (var i = 0; i < data.listaDeClientes.length; i++) {
                        if (data.listaDeClientes[i].Id == idSolucion) {
                            options += '<option value="' + data.listaDeClientes[i].Id + '" selected>'
                                + data.listaDeClientes[i].Nombre + '</option>';
                        } else {
                            options += '<option value="' + data.listaDeClientes[i].Id + '">'
                                + data.listaDeClientes[i].Nombre + '</option>';
                        }

                    }
                    $(elemento).append(options);
                    if (enableCampo == 1) {
                        $(elemento).prop("disabled", true);
                    }
                    else {
                        $(elemento).prop("disabled", false);
                        $('#ModalSolicitudesDesempeno').modal('show');
                    }


                } else {
                    alert("Error a nivel de la base de datos consultando los clientes!");
                }
            },
            error: function () {
                alert("Ocurrio un error consultando solicitudes de desempeño!!!");
            }
        });
    }
    else {
        $(elemento).html('');
        $(elemento).prop("disabled", true);
    }
};

function cargarFilaEditarSoluciones(elementoSeleccionado, idModal) {

    clearTextBox(idModal);
    var idCliente = $(elementoSeleccionado).parents("tr").find('#IdCliente').val();
    if (idCliente != "") {
        var idSolucion = $(elementoSeleccionado).parents("tr").find('#IdSolucion').val();
        $('#ListClientes').val(idCliente);
        var fila = $(elementoSeleccionado).closest('tr').index();
        $('#fila').val(fila);

        consultarSolucionesPorIdCliente($('#ListSoluciones'), idCliente, idSolucion, 0);
    }
    else {
        $('#fila').val(-1);
    }
    $(idModal).modal('show');
}

function AgregarSolucion(idForm, idTabla) {

    var esValido = validate(idForm);
    if (!esValido) {
        return false;
    }

    var idCliente = $('#ListClientes').val();
    var nombreCliente = $('#ListClientes option:selected').text();
    var idSolucion = $('#ListSoluciones').val();
    var nombreSolucion = $('#ListSoluciones option:selected').text();

    if ($('#fila').val().trim() == "" || $('#fila').val() == -1) {

        if ($('#fila').val() == -1) {
            $(idTabla + ' tr').eq(1).remove();
        }

        var htmlAcciones = document.getElementById('htmlAccionesSoluciones').innerHTML;
        var row = '<tr>'
            + '<td style="display:none;"><input type="text" value="' + idCliente + '" id="IdCliente" name="IdCliente"></td>'
            + '<td><input type="text" value="' + nombreCliente + '" readOnly class="form-control" id="NombreCliente"  name="NombreCliente"></td>'
            + '<td style="display:none;"><input type="text" value="' + idSolucion + '" id="IdSolucion" name="IdSolucion"></td>'
            + '<td><input type="text" value="' + nombreSolucion + '" readOnly class="form-control" id="NombreSolucion" name="NombreSolucion"></td>' + htmlAcciones + '</tr>';

        $(idTabla).append(row);
    }
    else {

        var fila = parseInt($('#fila').val()) + 1;
        var tr = $(idTabla + ' tr').eq(fila);
        tr.find('#IdCliente').val(idCliente);
        tr.find('#NombreCliente').val(nombreCliente);
        tr.find('#IdSolucion').val(idSolucion);
        tr.find('#NombreSolucion').val(nombreSolucion);

        $('#fila').val('');
    }

    $(idForm).modal('hide');
}

function EnviarCorreo(idSolucion) {
    var emailArquitecto = $('#emailArquitecto').val();
    var adicionales = $('#adicionales').val();
    $.ajax({
        url: '../Hitos/EnviarCorreo',
        type: "GET",
        data: {
            'idSolucion': idSolucion,
            'emailArquitecto': emailArquitecto,
            'adicionales': adicionales
        },
        dataType: "json",
        traditional: true,
        contentType: "application/json; charset=utf-8",
        beforeSend: function () {
            $("#wait").modal('show');
        },
        complete: function () {
            $("#wait").modal('hide');
        },
        success: function (data) {
            if (data.success == true) {
                Swal.fire({
                    position: "center",
                    icon: "success",
                    title: data.message,
                    showConfirmButton: true,
                })
            }
            location.reload(true);
        }
    });

    $("#ModalNotificacion").modal("hide");
}

$(function () {
    var dtToday = new Date();

    var month = dtToday.getMonth() + 1;
    var day = dtToday.getDate();
    var year = dtToday.getFullYear();
    if (month < 10)
        month = '0' + month.toString();
    if (day < 10)
        day = '0' + day.toString();

    var minDate = year + '-' + month + '-' + day;
    $('#itemFechaCierre').attr('min', minDate);
    $('#itemFechaSalidaProduccion').attr('min', minDate);
});



function consultarTiposHitoPorIdCategoria(elemento, idCategoria, idTipo) {
    return new Promise(function (resolve, reject) {
        if (idCategoria !== "") {
            $.ajax({
                url: '/Hitos/consultarTiposHitoPorIdCategoria',
                type: "GET",
                data: { 'idCategoria': idCategoria },
                dataType: "json",
                traditional: true,
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.success === true) {
                        $(elemento).html('');
                        var options = '<option></option>';
                        for (var i = 0; i < data.listaTipoHito.length; i++) {
                            if (data.listaTipoHito[i].Id == idTipo) {
                                options += '<option value="' + data.listaTipoHito[i].Id + '" selected>'
                                    + data.listaTipoHito[i].Nombre + '</option>';
                            } else {
                                options += '<option value="' + data.listaTipoHito[i].Id + '">'
                                    + data.listaTipoHito[i].Nombre + '</option>';
                            }
                       
                        }

                        $(elemento).prop("disabled", false);
                        $(elemento).append(options);
                        resolve();

                    } else {
                        alert("Error a nivel de la base de datos consultando Tipos de Hitos!");
                    }
                },
                error: function () {
                    alert("Ocurrio un error consultando Tipos de Hitos!!!");
                    reject()
                }
            });
        }
        else {
            $(elemento).html('');
            $(elemento).prop("disabled", true);
        }
        
    });
};

function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1);
        if (c.indexOf(name) == 0) return c.substring(name.length, c.length);
    }
    return "";
}

function CambiarCumplimientoTriEstado( valor ) {
    var lenguaje = getCookie("lenguajes")
    if (lenguaje == "es") {
        $(".tri-state").each(function (index) {
            $('select  option:contains("True")').text('Cumplido');
            $('select option:contains("False")').text('No Cumplido');
            $('select option:contains("Sin establecer")').text('Activo');
            $('select option:contains("Verdadero")').text('Cumplido');
        });
    }
    else {
        $(".tri-state").each(function (index) {
            $('select option:contains("Not Set")').text('Active');
            $('select option:contains("True")').text('Compliment');
            $('select option:contains("False")').text('Not accomplished');

        });
    }
    $('#ddlTipoHito').text(valor);
}

async function cargarFilaEditarHitos(elementoSeleccionado, idModal) {
    var idCategoria = $(elementoSeleccionado).parents("tr").find('#IdCategoria').val();
    var idTipo = $(elementoSeleccionado).parents("tr").find('#IdTipo').val();
    var descripcion = $(elementoSeleccionado).parents("tr").find('#Descripcion').val();
    var fecha = $(elementoSeleccionado).parents("tr").find('#FechaCierre').val();
    var observacion = $(elementoSeleccionado).parents("tr").find('#Observacion').val();
    var urlEvidencia = $(elementoSeleccionado).parents("tr").find('#UrlEvidencia').val();
    var completado = $(elementoSeleccionado).parents("tr").find('#Completado').val();
    var completadoTexto = $(elementoSeleccionado).parents("tr").find('#CompletadoTexto').val();

    $('#ddlCategoriaHito').val(idCategoria);
    $('#itemDescripcion').val(descripcion);
    $('#itemFecha').val(fecha);
    $('#itemObservacion').val(observacion);
    $('#itemUrl').val(urlEvidencia);

    $('#ddlCategoriaHito').css('border-color', 'lightgrey');
    $('#itemDescripcion').css('border-color', 'lightgrey');
    $('#itemFecha').css('border-color', 'lightgrey');
    $('#itemObservacion').css('border-color', 'lightgrey');
    $('#itemUrl').css('border-color', 'lightgrey');
    $('#itemCompletado').css('border-color', 'lightgrey');

    CambiarCumplimientoTriEstado(completado);
    await consultarTiposHitoPorIdCategoria($('#ddlTipoHito'), idCategoria, idTipo, completado);


    var fila = $(elementoSeleccionado).closest('tr').index();
    $('#fila').val(fila);

    if (completado != "") {
        $('#ddlCategoriaHito').prop("disabled", true);
        $('#ddlTipoHito').prop("disabled", true);
        $('#itemFecha').prop("disabled", true);
        $('#itemCompletado').prop("disabled", true);
    }
    else {
        $('#ddlCategoriaHito').prop("disabled", false);
        $('#ddlTipoHito').prop("disabled", false);
        $('#itemFecha').prop("disabled", false);
        $('#itemCompletado').prop("disabled", false);
    }

    $(idModal).modal('show')

}

function AgregarElementoHitos(idForm, idTabla) {

    var res = validate(idForm);
    if (res == false) {
        return false;
    }

    var idCategoria = $('#ddlCategoriaHito').val();
    var categoria = $("#ddlCategoriaHito option:selected").text();
    var idTipo = $('#ddlTipoHito').val();
    var tipo = $("#ddlTipoHito option:selected").text();
    var descripcion = $('#itemDescripcion').val();
    var fecha = $('#itemFecha').val();
    var observacion = $('#itemObservacion').val();
    var urlEvidencia = $('#itemUrl').val();
    var completadoTexto = $('#itemCompletado option:selected').text();
    var completado = $('#itemCompletado option:selected').val();


    if ($('#fila').val().trim() == "") {

        var htmlAcciones = document.getElementById('htmlAccionesHito').innerHTML;
        var row = '<tr>'
            + '<td style="display:none;"><input type="text" id="IdTipo" value= "' + idTipo + '" name="IdTipo"></td>'
            + '<td style="display:none;"><input type="text" id="IdCategoria" value= "' + idCategoria + '" name="IdCategoria"></td>'
            + '<td style="display:none;"><input type="text" id="Completado" value= "' + completado + '" name="Completado"></td>'
            + '<td><input type = "text" value = "' + categoria + '" readOnly class="form-control text-box" id = "NombreCategoria"  name = "NombreCategoria" ></td >'
            + '<td><input type = "text" value = "' + tipo + '" readOnly class="form-control text-box" id = "TipoNombre"  name = "TipoNombre" ></div></td > '
            + '<td><input type="text" value= "' + descripcion + '" readOnly class="form-control text-box" id="Descripcion" name="Descripcion"></td>'
            + '<td><input type="text" value= "' + fecha + '" readOnly class="form-control text-box" id="FechaCierre" name="FechaCierre" ></td>'
            + '<td><input type="text" value= "' + observacion + '" readOnly class="form-control text-box" id="Observacion" name="Observacion" ></td>'
            + '<td><input type="text" value= "' + urlEvidencia + '" readOnly class="form-control text-box" id="UrlEvidencia" name="UrlEvidencia" ></td>'
            + '<td><input type = "text" value = "' + completadoTexto + '" readOnly class="form-control text-box" id = "CompletadoTexto" name = "CompletadoTexto" ></td > '
            + htmlAcciones
            + '</tr>';

        $(idTabla).append(row);
    }
    else {

        var fila = parseInt($('#fila').val()) + 1;
        var tr = $(idTabla + ' tr').eq(fila);

        tr.find('#idCategoria').val(idCategoria);
        tr.find('#IdTipo').val(idTipo);
        tr.find('#Categoria').val(categoria);
        tr.find('#TipoNombre').val(tipo);
        tr.find('#Descripcion').val(descripcion);
        tr.find('#FechaCierre').val(fecha);
        tr.find('#Observacion').val(observacion);
        tr.find('#UrlEvidencia').val(urlEvidencia);
        tr.find('#Completado').val(completado);
        tr.find('#CompletadoTexto').val(completadoTexto);

        $('#fila').val('');
    }

    $(idForm).modal('hide');
}

function clearTextBoxHito(idForm) {

    CambiarCumplimientoTriEstado();
    $(idForm).find('select, input', 'textarea').each(function () {
        $(this).val('');
        $(this).css('border-color', 'lightgrey');
        $(this).prop('disabled', false);
    });
    $('#ddlTipoHito').prop("disabled", true);
    $('#fila').val('');
    $(idForm).modal('show')
}



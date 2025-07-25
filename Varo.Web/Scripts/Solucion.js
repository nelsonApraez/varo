function mostrarModalEspera() {
    $('#wait').modal('show');
}

function ocultarModalEspera() {
    $('#wait').modal('hide');
    $('body').removeClass('modal-open');
    $('.modal-backdrop').remove();
}

function obtenerUrlSonar(id) {
    $.ajax({
        url: '../Solucion/ObtenerUrlInspeccion',
        type: "GET",
        data: { 'id': id },
        dataType: "json",
        traditional: true,
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.success === true) {
                window.open(data.integracionesContinuas.UrlInspeccion);
            } else {
                alert("Error a nivel de la base de datos consultando la url de sonar de la solucion!");
            }
        },
        error: function () {
            alert("Ocurrio un error consultando la url de sonar de la solucion!!!");
        }
    });
};

function obtenerUrlVsts(id) {
    $.ajax({
        url: '../Solucion/obtenerUrl',
        type: "GET",
        data: { 'id': id },
        dataType: "json",
        traditional: true,
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.success === true) {
                window.open(data.solucion.UrlRepositorioCodigoFuente);
            } else {
                alert("Error a nivel de la base de datos consultando la url de vsts de la solucion!");
            }
        },
        error: function () {
            alert("Ocurrio un error consultando la url de vsts de la solucion!!!");
        }
    });
};

function eliminarSolucion(solucionId) {
    Swal.fire({
        title: "¿Estás seguro de eliminar el proyecto?",
        showDenyButton: true,
        showCancelButton: false,
        confirmButtonText: "Si, eliminar",
        denyButtonText: "Cancelar",
        icon: "question"
    }).then((result) => {
        if (result.value)
        {
            $.ajax({
            url: '../Solucion/Eliminar',
            type: "GET",
            data: { 'id': solucionId },
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

function mostrarInformes() {
    $('#infBI').addClass('c-sidenav--is-open');
}

function enviarSolucionIdAlModal(solucionId) {
    $('#hiddenSolucionId').val(solucionId);
}

function hoverSharepoint(element) {
    element.setAttribute('src', '/Content/images/sharepoint.png');
}

function unhoverSharepoint(element) {
    element.setAttribute('src', '/Content/images/sharepointGris.png');
}

function hoverSonar(element) {
    element.setAttribute('src', '/Content/images/sonar.png');
}

function unhoverSonar(element) {
    element.setAttribute('src', '/Content/images/sonarGris.png');
}

function hoverVsts(element) {
    element.setAttribute('src', '/Content/images/vsts.png');
}

function unhoverVsts(element) {
    element.setAttribute('src', '/Content/images/vstsGris.png');
}

function hoverMore(element) {
    element.setAttribute('src', '/Content/images/cruz.png');
}

function unhoverMore(element) {
    element.setAttribute('src', '/Content/images/menu_bar.png');
}

function hoverEdit(element) {
    element.setAttribute('src', '/Content/images/editar.png');
}

function unhoverEdit(element) {
    element.setAttribute('src', '/Content/images/editarGris.png');
}

function hoverEstadisticas(element) {
    element.setAttribute('src', '/Content/images/estadisticas.png');
}

function unhoverEstadisticas(element) {
    element.setAttribute('src', '/Content/images/estadisticasGris.png');
}

function hoverVistaPrevia(element) {
    element.setAttribute('src', '/Content/images/verdetalle.png');
}

function unhoverVistaPrevia(element) {
    element.setAttribute('src', '/Content/images/verdetalleGris.png');
}

function hoverAseguramientoCalidad(element) {
    element.setAttribute('src', '/Content/images/thor.png');
}

function unhoverAseguramientoCalidad(element) {
    element.setAttribute('src', '/Content/images/thorGris.png');
}

function hoverLeccionesAprendidas(element) {
    element.setAttribute('src', '/Content/images/LeccionesAprendidas.png');
}

function unhoverLeccionesAprendidas(element) {
    element.setAttribute('src', '/Content/images/LeccionesAprendidasGris.png');
}

function removeClaseButton(element) {
    $(element).removeClass('disabled');
}

function addClaseButton(element) {
    $(element).addClass('disabled');
}




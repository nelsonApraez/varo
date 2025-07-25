function mostrarModalEspera() {
    $('#wait').modal('show');
}

function ocultarModalEspera() {
    $('#wait').modal('hide');
    $('body').removeClass('modal-open');
    $('.modal-backdrop').remove();
}

function eliminarConsultoria(consultoriaId) {
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
                url: '../Consultoria/Eliminar',
                type: "GET",
                data: { 'id': consultoriaId },
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
        }
    })
}


function enviarConsultoriaIdAlModal(consultoriaId) {
    $('#hiddenConsultoriaId').val(consultoriaId);
}

function hoverSharepoint(element) {
    element.setAttribute('src', '/Content/images/sharepoint.png');
}

function unhoverSharepoint(element) {
    element.setAttribute('src', '/Content/images/sharepointGris.png');
}

function hoverEdit(element) {
    element.setAttribute('src', '/Content/images/editar.png');
}

function unhoverEdit(element) {
    element.setAttribute('src', '/Content/images/editarGris.png');
}

function hoverVistaPrevia(element) {
    element.setAttribute('src', '/Content/images/verdetalle.png');
}

function unhoverVistaPrevia(element) {
    element.setAttribute('src', '/Content/images/verdetalleGris.png');
}

function hoverClonar(element) {
    element.setAttribute('src', '/Content/images/clone.png');
}

function unhoverClonar(element) {
    element.setAttribute('src', '/Content/images/cloneGris.png');
}



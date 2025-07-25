$(document).ready(function () {
    
})

function mostrarModalEspera() {
    $('#wait').modal('show');
}
function ocultarModalEspera() {
    $('#wait').modal('hide');
    $('body').removeClass('modal-open');
    $('.modal-backdrop').remove();
}
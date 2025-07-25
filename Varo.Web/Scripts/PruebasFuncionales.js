
function ObtenerNombrePorUsuarioRed() {

    var usuarioRed = $('#usuarioRedTecnico').val();

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
                    var nombre = data.informacionUsuarioResponsable[1];
                    $('#nombreTecnico').val(nombre);
                    if (nombre === null) {
                        alert("Usuario de red no encontrado por favor verifiquelo");
                    }
                } else {
                    alert("Error a nivel de la base de datos consultando Nombre Responsable Por UsuarioRed!");
                }
            },
            error: function () {
                $('#nombreTecnico').val('');
                alert("Ocurrio un error consultando Nombre Responsable Por UsuarioRed!!!");
            }
        });
    }
    else {
        $('#nombreTecnico').val('');
    }
};


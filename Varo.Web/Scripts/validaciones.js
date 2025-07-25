var lenguaje = getIdiomaActual();

if (lenguaje == "en") {
    $.extend($.validator.messages, {
        required: "This field is required.",
        email: "Please enter a valid email address.",
        url: "Please enter a valid URL.",
        date: "Please enter a valid date.",
        number: "Please enter a valid number.",
        digits: "Please enter only digits.",
        maxlength: $.validator.format("Please enter no more than {0} characters."),
        minlength: $.validator.format("Please enter at least {0} characters."),
        rangelength: $.validator.format("Please enter a value between {0} and {1} characters long."),
        range: $.validator.format("Please enter a value between {0} and {1}."),
        max: $.validator.format("Please enter a value less than or equal to {0}."),
        min: $.validator.format("Please enter a value greater than or equal to {0}."),
        integer: "Please enter a positive or negative integer.",
        alphanumeric: "Please enter the letters, numbers or underscores.",
        minlength_with_cleaning: $.validator.format("Please enter at least {0} characters.")
    });
}
else {
    $.extend($.validator.messages, {
        required: "Campo requerido.",
        email: "Por favor, escribe una dirección de correo válida.",
        url: "Por favor, escribe una URL válida.",
        date: "Por favor, escribe una fecha válida.",
        number: "Por favor, escribe un número válido.",
        digits: "Por favor, escribe sólo dígitos.",
        maxlength: $.validator.format("Por favor, no escribas más de {0} caracteres."),
        minlength: $.validator.format("Por favor, no escribas menos de {0} caracteres."),
        rangelength: $.validator.format("Por favor, escribe un valor entre {0} y {1} caracteres."),
        range: $.validator.format("Por favor, escribe un valor entre {0} y {1}."),
        max: $.validator.format("Por favor, escribe un valor menor o igual a {0}."),
        min: $.validator.format("Por favor, escribe un valor mayor o igual a {0}.")
    });
}

var textoRequerido = $.validator.messages.required;

jQuery(function ($) {    
    $('#formularioCrearSolucion').validate({
        lang: lenguaje,
        rules: {
            'NombreProyecto': {
                required: true
            },
            'UsuarioRedGerente': {
                required: true
            },
            'NombreGerente': {
                required: true
            },
            'RolGerente': {
                required: true
            },
            'UsuarioRedResponsable': {
                required: true
            },
            'NombreResponsable': {
                required: true
            },
            'RolResponsable': {
                required: true
            },
            //'UrlDocumentacion': {
            //    required: true
            //},
            //'UrlGestionTareas': {
            //    required: true
            //},
            //'UrlGestionIncidentes': {
            //    required: true
            //},
            //'UrlGestionAseguramientoCalidad': {
            //    required: true
            //},
            //'UrlLeccionesAprendidas': {
            //    required: true
            //},
            //'UrlRepositorioCodigoFuente': {
            //    required: true
            //},
            //'NombreContactoCliente': {
            //    required: true
            //},
            //'CorreoContactoCliente': {
            //    required: true,
            //    email: true 
            //},
            'Cliente.Id': {
                required: true
            },
            'Tipo.Id': {
                required: true
            },
            'LineaSolucion.Id': {
                required: true
            },
            'LineaNegocio.Id': {
                required: true
            },
            'MarcoTrabajo.Id': {
                required: true
            },
            'Estado.Id': {
                required: true
            },
            'Oficina.Id': {
                required: true
            },
            'Pais.Id': {
                required: true
            },
            'EstimacionHoras.Concepto': {
                required: true
            },
            'EstimacionHoras.HorasEstimadas': {
                max: 2147483647,
                min: 0,
                number: true
            },
            'EstimacionHoras.HorasEjecutadas': {
                max: 2147483647,
                min: 0,
                number: true
            },
            //'TecnologiasViewModel.TipoTecnologia.Nombre': {
            //    required: true,
            //    min: 1
            //},
            //'TecnologiasViewModel.Tecnologia.Nombre': {
            //    required: true
            //},
            //'IntegracionesContinuas.Nombre': {
            //    required: true
            //},
            //'IntegracionesContinuas.UrlCompilacion': {
            //    required: true
            //},
            'UsoComercial.Id': {
                required: true
            },
            'Gsdc.Id': {
                required: true
            },
            'FechaCreacion': {
                required: true
            }
        }
    });

    $('#formularioCrearPruebasFuncionales').validate({
        lang: lenguaje,
        rules: {
            'CasosDefinidos': {
                required: true
            },
            'CasosaAutomatizar': {
                required: true
            },
            'CasosAutomatizados': {
                required: true
            },
            'CasosPendientes': {
                required: true
            },
            'UsuarioRedTecnico': {
                required: true
            },
            'NombreTecnico': {
                required: true
            },
            'FechaCreacion': {
                required: true,
            },
            
        }
    });

    $('#formularioCrearCalificacionAuditoria').validate({
        lang: lenguaje,
        rules: {
            'Calificacion': {
                required: true
            },
            'Fecha': {
                required: true
            },
            'Url': {
                required: true
            },
            'Proceso': {
                required: true
            },
            'NombreCliente': {
                required: true
            },
            'NombreSolucion': {
                required: true
            },
        }
    });

    $('#formularioCrearCalificacionAuditoriaConsultoria').validate({
        lang: lenguaje,
        rules: {
            'Calificacion': {
                required: true
            },
            'Fecha': {
                required: true
            },
            'Url': {
                required: true
            },
            'Proceso': {
                required: true
            },
        }
    });

    $('#formularioCrearCalificacionDesempeno').validate({
        lang: lenguaje,
        rules: {
            'Calificacion': {
                required: true
            },
            'Fecha': {
                required: true
            },
            'Url': {
                required: true
            },
        }
    });

    $('#formularioCrearCalificacionSeguridad').validate({
        lang: lenguaje,
        rules: {
            'CalificacionDeSeguridad': {
                required: true
            },
            'Fecha': {
                required: true
            },
            'Url': {
                required: true
            },
        }
    });

    $('#formularioHistoriasyEsfuerzos').validate({
        lang: lenguaje,
        rules: {
            'historiasyEsfuerzosViewModel.HistoriasEstimadas': {
                required: true,
                max: 2147483647,
                min: 0,
                number: true
            },
            'historiasyEsfuerzosViewModel.HistoriasLogradas': {
                required: true,
                max: 2147483647,
                min: 0,
                number: true
            },
            'historiasyEsfuerzosViewModel.EsfuerzoEstimado': {
                required: true
            },
            'historiasyEsfuerzosViewModel.EsfuerzoLogrado': {
                required: true
            },
            'historiasyEsfuerzosViewModel.Observaciones': {
                maxlength: 500,
                minlength: 0
            },
            'historiasViewModel.Numero': {
                required: true,
                maxlength: 10,
                minlength: 0
            },
            'historiasViewModel.Nombre': {
                required: true,
                maxlength: 500,
                minlength: 0
            },
            'historiasViewModel.EsfuerzoEstimado': {
                required: true, number: true
            },
            'historiasViewModel.EsfuerzoReal': {
                required: true, number: true
            },
            'historiasViewModel.Observaciones': {
                maxlength: 500,
                minlength: 0
            },
            'defectosInternosViewModel.ReportadosDefectos': {
                required: true,
                max: 2147483647,
                min: 0,
                number: true
            },
            'defectosInternosViewModel.CerradosDefectos': {
                required: true,
                max: 2147483647,
                min: 0,
                number: true
            },
            'defectosInternosViewModel.AbiertosDefectos': {
                required: true,
                max: 2147483647,
                min: 0,
                number: true
            },
            'defectosInternosViewModel.ObservacionesDefectos': {
                maxlength: 500,
                minlength: 0
            },
            'defectosExternosViewModel.ReportadosDefectos': {
                required: true,
                max: 2147483647,
                min: 0,
                number: true
            },
            'defectosExternosViewModel.CerradosDefectos': {
                required: true,
                max: 2147483647,
                min: 0,
                number: true
            },
            'defectosExternosViewModel.AbiertosDefectos': {
                required: true,
                max: 2147483647,
                min: 0,
                number: true
            },
            'defectosExternosViewModel.ObservacionesDefectos': {
                maxlength: 500,
                minlength: 0
            },
            'incendiosViewModel.ReportadosIncendios': {
                required: true,
                max: 2147483647,
                min: 0,
                number: true
            },
            'incendiosViewModel.SolucionadosIncendios': {
                required: true,
                max: 2147483647,
                min: 0,
                number: true
            },
            'incendiosViewModel.ObservacionesIncendios': {
                maxlength: 500,
                minlength: 0
            },
            'calidadCodigoViewModel.Bugs': {
                required: true,
                max: 2147483647,
                min: 0,
                number: true
            },
            'calidadCodigoViewModel.Vulnerabilidades': {
                required: true,
                max: 2147483647,
                minlength: 0,
                number: true
            },
            'calidadCodigoViewModel.DeudaTecnica': {
                required: true,
                maxlength: 10,
                minlength: 0
            },
            'calidadCodigoViewModel.Cobertura': {
                required: true,
                maxlength: 10,
                minlength: 0
            },
            'calidadCodigoViewModel.Duplicado': {
                required: true,
                maxlength: 10,
                minlength: 0
            },
            'calidadCodigoViewModel.ObservacionesdeCalidadCodigo': {
                maxlength: 500,
                minlength: 0
            },
            'accionesMejoraViewModel.AccionMejora': {
                required: true
            },
            'accionesMejoraViewModel.Accion': {
                required: true,
                maxlength: 500,
                minlength: 0
            },
            'accionesMejoraViewModel.Responsable.Nombre': {
                required: true
            },
            'accionesMejoraViewModel.Estado.Nombre': {
                required: true
            },
            'accionesMejoraViewModel.Causa': {
                required: true
            }
        }
    });
    $('#formularioMetricasAgiles').validate({
        lang: lenguaje,
        rules: {
            'Sprint': {
                required: true,
                maxlength: 500
            },
            'FechaInicial': { required: true },
            'FechaFinal': { required: true },
        }
    });
    $('#formularioSeguimiento').validate({
        lang: lenguaje,
        rules: {
            'Observacion': {
                required: true,
                maxlength: 500,
                minlength: 0
            },
        }
    });

    $('#formularioCrearConsultoria').validate({
        lang: lenguaje,
        rules: {
            'NombreProyecto': {
                required: true
            },
            'UsuarioRedGerente': {
                required: true
            },
            'NombreGerente': {
                required: true
            },
            'RolGerente': {
                required: true
            },
            'UsuarioRedConsultor': {
                required: true
            },
            'NombreConsultor': {
                required: true
            },
            'RolConsultor': {
                required: true
            },
            'UrlDocumentacion': {
                required: true
            },
            'UrlGestionTareas': {
                required: true
            },
            'UrlGestionIncidentes': {
                required: true
            },
            'UrlGestionAseguramientoCalidad': {
                required: true
            },
            'UrlLeccionesAprendidas': {
                required: true
            },
            'NombreContactoCliente': {
                required: true
            },
            'CorreoContactoCliente': {
                required: true,
                email: true
            },
            'Cliente.Id': {
                required: true
            },
            'LineaConsultoria.Id': {
                required: true
            },
            'Estado.Id': {
                required: true
            },
            'LineaNegocio.Id': {
                required: true
            },
            'Oficina.Id': {
                required: true
            },
            'Pais.Id': {
                required: true
            },
            'Descripcion': {
                required: true
            },
            'EstimacionHoras.Concepto': {
                required: true
            },
            'EstimacionHoras.HorasEstimadas': {
                max: 2147483647,
                min: 0,
                number: true
            },
            'EstimacionHoras.HorasEjecutadas': {
                max: 2147483647,
                min: 0,
                number: true
            },
            'UsoComercial.Id': {
                required: true
            },
            'Gsdc.Id': {
                required: true
            },
            'FechaCreacion': {
                required: true
            }
        }
    });
    $('#formularioCrearMetricas').validate({
        lang: lenguaje,
        rules: {
            'Mes': {
                required: true,
                range: [1, 12]
            },
            'Ano': {
                required: true,
                minlength : 4
            },
            'FechaAnalisis': {
                required: true
            },
            'lines': {
                required: true
            },
            'bugs': {
                required: true
            },
            'vulnerabilities': {
                required: true
            },
            'technical_debt_ratio': {
                required: true
            },
            'coverage': {
                required: true
            },
            'duplicated_lines_density': {
                required: true
            }
        }
    });
    $('#formularioEquipos').validate({
        lang: lenguaje,
        rules: {
            'Nombre': {
                required: true,
                maxlength: 500,
                minlength: 0
            },
        }
    });
});

$('#formIntegraciones').validate({
    lang: lenguaje,
    rules: {
        'NombreCompilacion': {
            required: true
        },
        'UrlCompilacion': {
            required: true
        }
    }
});

$('#formEstimacionHoras').validate({
    lang: lenguaje,
    rules: {
        'Concepto': {
            required: true
        },
        'HorasEstimadas': {
            required: true
        },
        'HorasEjecutadas': {
            required: true
        }
    }
});

$('#formularioCrearEstimacionHoras').validate({
    lang: lenguaje,
    rules: {
        'EstimacionHoras.Concepto': {
            required: true
        },
        'EstimacionHoras.HorasEstimadas': {
            required: true
        },
        'EstimacionHoras.HorasEjecutadas': {
            required: true
        }
    }
});

$('#formularioCrearAmbientes').validate({
    lang: lenguaje,
    rules: {
        'TipoAmbiente.Nombre': {
            required: true
        },
        'Ubicacion': {
            required: true
        },
        'itemUbicacion': {
            required: true
        },
        'Responsable': {
            required: true
        },
        'itemResponsable': {
            required: true
        }
    }
});

$('#formularioCrearHitos').validate({
    lang: lenguaje,
    rules: {
        'Tipo.Nombre': {
            required: true
        },
        'Descripcion': {
            required: true
        },
        'FechaCierre': {
            required: true
        },
        'Estado.Nombre': {
            required: true
        },
        'itemResponsable': {
            required: true
        },
        'ListaTipo': {
            required: true
        },
        'ListaEstados': {
            required: true
        }
    }
});

function getIdiomaActual() {
    return $('#lenguajeActual').val();
}

$('#ModalDetalleProyectoExterno').validate({
    lang: lenguaje,
    rules: {
        'ListClientes': {
            required: true
        },
        'ListSoluciones': {
            required: true
        },
        'ListaEstadosSolicitudesDesempeno': {
            required: true
        },
        'itemSolicitante': {
            required: true
        }   
    }
});


namespace Varo.Transversales
{
    using System;
    using System.Configuration;
    using System.Globalization;

    public static class ParametrosGenerales
    {
        public static string PrimeraPagina
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("PrimeraPagina");
            }
        }

        public static string UltimaPagina
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("UltimaPagina");
            }
        }

        public static string PaginaAnterior
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("PaginaAnterior");
            }
        }

        public static string PaginaSiguiente
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("PaginaSiguiente");
            }
        }

        public static int CantidadDeTarjetasPorPagina
        {
            get
            {
                return Int32.Parse(
                    ObtenerValorDeConfiguracion("CantidadDeTarjetasPorPagina"),
                    CultureInfo.InvariantCulture);
            }
        }

        public static int CantidadDeRegistrosPorPagina
        {
            get
            {
                return Int32.Parse(
                    ObtenerValorDeConfiguracion("CantidadDeRegistrosPorPagina"),
                    CultureInfo.InvariantCulture);
            }
        }

        public static string RutaImagenesTecnologia
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("RutaImagenesTecnologia");
            }
        }

        public static Uri UrlServicioWebConsultarPaises
        {
            get
            {
                return new Uri(ObtenerValorDeConfiguracion("UrlServicioWebConsultarPaises"));
            }
        }

        public static Uri UrlServicioWebConsultarCiudades
        {
            get
            {
                return new Uri(ObtenerValorDeConfiguracion("UrlServicioWebConsultarCiudades"));
            }
        }

        public static Uri UrlServicioWebConsultarDepartamentos
        {
            get
            {
                return new Uri(ObtenerValorDeConfiguracion("UrlServicioWebConsultarDepartamentos"));
            }
        }

        public static Uri UrlServicioWebConsultarDepartamentosPorIdPais
        {
            get
            {
                return new Uri(ObtenerValorDeConfiguracion("UrlServicioWebConsultarDepartamentosPorIdPais"));
            }
        }

        public static Uri urlCiudadesIdDepartamento
        {
            get
            {
                return new Uri(ObtenerValorDeConfiguracion("UrlServicioWebConsultarCiudadesPorIdDepartamento"));
            }
        }

        public static Uri UrlServicioWebConsultarClientes
        {
            get
            {
                return new Uri(ObtenerValorDeConfiguracion("UrlServicioWebConsultarClientes"));
            }
        }

        public static Uri UrlServicioWebConsultarProyectosSonar
        {
            get
            {
                return new Uri(ObtenerValorDeConfiguracion("UrlServicioWebConsultarProyectosSonar"));
            }
        }

        public static Uri UrlServicioWebConsultarValorMetricasPorSolucionSonar
        {
            get
            {
                return new Uri(ObtenerValorDeConfiguracion("UrlServicioWebConsultarValorMetricaPorSolucionSonar"));
            }
        }

        public static Uri UrlServicioWebConsultarProyectosSonarPorTipoOrigen
        {
            get
            {
                return new Uri(ObtenerValorDeConfiguracion("UrlServicioWebConsultarProyectosSonarPorTipoOrigen"));
            }
        }

        public static Uri UrlServicioWebConsultarMetricaSonar
        {
            get
            {
                return new Uri(ObtenerValorDeConfiguracion("UrlServicioWebConsultarMetricasSonar"));
            }
        }

        public static Uri UrlServicioWebCrearValorMetricaSonarExternos
        {
            get
            {
                return new Uri(ObtenerValorDeConfiguracion("UrlServicioWebCrearValorMetricasSonarExterno"));
            }
        }

        public static Uri UrlServicioWebInactivarProyectoExterno
        {
            get
            {
                return new Uri(ObtenerValorDeConfiguracion("UrlServicioWebInactivarProyectoExterno"));
            }
        }

        public static Uri UrlServicioWebActualizarProyectoExterno
        {
            get
            {
                return new Uri(ObtenerValorDeConfiguracion("UrlServicioWebActualizarProyectoExterno"));
            }
        }

        public static Uri UrlServicioWebCrearProyectoExterno
        {
            get
            {
                return new Uri(ObtenerValorDeConfiguracion("UrlServicioWebCrearProyectoExterno"));
            }
        }

        public static Uri UrlServicioWebConsultarValorMetricaSonarExterno
        {
            get
            {
                return new Uri(ObtenerValorDeConfiguracion("UrlServicioWebConsultarValorMetricasSonarExterno"));
            }
        }

        public static Uri UrlServicioWebConsultarProyectoExterno
        {
            get
            {
                return new Uri(ObtenerValorDeConfiguracion("UrlServicioWebConsultarProyectoExternoPorParametro"));
            }
        }

        public static string RutaConsultoriasEN
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("RutaConsultoriasEN");
            }
        }

        public static string RutaSolucionesEN
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("RutaSolucionesEN");
            }
        }

        public static string RutaPracticasTecnicasEN
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("RutaPracticasTecnicasEN");
            }
        }

        public static string RutaCalidadCodigoEN
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("RutaCalidadCodigoEN");
            }
        }

        public static string RutaPruebasFuncionalesEN
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("RutaPruebasFuncionalesEN");
            }
        }

        public static string RutaMetricasAgilesEN
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("RutaMetricasAgilesEN");
            }
        }

        public static string RutaHitosEN
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("RutaHitosEN");
            }
        }

        public static string RutaAuditoriasEN
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("RutaAuditoriasEN");
            }
        }

        public static string RutaDesempenoEN
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("RutaDesempenoEN");
            }
        }

        public static string RutaSeguridadEN
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("RutaSeguridadEN");
            }
        }

        public static string API_KEY
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("API-KEY");
            }
        }

        public static string JWT_SECRET_KEY
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("JWT-SECRET-KEY");
            }
        }

        public static string JWT_AUDIENCE_TOKEN
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("JWT_AUDIENCE_TOKEN");
            }
        }

        public static string JWT_ISSUER_TOKEN
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("JWT_ISSUER_TOKEN");
            }
        }

        public static string JWT_EXPIRE_MINUTES
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("JWT_EXPIRE_MINUTES");
            }
        }

        public static string UrlEndPoint
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("UrlEndPoint");
            }
        }

        public static string ClientId
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("ClientId");
            }
        }

        public static string ClientSecret
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("ClientSecret");
            }
        }

        public static string GrantTypeGraph
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("GrantTypeGraph");
            }
        }

        public static string Scope
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("Scope");
            }
        }

        public static string TenantId
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("TenantId");
            }
        }

        public static string UrlGraphUsers
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("UrlGraphUsers");
            }
        }

        public static string Dominio
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("Dominio");
            }
        }

        public static string EmailSender
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("EmailSender");
            }
        }

        public static string Host365
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("Host365");
            }
        }

        public static string Port365
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("Port365");
            }
        }

        public static string TargetName365
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("TargetName365");
            }
        }

        public static string PasswordApp365
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("PasswordApp365");
            }
        }

        public static string UrlWebSiteSombreroBlanco
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("UrlWebSiteSombreroBlanco");
            }
        }

        public static string UrlWebApiSombreroBlanco
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("UrlWebApiSombreroBlanco");
            }
        }

        public static string TokenSombreroBlanco
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("TokenSombreroBlanco");
            }
        }

        public static DateTime FechaCaducidadCacheDatosBasicos
        {
            get
            {
                int duracionCacheEnHoras = Int32.Parse(ObtenerValorDeConfiguracion("DuracionCacheDatosBasicosEnHoras"));
                DateTime fechaCaducidad = DateTime.Now.AddHours(duracionCacheEnHoras);

                return fechaCaducidad;
            }
        }

        public static DateTime FechaCaducidadCacheClientes
        {
            get
            {
                int duracionCacheEnHoras = Int32.Parse(ObtenerValorDeConfiguracion("DuracionCacheClientesEnHoras"));
                DateTime fechaCaducidad = DateTime.Now.AddHours(duracionCacheEnHoras);

                return fechaCaducidad;
            }
        }

        public static DateTime FechaCaducidadCacheUsuarios
        {
            get
            {
                int duracionCacheEnHoras = Int32.Parse(ObtenerValorDeConfiguracion("DuracionCacheUsuariosEnHoras"));
                DateTime fechaCaducidad = DateTime.Now.AddHours(duracionCacheEnHoras);

                return fechaCaducidad;
            }
        }

        public static string RutaRevisionEstimacion
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("RutaRevisionEstimacion");
            }
        }

        public static string RutaRevisionArquitectura
        {
            get
            {
                return
                    ObtenerValorDeConfiguracion("RutaRevisionArquitectura");
            }
        }

        private static string ObtenerValorDeConfiguracion(string llave)
        {
            string valorLlave = ConfigurationManager.AppSettings[llave];

            if (valorLlave == null)
            {
                throw new ConfigurationErrorsException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "La llave {0} no se encuentra configurada.",
                        llave));
            }

            return valorLlave;
        }
    }
}


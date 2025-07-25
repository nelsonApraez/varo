namespace Varo.Maestros.SistemasExternos
{
    using Varo.Maestros.Entidades;
    using Varo.Transversales;
    using Varo.Transversales.Excepciones;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Web.Caching;

    public class AdaptadorLocalizacion : IAdaptadorLocalizacion
    {
        private readonly Cache cache;
        private static readonly string claveCachePaises = "paises";
        private static readonly string claveCacheDepartamentos = "departamentos";
        private static readonly string claveCacheCiudades = "ciudades";
        private static readonly string claveCacheDepartamentosPorPais = "departamentosPorPais";
        private static readonly string claveCacheCiudadesPorDepartamento = "ciudadesPorDepartamento";

        public AdaptadorLocalizacion()
        {
            this.cache = new Cache();
        }

        public IList<Pais> ConsultarPaises()
        {
            List<Pais> paises;

            paises = ObtenerDatosDesdeCache<List<Pais>>(claveCachePaises);

            if (paises == null)
            {
                paises = ObtenerDatosDesdeAPIExterna<List<Pais>>(ParametrosGenerales.UrlServicioWebConsultarPaises);
                EstablecerCache(claveCachePaises, paises);
            }
            return paises;
        }

        public IList<Departamento> ConsultarDepartamentos()
        {
            List<Departamento> departamentos;

            departamentos = ObtenerDatosDesdeCache<List<Departamento>>(claveCacheDepartamentos);

            if (departamentos == null)
            {
                departamentos = ObtenerDatosDesdeAPIExterna<List<Departamento>>(ParametrosGenerales.UrlServicioWebConsultarDepartamentos);
                EstablecerCache(claveCacheDepartamentos, departamentos);
            }
            return departamentos;
        }

        public IList<Ciudad> ConsultarCiudades()
        {
            List<Ciudad> ciudades;

            ciudades = ObtenerDatosDesdeCache<List<Ciudad>>(claveCacheCiudades);

            if (ciudades == null)
            {
                ciudades = ObtenerDatosDesdeAPIExterna<List<Ciudad>>(ParametrosGenerales.UrlServicioWebConsultarCiudades);
                EstablecerCache(claveCacheCiudades, ciudades);
            }
            return ciudades;
        }

        public IList<Departamento> ConsultarDepartamentosPorIdPais(int idPais)
        {
            string claveCache = claveCacheDepartamentosPorPais + idPais;
            List<Departamento> departamentos;

            departamentos = ObtenerDatosDesdeCache<List<Departamento>>(claveCache);

            if (departamentos == null)
            {
                Uri ciudadesIdDepartamento = new Uri(
                    ParametrosGenerales.urlCiudadesIdDepartamento + idPais.ToString(
                        CultureInfo.CurrentCulture
                        )
                    );

                departamentos = ObtenerDatosDesdeAPIExterna<List<Departamento>>(ciudadesIdDepartamento);
                EstablecerCache(claveCache, departamentos);
            }
            return departamentos;
        }

        public IList<Ciudad> ConsultarCiudadesPorIdDepartamento(int idDepartamento)
        {
            string claveCache = claveCacheCiudadesPorDepartamento + idDepartamento;
            List<Ciudad> ciudades;

            ciudades = ObtenerDatosDesdeCache<List<Ciudad>>(claveCache);

            if (ciudades == null)
            {
                Uri ciudadesIdDepartamento = new Uri(
                    ParametrosGenerales.urlCiudadesIdDepartamento + idDepartamento.ToString(
                        CultureInfo.CurrentCulture
                        )
                    );

                ciudades = ObtenerDatosDesdeAPIExterna<List<Ciudad>>(ciudadesIdDepartamento);
                EstablecerCache(claveCache, ciudades);
            }

            return ciudades;
        }

        private T ObtenerDatosDesdeCache<T>(string clave)
        {
            return (T)this.cache.Get(clave);
        }

        private T ObtenerDatosDesdeAPIExterna<T>(Uri url)
        {
            string datosJson;
            HttpWebResponse respuestaJson;

            respuestaJson = SolicitarJsonAPIExterna(url);

            if (respuestaJson.StatusCode != HttpStatusCode.OK)
            {
                throw new SolicitudAPIExcepcion();
            }

            datosJson = LeerJson(respuestaJson);
            return ObtenerDatosDesdeJson<T>(datosJson);
        }

        private HttpWebResponse SolicitarJsonAPIExterna(Uri url)
        {
            HttpWebRequest peticionAPI = WebRequest.Create(url) as HttpWebRequest;
            peticionAPI.Method = "GET";

            return peticionAPI.GetResponse() as HttpWebResponse;
        }

        private string LeerJson(HttpWebResponse respuestaJson)
        {
            using (Stream responseResult = respuestaJson.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseResult, Encoding.UTF8);
                return reader.ReadToEnd();
            }
        }

        private T ObtenerDatosDesdeJson<T>(string datosJson)
        {
            if (string.IsNullOrEmpty(datosJson))
            {
                throw new JsonVacioExcepcion();
            }
            return JsonConvert.DeserializeObject<T>(datosJson);
        }

        private void EstablecerCache(string clave, Object datos)
        {
            this.cache.Add(
                clave,
                datos,
                null,
                ParametrosGenerales.FechaCaducidadCacheDatosBasicos,
                TimeSpan.Zero,
                CacheItemPriority.High,
                null);
        }

    }
}



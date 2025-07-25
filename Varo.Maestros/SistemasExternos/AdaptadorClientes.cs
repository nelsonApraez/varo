namespace Varo.Maestros.SistemasExternos
{
    using Varo.Maestros.Entidades;
    using Varo.Transversales;
    using Varo.Transversales.Excepciones;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Web.Caching;

    public class AdaptadorClientes : IAdaptadorClientes
    {
        private readonly Cache cache;
        private static string claveCache = "clientes";

        private IList<Cliente> clientes;
        private HttpWebResponse respuestaClientes;
        private string clientesJson;

        public AdaptadorClientes()
        {
            cache = new Cache();
        }

        public IList<Cliente> ConsultarClientes()
        {
            EstablecerClientesDesdeCache();

            if (clientes == null)
            {
                EstablecerClientesDesdeAPIExterna();
                EstablecerCache();
            }

            return clientes;
        }

        private void EstablecerClientesDesdeCache()
        {
            clientes = cache.Get(claveCache) as List<Cliente>;
        }

        private void EstablecerClientesDesdeAPIExterna()
        {
            respuestaClientes = SolicitarJsonClientes();

            if (respuestaClientes.StatusCode != HttpStatusCode.OK)
            {
                throw new SolicitudAPIExcepcion();
            }
            LeerJsonClientes();
            EstablecerClientesDesdeJson();
        }

        private HttpWebResponse SolicitarJsonClientes()
        {
            HttpWebRequest peticionClientes = WebRequest.Create(ParametrosGenerales.UrlServicioWebConsultarClientes) as HttpWebRequest;
            peticionClientes.Method = "GET";

            return peticionClientes.GetResponse() as HttpWebResponse;
        }

        private void LeerJsonClientes()
        {
            using (Stream responseResult = respuestaClientes.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseResult, Encoding.UTF8);
                clientesJson = reader.ReadToEnd();
            }
        }

        private void EstablecerClientesDesdeJson()
        {
            if (!string.IsNullOrEmpty(clientesJson))
            {
                clientes = JsonConvert.DeserializeObject<List<Cliente>>(clientesJson);
            }
        }

        private void EstablecerCache()
        {
            this.cache.Add(
                claveCache,
                clientes,
                null,
                ParametrosGenerales.FechaCaducidadCacheClientes,
                TimeSpan.Zero,
                CacheItemPriority.High,
                null);
        }
    }
}


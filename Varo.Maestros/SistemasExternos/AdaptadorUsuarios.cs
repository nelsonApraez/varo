namespace Varo.Maestros.SistemasExternos
{
    using Varo.Maestros.Entidades;
    using Varo.Transversales;
    using Varo.Transversales.Excepciones;
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Caching;

    class AdaptadorUsuarios : IAdaptadorUsuarios
    {
        private readonly Cache cache;
        private String claveCache = "usuarios";
        Usuario usuario;
        ResponseOAuth2 token;
        string url;

        private HttpWebResponse respuestaUsuario;
        private string usuarioJson;

        public AdaptadorUsuarios()
        {
            cache = new Cache();
        }

        public Usuario ObtenerInformacionUsuario(string nombreUsuario)
        {
            url = $"{ParametrosGenerales.UrlGraphUsers}{ nombreUsuario.Trim().ToLower(CultureInfo.CurrentCulture) + ParametrosGenerales.Dominio }";

            EstablecerUsuarioDesdeCache();
            if (usuario == null)
            {
                EstablecerTokenDesdeCache();
                if (token == null)
                {
                    ObtenerToken();
                    EstablecerCacheToken();
                }

                EstablecerUsuarioDesdeApiExterna(nombreUsuario);
                EstablecerCacheUsuario();
            }
            return usuario;
        }

        private void EstablecerUsuarioDesdeCache()
        {
            usuario = cache.Get(url) as Usuario;
        }

        private void EstablecerUsuarioDesdeApiExterna(String nombreUsuario)
        {
            try
            {
                respuestaUsuario = SolicitarJsonUsuarios();

                if (respuestaUsuario.StatusCode != HttpStatusCode.OK)
                {
                    throw new SolicitudAPIExcepcion();
                }

                LeerJsonUsuarios();
                EstablecerUsuariosDesdeJson();
            }
            catch (WebException)
            {
                usuario = new Usuario
                {
                    DisplayName = nombreUsuario,
                    JobTitle = String.Empty
                };
            }
        }

        private HttpWebResponse SolicitarJsonUsuarios()
        {
            HttpWebRequest peticionUsuarios = (HttpWebRequest)WebRequest.Create(url);

            peticionUsuarios.Headers.Add(HttpRequestHeader.Authorization,
                $"{ token.TokenType } { token.AccessToken }");

            peticionUsuarios.Method = "GET";

            return peticionUsuarios.GetResponse() as HttpWebResponse;
        }

        private void LeerJsonUsuarios()
        {
            using (Stream responseResult = respuestaUsuario.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseResult, Encoding.UTF8);
                usuarioJson = reader.ReadToEnd();
            }
        }

        private void EstablecerUsuariosDesdeJson()
        {
            if (!string.IsNullOrEmpty(usuarioJson))
            {
                usuario = JsonConvert.DeserializeObject<Usuario>(usuarioJson);
            }
        }

        private void EstablecerTokenDesdeCache()
        {
            token = cache.Get(claveCache) as ResponseOAuth2;
        }

        private void ObtenerToken()
        {
            ResponseOAuth2 result = null;

            //Establecer parametros de la peticion
            string urlGenerarToken =
                $"{ ParametrosGenerales.UrlEndPoint }/{ ParametrosGenerales.TenantId }/oauth2/v2.0/token";
            string datos =
                $"client_id={ ParametrosGenerales.ClientId }" +
                $"&client_secret={ HttpUtility.UrlEncode(ParametrosGenerales.ClientSecret) }" +
                $"&grant_type={ ParametrosGenerales.GrantTypeGraph }" +
                $"&scope={ ParametrosGenerales.Scope }";
            byte[] postData = Encoding.ASCII.GetBytes(datos);
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(urlGenerarToken);
            httpRequest.ContentType = "application/x-www-form-urlencoded";
            httpRequest.Method = "POST";
            httpRequest.ContentLength = postData.Length;
            using (var dataStream = httpRequest.GetRequestStream())
            {
                dataStream.Write(postData, 0, postData.Length);
            }
            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                string responseTemporal = string.Empty;
                using (Stream responseResult = httpResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseResult, Encoding.UTF8);
                    responseTemporal = reader.ReadToEnd();
                }
                if (!string.IsNullOrEmpty(responseTemporal))
                {
                    ResponseOAuth2 objectResponse =
                        JsonConvert.DeserializeObject<ResponseOAuth2>(responseTemporal);
                    if (objectResponse != null
                    && !string.IsNullOrEmpty(objectResponse.AccessToken))
                    {
                        result = objectResponse;
                    }
                }
            }
            else
            {
                throw new ArgumentNullException(string.Format(CultureInfo.CurrentCulture, "Status Code: {0}, Status Description: {1}",
                    httpResponse.StatusCode, httpResponse.StatusDescription));
            }

            token = result;
        }

        private void EstablecerCacheUsuario()
        {
            this.cache.Add(
                url,
                usuario,
                null,
                ParametrosGenerales.FechaCaducidadCacheUsuarios,
                TimeSpan.Zero,
                CacheItemPriority.High,
                null);
        }

        private void EstablecerCacheToken()
        {
            this.cache.Add(
                claveCache,
                token,
                null,
                DateTime.Now.AddSeconds(token.ExpiresIn),
                TimeSpan.Zero,
                CacheItemPriority.High,
                null);
        }
    }
}


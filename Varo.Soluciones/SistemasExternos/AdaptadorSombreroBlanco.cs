
namespace Varo.Soluciones.SistemasExternos
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Text;
    class AdaptadorSombreroBlanco : IAdaptadorSombreroBlanco
    {
        public IList<CalificacionSeguridad> ObtenerCalificacionSeguridad(Guid idSolucion)
        {
            IList<CalificacionSeguridad> result = null;
            string url = $"{ParametrosGenerales.UrlWebApiSombreroBlanco}{idSolucion}";
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Headers.Add("Authorize",
                $"{ ParametrosGenerales.TokenSombreroBlanco }");
            httpRequest.Method = "GET";
            try
            {
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
                        result = JsonConvert.DeserializeObject<List<CalificacionSeguridad>>(responseTemporal);
                    }
                }
                else
                {
                    throw new ArgumentNullException(string.Format(CultureInfo.CurrentCulture, "Status Code: {0}, Status Description: {1}",
                        httpResponse.StatusCode, httpResponse.StatusDescription));
                }

                return result;
            }
            catch (Exception ex)
            {
                return new List<CalificacionSeguridad>();
            }
        }
    }
}


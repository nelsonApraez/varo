namespace Varo.Soluciones.SistemasExternos
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Web.Caching;

    public class AdaptadorInspeccionTecnica : IAdaptadorInspeccionTecnica
    {

        private readonly Cache cache;

        private static string nombreDeLaLlaveDeProyectosEnLaCache = "proyectosInspeccionTecnica";

        public AdaptadorInspeccionTecnica()
        {
            this.cache = new Cache();
        }

        public IList<InspeccionesContinuas> ConsultarProyectos()
        {
            List<InspeccionesContinuas> proyectos =
                this.cache.Get(nombreDeLaLlaveDeProyectosEnLaCache) as List<InspeccionesContinuas>;

            if (proyectos == null)
            {
                HttpWebRequest peticionParaConsultarLosProyectos =
                    WebRequest.Create(ParametrosGenerales.UrlServicioWebConsultarProyectosSonar) as HttpWebRequest;
                peticionParaConsultarLosProyectos.Method = "GET";

                HttpWebResponse respuestaConsultaProyectos =
                    peticionParaConsultarLosProyectos.GetResponse() as HttpWebResponse;

                if (respuestaConsultaProyectos.StatusCode == HttpStatusCode.OK)
                {
                    string responseTemporal = string.Empty;

                    using (Stream responseResult = respuestaConsultaProyectos.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseResult, Encoding.UTF8);
                        responseTemporal = reader.ReadToEnd();
                    }

                    if (!string.IsNullOrEmpty(responseTemporal))
                    {
                        proyectos =
                            JsonConvert.DeserializeObject<List<InspeccionesContinuas>>(responseTemporal);
                    }
                }

                this.cache.Add(
                    nombreDeLaLlaveDeProyectosEnLaCache,
                    proyectos,
                    null,
                    DateTime.Now.AddDays(1),
                    TimeSpan.Zero,
                    CacheItemPriority.High,
                    null);
            }

            return proyectos;
        }

        public ValorMetricaSolucion ConsultarValorMetricaPorSolucion(Guid idSolucion)
        {
            ValorMetricaSolucion valorMetrica = new ValorMetricaSolucion();

            HttpWebRequest peticionParaConsultarValorMetricaPorSolucion =
                WebRequest.Create(ParametrosGenerales.UrlServicioWebConsultarValorMetricasPorSolucionSonar) as HttpWebRequest;
            peticionParaConsultarValorMetricaPorSolucion.Method = "POST";
            peticionParaConsultarValorMetricaPorSolucion.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(peticionParaConsultarValorMetricaPorSolucion.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(idSolucion);

                streamWriter.Write(json);
            }

            HttpWebResponse respuestaConsultaValorMetricaPorSolucion =
                    peticionParaConsultarValorMetricaPorSolucion.GetResponse() as HttpWebResponse;

            if (respuestaConsultaValorMetricaPorSolucion.StatusCode == HttpStatusCode.OK)
            {
                string responseTemporal = string.Empty;

                using (Stream responseResult = respuestaConsultaValorMetricaPorSolucion.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseResult, Encoding.UTF8);
                    responseTemporal = reader.ReadToEnd();
                }

                if (!string.IsNullOrEmpty(responseTemporal))
                {
                    valorMetrica =
                        JsonConvert.DeserializeObject<ValorMetricaSolucion>(responseTemporal);
                }
            }


            return valorMetrica;
        }
    }
}


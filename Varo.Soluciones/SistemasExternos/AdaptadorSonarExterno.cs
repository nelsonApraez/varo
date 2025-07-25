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
    using System.Web.Caching;

    public class AdaptadorSonarExterno : IAdaptadorSonarExterno
    {
        private readonly Cache cache;

        private static string nombreDeLaLlaveDeProyectosEnLaCache = "proyectosSonarExterno";

        public AdaptadorSonarExterno()
        {
            this.cache = new Cache();
        }

        public IList<Proyecto> ConsultarProyectos()
        {
            List<Proyecto> proyectos =
                this.cache.Get(nombreDeLaLlaveDeProyectosEnLaCache) as List<Proyecto>;
            const int idTipoOrigen = 3;

            if (proyectos == null)
            {
                HttpWebRequest peticionParaConsultarLosProyectos =
                    WebRequest.Create(ParametrosGenerales.UrlServicioWebConsultarProyectosSonarPorTipoOrigen) as HttpWebRequest;
                peticionParaConsultarLosProyectos.Method = "POST";
                peticionParaConsultarLosProyectos.ContentType = "application/json";

                using (var streamWriter = new StreamWriter(peticionParaConsultarLosProyectos.GetRequestStream()))
                {
                    streamWriter.Write(idTipoOrigen.ToString(CultureInfo.CurrentCulture));
                }
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
                            JsonConvert.DeserializeObject<List<Proyecto>>(responseTemporal);
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

        public IList<Metrica> ConsultarMetricas()
        {
            IList<Metrica> metrica = new List<Metrica>();
            HttpWebRequest peticionParaConsultarLasMetricas =
                    WebRequest.Create(ParametrosGenerales.UrlServicioWebConsultarMetricaSonar) as HttpWebRequest;
            peticionParaConsultarLasMetricas.Method = "GET";

            HttpWebResponse respuestaConsultaMetrica =
                  peticionParaConsultarLasMetricas.GetResponse() as HttpWebResponse;

            if (respuestaConsultaMetrica.StatusCode == HttpStatusCode.OK)
            {
                string responseTemporal = string.Empty;

                using (Stream responseResult = respuestaConsultaMetrica.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseResult, Encoding.UTF8);
                    responseTemporal = reader.ReadToEnd();
                }

                if (!string.IsNullOrEmpty(responseTemporal))
                {
                    metrica = JsonConvert.DeserializeObject<List<Metrica>>(responseTemporal);
                }
            }

            return metrica;
        }

        public void CrearValorMetrica(ValorMetricaProyecto valorMetricaProyecto)
        {
            HttpWebRequest peticionParaCrearMetricas =
                   WebRequest.Create(ParametrosGenerales.UrlServicioWebCrearValorMetricaSonarExternos) as HttpWebRequest;
            peticionParaCrearMetricas.Method = "POST";
            peticionParaCrearMetricas.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(peticionParaCrearMetricas.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(valorMetricaProyecto);

                streamWriter.Write(json);
            }

            HttpWebResponse respuestaCrearMetricas =
                peticionParaCrearMetricas.GetResponse() as HttpWebResponse;

            this.cache.Remove(nombreDeLaLlaveDeProyectosEnLaCache);

        }

        public void ActualizarProyecto(Proyecto proyecto)
        {
            HttpWebRequest peticionParaActualizarProyecto =
                   WebRequest.Create(ParametrosGenerales.UrlServicioWebActualizarProyectoExterno) as HttpWebRequest;
            peticionParaActualizarProyecto.Method = "POST";
            peticionParaActualizarProyecto.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(peticionParaActualizarProyecto.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(proyecto);

                streamWriter.Write(json);
            }

            HttpWebResponse respuestaActualizarProyecto =
                peticionParaActualizarProyecto.GetResponse() as HttpWebResponse;

            this.cache.Remove(nombreDeLaLlaveDeProyectosEnLaCache);
        }

        public void InactivarProyecto(Proyecto proyecto)
        {
            HttpWebRequest peticionParaActualizarProyecto =
                   WebRequest.Create(ParametrosGenerales.UrlServicioWebInactivarProyectoExterno) as HttpWebRequest;
            peticionParaActualizarProyecto.Method = "POST";
            peticionParaActualizarProyecto.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(peticionParaActualizarProyecto.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(proyecto);

                streamWriter.Write(json);
            }

            HttpWebResponse respuestaActualizarProyecto =
                peticionParaActualizarProyecto.GetResponse() as HttpWebResponse;

            this.cache.Remove(nombreDeLaLlaveDeProyectosEnLaCache);
        }

        public void CrearProyecto(Proyecto proyecto)
        {
            HttpWebRequest peticionParaCrearProyecto =
                   WebRequest.Create(ParametrosGenerales.UrlServicioWebCrearProyectoExterno) as HttpWebRequest;
            peticionParaCrearProyecto.Method = "POST";
            peticionParaCrearProyecto.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(peticionParaCrearProyecto.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(proyecto);

                streamWriter.Write(json);
            }

            HttpWebResponse respuestaActualizarProyecto =
                peticionParaCrearProyecto.GetResponse() as HttpWebResponse;

            this.cache.Remove(nombreDeLaLlaveDeProyectosEnLaCache);
        }

        public IList<ValorMetrica> ConsultarValorMetricas(int idProyecto)
        {
            IList<ValorMetrica> listaValorMetrica = new List<ValorMetrica>();
            HttpWebRequest peticionParaConsultarValorMetricas =
                    WebRequest.Create(ParametrosGenerales.UrlServicioWebConsultarValorMetricaSonarExterno) as HttpWebRequest;
            peticionParaConsultarValorMetricas.Method = "POST";
            peticionParaConsultarValorMetricas.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(peticionParaConsultarValorMetricas.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(idProyecto);

                streamWriter.Write(json);
            }

            HttpWebResponse respuestaConsultaValorMetrica =
                  peticionParaConsultarValorMetricas.GetResponse() as HttpWebResponse;

            if (respuestaConsultaValorMetrica.StatusCode == HttpStatusCode.OK)
            {
                string responseTemporal = string.Empty;

                using (Stream responseResult = respuestaConsultaValorMetrica.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseResult, Encoding.UTF8);
                    responseTemporal = reader.ReadToEnd();
                }

                if (!string.IsNullOrEmpty(responseTemporal))
                {
                    listaValorMetrica = JsonConvert.DeserializeObject<List<ValorMetrica>>(responseTemporal);
                }
            }

            return listaValorMetrica;
        }

        public IList<Proyecto> ConsultarProyectoPorParametro(FiltroProyecto filtroProyecto)
        {
            IList<Proyecto> listaProyecto = new List<Proyecto>();
            HttpWebRequest peticionParaConsultarProyectos =
                    WebRequest.Create(ParametrosGenerales.UrlServicioWebConsultarProyectoExterno) as HttpWebRequest;
            peticionParaConsultarProyectos.Method = "POST";
            peticionParaConsultarProyectos.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(peticionParaConsultarProyectos.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(filtroProyecto);

                streamWriter.Write(json);
            }

            HttpWebResponse respuestaConsultaProyectosPorParametro =
                  peticionParaConsultarProyectos.GetResponse() as HttpWebResponse;

            if (respuestaConsultaProyectosPorParametro.StatusCode == HttpStatusCode.OK)
            {
                string responseTemporal = string.Empty;

                using (Stream responseResult = respuestaConsultaProyectosPorParametro.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseResult, Encoding.UTF8);
                    responseTemporal = reader.ReadToEnd();
                }

                if (!string.IsNullOrEmpty(responseTemporal))
                {
                    listaProyecto = JsonConvert.DeserializeObject<List<Proyecto>>(responseTemporal);
                }
            }

            return listaProyecto;
        }
    }
}


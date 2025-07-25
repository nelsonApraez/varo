namespace Varo.Soluciones.Entidades
{
    using Newtonsoft.Json;
    using System;

    public class CalificacionSeguridad
    {
        [JsonProperty("proyecto_Id")]
        public int IdProyecto { get; set; }

        [JsonProperty("numeroServicio")]
        public string NumeroServicio { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("creado")]
        public DateTime FechaCreacion { get; set; }

        [JsonProperty("finalizado")]
        public DateTime FechaFinalizacion { get; set; }

        [JsonProperty("puntuacion")]
        public decimal Calificacion { get; set; }

    }
}


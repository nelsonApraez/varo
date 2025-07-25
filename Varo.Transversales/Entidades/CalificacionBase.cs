namespace Varo.Transversales.Entidades
{
    using System;

    public abstract class CalificacionBase
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public decimal Calificacion { get; set; }
        public DateTime Fecha { get; set; }
        public string Observacion { get; set; }
    }
}


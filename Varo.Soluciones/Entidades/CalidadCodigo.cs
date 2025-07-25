namespace Varo.Soluciones.Entidades
{
    public class CalidadCodigo
    {
        public int Id { get; set; }
        public int IdMetricaAgil { get; set; }
        public int? Bugs { get; set; }
        public int? Vulnerabilidades { get; set; }
        public decimal? DeudaTecnica { get; set; }
        public decimal? Cobertura { get; set; }
        public decimal? Duplicado { get; set; }
        public string Observaciones { get; set; }
    }
}


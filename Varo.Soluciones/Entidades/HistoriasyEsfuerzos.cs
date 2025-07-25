namespace Varo.Soluciones.Entidades
{
    public class HistoriasyEsfuerzos
    {
        public int Id { get; set; }

        public int IdMetricaAgil { get; set; }

        public int? HistoriasEstimadas { get; set; }

        public int? HistoriasLogradas { get; set; }

        public decimal? EsfuerzoEstimado { get; set; }
        public decimal? EsfuerzoLogrado { get; set; }
        public string Observaciones { get; set; }
    }
}


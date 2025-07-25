namespace Varo.Web.Models
{
    using System;

    public class HistoriasyEsfuerzosViewModel
    {
        public int Id { get; set; }
        public Guid IdSolucion { get; set; }
        public int IdMetricaAgil { get; set; }
        public int? HistoriasEstimadas { get; set; }
        public int? HistoriasLogradas { get; set; }
        public string EsfuerzoEstimado { get; set; }
        public string EsfuerzoLogrado { get; set; }
        public string Observaciones { get; set; }
    }
}

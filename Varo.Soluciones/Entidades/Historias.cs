namespace Varo.Soluciones.Entidades
{
    using System.Collections.Generic;

    public class Historias
    {
        public int Id { get; set; }
        public int IdMetricaAgil { get; set; }
        public string Numero { get; set; }
        public string Nombre { get; set; }
        public decimal EsfuerzoEstimado { get; set; }
        public decimal EsfuerzoReal { get; set; }
        public string Observaciones { get; set; }
        public IList<Historias> ListaHistorias { get; set; }
    }
}


namespace Varo.Soluciones.Entidades
{
    public class Defectos
    {
        public int Id { get; set; }

        public int IdMetricaAgil { get; set; }

        public int? Reportados { get; set; }

        public int? Cerrados { get; set; }

        public int? Actuales { get; set; }
        public int? Abiertos { get; set; }
        public string Observaciones { get; set; }
    }
}


using Varo.Soluciones.Entidades;

namespace Varo.Api.Models
{
    public class SolucionAgregado
    {
        public Solucion Solucion { get; set; }
        public TecnologiaSolucion tecnologia { get; set; }
        public DesplieguesContinuos despliegueContinuo { get; set; }
        public MonitoreosContinuos monitoreoContinuo { get; set; }
        public IntegracionesContinuas integracionContinua { get; set; }
        public PracticasCalidad practicasCalidad { get; set; }
    }
}

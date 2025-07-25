namespace Varo.Web.Models
{
    using Varo.Soluciones.Entidades;

    public class HistoriasViewModel
    {
        public HistoriasViewModel()
        {
            this.historias = new Historias();
        }
        public Historias historias { get; set; }
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Nombre { get; set; }
        public decimal? EsfuerzoEstimado { get; set; }
        public decimal? EsfuerzoReal { get; set; }
        public string Observaciones { get; set; }
    }
}

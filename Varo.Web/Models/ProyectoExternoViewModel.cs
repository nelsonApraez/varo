
namespace Varo.Web.Models
{
    using Varo.Soluciones.Entidades;

    public class ProyectoExternoViewModel
    {
        public ProyectoExternoViewModel()
        {
            this.Proyecto = new Proyecto();
        }
        public int Id { get; set; }

        public int IdTipoOrigen { get; set; }

        public string IdOrigen { get; set; }

        public string Nombre { get; set; }

        public bool Activo { get; set; }
        public Proyecto Proyecto { get; set; }
    }
}


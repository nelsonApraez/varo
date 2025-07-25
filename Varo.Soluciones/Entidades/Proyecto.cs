
namespace Varo.Soluciones.Entidades
{
    using System.Collections.Generic;
    public class Proyecto
    {
        public int Id { get; set; }

        public int IdTipoOrigen { get; set; }

        public string IdOrigen { get; set; }

        public string Nombre { get; set; }

        public bool Activo { get; set; }

        public IList<Proyecto> ListaProyectos { get; set; }

        public int ConteoTotalFilas { get; set; }
    }
}


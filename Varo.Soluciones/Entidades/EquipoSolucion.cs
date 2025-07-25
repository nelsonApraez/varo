
namespace Varo.Soluciones.Entidades
{
    using System;
    using System.Collections.Generic;

    public class EquipoSolucion
    {
        public Guid Id { get; set; }

        public Guid IdSolucion { get; set; }

        public string Nombre { get; set; }

        public IList<EquipoSolucion> ListaEquipoSolucion { get; set; }
    }
}


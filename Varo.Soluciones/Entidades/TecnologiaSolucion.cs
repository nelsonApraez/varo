namespace Varo.Soluciones.Entidades
{
    using Varo.Transversales.Entidades;
    using System;
    using System.Collections.Generic;

    public class TecnologiaSolucion
    {
        public TecnologiaSolucion()
        {
            this.TipoTecnologia = new ItemMaestro();
        }

        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public string Logo { get; set; }

        public Guid IdSolucion { get; set; }

        public ItemMaestro TipoTecnologia { get; set; }

        public IList<TecnologiaSolucion> Tecnologias { get; set; }
    }
}


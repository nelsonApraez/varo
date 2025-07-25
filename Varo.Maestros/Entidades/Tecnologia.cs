namespace Varo.Maestros.Entidades
{
    using Varo.Transversales.Entidades;
    using System;
    using System.Collections.Generic;

    public class Tecnologia
    {
        public Tecnologia()
        {
            this.TipoTecnologia = new ItemMaestro();
        }

        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public string Logo { get; set; }

        public ItemMaestro TipoTecnologia { get; set; }

        public IList<Tecnologia> Tecnologias { get; set; }
    }
}


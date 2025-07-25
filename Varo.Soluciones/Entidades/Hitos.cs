namespace Varo.Soluciones.Entidades
{
    using Varo.Transversales.Entidades;
    using System;
    using System.Collections.Generic;

    public class Hito
    {
        public Hito()
        {
            this.Tipo = new ItemMaestro();
            this.Estado = new ItemMaestro();
        }

        public Guid Id { get; set; }
        public Guid IdSolucion { get; set; }
        public ItemMaestro Tipo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCierre { get; set; }
        public ItemMaestro Estado { get; set; }
        public string Observaciones { get; set; }

        public IList<Hito> ListaHitos { get; set; }
    }
}


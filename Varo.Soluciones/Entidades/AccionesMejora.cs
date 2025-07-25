namespace Varo.Soluciones.Entidades
{
    using Varo.Transversales.Entidades;
    using System;
    using System.Collections.Generic;

    public class AccionesMejora
    {
        public AccionesMejora()
        {
            this.Responsable = new ItemMaestro();
            this.Estado = new ItemMaestro();
            this.ListaAccionesMejora = new List<AccionesMejora>();
        }
        public int Id { get; set; }
        public Guid IdSolucion { get; set; }
        public int IdMetricaAgil { get; set; }
        public string Sprint { get; set; }

        public string Accion { get; set; }

        public string Causa { get; set; }

        public ItemMaestro Responsable { get; set; }

        public ItemMaestro Estado { get; set; }
        public IList<AccionesMejora> ListaAccionesMejora { get; set; }
    }
}


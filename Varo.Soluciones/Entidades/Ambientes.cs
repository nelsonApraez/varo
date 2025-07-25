namespace Varo.Soluciones.Entidades
{
    using Varo.Transversales.Entidades;
    using System;
    using System.Collections.Generic;
    public class Ambientes
    {
        public Ambientes()
        {
            this.TipoAmbiente = new ItemMaestro();
            this.ListaAmbientes = new List<Ambientes>();
        }
        public Guid Id { get; set; }
        public Guid IdSolucion { get; set; }
        public ItemMaestro TipoAmbiente { get; set; }
        public string Ubicacion { get; set; }
        public string Responsable { get; set; }
        public IList<Ambientes> ListaAmbientes { get; set; }
    }
}


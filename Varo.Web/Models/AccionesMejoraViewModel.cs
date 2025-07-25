namespace Varo.Web.Models
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Entidades;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class AccionesMejoraViewModel
    {
        public AccionesMejoraViewModel()
        {
            this.Responsable = new ItemMaestro();
            this.Estado = new ItemMaestro();
            this.AccionesMejora = new AccionesMejora();
        }
        public int Id { get; set; }
        public Guid IdSolucion { get; set; }
        public string Sprint { get; set; }
        public string Accion { get; set; }
        public string Causa { get; set; }
        public ItemMaestro Responsable { get; set; }
        public IEnumerable<SelectListItem> ListaResponsablesAccionesMejora { get; set; }
        public ItemMaestro Estado { get; set; }
        public IEnumerable<SelectListItem> ListaEstadosAccionesMejora { get; set; }
        public AccionesMejora AccionesMejora { get; set; }
    }
}

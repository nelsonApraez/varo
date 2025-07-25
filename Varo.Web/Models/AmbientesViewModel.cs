namespace Varo.Web.Models
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Entidades;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class AmbientesViewModel
    {
        public AmbientesViewModel()
        {
            this.TipoAmbiente = new ItemMaestro();
        }
        public int Id { get; set; }
        public Guid IdSolucion { get; set; }
        public ItemMaestro TipoAmbiente { get; set; }
        public IEnumerable<SelectListItem> ListaTipoAmbiente { get; set; }
        public string Ubicacion { get; set; }
        public string Responsable { get; set; }
        public Ambientes Ambientes { get; set; }
    }
}

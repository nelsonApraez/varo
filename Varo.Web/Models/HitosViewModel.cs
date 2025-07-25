namespace Varo.Web.Models
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Entidades;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class HitosViewModel
    {
        public HitosViewModel()
        {
            this.Tipo = new ItemMaestro();
            this.Estado = new ItemMaestro();
        }

        public Guid Id { get; set; }
        public Guid IdSolucion { get; set; }
        public ItemMaestro Tipo { get; set; }
        public IEnumerable<SelectListItem> ListaTipo { get; set; }
        public string Descripcion { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaCierre { get; set; }
        public string Observaciones { get; set; }
        public ItemMaestro Estado { get; set; }
        public IEnumerable<SelectListItem> ListaEstados { get; set; }
        public string UsuarioRedGerente { get; set; }
        public string UsuarioRedResponsable { get; set; }
        public string UsuarioRedScrumMaster { get; set; }
        public string EmailArquitecto { get; set; }
        public Hito Hito { get; set; }
    }
}


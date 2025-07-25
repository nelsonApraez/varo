namespace Varo.Web.Models
{
    using Varo.Maestros.Entidades;
    using Varo.Transversales.Entidades;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class TecnologiasViewModel
    {
        public TecnologiasViewModel()
        {
            TipoTecnologia = new ItemMaestro();
            Tecnologia = new Tecnologia();
        }

        public IEnumerable<SelectListItem> ListaTiposDeTecnologia { get; set; }

        public IEnumerable<SelectListItem> ListaTecnologias { get; set; }

        public ItemMaestro TipoTecnologia { get; set; }

        public Tecnologia Tecnologia { get; set; }

        public IList<TecnologiasViewModel> ListaTecnologiasViewModel { get; set; }
    }
}

namespace Varo.Web.Helpers
{
    using Varo.Maestros.Entidades;
    using Varo.Transversales.Entidades;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web.Mvc;

    public static class HelperSelectListItem
    {
        public static IList<SelectListItem> ToSelectListItem(
            this IEnumerable<ItemMaestro> informacionMaestro)
        {
            return informacionMaestro.Select(
                        m => new SelectListItem
                        {
                            Value = m.Id.ToString(CultureInfo.CurrentCulture),
                            Text = m.Nombre
                        }).ToList();
        }

        public static IList<SelectListItem> ToRequiredSelectListItem(
            this IEnumerable<ItemMaestro> informacionMaestro)
        {
            IList<SelectListItem> informacionMaestroSelectListItem =
                informacionMaestro.Select(
                        m => new SelectListItem
                        {
                            Value = m.Id.ToString(CultureInfo.CurrentCulture),
                            Text = m.Nombre
                        }).ToList();

            SelectListItem itemVacio = new SelectListItem();
            itemVacio.Value = string.Empty;
            itemVacio.Text = string.Empty;

            informacionMaestroSelectListItem.Insert(0, itemVacio);

            return informacionMaestroSelectListItem;
        }

        public static IList<SelectListItem> ToRequiredSelectListItemPais(
            this IEnumerable<Pais> informacionMaestro)
        {
            IList<SelectListItem> informacionMaestroSelectListItem =
                informacionMaestro.Select(
                        m => new SelectListItem
                        {
                            Value = m.Id.ToString(CultureInfo.CurrentCulture),
                            Text = m.Name
                        }).ToList();

            SelectListItem itemVacio = new SelectListItem();
            itemVacio.Value = string.Empty;
            itemVacio.Text = string.Empty;

            informacionMaestroSelectListItem.Insert(0, itemVacio);

            return informacionMaestroSelectListItem;
        }

        public static IList<SelectListItem> ToRequiredSelectListItemEstadosDesempeno(
            this IEnumerable<ItemMaestro> informacionMaestro)
        {
            IList<SelectListItem> informacionMaestroSelectListItem =
                informacionMaestro.Select(
                        m => new SelectListItem
                        {
                            Value = m.Id.ToString(CultureInfo.CurrentCulture),
                            Text = m.Nombre
                        }).ToList();

            return informacionMaestroSelectListItem;
        }
    }
}


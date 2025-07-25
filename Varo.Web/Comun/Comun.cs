namespace Varo.Web.Comun
{
    using Varo.Maestros.Entidades;
    using Varo.Soluciones.Entidades;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web.Mvc;

    public static class Comun
    {
        public static IList<SelectListItem> ConvertirListaCiudadEnSelectListItem(IEnumerable<Ciudad> listaCiudad)
        {
            IList<SelectListItem> selectListItem =

            listaCiudad.ToList().ConvertAll(Ciudad =>
            {
                return new SelectListItem
                {
                    Text = Ciudad.Name,
                    Value = Ciudad.Id.ToString(CultureInfo.CurrentCulture)
                };
            });

            SelectListItem itemVacio = new SelectListItem();
            itemVacio.Value = string.Empty;
            itemVacio.Text = string.Empty;

            selectListItem.Insert(0, itemVacio);

            return selectListItem;
        }

        public static IList<SelectListItem> ConvertirListaClienteEnSelectListItem(IEnumerable<Cliente> listaCliente)
        {
            IList<SelectListItem> selectListItem =

            listaCliente.ToList().ConvertAll(Cliente =>
            {
                return new SelectListItem
                {
                    Text = Cliente.Name,
                    Value = Cliente.Id.ToString(CultureInfo.CurrentCulture)
                };
            });

            SelectListItem itemVacio = new SelectListItem();
            itemVacio.Value = string.Empty;
            itemVacio.Text = string.Empty;

            selectListItem.Insert(0, itemVacio);

            return selectListItem;
        }

        public static IList<SelectListItem> ConvertirListaDepartamentoEnSelectListItem(IEnumerable<Departamento> listaDepartamento)
        {
            IList<SelectListItem> selectListItem =

            listaDepartamento.ToList().ConvertAll(Departamento =>
            {
                return new SelectListItem
                {
                    Text = Departamento.Name,
                    Value = Departamento.Id.ToString(CultureInfo.CurrentCulture)
                };
            });

            SelectListItem itemVacio = new SelectListItem();
            itemVacio.Value = string.Empty;
            itemVacio.Text = string.Empty;

            selectListItem.Insert(0, itemVacio);

            return selectListItem;
        }

        public static IList<SelectListItem> ConvertirListaTecnologiaEnSelectListItem(IEnumerable<Tecnologia> listaTecnologia)
        {
            return listaTecnologia.ToList().ConvertAll(Tecnologia =>
            {
                return new SelectListItem
                {
                    Text = Tecnologia.Nombre,
                    Value = Tecnologia.Id.ToString()
                };
            });
        }

        public static IList<SelectListItem> ConvertirListaSolucionEnSelectListItem(IEnumerable<Solucion> listaSoluciones)
        {
            IList<SelectListItem> selectListItem = listaSoluciones.ToList().ConvertAll(Soluciones =>
            {
                return new SelectListItem
                {
                    Text = Soluciones.Nombre,
                    Value = Soluciones.Id.ToString()
                };
            });

            SelectListItem itemVacio = new SelectListItem();
            itemVacio.Value = string.Empty;
            itemVacio.Text = string.Empty;

            selectListItem.Insert(0, itemVacio);

            return selectListItem;
        }
    }
}


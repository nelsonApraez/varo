namespace Varo.Maestros.Negocio
{
    using Varo.Maestros.Entidades;
    using Varo.Maestros.SistemasExternos;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class NegocioClientes : INegocioClientes
    {
        private readonly IAdaptadorClientes adaptadorClientes;

        public NegocioClientes() :
           this(new AdaptadorClientes())
        { }

        public NegocioClientes(IAdaptadorClientes adaptadorClientes)
        {
            this.adaptadorClientes = adaptadorClientes;
        }

        public IList<Cliente> ConsultarClientes()
        {
            return this.adaptadorClientes.ConsultarClientes();
        }

        public Cliente ObtenerClientePorId(int idCliente)
        {
            IList<Cliente> listaClientes = this.adaptadorClientes.ConsultarClientes();

            return listaClientes.SingleOrDefault(Cliente => Cliente.Id == idCliente);
        }

        public IList<string> ObtenerIdClientePorNombre(string nombreCliente)
        {
            IList<Cliente> listaClientes = this.adaptadorClientes.ConsultarClientes();
            IEnumerable<Cliente> cliente =
                listaClientes.Where(x => x.Name.ToUpperInvariant().Contains(nombreCliente.ToUpperInvariant()));

            IList<string> listaIdClientes = new List<string>();

            foreach (var item in cliente)
            {
                listaIdClientes.Add(item.Id.ToString(CultureInfo.CurrentCulture));
            }

            return listaIdClientes;
        }
    }
}


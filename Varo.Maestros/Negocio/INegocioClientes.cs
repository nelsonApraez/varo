namespace Varo.Maestros.Negocio
{
    using Varo.Maestros.Entidades;
    using System.Collections.Generic;

    public interface INegocioClientes
    {
        IList<Cliente> ConsultarClientes();

        Cliente ObtenerClientePorId(int idCliente);

        IList<string> ObtenerIdClientePorNombre(string nombreCliente);

    }
}


namespace Varo.Maestros.SistemasExternos
{
    using Varo.Maestros.Entidades;
    using System.Collections.Generic;

    public interface IAdaptadorClientes
    {
        IList<Cliente> ConsultarClientes();
    }
}



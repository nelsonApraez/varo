namespace Varo.Maestros.Repositorio
{
    using Varo.Maestros.Entidades;
    using System.Collections.Generic;

    public interface IRepositorioTecnologia
    {
        IList<Tecnologia> ConsultarPorTipoDeTecnologia(byte tipoDeTecnologia);
    }
}


namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using System;
    using System.Collections.Generic;

    public interface IRepositorioTecnologiaSolucion
    {
        void Crear(TecnologiaSolucion tecnologia);

        void EliminarPorIdSolucion(Guid idSolucion);

        IList<TecnologiaSolucion> ConsultarPorIdSolucion(Guid idSolucion, string lenguaje);
    }
}


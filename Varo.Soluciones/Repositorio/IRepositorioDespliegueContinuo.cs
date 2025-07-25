namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using System;
    using System.Collections.Generic;

    public interface IRepositorioDespliegueContinuo
    {
        void Crear(DesplieguesContinuos despliegueContinuo);

        void EliminarPorIdSolucion(Guid idSolucion);

        IList<DesplieguesContinuos> ConsultarPorIdSolucion(Guid idSolucion);
    }
}


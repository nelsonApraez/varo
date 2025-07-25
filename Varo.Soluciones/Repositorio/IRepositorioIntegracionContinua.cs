namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using System;
    using System.Collections.Generic;

    public interface IRepositorioIntegracionContinua
    {
        void Crear(IntegracionesContinuas integracionContinua);

        void EliminarPorIdSolucion(Guid idSolucion);

        IList<IntegracionesContinuas> ConsultarPorIdSolucion(Guid idSolucion);
    }
}


namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using System;
    using System.Collections.Generic;

    public interface IRepositorioAmbientes
    {
        IList<Ambientes> Consultar(Guid idSolucion, string lenguaje);

        void Crear(Ambientes ambientes);

        void Eliminar(Guid idSolucion);
    }
}


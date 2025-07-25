namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using System;
    using System.Collections.Generic;

    public interface IRepositorioHito
    {
        IList<Hito> Obtener(Guid idSolucion, string lenguaje);

        void Crear(Hito hito);

        void Eliminar(Guid idSolucion);
    }
}


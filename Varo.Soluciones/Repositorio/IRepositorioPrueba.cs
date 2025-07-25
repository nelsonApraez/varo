namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using System;
    using System.Collections.Generic;

    public interface IRepositorioPrueba
    {
        IList<Prueba> Consultar();

        Prueba ConsultarPorIdSolucion(Guid idSolucion);

        Prueba Obtener(Guid id);

        void Crear(Prueba prueba);

        void Editar(Prueba prueba);

        void Eliminar(Guid id);
    }
}


namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using System.Collections.Generic;

    public interface IRepositorioSeguimiento
    {
        IList<Seguimiento> Consultar(int idAccionesMejora);

        void Crear(Seguimiento seguimiento);

        void Eliminar(int idAccionesMejora);
    }
}


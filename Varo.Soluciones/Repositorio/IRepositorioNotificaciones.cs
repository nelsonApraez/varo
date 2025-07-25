
namespace Varo.Soluciones.Repositorio
{
    using Varo.Soluciones.Entidades;
    using System.Collections.Generic;

    public interface IRepositorioNotificaciones
    {
        IList<Notificaciones> Consultar(string lenguaje);

        string ConsultarPorId(int id);

        void Editar(Notificaciones correoNotificaciones);
    }
}


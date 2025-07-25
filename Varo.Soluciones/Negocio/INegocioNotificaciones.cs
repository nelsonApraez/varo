
namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Transversales.Negocio;
    using System.Collections.Generic;

    public interface INegocioNotificaciones : INegocioBase
    {
        IList<Notificaciones> Consultar(string lenguaje);

        string ConsultarPorId(int idTipoNotificacion);

        void Editar(Notificaciones correoNotificaciones);
    }
}


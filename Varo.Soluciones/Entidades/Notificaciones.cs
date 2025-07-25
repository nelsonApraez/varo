
namespace Varo.Soluciones.Entidades
{
    using System.Collections.Generic;

    public class Notificaciones
    {
        public int Id { get; set; }

        public string Valor { get; set; }

        public string Nombre { get; set; }

        public IList<Notificaciones> ListaNotificaciones { get; set; }

    }
}


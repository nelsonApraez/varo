namespace Varo.Web.Models
{
    using Varo.Soluciones.Entidades;
    using System.Collections.Generic;

    public class CorreoNotificacionesViewModel
    {
        public int Id { get; set; }
        public string Valor { get; set; }

        public IList<Notificaciones> ListaCorreosNotificaciones { get; set; }
    }
}


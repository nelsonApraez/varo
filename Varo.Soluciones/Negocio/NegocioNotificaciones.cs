
namespace Varo.Soluciones.Negocio
{
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales.Negocio;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Collections.Generic;
    using System.Web.Caching;

    public class NegocioNotificaciones : NegocioBase, INegocioNotificaciones
    {
        private readonly IRepositorioNotificaciones repositorioCorreoNotificaciones;
        private readonly Cache cache;

        private static string nombreDeLaLlaveDeNotificacionesEnLaCache = "CorreoNotificaciones";
        public NegocioNotificaciones() :
            this(new RepositorioBase(), new RepositorioNotificaciones())
        { }

        public NegocioNotificaciones(IRepositorioBase repositorioBase
            , IRepositorioNotificaciones repositorioCorreoNotificaciones) : base(repositorioBase)
        {
            this.repositorioCorreoNotificaciones = repositorioCorreoNotificaciones;
            this.cache = new Cache();
        }

        public IList<Notificaciones> Consultar(string lenguaje)
        {
            return this.repositorioCorreoNotificaciones.Consultar(lenguaje);
        }

        public string ConsultarPorId(int id)
        {
            string listaCorreosNotificaciones =
                this.cache.Get(nombreDeLaLlaveDeNotificacionesEnLaCache) as string;


            if (listaCorreosNotificaciones == null)
            {
                listaCorreosNotificaciones = this.repositorioCorreoNotificaciones.ConsultarPorId(id);

                this.cache.Add(
                    nombreDeLaLlaveDeNotificacionesEnLaCache,
                    listaCorreosNotificaciones,
                    null,
                    DateTime.Now.AddHours(12),
                    TimeSpan.Zero,
                    CacheItemPriority.High,
                    null);
            }

            return listaCorreosNotificaciones;
        }

        public void Editar(Notificaciones correoNotificaciones)
        {
            this.repositorioCorreoNotificaciones.Editar(correoNotificaciones);
        }

    }
}


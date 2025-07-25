namespace Varo.Soluciones.Negocio
{
    using Varo.Maestros.Negocio;
    using Varo.Soluciones.Entidades;
    using Varo.Soluciones.Repositorio;
    using Varo.Transversales;
    using Varo.Transversales.Constantes;
    using Varo.Transversales.Negocio;
    using Varo.Transversales.Repositorio;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Mail;
    using System.Text;
    using System.Transactions;

    public class NegocioHito : NegocioBase, INegocioHito
    {
        private readonly IRepositorioHito repositorioHito;
        private readonly INegocioUsuarios negocioUsuarios;
        private readonly INegocioEmail365 negocioEmail365;

        public NegocioHito() : this(new RepositorioBase(),
            new RepositorioHito(),
            new NegocioUsuarios(),
            new NegocioEmail365())
        { }

        public NegocioHito(IRepositorioBase repositorioBase,
                                IRepositorioHito repositorioHito,
                                INegocioUsuarios negocioUsuarios,
                                INegocioEmail365 negocioEmail365) : base(repositorioBase)
        {
            this.repositorioHito = repositorioHito;
            this.negocioUsuarios = negocioUsuarios;
            this.negocioEmail365 = negocioEmail365;
        }

        public void Crear(Hito hito)
        {
            if (hito != null)
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    hito.ListaHitos.ToList().ForEach(h => h.IdSolucion = hito.IdSolucion);

                    this.repositorioHito.Eliminar(hito.IdSolucion);
                    this.repositorioHito.Crear(hito);

                    transactionScope.Complete();
                }
            }
        }

        public IList<Hito> Obtener(Guid idSolucion, string lenguaje)
        {
            IList<Hito> listaHitos = repositorioHito.Obtener(idSolucion, lenguaje);
            return listaHitos;
        }

        public void EnviarCorreo(Solucion solucion, string emailArquitecto, string emailAdicionales, string lenguaje)
        {
            int contadorHitosAbiertos = (int)default;

            string subject = string.Format(Recursos.Lenguaje.SubjectNotificacionHito,
                solucion.Cliente.Name.Trim(),
                solucion.Nombre.Trim());

            StringBuilder htmlContext = new StringBuilder(string.Format(
                Recursos.Lenguaje.NotificacionHitosInicio,
                solucion.Nombre, Recursos.Lenguaje.Tipo,
                Recursos.Lenguaje.Descripcion,
                Recursos.Lenguaje.FechaDeCierre,
                Recursos.Lenguaje.Estado,
                Recursos.Lenguaje.Observaciones
            ));

            IList<Hito> ListaHitos = this.Obtener(solucion.Id, lenguaje);

            foreach (var item in ListaHitos)
            {
                if (item.Estado.Id == 1)
                {
                    contadorHitosAbiertos++;
                    htmlContext.Append(string.Format(
                        Recursos.Lenguaje.ContenidoHitos,
                        item.Tipo.Nombre,
                        item.Descripcion,
                        item.FechaCierre,
                        item.Estado.Nombre,
                        item.Observaciones
                    ));
                }
            }

            htmlContext.Append(Recursos.Lenguaje.NotificacionHitosFin);
            htmlContext.Append(Recursos.Lenguaje.NotificacionCierre);

            List<MailAddress> ListaTo365 = new List<MailAddress>
                {
                    new MailAddress(
                        this.negocioUsuarios.ObtenerInformacionUsuario(solucion.UsuarioRedGerente).Mail,
                        this.negocioUsuarios.ObtenerInformacionUsuario(solucion.UsuarioRedGerente).DisplayName),
                    new MailAddress(
                        this.negocioUsuarios.ObtenerInformacionUsuario(solucion.UsuarioRedResponsable).Mail,
                        this.negocioUsuarios.ObtenerInformacionUsuario(solucion.UsuarioRedResponsable).DisplayName)
                };

            if (!string.IsNullOrEmpty(solucion.UsuarioRedScrumMaster))
            {
                ListaTo365.Add(
                      new MailAddress(
                          this.negocioUsuarios.ObtenerInformacionUsuario(solucion.UsuarioRedScrumMaster).Mail,
                          this.negocioUsuarios.ObtenerInformacionUsuario(solucion.UsuarioRedScrumMaster).DisplayName));
            }


            if (!string.IsNullOrEmpty(emailArquitecto))
            {
                ListaTo365.Add(
                    new MailAddress(emailArquitecto, this.negocioUsuarios.ObtenerInformacionUsuario(ObtenerUsuario(emailArquitecto)).DisplayName ?? TransversalesConstantes.CadenaVacia));
            }

            if (!string.IsNullOrEmpty(emailAdicionales))
            {
                string[] ListaAdicionales = emailAdicionales.Split(TransversalesConstantes.SeparadorComa);

                for (int i = 0; i < ListaAdicionales.Length; i++)
                {
                    ListaTo365.Add(new MailAddress(ListaAdicionales[i],
                    this.negocioUsuarios.ObtenerInformacionUsuario(ObtenerUsuario(ListaAdicionales[i])).DisplayName ?? TransversalesConstantes.CadenaVacia));
                }
            }

            if (contadorHitosAbiertos >= 1)
            {
                this.negocioEmail365.EnviarCorreo(subject, htmlContext.ToString(), ListaTo365);
            }
        }

        private string ObtenerUsuario(string email)
        {
            return email.Substring(0, email.Length - ParametrosGenerales.Dominio.Length);
        }
    }
}


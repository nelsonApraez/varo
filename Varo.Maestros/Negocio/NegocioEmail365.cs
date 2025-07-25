namespace Varo.Maestros.Negocio
{
    using Varo.Maestros.SistemasExternos;
    using System;
    using System.Collections.Generic;
    using System.Net.Mail;

    public class NegocioEmail365 : INegocioEmail365
    {
        private readonly IAdaptadorEmail365 adaptadorEmail365;

        public NegocioEmail365() :
            this(new AdaptadorEmail365())
        { }

        public NegocioEmail365(IAdaptadorEmail365 adaptadorEmail365)
        {
            this.adaptadorEmail365 = adaptadorEmail365;
        }

        public void EnviarCorreo(string subject, string htmlContent, List<MailAddress> to)
        {
            if (subject == "")
            {
                throw new ArgumentNullException("subject");
            }

            if (htmlContent == "")
            {
                throw new ArgumentNullException("htmlContent");
            }

            if (to.Count == 0)
            {
                throw new ArgumentNullException("to");
            }

            adaptadorEmail365.EnviarCorreo(subject, htmlContent, to);
        }
    }
}


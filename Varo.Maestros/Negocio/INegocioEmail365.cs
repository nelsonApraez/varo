namespace Varo.Maestros.Negocio
{
    using System.Collections.Generic;
    using System.Net.Mail;

    public interface INegocioEmail365
    {
        void EnviarCorreo(string subject, string htmlContent, List<MailAddress> to);
    }
}


namespace Varo.Maestros.SistemasExternos
{
    using System.Collections.Generic;
    using System.Net.Mail;

    public interface IAdaptadorEmail365
    {
        void EnviarCorreo(string subject, string htmlContent, List<MailAddress> to);
    }
}


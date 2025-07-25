namespace Varo.Maestros.SistemasExternos
{
    using Varo.Transversales;
    using Varo.Transversales.Constantes;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Net;
    using System.Net.Mail;

    class AdaptadorEmail365 : IAdaptadorEmail365
    {
        public void EnviarCorreo(string subject, string htmlContent, List<MailAddress> to)
        {
            using (SmtpClient client = new SmtpClient
            {
                Host = ParametrosGenerales.Host365,
                Port = Convert.ToInt32(ParametrosGenerales.Port365, CultureInfo.CurrentCulture),
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(ParametrosGenerales.EmailSender, ParametrosGenerales.PasswordApp365),
                TargetName = ParametrosGenerales.TargetName365,
                EnableSsl = true
            })

            {
                MailMessage message = new MailMessage
                {
                    From = new MailAddress(ParametrosGenerales.EmailSender, TransversalesConstantes.Varo),
                    Subject = subject,
                    IsBodyHtml = true,
                    Body = htmlContent,
                    BodyEncoding = System.Text.Encoding.UTF8,
                    SubjectEncoding = System.Text.Encoding.UTF8,

                };

                foreach (var toAddress in to)
                {
                    message.To.Add(toAddress);
                }

                try
                {
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }
    }
}


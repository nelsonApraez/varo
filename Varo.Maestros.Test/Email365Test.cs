namespace Varo.Maestros.Test
{
    using Varo.Maestros.Negocio;
    using Varo.Maestros.SistemasExternos;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Net.Mail;

    /// <summary>
    /// Summary description for SolucionesConsultarClientesPorIdPaisTest
    /// </summary>
    [TestClass]
    public class Email365Test
    {
        private Mock<IAdaptadorEmail365> adaptadorEmail365 = null;
        private INegocioEmail365 negocioEmail365 = null;

        [TestInitialize]
        public void InicializarPruebasUnitarias()
        {
            this.adaptadorEmail365 = new Mock<IAdaptadorEmail365>();

            this.negocioEmail365 =
                new NegocioEmail365(this.adaptadorEmail365.Object);
        }

        [TestMethod]
        public void EnviarCorreoTest()
        {
            string subject = "test";
            string content = "<html></html>";
            List<MailAddress> to = new List<MailAddress>()
            {
                new MailAddress("test@company.com")
            };

            this.adaptadorEmail365.Setup(
                it => it.EnviarCorreo(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<MailAddress>>()));

            this.negocioEmail365.EnviarCorreo(subject, content, to);

            Assert.IsTrue(true);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EnviarCorreoSinTituloTest()
        {
            string subject = "";
            string content = "<html></html>";
            List<MailAddress> to = new List<MailAddress>()
            {
                new MailAddress("test@company.com")
            };

            this.adaptadorEmail365.Setup(
                it => it.EnviarCorreo(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<MailAddress>>()));

            this.negocioEmail365.EnviarCorreo(subject, content, to);

            Assert.IsTrue(true);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EnviarCorreoSinContenidoTest()
        {
            string subject = "test";
            string content = "";
            List<MailAddress> to = new List<MailAddress>()
            {
                new MailAddress("test@company.com")
            };

            this.adaptadorEmail365.Setup(
                it => it.EnviarCorreo(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<MailAddress>>()));

            this.negocioEmail365.EnviarCorreo(subject, content, to);

            Assert.IsTrue(true);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EnviarCorreoSinDestinatarioTest()
        {
            string subject = "test";
            string content = "<html></html>";
            List<MailAddress> to = new List<MailAddress>();

            this.adaptadorEmail365.Setup(
                it => it.EnviarCorreo(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<MailAddress>>()));

            this.negocioEmail365.EnviarCorreo(subject, content, to);

            Assert.IsTrue(true);
        }
    }
}


namespace Varo.Soluciones.Entidades
{
    using Varo.Maestros.Entidades;
    using Varo.Transversales.Entidades;
    using System;

    public class SolucionInformacionBasica
    {
        public SolucionInformacionBasica()
        {
            this.Cliente = new Cliente();
            this.Tipo = new ItemMaestro();
            this.LineaSolucion = new ItemMaestro();
            this.Estado = new ItemMaestro();
            this.Oficina = new ItemMaestro();
        }

        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public Cliente Cliente { get; set; }

        public string UsuarioRedGerente { get; set; }

        public string NombreGerente { get; set; }

        public string UsuarioRedResponsable { get; set; }

        public string NombreResponsable { get; set; }

        public string UsuarioRedScrumMaster { get; set; }

        public string NombreScrumMaster { get; set; }

        public string UrlRepositorioCodigoFuente { get; set; }

        public string UrlDocumentacion { get; set; }

        public string UrlInspeccion { get; set; }

        public string UrlLeccionesAprendidas { get; set; }

        public string UrlGestionAseguramientoCalidad { get; set; }

        public ItemMaestro Tipo { get; set; }

        public ItemMaestro LineaSolucion { get; set; }

        public ItemMaestro Estado { get; set; }

        public ItemMaestro Oficina { get; set; }

        public int ConteoTotalFilas { get; set; }
    }
}


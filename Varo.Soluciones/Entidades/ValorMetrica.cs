
namespace Varo.Soluciones.Entidades
{
    public class ValorMetrica
    {
        public Proyecto Proyecto { get; set; }

        public Metrica Metrica { get; set; }

        public string IdSnapshot { get; set; }

        public int Ano { get; set; }

        public int Mes { get; set; }

        public decimal Valor { get; set; }

    }
}


using System.Collections.Generic;

namespace GeradorTxt
{
    public class ItemDocumento
    {
        public int NumeroItem { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public List<Categoria> Categorias { get; set; }
    }
}

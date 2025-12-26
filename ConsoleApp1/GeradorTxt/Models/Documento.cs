using System.Collections.Generic;

namespace GeradorTxt
{
    public class Documento
    {
        public string Modelo { get; set; }
        public string Numero { get; set; }
        public decimal Valor { get; set; }
        public List<ItemDocumento> Itens { get; set; }
    }
}

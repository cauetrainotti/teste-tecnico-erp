using System.Text;

namespace GeradorTxt
{
    public class GeradorArquivoLeiaute02 : GeradorArquivoBase
    {
        protected override void EscreverTipo02(StringBuilder sb, ItemDocumento item)
        {
            // 01|MODELODOCUMENTO|NUMERODOCUMENTO|VALORDOCUMENTO
            sb.Append("02").Append("|")
              .Append(item.NumeroItem).Append("|")
              .Append(item.Descricao).Append("|")
              .Append(ToMoney(item.Valor)).AppendLine();

            RegistrarLinha("02");
        }
        protected override void EscreverTipo03(StringBuilder sb, Categoria cat)
        {
            // 03|NUMEROCATEGORIA|DESCRICAOCATEGORIA
            sb.Append("03").Append("|")
              .Append(cat.NumeroCategoria).Append("|")
              .Append(cat.DescricaoCategoria).AppendLine();

            RegistrarLinha("03");
        }
    }
}

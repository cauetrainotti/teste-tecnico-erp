using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace GeradorTxt
{
    /// <summary>
    /// Implementa a geração do Leiaute 1.
    /// IMPORTANTE: métodos NÃO marcados como virtual de propósito.
    /// O candidato deve decidir onde permitir override para suportar versões futuras.
    /// </summary>
    public class GeradorArquivoBase
    {
        protected Dictionary<string, int> ContadorLinhas = new Dictionary<string, int>();

        public void Gerar(List<Empresa> empresas, string outputPath)
        {
            var sb = new StringBuilder();

            foreach (var emp in empresas)
            {
                ValidarValoresDosDocumentos(sb, emp);

                EscreverTipo00(sb, emp);
                foreach (var doc in emp.Documentos)
                {
                    EscreverTipo01(sb, doc);

                    foreach (var item in doc.Itens)
                    {
                        EscreverTipo02(sb, item);
                        foreach (var cat in item.Categorias)
                        {
                                EscreverTipo03(sb, cat);
                        }
                    }
                }
            }

            EscreverTipo09(sb);
            EscreverTipo99(sb);

            File.WriteAllText(outputPath, sb.ToString(), Encoding.UTF8);
        }

        protected string ToMoney(decimal val)
        {
            // Força ponto como separador decimal, conforme muitos leiautes.
            return val.ToString("0.00", CultureInfo.InvariantCulture);
        }

        protected void ValidarValoresDosDocumentos(StringBuilder sb, Empresa emp)
        {
            foreach (var doc in emp.Documentos)
            {
                decimal somaItens = doc.Itens.Sum(i => i.Valor);
                if (somaItens != doc.Valor)
                {
                    throw new InvalidOperationException(
                        $"Documento {doc.Numero} da empresa {emp.Nome} possui valor {doc.Valor} " +
                        $"diferente da soma dos itens {somaItens}.");
                }
            }
        }

        protected void EscreverTipo00(StringBuilder sb, Empresa emp)
        {
            // 00|CNPJEMPRESA|NOMEEMPRESA|TELEFONE
            sb.Append("00").Append("|")
              .Append(emp.CNPJ).Append("|")
              .Append(emp.Nome).Append("|")
              .Append(emp.Telefone).AppendLine();

            RegistrarLinha("00");
        }

        protected void EscreverTipo01(StringBuilder sb, Documento doc)
        {
            // 01|MODELODOCUMENTO|NUMERODOCUMENTO|VALORDOCUMENTO
            sb.Append("01").Append("|")
              .Append(doc.Modelo).Append("|")
              .Append(doc.Numero).Append("|")
              .Append(ToMoney(doc.Valor)).AppendLine();

            RegistrarLinha("01");
        }

        protected virtual void EscreverTipo02(StringBuilder sb, ItemDocumento item)
        {
            // 02|DESCRICAOITEM|VALORITEM
            sb.Append("02").Append("|")
              .Append(item.Descricao).Append("|")
              .Append(ToMoney(item.Valor)).AppendLine();

            RegistrarLinha("02");
        }

        protected virtual void EscreverTipo03(StringBuilder sb, Categoria cat)
        {
            // 03|NUMEROCATEGORIA|DESCRICAOCATEGORIA
            // Não implementado no leiaute base
        }

        protected virtual void EscreverTipo09(StringBuilder sb)
        {
            // 09|QTD_LINHA_TIPO_00|QTD_LINHA_TIPO_01|QTD_LINHA_TIPO_02|...
            sb.Append("09");

            foreach (var tipo in ContadorLinhas.Keys.OrderBy(t => t))
            {
                sb.Append("|").Append(ContadorLinhas[tipo]);
            }

            sb.AppendLine();
        }

        protected void RegistrarLinha(string tipo)
        {
            if (!ContadorLinhas.ContainsKey(tipo))
                ContadorLinhas[tipo] = 0;

            ContadorLinhas[tipo]++;
        }

        protected virtual void EscreverTipo99(StringBuilder sb)
        {
            // 99|QTD_LINHAS_TOTAL
            sb.AppendLine($"99|{ContadorLinhas.Values.Sum()}");
        }
    }
}

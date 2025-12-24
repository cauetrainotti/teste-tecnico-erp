using ConsoleApp1.GeradorTxt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTxt
{
    public class GeradorArquivoFactory
    {
        public static GeradorArquivoBase Criar(LeiauteTipo tipo)
        {
            switch (tipo)
            {
                case LeiauteTipo.Leiaute1:
                    return new GeradorArquivoLeiaute01();

                case LeiauteTipo.Leiaute2:
                    return new GeradorArquivoLeiaute02();

                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(tipo),
                        tipo,
                        "Leiaute desconhecido"
                    );
            }
        }
    }
}

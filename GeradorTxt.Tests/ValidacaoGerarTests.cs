using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace GeradorTxt.Tests
{
    [TestFixture]
    public class ValidacaoArquivoTests
    {
        [Test]
        public void Gerar_SomaDivergente_LancaExcecao()
        {
            var gerador = new GeradorArquivoLeiaute01();
            var empresaInvalida = CriarEmpresaComErroSoma();

            var ex = Assert.Throws<InvalidOperationException>(() =>
                gerador.Gerar(empresaInvalida, Path.GetTempFileName()));

            Assert.That(ex.Message, Does.Contain("diferente da soma"));
        }

        private List<Empresa> CriarEmpresaComErroSoma()
        {
            return new List<Empresa>
            {
                new Empresa
                {
                    Nome = "Empresa Erro",
                    Documentos = new List<Documento>
                    {
                        new Documento
                        {
                            Numero = "999",
                            Valor = 500.00m,
                            Itens = new List<ItemDocumento>
                            {
                                new ItemDocumento { Descricao = "Item A", Valor = 100.00m }
                            }
                        }
                    }
                }
            };
        }
    }
}

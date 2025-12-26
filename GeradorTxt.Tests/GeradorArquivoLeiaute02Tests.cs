using NUnit.Framework;

namespace GeradorTxt.Tests
{
    public class GeradorArquivoLeiaute02Tests : BaseTesteGerador
    {
        [Test]
        public void DeveGerarLinha03()
        {
            var gerador = new GeradorArquivoLeiaute02();
            var conteudo = GerarArquivo(gerador);

            Assert.That(conteudo, Does.Contain("03|1|Cat A"));
        }

        [Test]
        public void Linha02DeveConterNumeroItem()
        {
            var gerador = new GeradorArquivoLeiaute02();
            var conteudo = GerarArquivo(gerador);

            Assert.That(conteudo, Does.Contain("02|1|Item A|100.00"));
        }
    }
}

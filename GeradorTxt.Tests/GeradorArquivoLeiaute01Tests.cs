using NUnit.Framework;

namespace GeradorTxt.Tests
{
    [TestFixture]
    public class GeradorArquivoLeiaute01Tests : BaseTesteGerador
    {
        [Test]
        public void NaoDeveGerarLinha03()
        {
            var gerador = new GeradorArquivoLeiaute01();
            var conteudo = GerarArquivo(gerador);

            Assert.That(conteudo, Does.Not.Contain("03|"));
        }

        [Test]
        public void Linha02NaoDeveConterNumeroItem()
        {
            var gerador = new GeradorArquivoLeiaute01();
            var conteudo = GerarArquivo(gerador);

            Assert.That(conteudo, Does.Contain("02|Item A|100.00"));
        }
    }
}

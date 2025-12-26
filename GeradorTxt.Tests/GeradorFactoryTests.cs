using NUnit.Framework;
using System;

namespace GeradorTxt.Tests
{
    [TestFixture] 
    public class GeradorFactoryTests
    {
        [Test]
        public void Criar_Leiaute01_RetornaInstanciaCorreta()
        {
            var gerador = GeradorArquivoFactory.Criar(LeiauteTipo.Leiaute1);

            Assert.That(gerador, Is.InstanceOf<GeradorArquivoLeiaute01>());
        }

        [Test]
        public void Criar_Leiaute02_RetornaInstanciaCorreta()
        {
            var gerador = GeradorArquivoFactory.Criar(LeiauteTipo.Leiaute2);

            Assert.That(gerador, Is.InstanceOf<GeradorArquivoLeiaute02>());
        }

        [Test]
        public void Criar_TipoInvalido_LancaExcecao()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                GeradorArquivoFactory.Criar((LeiauteTipo)99));
        }
    }
}

using System.Collections.Generic;
using System.IO;

namespace GeradorTxt.Tests
{
    public abstract class BaseTesteGerador
    {
        protected string GerarArquivo(GeradorArquivoBase gerador)
        {
            var empresas = new List<Empresa>
            {
                new Empresa
                {
                    CNPJ = "123",
                    Nome = "Empresa Teste",
                    Telefone = "999",
                    Documentos = new List<Documento>
                    {
                        new Documento
                        {
                            Modelo = "NFE",
                            Numero = "1",
                            Valor = 100,
                            Itens = new List<ItemDocumento>
                            {
                                new ItemDocumento
                                {
                                    NumeroItem = 1,
                                    Descricao = "Item A",
                                    Valor = 100,
                                    Categorias = new List<Categoria>
                                    {
                                        new Categoria
                                        {
                                            NumeroCategoria = 1,
                                            DescricaoCategoria = "Cat A"
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            var path = Path.GetTempFileName();
            gerador.Gerar(empresas, path);

            return File.ReadAllText(path);
        }
    }
}

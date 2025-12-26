# GeradorTxt – Teste Técnico Programador (Produto ERP)

---

## Descrição
Aplicação console responsável por gerar arquivos texto (.txt) a partir de um arquivo JSON contendo dados de empresas, documentos, itens e categorias.

O projeto foi desenvolvido com foco em com foco em **Clean Code**, **SOLID** e suportar adaptabilidade e expansão, permitindo a inclusão de novos leiautes (versões) sem impacto na lógica principal.

---

## Tecnologias
- C# 7.3  
- .NET Framework 4.8  
- Testes unitários: NUnit  
- JSON: Newtonsoft.Json  

---

## Requisitos implementados
- Suporte a múltiplos leiautes via herança (`GeradorArquivoBase` + overrides).
- Seleção de leiaute via console no momento da geração do arquivo.
- Validação de integridade:
  - A soma dos valores dos itens deve ser igual ao valor do documento.
  - Em caso de divergência, é lançada `InvalidOperationException`.
- Geração das linhas:
  - `09`: quantidade de linhas por tipo.
  - `99`: quantidade total de linhas do arquivo.
- Testes unitários com NUnit cobrindo:
  - Factory de criação de leiautes.
  - Erros e validação de regra de negócio.

---

## Estrutura do projeto

```text
AvaliacaoDotnet/ (Solução)
│
├── GeradorTxt/
│   ├── Models/                 # Entidades de Domínio (Empresa, Documento...)
│   ├── GeradorArquivoBase.cs   # Lógica compartilhada (DRY)
│   ├── GeradorArquivoFactory.cs# Padrão Factory
│   ├── GeradorArquivoLeiaute01.cs
│   ├── GeradorArquivoLeiaute02.cs
│   ├── JsonRepository.cs       # Camada de Acesso a Dados
│   └── MainConsole.cs          # Interação com Usuário
│
└── GeradorTxt.Tests/           # Testes Unitários com NUnit
```
---

## Como executar
1. Executar a aplicação console.
2. Informar o caminho do arquivo JSON (opcional – pode usar o padrão).
3. Informar o diretório de saída do arquivo `.txt`.
4. Selecionar a opção **Gerar arquivo**.
5. Escolher o leiaute desejado (ex: `01` ou `02`).

O arquivo será gerado no diretório configurado.

---

## Exemplo mínimo de entrada (JSON)
```json
[
  {
    "CNPJ": "123",
    "Nome": "Empresa Teste",
    "Telefone": "999",
    "Documentos": [
      {
        "Modelo": "NFE",
        "Numero": "1",
        "Valor": 100.00,
        "Itens": [
          {
            "NumeroItem": 1,
            "Descricao": "Item A",
            "Valor": 100.00,
            "Categorias": [
              {
                "NumeroCategoria": 1,
                "DescricaoCategoria": "Cat A"
              }
            ]
          }
        ]
      }
    ]
  }
]

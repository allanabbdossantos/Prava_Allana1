# Biblioteca — Apresentação do produto

## 1. Visão do produto

A **Biblioteca** é uma aplicação web simples para cadastro e organização de livros. Ela permite registrar informações essenciais das obras e consultar o catálogo em uma interface única, leve e responsiva.

O produto foi desenvolvido como uma primeira versão funcional sobre ASP.NET Core e .NET 10, com uma API HTTP e uma interface web integrada.

## 2. Problema que resolve

Manter uma coleção de livros organizada pode ser difícil quando as informações ficam espalhadas em anotações, planilhas ou diferentes aplicativos. A Biblioteca centraliza os dados básicos de cada obra em um catálogo acessível pelo navegador.

## 3. Proposta de valor

- Cadastro rápido de livros;
- Catálogo visual e fácil de consultar;
- Validação dos dados principais antes do armazenamento;
- Acesso por navegador na máquina local ou na rede local;
- Interface responsiva para computadores e dispositivos móveis;
- Arquitetura preparada para futuras evoluções.

## 4. Público-alvo

- Leitores que desejam organizar uma coleção pessoal;
- Pequenas bibliotecas e grupos de estudo;
- Projetos educacionais de cadastro e consulta;
- Equipes que precisam de um catálogo inicial sem infraestrutura complexa.

## 5. Funcionalidades principais

### Cadastro de livros

O usuário pode informar:

- Título;
- Autor;
- Ano de publicação;
- ISBN.

Após o envio, o livro é validado e adicionado ao catálogo.

### Listagem do catálogo

A página inicial exibe todos os livros cadastrados, com título, autor, ano e ISBN. A listagem pode ser atualizada pelo botão de atualização da interface.

### Validações

A aplicação valida:

- título obrigatório;
- autor obrigatório;
- ano de publicação válido;
- ISBN-10 ou ISBN-13 válido;
- ISBN duplicado.

### Acesso em rede local

A aplicação pode ser acessada por outras máquinas da mesma rede usando o IP da máquina que executa o sistema e a porta `5283`.

## 6. Experiência de uso

1. O usuário abre a página inicial no navegador.
2. Preenche os dados do livro no formulário.
3. Seleciona **Adicionar ao catálogo**.
4. A API valida e registra os dados.
5. O novo livro aparece imediatamente na coleção.
6. O usuário pode consultar ou atualizar a listagem quando quiser.

## 7. Arquitetura do produto

A solução utiliza uma API ASP.NET Core com camadas separadas:

- **Apresentação:** interface web estática e controllers HTTP;
- **Aplicação:** casos de uso, DTOs e contratos;
- **Domínio:** entidade `Livro` e regras de validação;
- **Infraestrutura:** repositório em memória.

A comunicação entre a interface e o backend ocorre por meio dos endpoints:

- `GET /api/livros` — lista os livros;
- `POST /api/livros` — cadastra um livro.

## 8. Stack tecnológica

- C#;
- .NET 10;
- ASP.NET Core;
- HTML, CSS e JavaScript nativos;
- Kestrel;
- OpenAPI em ambiente de desenvolvimento;
- Armazenamento em memória.

## 9. Demonstração local

Execute o projeto com o perfil HTTP:

```powershell
dotnet run --project .\Prava_Allana1\Prava_Allana1.csproj --launch-profile http
```

Acesse localmente:

```text
http://localhost:5283/
```

Para acesso por outra máquina, utilize o IP da máquina host:

```text
http://IP_DA_MAQUINA:5283/
```

Mais detalhes estão disponíveis em [`NETWORK_ACCESS.md`](../NETWORK_ACCESS.md).

## 10. Estado atual do produto

A versão atual é uma primeira versão funcional, adequada para demonstração e uso local. Os livros são armazenados em memória e, portanto, são perdidos quando a aplicação é encerrada ou reiniciada.

Não fazem parte da versão atual:

- login e usuários;
- banco de dados;
- edição e exclusão de livros;
- pesquisa e filtros;
- integração com serviços externos;
- publicação em ambiente de produção.

## 11. Próximas evoluções

A evolução natural do produto pode incluir:

1. Persistência em banco de dados;
2. Operações de edição e exclusão;
3. Pesquisa por título, autor ou ISBN;
4. Filtros por ano e autor;
5. Autenticação de usuários;
6. Capas e metadados dos livros;
7. Importação e exportação do catálogo;
8. Relatórios e estatísticas de leitura;
9. Implantação com HTTPS e domínio público;
10. Testes automatizados de unidade e integração.

## 12. Mensagem do produto

> **Biblioteca: seus livros, organizados.**
>
> Um catálogo simples, acessível e preparado para crescer junto com a sua coleção.

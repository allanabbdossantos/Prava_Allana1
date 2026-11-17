# Stack tecnológica

## Visão geral

O projeto `Prava_Allana1` é uma API HTTP desenvolvida com ASP.NET Core e executada sobre o .NET 10.

## Tecnologias principais

| Categoria | Tecnologia | Uso |
|---|---|---|
| Linguagem | C# | Implementação da aplicação |
| Runtime e SDK | .NET 10 | Execução e compilação do projeto |
| Framework web | ASP.NET Core | Hospedagem HTTP, pipeline e controllers |
| Servidor web | Kestrel | Servidor HTTP utilizado pela aplicação ASP.NET Core |
| Projeto | `Microsoft.NET.Sdk.Web` | SDK do projeto web |
| Documentação de API | OpenAPI | Geração do documento da API em desenvolvimento |
| Configuração | `appsettings.json` | Logging e configurações da aplicação |
| Testes manuais | Arquivo `.http` | Execução de requisições HTTP pela IDE ou cliente compatível |

## Framework e configuração do projeto

O projeto está configurado no arquivo `Prava_Allana1/Prava_Allana1.csproj` com:

- Target framework: `net10.0`;
- Nullable reference types habilitado;
- Implicit usings habilitado;
- SDK `Microsoft.NET.Sdk.Web`.

## Pacotes NuGet

- `Microsoft.AspNetCore.OpenApi` `10.0.9`: integração com OpenAPI para descrever os endpoints da API.

## Componentes ASP.NET Core utilizados

- Minimal hosting model para inicialização da aplicação;
- MVC Controllers com `AddControllers()`;
- Roteamento baseado em atributos;
- Middleware de redirecionamento HTTPS;
- Middleware de autorização;
- Mapeamento de controllers com `MapControllers()`;
- Endpoint OpenAPI habilitado somente no ambiente de desenvolvimento.

## Persistência e integrações

A versão atual não utiliza:

- Banco de dados;
- ORM ou micro-ORM;
- Cache;
- Filas ou mensageria;
- Serviços externos;
- Autenticação configurada;
- Armazenamento persistente.

Os dados retornados pelo endpoint `GET /WeatherForecast` são gerados em memória durante cada requisição.

## Ferramentas de desenvolvimento

- Microsoft Visual Studio Community 2026;
- PowerShell;
- CLI do .NET (`dotnet restore`, `dotnet build` e `dotnet run`);
- Arquivo `Prava_Allana1/Prava_Allana1.http` para testes manuais.

## Execução

Na raiz do workspace, execute:

```powershell
dotnet restore .\Prava_Allana1\Prava_Allana1.csproj
dotnet build .\Prava_Allana1\Prava_Allana1.csproj
dotnet run --project .\Prava_Allana1\Prava_Allana1.csproj
```

As URLs de execução local são definidas em `Prava_Allana1/Properties/launchSettings.json`.

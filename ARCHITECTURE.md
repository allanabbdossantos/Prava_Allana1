# Arquitetura

## Visão geral

`Prava_Allana1` é uma API HTTP construída com ASP.NET Core e direcionada ao `.NET 10`. O projeto utiliza o modelo de hospedagem mínima, com a configuração de serviços e do pipeline concentrada em `Prava_Allana1/Program.cs`.

Atualmente, a aplicação é um exemplo funcional de API que expõe dados de previsão do tempo gerados em memória. Não há banco de dados, autenticação, persistência ou serviços externos configurados.

## Estrutura do projeto

```text
Prava_Allana1/
├── Controllers/
│   └── WeatherForecastController.cs  # Endpoint de previsão do tempo
├── Properties/
│   └── launchSettings.json           # Perfis locais de execução
├── Program.cs                        # Composição da aplicação e pipeline HTTP
├── WeatherForecast.cs                # Modelo de resposta da previsão
├── appsettings.json                  # Configuração base
├── appsettings.Development.json      # Configuração específica de desenvolvimento
├── Prava_Allana1.http                # Requisições para testes manuais
└── Prava_Allana1.csproj              # Configuração do projeto e dependências
```

## Componentes e responsabilidades

### `Program.cs`

É o ponto de entrada e o composition root da aplicação. Ele:

- registra MVC com `AddControllers()`;
- registra suporte a OpenAPI com `AddOpenApi()`;
- publica o documento OpenAPI apenas no ambiente de desenvolvimento;
- habilita redirecionamento para HTTPS;
- habilita autorização no pipeline;
- mapeia os controllers com `MapControllers()`.

### `WeatherForecastController`

Controller HTTP com rota base `[controller]`, resultando em:

- `GET /WeatherForecast`

A resposta contém cinco previsões geradas sob demanda. Os valores são aleatórios e não são persistidos.

### `WeatherForecast`

Modelo de transporte usado na resposta da API. Contém a data, a temperatura em Celsius, a temperatura calculada em Fahrenheit e um resumo textual opcional.

## Fluxo de uma requisição

1. O cliente envia uma requisição HTTP para a aplicação.
2. O Kestrel recebe a requisição e o middleware aplica o redirecionamento para HTTPS quando necessário.
3. O roteamento identifica o `WeatherForecastController`.
4. A action `Get` gera os dados em memória.
5. O ASP.NET Core serializa o resultado para JSON e devolve a resposta.

Em desenvolvimento, o documento OpenAPI fica disponível pelo endpoint configurado pelo suporte nativo de OpenAPI.

## Configuração

A configuração base está em `appsettings.json`. Atualmente, ela define apenas os níveis de log e permite qualquer host por meio de `AllowedHosts: "*"`. Configurações específicas de desenvolvimento devem ser mantidas em `appsettings.Development.json` e não devem conter segredos versionados.

## Dependências e plataforma

- SDK: `Microsoft.NET.Sdk.Web`
- Target framework: `net10.0`
- Nullable reference types: habilitado
- Implicit usings: habilitado
- Pacote: `Microsoft.AspNetCore.OpenApi` versão `10.0.9`

## Execução local

A partir da raiz da solução:

```powershell
dotnet restore .\Prava_Allana1\Prava_Allana1.csproj
dotnet run --project .\Prava_Allana1\Prava_Allana1.csproj
```

As URLs locais e os perfis de execução são definidos em `Prava_Allana1/Properties/launchSettings.json`. Para validar o endpoint, use `Prava_Allana1/Prava_Allana1.http` ou uma ferramenta HTTP compatível.

## Evolução prevista

Para ampliar a aplicação, recomenda-se manter as responsabilidades separadas:

- adicionar serviços de aplicação em uma camada própria;
- introduzir interfaces para dependências externas;
- mover acesso a dados para uma camada de infraestrutura quando houver persistência;
- adicionar DTOs e validação para contratos públicos;
- criar testes unitários e de integração para controllers e serviços;
- configurar autenticação, autorização e políticas de CORS conforme os requisitos do ambiente de publicação.

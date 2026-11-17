# Especificação do sistema

## 1. Objetivo

`Prava_Allana1` é uma API HTTP demonstrativa para disponibilizar previsões do tempo geradas em memória. O projeto serve como base para evolução de uma API ASP.NET Core executada no .NET 10.

## 2. Escopo atual

A primeira versão deve:

- iniciar como uma aplicação ASP.NET Core;
- aceitar requisições HTTP por HTTPS;
- expor um endpoint de previsão do tempo;
- retornar cinco previsões em formato JSON;
- calcular a temperatura equivalente em Fahrenheit;
- disponibilizar documentação OpenAPI no ambiente de desenvolvimento.

A primeira versão não contempla persistência, usuários, autenticação, integração com provedores meteorológicos ou gerenciamento de localidades.

## 3. Requisitos funcionais

### RF-01 — Consultar previsões

O sistema deve disponibilizar o endpoint `GET /WeatherForecast`.

### RF-02 — Retornar cinco registros

Uma consulta bem-sucedida deve retornar exatamente cinco objetos de previsão.

### RF-03 — Gerar datas futuras

Cada registro deve representar um dos cinco dias seguintes à data atual do servidor.

### RF-04 — Informar temperatura em Celsius

Cada registro deve conter uma temperatura inteira em Celsius, gerada no intervalo de `-20` a `54` graus.

### RF-05 — Informar temperatura em Fahrenheit

Cada registro deve conter a temperatura equivalente em Fahrenheit, calculada a partir do valor em Celsius.

### RF-06 — Informar resumo climático

Cada registro deve conter um resumo textual selecionado da lista configurada pela aplicação.

### RF-07 — Disponibilizar OpenAPI em desenvolvimento

A aplicação deve mapear o documento OpenAPI somente quando estiver executando no ambiente de desenvolvimento.

## 4. Contrato da API

### `GET /WeatherForecast`

#### Requisição

- Método: `GET`
- Parâmetros de rota: nenhum
- Parâmetros de consulta: nenhum
- Corpo: nenhum

#### Resposta de sucesso

- Status HTTP esperado: `200 OK`
- Content-Type: `application/json`
- Corpo: coleção com cinco objetos `WeatherForecast`.

Exemplo de estrutura de resposta:

```json
[
  {
	"date": "2025-01-02",
	"temperatureC": 21,
	"temperatureF": 69,
	"summary": "Warm"
  }
]
```

O exemplo representa a estrutura do contrato. A aplicação atual retorna cinco itens e os valores são gerados dinamicamente.

### Modelo `WeatherForecast`

| Campo | Tipo | Obrigatório | Descrição |
|---|---|---:|---|
| `date` | `date` | Sim | Data da previsão |
| `temperatureC` | `integer` | Sim | Temperatura em Celsius |
| `temperatureF` | `integer` | Sim | Temperatura calculada em Fahrenheit |
| `summary` | `string` | Não | Descrição textual do clima |

## 5. Requisitos não funcionais

### RNF-01 — Plataforma

A aplicação deve ser compilada para o target framework `net10.0`.

### RNF-02 — Segurança de transporte

A aplicação deve redirecionar requisições HTTP para HTTPS quando o middleware correspondente estiver habilitado.

### RNF-03 — Configuração

As configurações devem utilizar `appsettings.json` e os arquivos específicos por ambiente do ASP.NET Core.

### RNF-04 — Observabilidade

O nível padrão de logging deve ser `Information`, enquanto os logs do ASP.NET Core devem utilizar o nível `Warning`, conforme a configuração atual.

### RNF-05 — Documentação

Os endpoints devem permanecer documentados por OpenAPI à medida que a API evoluir.

## 6. Regras de dados

- As previsões atuais não são persistidas.
- Os dados são gerados a cada requisição.
- O sistema não deve assumir que a previsão representa dados meteorológicos reais.
- A temperatura em Fahrenheit deve permanecer consistente com a temperatura em Celsius do mesmo registro.

## 7. Ambiente de execução

Os perfis e URLs locais são definidos em `Prava_Allana1/Properties/launchSettings.json`. A aplicação pode ser executada com:

```powershell
dotnet run --project .\Prava_Allana1\Prava_Allana1.csproj
```

As requisições manuais podem ser mantidas em `Prava_Allana1/Prava_Allana1.http`.

## 8. Critérios de aceite

- A aplicação compila para o .NET 10 sem erros.
- `GET /WeatherForecast` responde com HTTP `200`.
- A resposta contém cinco previsões.
- Cada previsão possui data, temperaturas em Celsius e Fahrenheit e resumo.
- A temperatura em Fahrenheit é derivada da temperatura em Celsius.
- O documento OpenAPI é acessível somente durante o desenvolvimento.
- A execução local utiliza HTTPS conforme o perfil configurado.

## 9. Fora de escopo

Os itens abaixo não fazem parte da implementação atual:

- persistência em banco de dados;
- cadastro de cidades ou usuários;
- atualização ou exclusão de previsões;
- integração com APIs meteorológicas externas;
- autenticação e autorização de consumidores;
- cache, filas e processamento assíncrono;
- métricas e monitoramento distribuído.

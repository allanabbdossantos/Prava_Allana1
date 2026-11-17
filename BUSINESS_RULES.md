# Regras de negócio

## Escopo atual

A aplicação é um exemplo de API de previsão do tempo. No estado atual, não existem regras de negócio persistentes, cálculos dependentes de dados externos ou fluxos de aprovação. O endpoint disponível gera dados demonstrativos em memória.

## Endpoint de previsão do tempo

### Consulta

- Método: `GET`
- Rota: `/WeatherForecast`
- Acesso: não há autenticação configurada atualmente.

### Regras de geração

Ao receber uma requisição válida:

1. A API deve retornar exatamente cinco previsões.
2. As previsões devem representar os cinco dias seguintes à data atual do servidor.
3. A data inicial é calculada a partir de `DateTime.Now`.
4. A temperatura em Celsius deve ser um número inteiro aleatório entre `-20` e `54` graus, pois o limite superior da geração é exclusivo.
5. O resumo deve ser escolhido aleatoriamente entre os valores configurados:
   - `Freezing`
   - `Bracing`
   - `Chilly`
   - `Cool`
   - `Mild`
   - `Warm`
   - `Balmy`
   - `Hot`
   - `Sweltering`
   - `Scorching`
6. A temperatura em Fahrenheit deve ser calculada a partir da temperatura em Celsius.
7. O resultado deve ser retornado como uma coleção serializada em JSON.

## Características dos dados

- Os dados são temporários e gerados em memória.
- Duas requisições podem retornar valores diferentes.
- Não há garantia de que os valores gerados correspondam ao clima real.
- Não há cadastro, atualização ou exclusão de previsões.
- Não há relacionamento com usuários, cidades ou localidades.

## Validações e erros

- O endpoint não recebe parâmetros de entrada.
- Não há regras de validação de payload implementadas.
- Não há tratamento de erros de domínio específico.
- Erros de infraestrutura e falhas não previstas devem seguir o comportamento padrão do ASP.NET Core.

## Segurança e acesso

A configuração atual não implementa autenticação nem autorização específica para o endpoint. O pipeline contém suporte a autorização, mas nenhuma política ou requisito de acesso foi definido.

Antes de disponibilizar a API em produção, devem ser definidas regras para:

- autenticação dos consumidores;
- autorização por recurso ou perfil;
- limitação de requisições;
- validação de origem e CORS;
- proteção de informações de configuração e segredos.

## Evolução das regras de negócio

Novos requisitos devem ser documentados neste arquivo e acompanhados por testes automatizados. Ao adicionar persistência ou integrações externas, as regras devem deixar de depender de valores aleatórios e passar a considerar contratos explícitos para localidades, períodos, unidades de temperatura e origem dos dados.

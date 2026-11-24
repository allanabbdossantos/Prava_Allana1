# Acesso pela rede local

A aplicação está configurada para aceitar conexões de outras máquinas na porta `5283`.

## Iniciar a aplicação

Na máquina que executa o projeto, use o perfil HTTP:

```powershell
dotnet run --project .\Prava_Allana1\Prava_Allana1.csproj --launch-profile http
```

O perfil escuta em `0.0.0.0:5283`, ou seja, em todas as interfaces de rede disponíveis.

## Descobrir o endereço IP

No PowerShell da máquina host, execute:

```powershell
Get-NetIPAddress -AddressFamily IPv4 | Where-Object { $_.IPAddress -notlike '127.*' -and $_.IPAddress -notlike '169.254.*' } | Select-Object InterfaceAlias,IPAddress
```

Identifique o endereço IPv4 da rede utilizada, por exemplo `192.168.1.25`.

Em outra máquina conectada à mesma rede, abra:

```text
http://192.168.1.25:5283/
```

Substitua `192.168.1.25` pelo IP real da máquina host.

## Firewall do Windows

Se a página não abrir em outro dispositivo, crie uma regra de entrada no PowerShell executado como Administrador:

```powershell
New-NetFirewallRule -DisplayName "Prava_Allana1 - HTTP 5283" -Direction Inbound -Protocol TCP -LocalPort 5283 -Action Allow -Profile Private
```

A regra é limitada ao perfil de rede `Private`. Evite liberar essa porta em redes públicas.

## Observações de segurança

- O modo HTTP foi configurado para facilitar o desenvolvimento em uma rede local confiável.
- Para publicação fora da rede local, use HTTPS com um certificado válido e um proxy reverso ou configuração de Kestrel apropriada.
- Os dados dos livros continuam armazenados somente em memória.
- A aplicação e os dispositivos clientes precisam estar na mesma rede e não podem estar isolados por políticas do roteador.

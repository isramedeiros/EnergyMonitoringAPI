# Postman Collection - Energy Monitoring API

## Como importar

1. Abra o Postman
2. Clique em **Import**
3. Selecione os arquivos:
   - `EnergyMonitoringAPI.postman_collection.json`
   - `Local.postman_environment.json`

## Como usar

1. **Selecione o environment** "Local Environment" no canto superior direito
2. **Execute Register ou Login** para obter o token JWT
   - O token será salvo automaticamente na variável `jwt_token`
3. **Teste os demais endpoints** - o token será usado automaticamente

## Ordem recomendada

1. **Authentication > Register** - Criar usuário
2. **Authentication > Login** - Obter token
3. **Energy Readings > Create Reading** - Criar leitura
4. **Energy Readings > List All** - Listar leituras
5. **Analytics > Consumption Analysis** - Ver análises

## Variáveis

- `base_url`: URL da API (padrão: https://localhost:5066)
- `jwt_token`: Token JWT (preenchido automaticamente após login)
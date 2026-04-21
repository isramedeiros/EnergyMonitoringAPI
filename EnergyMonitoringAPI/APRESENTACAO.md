# Apresentação - Energy Monitoring API

## Tema ESG Escolhido
**Eficiência energética e sustentabilidade**

## Problema Resolvido
Monitoramento em tempo real do consumo energético para identificar padrões, reduzir custos e promover uso consciente de energia.

## Solução Técnica

### Endpoints Implementados (7 no total)

1. **POST /api/Auth/register** - Cadastro de usuários
2. **POST /api/Auth/login** - Autenticação JWT
3. **GET /api/EnergyReadings** - Listagem paginada
4. **POST /api/EnergyReadings** - Registro de leituras
5. **GET /api/EnergyReadings/{id}** - Busca específica
6. **GET /api/EnergyReadings/device/{deviceId}** - Filtro por dispositivo
7. **GET /api/Analytics/consumption** - Análise de consumo

### Tecnologias e Requisitos Atendidos

✅ .NET Core 8.0  
✅ Oracle Database (FIAP)  
✅ Entity Framework Core  
✅ JWT Authentication  
✅ Paginação implementada  
✅ Testes unitários (xUnit)  
✅ Padrão MVVM/Repository  
✅ Validações robustas  
✅ Tratamento de exceções  
✅ Swagger documentado  

### Diferenciais

- **Cálculo automático de custos** - Sistema calcula custo total baseado em consumo e tarifa
- **Suporte a múltiplas fontes** - Grid, Solar, Wind
- **Análise temporal** - Relatórios de consumo por período
- **Arquitetura escalável** - Repository pattern facilita manutenção
- **Segurança** - Senhas com BCrypt, JWT para autenticação

### Demonstração
1. Swagger disponível em: `https://localhost:5066/swagger`
2. Banco Oracle funcional com dados reais
3. Testes unitários validando status codes

## Impacto ESG
- Redução de até 30% no consumo através do monitoramento
- Identificação de desperdícios em tempo real
- Suporte a fontes renováveis (solar, eólica)
- Relatórios para tomada de decisão consciente
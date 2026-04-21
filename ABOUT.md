# Energy Monitoring API 🔋

API RESTful para monitoramento e otimização de consumo energético, desenvolvida como parte do desafio de .NET Core 8 com foco em ESG (Eficiência energética e sustentabilidade).

## 📋 Sobre o Projeto

Sistema de monitoramento de energia que permite:
- Registrar leituras de consumo energético de múltiplos dispositivos
- Analisar padrões de consumo e custos
- Gerar relatórios de eficiência energética
- Suportar múltiplas fontes de energia (Grid, Solar, Wind)

## 🛠️ Tecnologias Utilizadas

- **.NET Core 8.0**
- **Oracle Database** (FIAP)
- **Entity Framework Core 8.0**
- **JWT Authentication**
- **Swagger/OpenAPI**
- **xUnit** (Testes)
- **BCrypt** (Criptografia de senhas)

## 📁 Estrutura do Projeto
```
EnergyMonitoringAPI/
├── Controllers/          # Endpoints da API
│   ├── AuthController.cs
│   ├── EnergyReadingsController.cs
│   └── AnalyticsController.cs
├── Models/              # Entidades do banco
│   ├── User.cs
│   ├── EnergyReading.cs
│   └── Alert.cs
├── ViewModels/          # DTOs
│   ├── AuthViewModel.cs
│   ├── EnergyReadingViewModel.cs
│   └── PaginatedResultViewModel.cs
├── Data/               # Contexto do banco
│   └── AppDbContext.cs
├── Repositories/       # Acesso a dados
│   ├── IEnergyReadingRepository.cs
│   └── EnergyReadingRepository.cs
├── Services/           # Lógica de negócio
│   ├── IAuthService.cs
│   └── AuthService.cs
└── Program.cs         # Configuração da aplicação

EnergyMonitoringAPI.Tests/
├── AuthControllerTests.cs
├── EnergyReadingsControllerTests.cs
├── AnalyticsControllerTests.cs
└── CustomWebApplicationFactory.cs
```

## 🔌 Endpoints Principais

### Autenticação

**POST** `/api/Auth/register` - Registrar novo usuário
```json
{
  "username": "admin",
  "email": "admin@fiap.com",
  "password": "Admin123!"
}
```

**POST** `/api/Auth/login` - Login (retorna JWT token)
```json
{
  "username": "admin",
  "password": "Admin123!"
}
```

### Leituras de Energia

**GET** `/api/EnergyReadings` - Listar leituras (paginado)
- Query params: `page` (padrão: 1), `pageSize` (padrão: 10)
- Requer autenticação

**POST** `/api/EnergyReadings` - Criar nova leitura
```json
{
  "deviceId": "SENSOR-001",
  "location": "Prédio Principal - Andar 3",
  "energyConsumption": 245.50,
  "powerDemand": 45.8,
  "energySource": "Grid",
  "costPerKWh": 0.75
}
```
- Requer autenticação

**GET** `/api/EnergyReadings/{id}` - Buscar por ID
- Requer autenticação

**GET** `/api/EnergyReadings/device/{deviceId}` - Buscar por dispositivo
- Requer autenticação

### Analytics

**GET** `/api/Analytics/consumption` - Análise de consumo
- Query params: `startDate`, `endDate` (opcional)
- Requer autenticação

## 🗄️ Banco de Dados

### Configuração Oracle

**Servidor:** oracle.fiap.com.br  
**Porta:** 1521  
**SID:** ORCL  
**User:** RM560139  
**Password:** 130399

### Tabelas

- **USERS** - Usuários do sistema
- **ENERGY_READINGS** - Leituras de energia
- **ALERTS** - Alertas de consumo

## 🚀 Como Executar

### Pré-requisitos

- .NET 8.0 SDK
- Acesso ao banco Oracle da FIAP (rede/VPN)

### Passos

1. **Clone o repositório**
```bash
git clone [seu-repositorio]
cd EnergyMonitoringAPI
```

2. **Restaurar pacotes**
```bash
dotnet restore
```

3. **Executar a aplicação**
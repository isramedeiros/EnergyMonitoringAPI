# Scripts de Migração do Banco de Dados

## Como executar

### 1. Conectar no Oracle
```
Host: oracle.fiap.com.br
Port: 1521
SID: ORCL
Username: RM560139
Password: 130399
```

### 2. Executar scripts na ordem

1. **01_CreateTables.sql** - Cria todas as tabelas e índices
2. **02_SeedData.sql** - Insere dados de exemplo (opcional)

### 3. Verificar instalação
```sql
-- Verificar tabelas criadas
SELECT table_name FROM user_tables;

-- Verificar dados
SELECT COUNT(*) FROM USERS;
SELECT COUNT(*) FROM ENERGY_READINGS;
SELECT COUNT(*) FROM ALERTS;
```

## Rollback (Caso necessário)
```sql
DROP TABLE ALERTS CASCADE CONSTRAINTS;
DROP TABLE ENERGY_READINGS CASCADE CONSTRAINTS;
DROP TABLE USERS CASCADE CONSTRAINTS;
DROP TABLE "__EFMigrationsHistory" CASCADE CONSTRAINTS;
COMMIT;
```
-- ==============================================
-- Energy Monitoring API - Seed Data
-- Dados de exemplo para demonstração
-- ==============================================

-- Inserir usuário admin de exemplo
-- Senha: Admin123! (hash BCrypt)
INSERT INTO USERS (USERNAME, EMAIL, PASSWORD_HASH, ROLE, CREATED_AT)
VALUES (
    'admin',
    'admin@fiap.com',
    '$2a$11$xvW8K5Y7LXPqGfZHqGqYOeNYQ7ZJqJ5Y8L5qYqGqYqGqYqGqYqGq',
    'Admin',
    SYSTIMESTAMP
);

-- Inserir leituras de exemplo
INSERT INTO ENERGY_READINGS (DEVICE_ID, LOCATION, ENERGY_CONSUMPTION, POWER_DEMAND, READING_DATE, ENERGY_SOURCE, COST_PER_KWH, TOTAL_COST)
VALUES ('SENSOR-001', 'Prédio Principal - Andar 1', 150.50, 25.5, SYSTIMESTAMP, 'Grid', 0.75, 112.88);

INSERT INTO ENERGY_READINGS (DEVICE_ID, LOCATION, ENERGY_CONSUMPTION, POWER_DEMAND, READING_DATE, ENERGY_SOURCE, COST_PER_KWH, TOTAL_COST)
VALUES ('SENSOR-002', 'Prédio Principal - Andar 2', 200.30, 35.2, SYSTIMESTAMP, 'Solar', 0.50, 100.15);

INSERT INTO ENERGY_READINGS (DEVICE_ID, LOCATION, ENERGY_CONSUMPTION, POWER_DEMAND, READING_DATE, ENERGY_SOURCE, COST_PER_KWH, TOTAL_COST)
VALUES ('SENSOR-003', 'Laboratório de Informática', 180.75, 30.8, SYSTIMESTAMP, 'Grid', 0.75, 135.56);

-- Inserir alertas de exemplo
INSERT INTO ALERTS (DEVICE_ID, ALERT_TYPE, MESSAGE, SEVERITY, CREATED_AT, IS_RESOLVED)
VALUES ('SENSOR-001', 'HighConsumption', 'Consumo acima do esperado detectado', 'High', SYSTIMESTAMP, 0);

INSERT INTO ALERTS (DEVICE_ID, ALERT_TYPE, MESSAGE, SEVERITY, CREATED_AT, IS_RESOLVED)
VALUES ('SENSOR-003', 'AbnormalPattern', 'Padrão de consumo anormal', 'Medium', SYSTIMESTAMP, 0);

COMMIT;
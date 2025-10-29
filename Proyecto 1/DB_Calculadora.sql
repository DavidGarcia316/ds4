-- Crear la base de datos
CREATE DATABASE DB_Calculadora;
GO

-- Usar la base de datos
USE DB_Calculadora;
GO

-- Crear la tabla de cálculos
CREATE TABLE Calculos (
    IdCalculo INT IDENTITY(1,1) PRIMARY KEY,
    Valor1 DECIMAL(18,6) NOT NULL,
    Valor2 DECIMAL(18,6) NOT NULL,
    Operacion NVARCHAR(20) NOT NULL,
    Resultado DECIMAL(18,6) NOT NULL,
    FechaHora DATETIME DEFAULT GETDATE()
);
GO

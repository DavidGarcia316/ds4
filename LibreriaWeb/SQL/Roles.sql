USE LibreriaDB;
GO

-- 1. Crear Tabla Usuarios
CREATE TABLE Usuarios (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    NombreCompleto VARCHAR(100),
    Email VARCHAR(100) UNIQUE NOT NULL,
    Password VARCHAR(100) NOT NULL, -- En un sistema real, esto debe ir encriptado
    Rol VARCHAR(20) NOT NULL -- 'Admin', 'Vendedor', 'Cliente'
);

-- 2. Insertar Usuarios de Prueba (Uno de cada tipo)
-- Admin: Puede hacer todo
INSERT INTO Usuarios (NombreCompleto, Email, Password, Rol) 
VALUES ('Administrador Jefe', 'admin@libreria.com', '123', 'Admin');

-- Vendedor: Puede vender y consultar
INSERT INTO Usuarios (NombreCompleto, Email, Password, Rol) 
VALUES ('Juan Vendedor', 'vendedor@libreria.com', '123', 'Vendedor');

-- Cliente: Solo puede ver y comprar para sí mismo
INSERT INTO Usuarios (NombreCompleto, Email, Password, Rol) 
VALUES ('Maria Cliente', 'cliente@libreria.com', '123', 'Cliente');
GO

-- 3. Procedimiento para Validar Login
CREATE PROCEDURE sp_ValidarUsuario
    @Email VARCHAR(100),
    @Password VARCHAR(100)
AS
BEGIN
    SELECT NombreCompleto, Rol FROM Usuarios 
    WHERE Email = @Email AND Password = @Password;
END
GO
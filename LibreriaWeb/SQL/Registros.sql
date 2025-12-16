USE LibreriaDB;
GO

-- 1. Tabla para los Pedidos/Carrito
CREATE TABLE Pedidos (
    IdPedido INT IDENTITY(1,1) PRIMARY KEY,
    IdUsuario INT NOT NULL, -- Quién compra
    NombreCliente VARCHAR(100), -- Para mostrarlo fácil al vendedor
    IdLibro INT NOT NULL,
    TituloLibro VARCHAR(100),
    Cantidad INT DEFAULT 1,
    Fecha DATETIME DEFAULT GETDATE(),
    Estado VARCHAR(20) DEFAULT 'Pendiente' -- 'Pendiente', 'Aprobado'
);
GO

-- 2. Procedimiento para que el Vendedor registre Clientes Nuevos
CREATE PROCEDURE sp_RegistrarUsuario
    @Nombre VARCHAR(100),
    @Email VARCHAR(100),
    @Password VARCHAR(100),
    @Rol VARCHAR(20)
AS
BEGIN
    INSERT INTO Usuarios (NombreCompleto, Email, Password, Rol)
    VALUES (@Nombre, @Email, @Password, @Rol);
END
GO
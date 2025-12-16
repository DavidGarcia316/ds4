USE master;
GO

-- 1. Si la base de datos ya existe, la eliminamos para empezar de cero (LIMPIEZA)
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'LibreriaDB')
BEGIN
    ALTER DATABASE LibreriaDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE LibreriaDB;
END
GO

-- 2. Crear la Base de Datos
CREATE DATABASE LibreriaDB;
GO

USE LibreriaDB;
GO

-- =============================================
-- CREACIÓN DE TABLAS
-- =============================================

-- Tabla de Estados (Coincide con la lógica de colores de tu vista Razor)
CREATE TABLE Estados (
    IdEstado INT PRIMARY KEY,
    Nombre VARCHAR(50) -- 'Disponible', 'Agotado', 'Bajo Stock'
);

-- Tabla de Libros (Estructura adaptada a tu Modelo C#)
CREATE TABLE Libros (
    IdLibro INT IDENTITY(1,1) PRIMARY KEY,
    Titulo VARCHAR(150) NOT NULL,
    Autor VARCHAR(100), -- Agregado como dato extra, aunque el modelo básico use Titulo
    Categoria VARCHAR(50),
    Precio DECIMAL(10,2),
    Stock INT,
    IdEstado INT FOREIGN KEY REFERENCES Estados(IdEstado) DEFAULT 1
);

-- Tabla de Ventas (Cabecera)
CREATE TABLE Ventas (
    IdVenta INT IDENTITY(1,1) PRIMARY KEY,
    Cliente VARCHAR(100),
    Fecha DATETIME DEFAULT GETDATE(),
    Total DECIMAL(10,2)
);

-- Tabla de Detalle de Venta
CREATE TABLE DetalleVentas (
    IdDetalle INT IDENTITY(1,1) PRIMARY KEY,
    IdVenta INT FOREIGN KEY REFERENCES Ventas(IdVenta),
    IdLibro INT FOREIGN KEY REFERENCES Libros(IdLibro),
    Cantidad INT,
    Subtotal DECIMAL(10,2)
);
GO

-- =============================================
-- INSERCIÓN DE DATOS INICIALES (SEMILLA)
-- =============================================

-- 1. Insertar Estados
INSERT INTO Estados (IdEstado, Nombre) VALUES (1, 'Disponible');
INSERT INTO Estados (IdEstado, Nombre) VALUES (2, 'Agotado');
INSERT INTO Estados (IdEstado, Nombre) VALUES (3, 'Descontinuado');

-- 2. Insertar Libros Reales
-- Nota: Algunos tienen poco stock para que pruebes la alerta amarilla, y uno en 0 para la roja.

-- LITERATURA
INSERT INTO Libros (Titulo, Autor, Categoria, Precio, Stock, IdEstado) 
VALUES ('Cien años de soledad', 'Gabriel García Márquez', 'Novela', 19.99, 50, 1);

INSERT INTO Libros (Titulo, Autor, Categoria, Precio, Stock, IdEstado) 
VALUES ('El Principito', 'Antoine de Saint-Exupéry', 'Infantil', 12.50, 100, 1);

INSERT INTO Libros (Titulo, Autor, Categoria, Precio, Stock, IdEstado) 
VALUES ('1984', 'George Orwell', 'Ciencia Ficción', 15.00, 4, 1); -- Stock Bajo (Probar alerta amarilla)

INSERT INTO Libros (Titulo, Autor, Categoria, Precio, Stock, IdEstado) 
VALUES ('Don Quijote de la Mancha', 'Miguel de Cervantes', 'Clásicos', 25.00, 10, 1);

INSERT INTO Libros (Titulo, Autor, Categoria, Precio, Stock, IdEstado) 
VALUES ('Harry Potter y la Piedra Filosofal', 'J.K. Rowling', 'Fantasía', 22.00, 30, 1);

-- PROGRAMACIÓN Y TECNOLOGÍA
INSERT INTO Libros (Titulo, Autor, Categoria, Precio, Stock, IdEstado) 
VALUES ('Clean Code: A Handbook of Agile Software Craftsmanship', 'Robert C. Martin', 'Tecnología', 45.00, 15, 1);

INSERT INTO Libros (Titulo, Autor, Categoria, Precio, Stock, IdEstado) 
VALUES ('C# 10 and .NET 6 - Modern Cross-Platform Development', 'Mark J. Price', 'Tecnología', 55.00, 3, 1); -- Stock Bajo

INSERT INTO Libros (Titulo, Autor, Categoria, Precio, Stock, IdEstado) 
VALUES ('The Pragmatic Programmer', 'Andrew Hunt', 'Tecnología', 40.00, 0, 2); -- AGOTADO (Probar alerta roja)

INSERT INTO Libros (Titulo, Autor, Categoria, Precio, Stock, IdEstado) 
VALUES ('Introducción a SQL Server', 'Microsoft Press', 'Tecnología', 35.50, 20, 1);

INSERT INTO Libros (Titulo, Autor, Categoria, Precio, Stock, IdEstado) 
VALUES ('Design Patterns: Elements of Reusable Object-Oriented Software', 'Erich Gamma', 'Tecnología', 48.00, 8, 1);

GO

-- =============================================
-- PROCEDIMIENTOS ALMACENADOS (Lógica de Negocio)
-- =============================================

-- SP: Registra la venta, baja el stock y actualiza el estado si es necesario
CREATE PROCEDURE sp_RegistrarVenta
    @Cliente VARCHAR(100),
    @IdLibro INT,
    @Cantidad INT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @Precio DECIMAL(10,2);
    DECLARE @StockActual INT;
    DECLARE @IdVenta INT;
    DECLARE @NuevoStock INT;

    -- 1. Obtener datos actuales del libro
    SELECT @Precio = Precio, @StockActual = Stock 
    FROM Libros WHERE IdLibro = @IdLibro;

    -- 2. Validar que exista suficiente stock
    IF @StockActual >= @Cantidad
    BEGIN
        -- Iniciar Transacción (para asegurar que todo se guarde o nada)
        BEGIN TRANSACTION;

        BEGIN TRY
            -- Insertar Venta (Cabecera)
            INSERT INTO Ventas (Cliente, Total) 
            VALUES (@Cliente, @Precio * @Cantidad);
            
            -- Obtener el ID de la venta recién creada
            SET @IdVenta = SCOPE_IDENTITY();

            -- Insertar Detalle
            INSERT INTO DetalleVentas (IdVenta, IdLibro, Cantidad, Subtotal) 
            VALUES (@IdVenta, @IdLibro, @Cantidad, @Precio * @Cantidad);

            -- Actualizar Stock del Libro
            SET @NuevoStock = @StockActual - @Cantidad;
            
            UPDATE Libros 
            SET Stock = @NuevoStock 
            WHERE IdLibro = @IdLibro;

            -- Actualizar Estado: Si llega a 0, pasa a 'Agotado' (ID 2)
            IF @NuevoStock <= 0
            BEGIN
                UPDATE Libros SET IdEstado = 2 WHERE IdLibro = @IdLibro;
            END

            -- Confirmar transacción
            COMMIT TRANSACTION;
            
            SELECT 'Exito' AS Mensaje;
        END TRY
        BEGIN CATCH
            ROLLBACK TRANSACTION;
            SELECT 'Error en la base de datos: ' + ERROR_MESSAGE() AS Mensaje;
        END CATCH
    END
    ELSE
    BEGIN
        -- Retornar mensaje si no hay stock suficiente
        SELECT 'Error: Stock insuficiente. Solo quedan ' + CAST(@StockActual AS VARCHAR) + ' unidades.' AS Mensaje;
    END
END
GO
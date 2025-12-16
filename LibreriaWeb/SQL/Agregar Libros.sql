USE LibreriaDB;
GO

CREATE PROCEDURE sp_AgregarLibro
    @Titulo VARCHAR(100),
    @Categoria VARCHAR(50),
    @Precio DECIMAL(10,2),
    @Stock INT
AS
BEGIN
    -- 1. Validamos si el libro ya existe por el Título
    IF EXISTS (SELECT 1 FROM Libros WHERE Titulo = @Titulo)
    BEGIN
        -- SI EXISTE: Actualizamos el stock (sumamos lo nuevo a lo que había)
        UPDATE Libros 
        SET Stock = Stock + @Stock,
            Precio = @Precio -- Actualizamos el precio por si subió
        WHERE Titulo = @Titulo;
    END
    ELSE
    BEGIN
        -- NO EXISTE: Calculamos el estado inicial y creamos el libro
        DECLARE @IdEstado INT = 1 -- Default 'Disponible'
        IF @Stock = 0 SET @IdEstado = 3 -- 'Agotado'
        
        INSERT INTO Libros (Titulo, Categoria, Precio, Stock, IdEstado)
        VALUES (@Titulo, @Categoria, @Precio, @Stock, @IdEstado);
    END
END
GO
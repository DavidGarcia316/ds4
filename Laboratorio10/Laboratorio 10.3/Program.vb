Imports System

Module Program
    Sub Main()
        'declaración de variables
        Dim M As Double
        Dim G As Double
        Dim P As Double

        'Ingresar valores para las variables
        G = 9.8
        Console.WriteLine("Ingrese la masa del objeto:")
        M = Console.ReadLine

        'Realizar Procesos
        P = M * G

        ' Mostrar resultados
        Console.WriteLine("Peso del objeto: {0}", P)
        'Console.ReadKey()
    End Sub
End Module

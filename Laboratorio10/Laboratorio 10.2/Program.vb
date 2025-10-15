Imports System

Module Program
    Sub Main()
        Dim radio As Single
        Dim area As Single
        Dim circunferencia As Single
        Const pi = 3.1415926

        Console.WriteLine("Ingresa el radio: ")
        radio = Console.ReadLine

        area = pi * radio ^ 2
        circunferencia = 2 * pi * radio

        Console.WriteLine("El área es: {0}", area)
        Console.WriteLine("El circunferencia es: {0}", circunferencia)

        Console.ReadKey()

    End Sub
End Module

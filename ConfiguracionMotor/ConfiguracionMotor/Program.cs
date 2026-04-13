// Programa de pruebas para la clase ConfiguracionMotor
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Pruebas de ConfiguracionMotor ---\n");

        // Prueba 1: Iniciar y apagar correctamente
        try
        {
            var m1 = new ConfiguracionMotor(5000, 25);
            Console.WriteLine("Prueba 1: Intentando iniciar motor (valores válidos)...");
            m1.IniciarMotor();
            m1.ApagarMotor();
            Console.WriteLine("Prueba 1: OK\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Prueba 1: Falló -> {ex.GetType().Name}: {ex.Message}\n");
        }

        // Prueba 2: Intentar iniciar cuando ya está encendido
        try
        {
            var m2 = new ConfiguracionMotor(5000, 20);
            Console.WriteLine("Prueba 2: Iniciando por primera vez...");
            m2.IniciarMotor();
            Console.WriteLine("Prueba 2: Intentando iniciar de nuevo (debe mostrar aviso)...");
            m2.IniciarMotor();
            m2.ApagarMotor();
            Console.WriteLine("Prueba 2: OK\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Prueba 2: Falló -> {ex.GetType().Name}: {ex.Message}\n");
        }

        // Prueba 3: Temperatura fuera de rango al iniciar
        try
        {
            Console.WriteLine("Prueba 3: Intentando crear e iniciar con temperatura fuera de rango...");
            var m3 = new ConfiguracionMotor(5000, -30);
            m3.IniciarMotor();
            Console.WriteLine("Prueba 3: ERROR - No lanzó excepción esperada\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Prueba 3: Excepción esperada -> {ex.GetType().Name}: {ex.Message}\n");
        }

        // Prueba 4: Potencia insuficiente (debe fallar al asignar la propiedad)
        try
        {
            Console.WriteLine("Prueba 4: Intentando crear con potencia insuficiente (500)...");
            var m4 = new ConfiguracionMotor(500, 20);
            Console.WriteLine("Prueba 4: ERROR - No lanzó excepción al crear con potencia insuficiente\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Prueba 4: Excepción esperada -> {ex.GetType().Name}: {ex.Message}\n");
        }

        // Prueba 5: Acelerar con motor apagado
        try
        {
            Console.WriteLine("Prueba 5: Intentando acelerar con motor apagado...");
            var m5 = new ConfiguracionMotor(5000, 20);
            m5.AcelerarMotor(100);
            Console.WriteLine("Prueba 5: ERROR - No lanzó excepción al acelerar motor apagado\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Prueba 5: Excepción esperada -> {ex.GetType().Name}: {ex.Message}\n");
        }

        // Prueba 6: Acelerar con incremento no positivo
        try
        {
            Console.WriteLine("Prueba 6: Iniciando motor y acelerando con incremento 0 (debe lanzar ArgumentOutOfRange)...");
            var m6 = new ConfiguracionMotor(5000, 20);
            m6.IniciarMotor();
            m6.AcelerarMotor(0);
            Console.WriteLine("Prueba 6: ERROR - No lanzó excepción al usar incremento 0\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Prueba 6: Excepción esperada -> {ex.GetType().Name}: {ex.Message}\n");
        }

        // Prueba 7: Acelerar que excede potencia máxima
        try
        {
            Console.WriteLine("Prueba 7: Intentando acelerar más allá del límite de potencia...");
            var m7 = new ConfiguracionMotor(19950, 20);
            m7.IniciarMotor();
            m7.AcelerarMotor(100);
            Console.WriteLine("Prueba 7: ERROR - No lanzó excepción al exceder potencia máxima\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Prueba 7: Excepción esperada -> {ex.GetType().Name}: {ex.Message}\n");
        }

        // Prueba 8: Acelerar que causaría sobrecalentamiento
        try
        {
            Console.WriteLine("Prueba 8: Intentando acelerar causando sobrecalentamiento...");
            var m8 = new ConfiguracionMotor(5000, 99);
            m8.IniciarMotor();
            m8.AcelerarMotor(40); // aumenta 2 grados -> 101
            Console.WriteLine("Prueba 8: ERROR - No lanzó excepción al causar sobrecalentamiento\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Prueba 8: Excepción esperada -> {ex.GetType().Name}: {ex.Message}\n");
        }

        // Prueba 9: Aceleración válida
        try
        {
            Console.WriteLine("Prueba 9: Aceleración válida (debe ejecutarse sin excepciones)...");
            var m9 = new ConfiguracionMotor(5000, 20);
            m9.IniciarMotor();
            m9.AcelerarMotor(100); // aumenta 5 grados
            Console.WriteLine("Prueba 9: OK (no hay cambios visibles porque la implementación no asigna los nuevos valores)\n");
            m9.ApagarMotor();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Prueba 9: Falló -> {ex.GetType().Name}: {ex.Message}\n");
        }

        Console.WriteLine("--- Fin de las pruebas ---");
    }
}

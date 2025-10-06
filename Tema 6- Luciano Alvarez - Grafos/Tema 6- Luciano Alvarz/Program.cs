using System;
using System.Collections.Generic;
using System.Linq;

public class Programa
{
    public static void Main(string[] args)
    {
        var g = new GrafoManual();

        g.AgregarArista("Base de Rescate", "Puesto A", 8);
        g.AgregarArista("Base de Rescate", "Puesto C", 15);
        g.AgregarArista("Puesto A", "Puesto D", 9);
        g.AgregarArista("Puesto A", "Puesto B", 10);
        g.AgregarArista("Puesto D", "Puesto B", 11);
        g.AgregarArista("Puesto D", "Objetivo", 5);
        g.AgregarArista("Puesto C", "Puesto B", 7);
        g.AgregarArista("Puesto C", "Objetivo", 7);
        g.AgregarArista("Puesto B", "Objetivo", 5);

        g.AgregarArista("Puesto A", "Base de Rescate", 8);
        g.AgregarArista("Puesto C", "Base de Rescate", 15);
        g.AgregarArista("Puesto D", "Puesto A", 9);
        g.AgregarArista("Puesto B", "Puesto A", 10);
        g.AgregarArista("Puesto B", "Puesto D", 11);
        g.AgregarArista("Objetivo", "Puesto D", 5);
        g.AgregarArista("Puesto B", "Puesto C", 7);
        g.AgregarArista("Objetivo", "Puesto C", 7);
        g.AgregarArista("Objetivo", "Puesto B", 5);

        var baseRescate = "Base de Rescate";
        var objetivo = "Objetivo";
        var alg = new LogicaRescate();
        
        int maxDuracion = 12;
        var ruta = alg.rutaRescateOptima(g, baseRescate, objetivo, maxDuracion);

        Console.WriteLine("--- Prueba 1: Restricción de 12 minutos ---");
        Console.WriteLine("Max Duración: {0}", maxDuracion);
        if (ruta != null && ruta.Any())
        {
            Console.WriteLine("Ruta Óptima encontrada: {0}", string.Join(" -> ", ruta));
        }
        else
        {
            Console.WriteLine("No se encontró ninguna ruta que cumpla la restricción.");
        }
        
        maxDuracion = 25; 
        ruta = alg.rutaRescateOptima(g, baseRescate, objetivo, maxDuracion);
        
        Console.WriteLine("\n--- Prueba 2: Restricción de 25 minutos ---");
        Console.WriteLine("Max Duración: {0}", maxDuracion);
        
        if (ruta != null && ruta.Any())
        {
            Console.WriteLine("Ruta Óptima encontrada: {0}", string.Join(" -> ", ruta));
        }
        else
        {
            Console.WriteLine("No se encontró ninguna ruta que cumpla la restricción.");
        }

        Console.ReadKey();
    }
}
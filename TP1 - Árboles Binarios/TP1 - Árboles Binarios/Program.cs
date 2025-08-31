using System;
using tp1;

class Program
{
    static void Main()
    {
        ArbolBinario<int> raiz = new ArbolBinario<int>(0);
        raiz.agregarHijoIzquierdo(new ArbolBinario<int>(1));
        raiz.agregarHijoDerecho(new ArbolBinario<int>(4));
        raiz.getHijoIzquierdo().agregarHijoIzquierdo(new ArbolBinario<int>(2));
        raiz.getHijoIzquierdo().agregarHijoDerecho(new ArbolBinario<int>(3));
        raiz.getHijoDerecho().agregarHijoDerecho(new ArbolBinario<int>(5));

        ProfundidadDeArbolBinario prof = new ProfundidadDeArbolBinario(raiz);

        int suma = prof.sumaElementosProfundidad(2);
        Console.WriteLine("suma de los nodos en profundidad 2: " + suma);

        Console.ReadKey();
    }
}

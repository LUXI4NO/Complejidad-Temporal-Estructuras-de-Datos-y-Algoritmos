using System;

namespace tp1
{
    public class ProfundidadDeArbolBinario
    {
        private ArbolBinario<int> arbol;

        public ProfundidadDeArbolBinario(ArbolBinario<int> arbol)
        {
            this.arbol = arbol;
        }

        public int sumaElementosProfundidad(int p)
        {
            return sumar(this.arbol, p, 0);
        }

        private int sumar(ArbolBinario<int> nodo, int nivelBuscado, int nivelActual)
        {
            if (nodo == null) return 0;

            if (nivelActual == nivelBuscado)
                return nodo.getDatoRaiz();

            int sumaIzq = sumar(nodo.getHijoIzquierdo(), nivelBuscado, nivelActual + 1);
            int sumaDer = sumar(nodo.getHijoDerecho(), nivelBuscado, nivelActual + 1);

            return sumaIzq + sumaDer;
        }
    }
}

using System;
using System.Collections.Generic;

namespace tp2
{
    public class ArbolGeneral<T>
    {
        private T datoRaiz;
        private List<ArbolGeneral<T>> listaHijos;

        public ArbolGeneral(T dato)
        {
            datoRaiz = dato;
            listaHijos = new List<ArbolGeneral<T>>();
        }

        public T ObtenerDato()
        {
            return datoRaiz;
        }

        public List<ArbolGeneral<T>> ObtenerHijos()
        {
            return listaHijos;
        }

        public void AgregarHijo(ArbolGeneral<T> hijo)
        {
            listaHijos.Add(hijo);
        }

        public void QuitarHijo(ArbolGeneral<T> hijo)
        {
            listaHijos.Remove(hijo);
        }

        public bool EsHoja()
        {
            return listaHijos.Count == 0;
        }

        public int CalcularAltura()
        {
            if (EsHoja())
                return 0;

            int alturaMax = 0;
            foreach (var hijo in listaHijos)
            {
                int alturaHijo = hijo.CalcularAltura();
                if (alturaHijo > alturaMax)
                    alturaMax = alturaHijo;
            }
            return alturaMax + 1;
        }

        public int NivelDe(T datoBuscado, int nivelActual = 0)
        {
            if (datoRaiz != null && datoRaiz.Equals(datoBuscado))
                return nivelActual;

            foreach (var hijo in listaHijos)
            {
                int nivelEncontrado = hijo.NivelDe(datoBuscado, nivelActual + 1);
                if (nivelEncontrado != -1)
                    return nivelEncontrado;
            }

            return -1;
        }
    }
}

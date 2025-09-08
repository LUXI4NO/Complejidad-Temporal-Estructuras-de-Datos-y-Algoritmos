using System.Collections.Generic;

namespace tp2
{
    public class Estrategia
    {
        public List<Neumatico> ObtenerMejorEstrategia(ArbolGeneral<Neumatico> arbol)
        {
            if (arbol == null)
                return new List<Neumatico>();

            List<Neumatico> mejorEstrategia = new List<Neumatico>();
            double tiempoMenor = double.MaxValue;

            BuscarMejor(arbol, new List<Neumatico>(), 0, null, ref mejorEstrategia, ref tiempoMenor);

            return mejorEstrategia;
        }

        private void BuscarMejor(ArbolGeneral<Neumatico> nodo, List<Neumatico> estrategiaActual,
                                 double tiempoActual, Neumatico anterior,
                                 ref List<Neumatico> mejorEstrategia, ref double tiempoMenor)
        {
            Neumatico neumático = nodo.ObtenerDato();

            if (neumático != null)
            {
                tiempoActual += neumático.CalcularTiempo();

                if (anterior != null && neumático.Categoria != anterior.Categoria)
                    tiempoActual += 10;

                estrategiaActual.Add(neumático);
            }

            if (nodo.EsHoja())
            {
                if (tiempoActual < tiempoMenor)
                {
                    tiempoMenor = tiempoActual;
                    mejorEstrategia = new List<Neumatico>(estrategiaActual);
                }
            }
            else
            {
                foreach (var hijo in nodo.ObtenerHijos())
                {
                    BuscarMejor(hijo, estrategiaActual, tiempoActual, neumático, ref mejorEstrategia, ref tiempoMenor);
                }
            }

            if (neumático != null)
                estrategiaActual.RemoveAt(estrategiaActual.Count - 1);
        }
    }
}

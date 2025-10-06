using System.Collections.Generic;
using System.Linq;

public class LogicaRescate
{
    private List<string> rutaOptima = new List<string>();
    private int pesoMinimo = int.MaxValue;

    public List<string> rutaRescateOptima(GrafoManual grafo, 
                                         string baseRescate, 
                                         string objetivo, 
                                         int maxDuracion)
    {
        pesoMinimo = int.MaxValue;
        rutaOptima = new List<string>();
        
        var visitados = new HashSet<string>();
        var rutaActual = new List<string>();

        visitados.Add(baseRescate);
        rutaActual.Add(baseRescate);

        buscarCaminos(grafo, 
                      baseRescate, 
                      objetivo, 
                      maxDuracion, 
                      0, 
                      visitados, 
                      rutaActual);

        return rutaOptima;
    }

    private void buscarCaminos(GrafoManual grafo,
                               string actual,
                               string destino,
                               int maxDuracion,
                               int duracionActual,
                               HashSet<string> visitados,
                               List<string> rutaActual)
    {
        if (duracionActual > maxDuracion || duracionActual >= pesoMinimo)
        {
            return;
        }

        if (actual.Equals(destino))
        {
            if (duracionActual < pesoMinimo)
            {
                pesoMinimo = duracionActual;
                rutaOptima = new List<string>(rutaActual);
            }
            return; 
        }

        foreach (var adyacente in grafo.ObtenerAdyacentesConPeso(actual))
        {
            var siguiente = adyacente.Key;
            var peso = adyacente.Value;

            if (!visitados.Contains(siguiente))
            {
                visitados.Add(siguiente);
                rutaActual.Add(siguiente);

                buscarCaminos(grafo, 
                              siguiente, 
                              destino, 
                              maxDuracion, 
                              duracionActual + peso, 
                              visitados, 
                              rutaActual);

                rutaActual.RemoveAt(rutaActual.Count - 1);
                visitados.Remove(siguiente);
            }
        }
    }
}
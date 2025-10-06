using System.Collections.Generic;

public class GrafoManual
{
    private Dictionary<string, Dictionary<string, int>> Adyacencias;

    public GrafoManual()
    {
        Adyacencias = new Dictionary<string, Dictionary<string, int>>();
    }

    public void AgregarArista(string origen, string destino, int peso)
    {
        if (!Adyacencias.ContainsKey(origen))
        {
            Adyacencias.Add(origen, new Dictionary<string, int>());
        }
        Adyacencias[origen].Add(destino, peso);
    }

    public IEnumerable<KeyValuePair<string, int>> ObtenerAdyacentesConPeso(string origen)
    {
        if (Adyacencias.ContainsKey(origen))
        {
            return Adyacencias[origen];
        }
        return new Dictionary<string, int>();
    }
}
using System;

namespace tp2
{
    public enum TipoNeumatico { Soft, Med, Hard }

    public class Neumatico
    {
        public int CantidadVueltas { get; set; }
        public TipoNeumatico Categoria { get; set; }

        public Neumatico(int vueltas, TipoNeumatico tipo)
        {
            CantidadVueltas = vueltas;
            Categoria = tipo;
        }

        public double CalcularTiempo()
        {
            switch (Categoria)
            {
                case TipoNeumatico.Soft: return CantidadVueltas * 0.2;
                case TipoNeumatico.Med: return CantidadVueltas * 0.4;
                case TipoNeumatico.Hard: return CantidadVueltas * 0.7;
                default: return 0;
            }
        }

        public override string ToString()
        {
            return CantidadVueltas + " vueltas - " + Categoria;
        }
    }
}

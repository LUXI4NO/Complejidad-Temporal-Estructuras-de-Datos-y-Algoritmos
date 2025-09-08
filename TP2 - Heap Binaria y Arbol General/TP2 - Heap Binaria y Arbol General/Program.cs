using System;
using System.Collections.Generic;

namespace tp2
{
    class Program
    {
        static void Main()
        {
            ArbolGeneral<Neumatico> arbolNeumaticos = new ArbolGeneral<Neumatico>(null);

            var softInicio = new ArbolGeneral<Neumatico>(new Neumatico(10, TipoNeumatico.Soft));
            var softMedia = new ArbolGeneral<Neumatico>(new Neumatico(10, TipoNeumatico.Soft));
            var hardFinal = new ArbolGeneral<Neumatico>(new Neumatico(30, TipoNeumatico.Hard));
            softMedia.AgregarHijo(hardFinal);
            softInicio.AgregarHijo(softMedia);
            arbolNeumaticos.AgregarHijo(softInicio);

            var hardCorto = new ArbolGeneral<Neumatico>(new Neumatico(20, TipoNeumatico.Hard));
            var hardLargo = new ArbolGeneral<Neumatico>(new Neumatico(30, TipoNeumatico.Hard));
            hardCorto.AgregarHijo(hardLargo);
            arbolNeumaticos.AgregarHijo(hardCorto);
            
            var hardInicial = new ArbolGeneral<Neumatico>(new Neumatico(20, TipoNeumatico.Hard));
            var mediano = new ArbolGeneral<Neumatico>(new Neumatico(15, TipoNeumatico.Med));
            var medianoFinal = new ArbolGeneral<Neumatico>(new Neumatico(15, TipoNeumatico.Med));
            mediano.AgregarHijo(medianoFinal);
            hardInicial.AgregarHijo(mediano);
            arbolNeumaticos.AgregarHijo(hardInicial);

            var hardPrincipal = new ArbolGeneral<Neumatico>(new Neumatico(35, TipoNeumatico.Hard));
            var softSecundario = new ArbolGeneral<Neumatico>(new Neumatico(15, TipoNeumatico.Soft));
            hardPrincipal.AgregarHijo(softSecundario);
            arbolNeumaticos.AgregarHijo(hardPrincipal);

            Estrategia calculador = new Estrategia();
            List<Neumatico> mejorRuta = calculador.ObtenerMejorEstrategia(arbolNeumaticos);

            Console.WriteLine("Mejor estrategia de neumáticos:");
            foreach (var neumatico in mejorRuta)
                Console.WriteLine(neumatico);

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;

namespace Tema
{
    public class expresionesLambda
    {
        // Sintaxis -> (parametros) => instrucciones
        public void lambdaPrimitivos()
        {

            List<int> numeros = new List<int> {1,2,3,4,5,6,7,8,9};

            List<int> numerosPares = numeros.FindAll(i => i % 2 == 0);

            foreach (int numero in numerosPares) Console.WriteLine(numero);

            // Otra forma de hacerlo con operador LAMBDA => numerosPares.ForEach(numero => Console.WriteLine(numero));

        }

        public void lambdaObjetos()
        {
            Humanos P1 = new Humanos();
            P1.Nombre = "Juan";
            P1.Edad = 18;

            Humanos P2 = new Humanos();
            P2.Nombre = "Maria";
            P2.Edad = 28;

            ComparaPersonas comparaEdad = (persona1, persona2) => persona1 == persona2;

            Console.WriteLine(comparaEdad(P1.Edad, P2.Edad));

        }

        public delegate bool ComparaPersonas(int edad1, int edad21);

    }

    public class Humanos
    {
        private string nombre;
        private int edad;

        public string Nombre { get => nombre; set => nombre = value; }
        public int Edad { get => edad; set => edad = value; }
    }

}






using System;

namespace Ejercicio
{
    public class manejoVariables
    {
        public void manVar()
        {

            int edadPersona1;
            int edadPersona2;
            int edadPersona3;
            int edadPersona4;

            //Asignacion de un mismo valor a varias variables
            edadPersona1 = edadPersona2 = edadPersona3 = edadPersona4 = 27;

            //Declaracion implicita de variables -> El compilador asigna el tipo de variable en tipo de ejecucion, segun el valor asignado.
            //Se declara y se inicia en la misma linea.
            var edadPersona5 = 27;

            //Conversion explicita o casting
            double celcius = 34;
            int temperatura;
            temperatura = (int)celcius;

            //Conversion implicita. Depende de las jerarquias de precision.
            int habitantesCiudad = 10000000;
            long habitantesCiudad2018 = habitantesCiudad;

            float pesoMaterial = 5.78F;
            double pesoMaterialPrec = pesoMaterial;

            Console.WriteLine(pesoMaterialPrec);
        }
    }
}

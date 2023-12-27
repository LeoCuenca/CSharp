using System;

namespace Tema
{
    // Los ENUM son un conjunto de constantes con nombre.
    // Se usan para representar y manejar valores fijos (constantes) en un programa.

    public enum Bonus { Bajo = 500, Normal = 1000, Bueno = 1500, Extra = 3000 };

    public class TiposEnum
    {
        // No son STRINGS, son CONSTANTES ... es por esto que no van entrecomilladas.
        enum Estaciones { Primavera, Verano, Otoño, Invierno };

        public void ejecutar()
        {

            double salarioFreeman = 1500;
            Bonus Freeman = Bonus.Bueno;

            Estaciones alergia = Estaciones.Primavera;
            Console.WriteLine($"\n\t{alergia}");

            // Si intento asignar a una variable de tipo STRING uno de estos tipos enumerados, va a dar error porque es una constante, no un STRING.
            // Pero si trato al tipo enumerado como STRING mediante el metodo ToString(), entonces si puedo asignarlo e incluso concatenar varios.
            string la_alergia = $"{Estaciones.Primavera.ToString()} + {Estaciones.Verano.ToString()}";
            Console.WriteLine($"\n\t{la_alergia}");

            //Si por alguna razon necesito asignar el nulo a un enum, se debe utilizar el '?'
            Estaciones? alegria = null;
            Console.WriteLine($"\n\tAlegria ahora vale nulo : ({alegria})");

            // Si quisiera ver el valor de cada una de las constantes del ENUM 'Bonus', tengo que hacer un casting
            double bonusFreeman = (double)Freeman;
            Console.WriteLine($"\n\tEl bonus de Freeman es de $ {bonusFreeman}");

            Empleado Juan = new Empleado(Bonus.Extra, 1900.50);

            Console.WriteLine($"El salario del empleado es : {Juan.getSalario}");

        }


    }

    public class Empleado
    {

        public Empleado(Bonus bonusEmpleado, double salario)
        {

            bonus = (double)bonusEmpleado;
            this.salario = salario;

        }

        public double getSalario => salario + bonus;

        private double salario, bonus;


    }
}







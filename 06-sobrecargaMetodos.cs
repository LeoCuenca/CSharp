using System;

namespace Ejercicio
{
    public class sobrecargaMetodos
    {
        // Para sobrecargar metodos, los mismo deben tener el mismo nombre, PERO deben recibir o bien, distintos tipos de parametros, o bien distinta cantidad de parametros (Los utilice o no)

        public void suma(int operador1, int operador2) => Console.WriteLine($"Suma de {operador1} + {operador2} con el metodo 'suma()' con 2 parametros enteros : {operador1 + operador2}");
        public void suma(int numero1, int numero2, int numero3) => Console.WriteLine($"Suma de {numero1} + {numero2} con el metodo sobrecargado 'suma()' que recibe 3 parametros enteros, pero solo utiliza 2 en este caso : {numero1 + numero2}");
        public void suma(float numero1, float numero2, float numero3) => Console.WriteLine($"Suma de {numero1} + {numero2} + {numero3}con el metodo sobrecargado 'suma()' que recibe 3 parametros, utilizando esta vez 3 float: {numero1 + numero2 + numero3}");
        public void parametrosOpcionales(int num1, double num2, double num3 = 0) => Console.WriteLine($"		El metodo recibe 3 parametros, de los cuales el ultimo es opcional, ya que fue asignado el valor 0 por defecto. El resultado de la suma de {num1} + {num2} + {num3} = {num1 + num2 + num3}");

    }
}

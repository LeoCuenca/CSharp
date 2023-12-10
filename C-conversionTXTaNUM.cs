using System;

public class converstionTXTaNUM
{
	public void convNUM()
	{
        const float PI = 3.1416F;
        //.Parse convierte un texto a lo que precede al punto.
        Console.WriteLine("Introduce el primer numero: ");
        int num1 = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Introduce el segundo numero: ");
        int num2 = int.Parse(Console.ReadLine());


        Console.WriteLine($"La suma del numero {num1} + {num2} es igual a {num1+num2}");
        //Otra forma de mandar mensajes
        Console.WriteLine("La suma del numero {0} + {1} es igual a {2}", num1, num2, num1+num2);

        Console.WriteLine("Introduzca la medida del radio: ");
        
        double radio = double.Parse(Console.ReadLine());

        //Dos formas de expresar lo mismo
        Console.WriteLine("El area del circulo es: {0}", radio * radio * PI);
        Console.WriteLine("El area del circulo es: {0}", Math.Pow(radio, 2) * PI);

    }
}

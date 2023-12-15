using System;

public class impresionStrings
{
	public void impStr()
	{

        //Podemos crear Clases Predefinidas ó Biblioteca de clases ó API's
        int edad = 19;
        //Declaracion de Strings concatenando normalmente
        Console.WriteLine("\tStrings Normalmente -> Tienes una edad de " + edad + " años");
        //Interpolacion de Strings
        Console.WriteLine($"\tInterpolacion de Strings -> Tienes una edad de {edad} años");
        //Concepto de preincremento y postincremento. El flujo de lectura del codigo es de arriba a abajo y de izquierda a derecha
        Console.WriteLine($"\tPostincremento -> Tenes {edad++} años. Se imprime y luego se incrementa");
        //Linea para volver edad a 19
        edad -= 1;
        Console.WriteLine($"\tPreincremento -> Tenes {++edad} años. Se incremente y luego se imprime");

        Console.WriteLine("\t\t\nPresione cualquier tecla para volver atras ... ");
        Console.ReadLine();

    }
}

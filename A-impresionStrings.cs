using System;

public class impresionStrings
{
	public void impStr()
	{
        //Podemos crear Clases Predefinidas ó Biblioteca de clases ó API's
        int edad = 19;
        //Declaracion de Strings concatenando normalmente
        Console.WriteLine("Strings Normalmente -> Tienes una edad de " + edad + " años");
        //Interpolacion de Strings
        Console.WriteLine($"Interpolacion de Strings -> Tienes una edad de {edad} años");
        //Concepto de preincremento y postincremento. El flujo de lectura del codigo es de arriba a abajo y de izquierda a derecha
        Console.WriteLine($"Postincremento -> Tenes {edad++} años. Se imprime y luego se incrementa");
        //Linea para volver edad a 19
        edad -= 1;
        Console.WriteLine($"Preincremento -> Tenes {++edad} años. Se incremente y luego se imprime");
    }
}

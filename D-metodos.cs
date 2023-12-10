using System;

public class metodos
{
	public void met()
	{
        Console.WriteLine("     Mensaje en pantalla desde metodos.met");
    }

    public void sumaNumeros(int num1, int num2)
    {
        Console.WriteLine($"        La suma es : {num1+num2}");
    }

    public int multiplicacionNumeros(int num1, int num2)
    {
        return num1 * num2;
    }

    public double divisionNumeros(double num1, int num2)
    {
        return num1 / num2;
    }

    // Cuando hay una sola linea dentro del metodo, se puede simplificar la sintaxis utilizando el operador flecha. A la izquierda va la declaracion del metodo y a la derecha, lo que queremos que nos devuelva.
    public double divNumFlecha(double num1, double num2) => num1 / num2;

}

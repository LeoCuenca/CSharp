using System;

//Las estructuras, como bien se sabe ya desde C/C++, trabajan en la pila (Stack), mientras que las clases trabajan en el HEAP. Los cambios se reflejan por refencia en una clase, cosa que no pasa en las estructuras, ya 
//que se crea una copia de la estructura en la pila. Es por eso que los cambios no se ven reflejados, solo muestra los valores pasados por parametro.

/*
 Diferencias de STRUCTS con CLASES

	- No permite declaracion de constructor por defecto
	- El compilador no incia los campos. Puedes iniciarlos en el constructor
	- No puede haber sobrecarga de constructores
	- No heredan de otras clases pero si implementan interfaces
	- Son selladas (Sealed)
 */

public class Estructuras
{

	public void ejecutar()
	{
		Empleado empleado1 = new Empleado(1200, 250);

		empleado1.cambiaSalario(empleado1, 100);

        Console.WriteLine(empleado1);
    }


	public struct Empleado
	{
		private double salarioBase, comision;

		public Empleado(int salarioBase, int comision)
		{
			this.salarioBase = salarioBase;
			this.comision = comision;
		}

		public override string ToString() => string.Format($"Salario y comision del empleado {this.salarioBase}, {this.comision}");

		public void cambiaSalario(Empleado emp, double incremente)
		{
			emp.salarioBase += incremente;
			emp.comision += incremente;
		}

    }









}

using System;

namespace Tema
{
    public class Properties
    {
        public void ejecutar()
        {
            Empleado employer = new Empleado();
            employer.SALARIO = 1200;
            Console.WriteLine($"El salario del empleado es : {employer.SALARIO}");
        }

        public class Empleado
        {

            private string nombre;
            private double salario;

            //public Empleado(string nombre) => this.nombre = nombre;

            //public void setSalario(double salario)
            //{
            //	if (salario < 0)
            //	{
            //		Console.WriteLine("El salario no puede ser negativo. Se asignara 0 como salario");
            //		this.salario = 0;
            //	}
            //	else
            //	{
            //		this.salario = salario;
            //	}
            //}

            //METODO DE CONTROL
            private double evaluaSalario(double salario)
            {
                if (salario < 0)
                {
                    return 0;
                }
                else
                {
                    return salario;
                }
            }

            //CREACION DE PROPIEDAD
            //Sacando el get o set se puede hacer una propiedad de solo lectura o solo escritura
            public double SALARIO
            {
                get => this.salario;
                set => this.salario = evaluaSalario(value);
            }

            //public double getSalario() => salario;

        }
    }
}

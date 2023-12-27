using System;

namespace Tema
{
    // Declaracion de una clase con restriccion
    public class AlmacenEmpleados<T> where T: IParaEmpleados
    {
        private int i = 0;
        private T[] datosEmpleado;

        public AlmacenEmpleados(int z)
        {
            datosEmpleado = new T[z];
        }

        public void agregar(T obj)
        {
            datosEmpleado[i] = obj;
            i++;
        }

        public T getEmpleado(int i) => datosEmpleado[i];

    }

    public class Director : IParaEmpleados
    {
        private double salario;

        public Director(double salario)
        {
            this.salario = salario;
        }

        public double getSalario() => salario;

    }

    class Secretaria : IParaEmpleados
    {
        private double salario;

        public Secretaria(double salario)
        {
            this.salario = salario;
        }

        public double getSalario() => salario;

    }

    class Electricista : IParaEmpleados
    {
        private double salario;

        public Electricista(double salario)
        {
            this.salario = salario;
        }

        public double getSalario() => salario;

    }

    public interface IParaEmpleados
    {
        double getSalario();
    }

}

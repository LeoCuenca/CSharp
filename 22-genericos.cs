using System;

namespace Ejercicio
{
    public class Genericos
    {

        public void ejecutar()
        {
            // Instansiacion de una clase generica.
            // Con tal solo cambiar el tipo de dato que se va a manejar entre los parentesis en punta, es suficiente para tratar otro tipos de objetos.
            AlmacenObjetos<DateTime> archivos = new AlmacenObjetos<DateTime>(4);

            //archivos.agregar("Juan");
            //archivos.agregar("Elena");
            //archivos.agregar("Antonio");
            //archivos.agregar("Sandra");

            archivos.agregar(new DateTime());
            archivos.agregar(new DateTime());
            archivos.agregar(new DateTime());
            archivos.agregar(new DateTime());

            //archivos.agregar(new EmpleadoGenerico(1000));
            //archivos.agregar(new EmpleadoGenerico(1500));
            //archivos.agregar(new EmpleadoGenerico(2000));
            //archivos.agregar(new EmpleadoGenerico(2500));

            DateTime salarioEmpleado = archivos.getElemento(2);
            Console.WriteLine(salarioEmpleado);

        }

    }

    // Creacion de una clase generica, por convencion se utiliza la T mayuscula en el generico. Con este <T> le estamos diciendo que este objeto va a poder manejar cualquier tipo de OBJETO.
    public class AlmacenObjetos<T>
    {
        // Constructor que recibe como parametro la cantidad de elementos del ARRAY
        public AlmacenObjetos(int z)
        {
            datosElemento = new T[z];
        }

        // Metodo que permite agregar un nuevo elemento al ARRAY
        public void agregar(T obj)
        {
            datosElemento[i] = obj;
            i++;
        }

        // Metodo getter que devuelve los datos del objeto generico. 
        public T getElemento(int i) => datosElemento[i];

        private T[] datosElemento;
        private int i = 0;

    }

    public class EmpleadoGenerico
    {
        public EmpleadoGenerico(double salario)
        {
            this.salario = salario;
        }

        public double getSalario() => salario;

        private double salario;
    }


}
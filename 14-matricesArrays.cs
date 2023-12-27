using System;

namespace Tema
{
    public class matricesArrays
    {
        //Declaracion: int[] miMatriz;
        //Iniciacion: miMatriz = new int[4];
        //Una linea : int[] miMatriz = new int[4];

        public void listarEmpleados()
        {

            //array implicito. En funcion del tipo de datos recibidos en los corchetes, de ese tipo sera el Array. En este ej. 'datos' sera double.
            var datos = new[] { 1, 2, 3, 4.5 };

            //array de objetos
            Empleados[] arrayEmpleados = new Empleados[2];

            //Asignacion del objeto 'arrayEmpleados' de tipo 'Empleados' en la posicion [0] del array con un nuevo objeto 'Empleados', pasandole los parametros que pide el constructor de la clase.
            arrayEmpleados[0] = new Empleados("Sara", 37);

            //Otra forma de hacer lo mismo de arriba, creo un objeto 'Ana' de tipo 'Empleados', pasandole como parametros los datos que nos pide el constructor de la clase 'Empleados'
            Empleados Ana = new Empleados("Ana", 27);
            arrayEmpleados[1] = Ana;

            //Array de tipos o clases anonimas
            var personas = new[]
            {
            new {Nombre= "Juan", edad = 19},
            new {Nombre= "Maria", edad = 49},
            new {Nombre= "Diana", edad = 35}
        };

            Console.WriteLine("\n\tRecorriendo el objeto 'arrayEmpleados' de la clase Empleados con el BUCLE FOR.");
            for (int i = 0; i < arrayEmpleados.Length; i++)
            {
                Console.WriteLine($"\t\tEl nombre del {i + 1}º empleado/a es {arrayEmpleados[i].getNombre()} y tiene {arrayEmpleados[i].getEdad()} años.");
            }

            Console.WriteLine("\n\tRecorriendo el objeto 'arrayEmpleados' de la clase Empleados con el BUCLE FOREACH.");
            foreach (Empleados obj in arrayEmpleados)
            {
                Console.WriteLine($"\t\tEl nombre del empleado/a es {obj.getNombre()} y tiene {obj.getEdad()} años.");
            }

            Console.WriteLine("\n\tRecorriendo el array IMPLICITO 'datos' con el BUCLE FOREACH.");
            foreach (var num in datos)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("\n\tRecorriendo el array ANONIMO 'personas' con el BUCLE FOREACH.");
            foreach (var per in personas)
            {
                Console.WriteLine($"\t\tEl nombre del empleado/a es {per.Nombre} y tiene {per.edad} años.");
            }

        }

        public void cargarArray(int[] arrayACargar)
        {
            for (int i = 0; i < 4; i++)
            {
                Console.Write($"\tIngrese el {i + 1}º valor : ");
                arrayACargar[i] = int.Parse(Console.ReadLine()!);
            }
        }

        public void mostrarFor(int[] aMostrar)
        {
            Console.WriteLine("\tMOSTRANDO EL CONTENIDO DE LEGAJOS CON BUCLE FOR");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"\t{aMostrar[i]}");
            }
        }

        public void mostrarForEach(int[] aMostrar)
        {
            Console.WriteLine("\tMOSTRANDO EL CONTENIDO DE LEGAJOS CON BUCLE FOR EACH");
            foreach (int i in aMostrar)
            {
                Console.WriteLine($"\t{i}");
            }

        }

        //Constructor
        class Empleados
        {
            private string nombre;
            private int edad;

            public Empleados(string nombre, int edad)
            {
                this.nombre = nombre;
                this.edad = edad;
            }
            public string getNombre() => nombre;
            public int getEdad() => edad;
        }
    }
}


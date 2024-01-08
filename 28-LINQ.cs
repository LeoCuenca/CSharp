using System;

namespace Tema
{    
    public class LINQ
    {
        public void linq()
        {
            Console.WriteLine("\n\tTrabajo con LINQ en ARRAY de numeros enteros");
            int[] valoresNumericos = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            // Instruccion LINQ
            IEnumerable<int> numerosPares = from numero in valoresNumericos where numero % 2 == 0 select numero;
            Console.WriteLine("\n\tNumerosPares");
            foreach (int i in numerosPares)
            {
                Console.WriteLine(i);
            }
        }

        public void linqObjetos()
        {
            ControlEmpresasEmpleado CEE = new ControlEmpresasEmpleado();

            Console.WriteLine("\n\tEmpleados que son CEO");
            CEE.getCEO();
            Console.WriteLine("\n\n\tEmpleados ordenados alfabeticamente");
            CEE.getEmpleadosAlfabeticamente();
            Console.WriteLine("\n\n\tEmpleados ordenados a la inversa");
            CEE.getEmpleadosInversa();
            Console.Write("\n\n\tElija que empresa mostrar (1 o 2) : ");
            try
            {
                CEE.getEmpleadosEmpresa(Int32.Parse(Console.ReadLine()!));
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\tEl valor ingresado es incorrecto. Se mostraran todos los registros");
                Console.ForegroundColor = ConsoleColor.White;
                CEE.mostrarTodos();

            }

            Console.WriteLine("\n\n");
        }
    }

    class EmpresaLINQ
    {
        public int ID {  get; set; }
        public string Nombre { get; set; }

        public void getDatosEmpresa()
        {
            Console.WriteLine($"Empresa {Nombre} con ID {ID}");
        }
    }

    class EmpleadoLINQ
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Cargo { get; set; }
        public double Salario { get; set; }
        //Clave Foranea (Relacion entre la clase EMPRESA y EMPLEADO)
        public int EmpresaID { get; set; }

        public void getDatosEmpleado()
        {
            Console.Write($"\n\t\tEmpleado {Nombre} con ID {ID}, cargo {Cargo} con salario {Salario} perteneciente a la empresa {EmpresaID}");
        }
    }

    class ControlEmpresasEmpleado
    {

        public List<EmpresaLINQ> listaEmpresas;
        public List<EmpleadoLINQ> listaEmpleados;

        public ControlEmpresasEmpleado()
        {
            listaEmpresas = new List<EmpresaLINQ>();
            listaEmpleados = new List<EmpleadoLINQ>();

            listaEmpresas.Add(new EmpresaLINQ { ID = 1, Nombre = "Google" });
            listaEmpresas.Add(new EmpresaLINQ { ID = 2, Nombre = "Leonel Inc." });

            listaEmpleados.Add(new EmpleadoLINQ { ID = 1, Nombre = "Celeste", Cargo = "CEO", Salario = 15000000, EmpresaID = 1});
            listaEmpleados.Add(new EmpleadoLINQ { ID = 2, Nombre = "Leonel", Cargo = "CEO", Salario = 15000000, EmpresaID = 2});
            listaEmpleados.Add(new EmpleadoLINQ { ID = 3, Nombre = "Gabriela", Cargo = "Co-CEO", Salario = 10000000, EmpresaID = 1});
            listaEmpleados.Add(new EmpleadoLINQ { ID = 4, Nombre = "Guadalupe", Cargo = "Co-CEO", Salario = 10000000, EmpresaID = 2});

        }

        public void mostrarTodos()
        {
            IEnumerable<EmpleadoLINQ> EMP = from empleado in listaEmpleados select empleado;
            foreach (EmpleadoLINQ empleado in EMP)
            {
                empleado.getDatosEmpleado();
            }
        }

        public void getCEO()
        {
            IEnumerable<EmpleadoLINQ> EMP = from empleado in listaEmpleados where empleado.Cargo == "CEO" select empleado;
            foreach (EmpleadoLINQ empleado in EMP)
            {
                empleado.getDatosEmpleado();
            }
        }

        public void getEmpleadosAlfabeticamente()
        {
            IEnumerable<EmpleadoLINQ> EMP = from empleado in listaEmpleados orderby empleado.Nombre select empleado;
            foreach (EmpleadoLINQ empleado in EMP)
            {
                empleado.getDatosEmpleado();
            }
        }

        public void getEmpleadosInversa()
        {
            IEnumerable<EmpleadoLINQ> EMP = from empleado in listaEmpleados orderby empleado.Nombre descending select empleado;
            foreach (EmpleadoLINQ empleado in EMP)
            {
                empleado.getDatosEmpleado();
            }
        }

        public void getEmpleadosEmpresa(int ID)
        {
            IEnumerable<EmpleadoLINQ> EMP = from empleado in listaEmpleados join empresa in listaEmpresas on empleado.EmpresaID equals empresa.ID where empresa.ID == ID select empleado;
            foreach (EmpleadoLINQ empleado in EMP)
            {
                empleado.getDatosEmpleado();
            }
        }



    }




}

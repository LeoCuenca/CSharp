using System;
using System.Threading;

namespace Tema
{
    public class Threads
    {
        public void thread1()
        {
            // Instanciamos el objeto t de tipo Thread, cuyo constructor recibe como argumento el metodo a iniciar
            Thread t = new Thread(thread2);
            t.Start();
            // Sincronizacion -> Hasta que no se termine de ejecutar este Thread, no se pasa a la siguiente instruccion
            t.Join();
            
            Thread t2 = new Thread(thread2);
            t2.Start();
            // Sincronizacion
            t2.Join();

            Console.WriteLine("Hola alumnos desde thread 1");
            Thread.Sleep(1000);
            Console.WriteLine("Hola alumnos desde thread 1");
            Thread.Sleep(1000);            
            Console.WriteLine("Hola alumnos desde thread 1");
            Thread.Sleep(1000);
            Console.WriteLine("Hola alumnos desde thread 1");
            Thread.Sleep(1000);
            Console.WriteLine("Hola alumnos desde thread 1");
            Thread.Sleep(1000);
        }

        public void thread2()
        {
            Console.WriteLine("Hola alumnos desde thread 2");
            Thread.Sleep(500);
            Console.WriteLine("Hola alumnos desde thread 2");
            Thread.Sleep(500);
            Console.WriteLine("Hola alumnos desde thread 2");
            Thread.Sleep(500);
            Console.WriteLine("Hola alumnos desde thread 2");
            Thread.Sleep(500);
            Console.WriteLine("Hola alumnos desde thread 2");
            Thread.Sleep(500);
        }

    }
}

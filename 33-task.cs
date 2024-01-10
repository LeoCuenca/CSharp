using System;
using System.Threading;

namespace Tema
{
    public class Tasks
    {
        public void ejecutar()
        {
            //Task tarea = new Task(ejecutarTarea);
            //tarea.Start();
            // La siguiente linea reemplaza a las 2 de arriba, hace de 2 lineas una sola.
            Task tarea = Task.Run(() => ejecutarTarea());
            Task tarea2 = tarea.ContinueWith(ejecutarOtraTarea);

            /*Task tarea2 = new Task(() =>
            {
                for (int j = 0; j < 100; j++)
                {
                    var miThread = Thread.CurrentThread.ManagedThreadId;
                    Thread.Sleep(1000);
                    Console.WriteLine("Tarea correspondiente al hilo : " + miThread + " ejecutandose desde el main");
                }
            });
            tarea2.Start();*/

            Console.ReadLine();
        }

        public void ejecutarTarea()
        {
            for (int i = 0; i < 10; i++)
            {
                var miThread = Thread.CurrentThread.ManagedThreadId;
                Thread.Sleep(1000);
                Console.WriteLine("Esta vuelta de bucle corresponde al Thread : " + miThread);
            }
        }
        public void ejecutarOtraTarea(Task obj)
        {
            for (int i = 0; i < 10; i++)
            {
                var miThread = Thread.CurrentThread.ManagedThreadId;
                Thread.Sleep(1000);
                Console.WriteLine("Esta es otra tarea y esta vuelta de bucle corresponde al Thread : " + miThread);
            }
        }
    }



}

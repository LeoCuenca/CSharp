using System;
using System.Threading;

namespace Tema
{
    public class TasksWait
    {
        public void ejecutar()
        {
            realizarTodasTareas();
            Console.ReadLine();
        }

        public void realizarTodasTareas()
        {
            var tarea1 = Task.Run(() =>
            {
                ejecutarTarea();
            });

            // Con este metodo lo que hacemos es que la tarea 1 debe completarse antes de que comienzen las otras 2 tareas.
            //tarea1.Wait();

            var tarea2 = Task.Run(() =>
            {
                ejecutarTarea2();
            });
            // A cada una de las tareas, tengo que guardarlas dentro de una variable para poder asi pasarselas como argumento al metodo 'WaitAll' de la clase 'Task'
            // Con esta instruccion, la tarea 3 no comienza a ejecutarse sino hasta que la tarea 1 y 2 hayan sido completadas.
            // Esto es muy util si la tarea 3 recibe datos de las tareas 1 y 2, sin los cuales no podria realizar tu trabajo.
            //Task.WaitAll(tarea1, tarea2);
            
            // Con el metodo 'WaitAny' funciona como un OR, cuando cualquiera de las 2 termine, empieza la tarea 3.
            //Task.WaitAny(tarea1, tarea2);

            var tarea3 = Task.Run(() =>
            {
                ejecutarTarea3();
            });

        }

        public void ejecutarTarea()
        {
            for (int i = 0; i < 5; i++)
            {
                var miThread = Thread.CurrentThread.ManagedThreadId;
                Thread.Sleep(1000);
                Console.WriteLine("Esta vuelta de bucle corresponde a la tarea 1");
            }
        }
        public void ejecutarTarea2()
        {
            for (int i = 0; i < 5; i++)
            {
                var miThread = Thread.CurrentThread.ManagedThreadId;
                Thread.Sleep(500);
                Console.WriteLine("Esta vuelta de bucle corresponde a la tarea 2");
            }
        }
        public void ejecutarTarea3()
        {
            for (int i = 0; i < 5; i++)
            {
                var miThread = Thread.CurrentThread.ManagedThreadId;
                Thread.Sleep(250);
                Console.WriteLine("Esta vuelta de bucle corresponde a la tarea 3");
            }
        }

    }



}

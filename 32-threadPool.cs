using System;
using System.Threading;

namespace Tema
{
    public class ThreadPools
    {

        public void ejecutar()
        {
            for (int i = 0; i < 500; i++)
            {
                //Thread t = new Thread(ejecutarTarea);
                //t.Start();

                ThreadPool.QueueUserWorkItem(ejecutarTarea, i);

            }
            Console.ReadLine();
        }

        static void ejecutarTarea(Object o)
        {
            int nTarea = (int) o;
            Console.WriteLine($"Thread Nº : {Thread.CurrentThread.ManagedThreadId} ha comenzado la tarea {nTarea}");
            Thread.Sleep(10000);
            Console.WriteLine($"Thread Nº : {Thread.CurrentThread.ManagedThreadId} ha terminado la tarea {nTarea}");
        }



    }
}

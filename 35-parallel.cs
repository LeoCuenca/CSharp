using System;

namespace Tema
{
    public class ParallelClass
    {

        private static int acumulador = 0;
        public void ejecutar()
        {
            /*for (int i = 0; i < 100; i++)
            {
                RealizarTareas(i);
                Console.WriteLine($"Acumulador vale : {acumulador}. Tarea realizada por el hilo : {Thread.CurrentThread.ManagedThreadId}");
            }*/

            // Con esta instruccion, el metodo se ejecuta de manera CONCURRENTE por varias Tasks. El programa solo se encarga de crear las Tasks por si mismo.
            //Parallel.For(0, 100, RealizarTareas);
            //Esta instruccion utiliza expresiones Lambda y simplifica el codigo, pero hasta que me acostumbre, va a tomar un tiempo.
            Parallel.For(0, 100, dato =>
            {
                Console.WriteLine($"Acumulador vale : {acumulador}. Tarea realizada por el hilo : {Thread.CurrentThread.ManagedThreadId}");
                if (acumulador % 2 == 0)
                {
                    acumulador += dato;
                    Thread.Sleep(100);
                }
                else
                {
                    acumulador -= dato;
                    Thread.Sleep(100);
                }
            });

        }

        /*public void RealizarTareas(int dato)
        {
            Console.WriteLine($"Acumulador vale : {acumulador}. Tarea realizada por el hilo : {Thread.CurrentThread.ManagedThreadId}");
            //if (acumulador %2 == 0)
            {
                acumulador += dato;
                Thread.Sleep(100);
            }
            else
            {
                acumulador -= dato;
                Thread.Sleep(100);
            }
        }*/
    }
}

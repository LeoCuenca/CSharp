using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tema
{
    public class TaskCompSource
    {
        // la idea es setear una condicion de que solamente se inicie con el hilo2 solamente cuando el hilo1 se haya completado
        // Recordatorio -> VAR es una declaracion implicita de variable, el compilador asigna el tipo de valor segun el tipo asignado y debe inicializarse en la misma linea
         public void ejecutar()
        {

            var TareaTerminada = new TaskCompletionSource<bool>();

            var hilo1 = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Hilo 1");
                    Thread.Sleep(1000);
                }
                // Cuando el programa llegue a esta linea el programa da por finalizada la tarea del hilo 1
                TareaTerminada.TrySetResult(true);
            });

            var hilo2 = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Hilo 2");
                    Thread.Sleep(1000);
                }
            });
            
            var hilo3 = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Hilo 3");
                    Thread.Sleep(1000);
                }
            });

            hilo1.Start();

            // Cuadno llegue a estalinea el programa sabra si la tarea ha finalizado o no
            var resultado = TareaTerminada.Task.Result;

            hilo2.Start();

            hilo3.Start();

        }
    }
}


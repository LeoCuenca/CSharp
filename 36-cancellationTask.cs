using System;

namespace Tema
{
    public class CancelationTask
    {
        private static int acumulador = 0;
        public void ejecutar()
        {
            // Senala quien es el cancelation token que debe cancelar la tarea
            CancellationTokenSource miToken = new CancellationTokenSource();
            // El que debe cancelar la tarea es este que sigue
            CancellationToken cancelaToken = miToken.Token;

            // Hay que decirle al metodo que llamamos que puede estar sujeto a cancelaciones, y para esto le pasamos el objeto de tipo CANCELLATIONTOKEN
            Task tarea = Task.Run(() => RealizarTareas(cancelaToken));

            // Este bucle for es simplemente para incrementar 'acumulador' y que cumpla lo antes posible la condicion de exceder 100 y podamos testear como salta el cancelation token.
            for (int i = 0; i < 100; i++)
            {
                acumulador += 30;
                Thread.Sleep(1000);
                // Con un condicional, propagamos la cancelacion de la tarea. Cuando pase X cosa, que cancele la tarea.
                if (acumulador >100)
                { 
                    miToken.Cancel();
                    break;
                }
            }

            Thread.Sleep(1000);

            Console.WriteLine($"VALOR DEL ACUMULADOR : {acumulador}");

            Console.ReadLine();
        }

       public void RealizarTareas(CancellationToken token)
        {
            for (int i = 0; i < 100; i++)
            {
                acumulador++;
                var miThread = Thread.CurrentThread.ManagedThreadId;
                Thread.Sleep(1000);
                Console.WriteLine($"Ejecutando el Thread : {miThread}");
                Console.WriteLine(acumulador);

                // Si la tarea recibe un token de cancelacion, entonces que el programa retorne al main.
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Salto el cancellation token");
                    // Es desebale que se reviertan los cambios hechos durante la ejecucion de la tarea, hasta que salte el token de cancelacion.
                    // Esto lo podems hacer tranquilamente antes de devolver el flujo de ejecucion del programa al llamante del metodo. En este caso es simple.
                    acumulador = 0;

                    return;
                }
                    
            }
        }
        
    }
}
using System;

namespace Tema
{
    public class numAleaExcepcion
    {
        public void numAle()
        {
            Random numero = new Random();
            int numeroAleatorio = numero.Next(0, 100);
            int numeroUsuario;

            Console.Write("    Ingrese el numero que cree que ha sido generado : ");

            try
            {
                numeroUsuario = int.Parse(Console.ReadLine());
            }
            // Se pueden utilizar varios catch, pero siempre el mas generico (Exception) va al final.

            catch (FormatException ex)
            {
                Console.WriteLine("No ha introducido un valor numerico valido. Se tomara el numero 0 como valor.");
                numeroUsuario = 0;
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("No se introdujo un numero valido. Se tomara el 0 como valor.");
                numeroUsuario = 0;
            }

            //catch (Exception ex)
            //{
            //    Console.WriteLine("Se ha ingresado un valor incorrecto. Se utilizara el 0 como valor ingresado");
            //    Console.WriteLine(ex.Message);
            //    numeroUsuario = 0;
            //}

            // Uso de filtros
            // Captura todas las excepciones que no sean del tipo FormatException
            catch (Exception ex) when (ex.GetType() != typeof(FormatException))
            {
                Console.WriteLine("Se ha ingresado un valor incorrecto. Se utilizara el 0 como valor ingresado");
                Console.WriteLine(ex.Message);
                numeroUsuario = 0;
            }

            int contador = 1;

            while (numeroUsuario != numeroAleatorio)
            {
                if (numeroUsuario > numeroAleatorio) Console.WriteLine($"    El numero {numeroUsuario} es mayor al generado. Intentelo nuevamente.");

                if (numeroUsuario < numeroAleatorio) Console.WriteLine($"    El numero {numeroUsuario} es menor al generado. Intentelo nuevamente");

                Console.Write("    Ingrese el numero que cree que ha sido generado : ");
                numeroUsuario = int.Parse(Console.ReadLine());
                contador++;
            }

            Console.Write($"    Felicidades, el numero {numeroUsuario} es el que fue generado. Lo acerto luego de {contador} intentos.");
        }
    }
}

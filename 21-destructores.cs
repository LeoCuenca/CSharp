using System;
using System.IO;

namespace Tema
{
    class Destructores
    {

        public void ejecutar()
        {
            ManejoArchivos miArchivo = new ManejoArchivos();
            miArchivo.mensaje();
        }

        class ManejoArchivos
        {
            StreamReader archivo = null;
            int contador = 0;
            string linea;

            public ManejoArchivos()
            {
                archivo = new StreamReader(@"C:\Users\iSkyline\Escritorio\Coding\Curso C#\000-destructores.txt");
                while ((linea = archivo.ReadLine()!) != null)
                {
                    Console.WriteLine(linea);
                    contador++;
                }
            }

            public void mensaje()
            {
                Console.WriteLine($"Hay {contador} lineas");
            }

            ~ManejoArchivos()
            {
                archivo.Close();
            }

        }

    }
}

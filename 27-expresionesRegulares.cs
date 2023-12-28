using System;
using System.Text.RegularExpressions;

namespace Tema
{
    class ExpresionesRegulares
    {
        // Para buscar numeros, se utiliza el \d, pero antes de los "" tengo que colocar un @, sino el compilador me tira error porque la barra invertida se usa, como bien sabemos, para secuencias de escape (Saltos de linea, tabulaciones ...)
        // Para buscar bloques de 3 numeros, utilizariamos "\d\d\d" o @"\d{3}"
        // Las expresiones regulares son una MARAVILLA para validar datos, algo que SIEMPRE me gusto. Podemos validar telefonos, mails, DNI, etc ...
        // El | es el operador logico que se puede utilizar tambien para 

        public void regularesTeclado()
        {
            Console.WriteLine("Ingrese la frase : ");
            string frase = Console.ReadLine()!;
            Console.WriteLine($"La frase ingresada es : {frase}");

            // Puedo buscar letras con "[letra]" o palabras con "(palabra)"
            Console.Write("Ingrese la palabra a buscar : ");
            string respuesta = Console.ReadLine()!;

            string patron = $"({respuesta})";

            Regex miRegex = new Regex(patron);

            MatchCollection elMatch = miRegex.Matches(frase);

            if (elMatch.Count > 0) Console.WriteLine($"Se ha encontrado la palabra {respuesta}");
            else Console.WriteLine("No se ha encontrado");

        }

        public void regularesNumeros()
        {
            // Podemos ayudarnos con CTRL + F para ubicar patrones de expresiones regulares.
            string frase = "Mi nombre es Leonel y mi numero de telefono es (+54) 11-1234-5678 y mi codigo postal es 4545";

            // El siguiente patron verifica un numero de telefono
            string patron = @"\d{2}-\d{4}-\d{4}";

            Regex miRegex = new Regex(patron);

            MatchCollection elMatch = miRegex.Matches(frase);

            if (elMatch.Count == 0) Console.WriteLine("No hay numeros de telefono validos");
            else Console.WriteLine("Hay numeros de telefono validos");

        }

        public void regularesWeb()
        {
            // Podemos ayudarnos con CTRL + F para ubicar patrones de expresiones regulares.
            string frase = "Mi web es https://www.pildorasinformaticas.es";

            // El siguiente patron verifica una web, el ? significa que el caracter o el grupo anterior puede estar o no.
            string patron = "https?://(www.)?pildorasinformaticas.es";

            Regex miRegex = new Regex(patron);

            MatchCollection elMatch = miRegex.Matches(frase);

            if (elMatch.Count != 0) Console.WriteLine("Se ha encontrado web");
            else Console.WriteLine("No se ha encontrado web");

        }



    }











}



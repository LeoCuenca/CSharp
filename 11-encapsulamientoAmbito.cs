using System;

namespace Ejercicio
{
    public class encapsulamientoAmbito
    {
        //Hacer una variable de una clase publica para que sea visible desde otro ambito, es una MALA PRACTICA.
        //Para acceder a las variables de una clase desde otra, debemos utilizar un 'METODO DE ACCESO'
        private double euro = 1.253;
        public double convertidorEuroDolar(double cantidad) => cantidad * euro;

        //METODO DE ACCESO para modificar el valor de una variable de la clase, sin que la misma sea publica.
        //Solo se pueden modificar valores de variables de una clase desde la clase misma, mediante un metodo interno.
        public void cambiaValorEuro(double nuevoValor)
        {
            try
            {
                if (nuevoValor < 0) throw new ArgumentOutOfRangeException();
                else euro = nuevoValor;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ingresaste un numero negativo, se calculara la conversion con el valor anterior ({euro})");

            }

        }
    }
}

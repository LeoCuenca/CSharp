using System;
using System.Collections.Generic;

namespace Ejercicio
{

    class Colecciones
    {
        public void listas()
        {

            List<int> numeros = new List<int>();
            int elemento;

            do
            {

                Console.Write("\tIngrese valores (Cero para terminar) : ");
                elemento = Int32.Parse(Console.ReadLine()!);

                if (elemento != 0)
                {
                    numeros.Add(elemento);
                }            

            } while (elemento != 0);

            foreach (int numero in numeros)
            { 
                Console.Write($"\t{numero} ");
            }
        }

        public void listasEnlazadas()
        {
            LinkedList<int> numerosLinked = new LinkedList<int>();

            // Agregando elementos desde un array con foreach
            foreach (int numero in new int[] {1,2,3,4,5,6})
            {
                numerosLinked.AddFirst(numero);
            }

            // Agregando un elemento con nodos. Creo un LinkedListNode y le doy el valor. Luego asigno a la lista enlazada ese valor primero.
            LinkedListNode<int> nodoAgregar = new LinkedListNode<int>(15);
            numerosLinked.AddFirst(nodoAgregar);

            for (LinkedListNode<int> nodo = numerosLinked.First; nodo != null; nodo = nodo.Next)
            {
                int numero = nodo.Value;
                Console.WriteLine(numero);
            }

            Console.ReadKey();

            numerosLinked.Remove(15);

            for (LinkedListNode<int> nodo = numerosLinked.First; nodo != null; nodo = nodo.Next)
            {
                int numero = nodo.Value;
                Console.WriteLine(numero);
            }

        }

        public void queue()
        {
            // Metodologia FIFO -> First In First Out

            Queue<int> numeros = new Queue<int>();

            // Agregando elementos a la cola
            // 'Por cada numero entero que hay en el array de ints'
            foreach(int numero in new int[5] { 2, 4, 6, 8, 10 })
            {
                numeros.Enqueue(numero);
            }

            // Recorriendo la cola
            Console.WriteLine("Recorriendo la Queue");
            foreach (int numero in numeros)
            {
                Console.WriteLine(numero);
            }

            // Eliminando elementos de la cola
            numeros.Dequeue();

            Console.WriteLine("Recorriendo la Queue despues de un Dequeue");
            foreach (int numero in numeros)
            {
                Console.WriteLine(numero);
            }

        }

        public void stack()
        {
            // Metodologia LIFO -> Last In First Out

            Stack<int> numeros = new Stack<int>();

            // Agregando elementos a la cola
            // 'Por cada numero entero que hay en el array de ints'
            foreach (int numero in new int[5] { 2, 4, 6, 8, 10 })
            {
                numeros.Push(numero);
            }

            // Recorriendo la pila
            Console.WriteLine("Recorriendo la Pila");
            foreach (int numero in numeros)
            {
                Console.WriteLine(numero);
            }

            // Eliminando elementos de la pila
            numeros.Pop();

            Console.WriteLine("Recorriendo la Pila despues de un Pop");
            foreach (int numero in numeros)
            {
                Console.WriteLine(numero);
            }

        }

        public void dictionary()
        {

            Dictionary<string, int> edades = new Dictionary<string, int>();

            // Llenando el diccionario
            // 1 Forma
            edades.Add("Juan", 18);
            edades.Add("Diana", 35);
            // 2 Forma
            edades["Maria"] = 25;
            edades["Antonio"] = 29;

            //Recorriendo el diccionario
            foreach (KeyValuePair <string, int> persona in edades)
            {
                Console.WriteLine($"Nombre : {persona.Key} | Edad : {persona.Value}");
            }




        }

    }
            
}

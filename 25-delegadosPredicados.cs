using System;

namespace Tema
{
    public class DelegadosPredicados
    {

        // Declaracion del objeto delegado
        delegate void ObjetoDelegado(string x);

        public void delegados()
        {
            // Creacion del objeto delegado apuntando a MensajeBienvenida
            ObjetoDelegado ElDelegado = new ObjetoDelegado(MensajeBienvenida.saludoBienvenida);

            // Utilizacion del delegado para llamar al metodo saludoBienvenida
            ElDelegado("Hola, acabo de llegar");

            ElDelegado = new ObjetoDelegado(MensajeDespedida.saludoDespedida);

            ElDelegado("Chau, me voy");

        }

        public void delegadosPredicados()
        {
            // Declaramos una lista
            List<int> listaNumeros = new List<int>();
            // En la lista, añadimos valores de un array a esta lista
            listaNumeros.AddRange(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            // Declaramos el delegado predicado. Si vemos la documentacion oficial, Predicate<T> devuelve una lista.
            Predicate<int> elDelegadoPred = new Predicate<int>(damePares);
            // Creo la lista que va a contener los resultados del predicado
            List<int> numerosPares = listaNumeros.FindAll(elDelegadoPred);
        }

        public bool damePares(int x)
        {
            if (x % 2 == 0) return true;
            else return false;
        }

        public void delegadosPredicadosObjetos()
        {
            // Creacion de la lista de objetos de tipo Personas
            List<Personas> gente = new List<Personas>();

            // Creacion de varios objetos de tipo Personas
            Personas P1 = new Personas();
            P1.Nombre = "Juan";
            P1.Edad = 18;
            
            Personas P2 = new Personas();
            P2.Nombre = "Maria";
            P2.Edad = 28;

            // Agregando a la lista gente, una instancia de array de Personas, que contiene los objetos Persona creados anteriormente.
            gente.AddRange(new Personas[] { P1, P2 });

            // Creacion del predicado
            Predicate<Personas> predicadoNombre = new Predicate<Personas>(existeJuan);
            Predicate<Personas> predicadoEdad = new Predicate<Personas>(comprobarEdad);

            if (gente.Exists(predicadoNombre) == true) Console.WriteLine("Hay una persona llamada Juan");
            else Console.WriteLine("No hay una persona llamada Juan");

            if (gente.Exists(predicadoEdad) == true) Console.WriteLine("Hay menores de edad");
            else Console.WriteLine("No hay menores de edad");

        }

        public bool comprobarEdad(Personas persona)
        {
            if (persona.Edad < 18) return true;
            else return false;
        }

        public bool existeJuan(Personas persona)
        {
            if (persona.Nombre == "Juan") return true;
            else return false;
        }

    }

    public class Personas
    {
        private string nombre;
        private int edad;

        public string Nombre { get => nombre; set => nombre = value; }
        public int Edad { get => edad; set => edad = value; }
    }

    class MensajeBienvenida
    {
        public static void saludoBienvenida(string msj) => Console.WriteLine("Mensaje de bienvenida : {0}", msj);
    }

    class MensajeDespedida
    {
        public static void saludoDespedida(string msj) => Console.WriteLine("Mensaje de despedida : {0}", msj);
    }


}

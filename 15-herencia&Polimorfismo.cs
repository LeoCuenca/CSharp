using System;
//NO SE ADMITE LA HERENCIA MULTIPLE EN C#. Solamente se puede heredar de una clase.
public class Herencia
{
    public void ejecutarHerenciaPolimorfismo()
    {

        Caballo miCaballo = new Caballo("Babieca");
        Humano miHumano = new Humano("Juan");
        Gorila miGorila = new Gorila("Copito");

        //Principio de sustitucion
        Mamiferos animal = new Caballo("Jorge");
        Mamiferos persona = new Humano("Juan");

        //La clase 'Object' es la superclase cosmica, es la que esta por encima de cualquier otro objeto.
        Object miAnimal = new Caballo("Esteban");
        Object miPersona = new Humano("Jose Luis");
        Object miMamifero = new Mamiferos("Wally");

        //miHumano.getNombre();

        //Todo esto se puede usar para cargar arrays con distintos tipos de objetos
        Mamiferos[] almacenAnimales = new Mamiferos[3];

        almacenAnimales[0] = miCaballo;
        almacenAnimales[1] = miHumano;
        almacenAnimales[2] = miGorila;


        Console.WriteLine("\n\tMostrandolo con bucle FOREACH");
        foreach (Mamiferos obj in almacenAnimales)
        {
            obj.pensar();
        }

        Console.WriteLine("\n\tMostrandolo con bucle FOR");
        for ( int i = 0; i < 3; i++ )   
        {
            //almacenAnimales se esta comportando en la primera ocasion como un mamifero, en la segunda como humano y en la ultima como gorila. A esto se lo conoce como POLIMORFISMO
            almacenAnimales[i].pensar();
        }

        Ballena miWally = new Ballena("Wally");
        miWally.nadar();

        //De esta forma estamos accediendo a los metodos privados de la INTERFACE que tienen nombres ambiguos para el compilador.
        //Creamos un OBJETO perteneciente a la INTERFACE 'IMamiferosTerrestres' y nombrarlo como queramos e igualarlo a un OBJETO de TIPO CABALLO (En este caso) -> Con esto estamos utilizando el principio de sustitucion
        IMamiferosTerrestres IPatas = miCaballo;
        //Hacemos lo mismo con el otro metodo ambiguo, y de esta forma podemos acceder a los metodos private de cada una de las INTERFACE.
        ISaltoConPatas ISalto = miCaballo;

        Console.WriteLine($"Mi caballo tiene {IPatas.NumeroPatas()} patas y salta solo con {ISalto.NumeroPatas()}");   

    }

    public class Mamiferos
    {
        private string nombreSerVivo;

        public Mamiferos(string nombre) => nombreSerVivo = nombre;

        //PROTECTED permite que el metodo sea accesible desde la propia clase y de todas aquellas clases que hereden de esta, pero de ninguna otra mas.
        protected void respirar() => Console.WriteLine("Soy capaz de respirar");

        //Para poder usar el override y asi SOBREESCRIBIR O MODIFICAR una clase heredada, debemos asignar al metodo en cuestion la palabra reservada virtual, sino, marcara un error en la clase que herede del padre.
        public virtual void pensar() => Console.WriteLine("Soy capaz de pensar instintivamente");

        public void cuidarCrias() => Console.WriteLine("Cuido de mis crias");

        public void getNombre() => Console.WriteLine($"El nombre del ser vivo es : {nombreSerVivo}");

    }


    //La INTERFACE lo que hace es dar un conjunto de directrices que deben cumplir las clases a las que se le asigna.
    //Adentro de una INTERFACE se declararan metodos SIN MODIFICADOR DE ACCESO (Public/Private/Protected) solo con el tipo de dato que devuelve.
    interface IMamiferosTerrestres
    {
        int NumeroPatas();
    }

    interface IAnimalesYDeportes
    {
        string TipoDeporte();
        bool EsOlimpico();
    }

    interface ISaltoConPatas
    {
        int NumeroPatas();
    }

    public class Ballena : Mamiferos
    {
        public Ballena(string nombreBallena) : base(nombreBallena)
        {

        }

        public void nadar() => Console.WriteLine("Soy capaz de nadar");

    }

    public class Caballo : Mamiferos, IMamiferosTerrestres, IAnimalesYDeportes, ISaltoConPatas
    {
        //Tenemos que hacer que las subclases llamen al constructor de la clase padre, para que sea este el que de un estado inicial a todos los objetos.
        //Lo que sigue es el constructor de la clase 'caballo', que llama al constructor padre 'mamiferos' (Mediante :base()).
        public Caballo(string nombreCaballo) : base(nombreCaballo)
        {
            
        }

        public void galopar() => Console.WriteLine("Soy capaz de galopar");

        //Metodo de INTEFACE
        //Debe cumplir: 1. Mismo nombre del metodo / 2. Mismo tipo de dato a devolver / Mismo numero de parametro y tipo 
        //No llevan modificar de acceso
        int IMamiferosTerrestres.NumeroPatas() => 4;

        int ISaltoConPatas.NumeroPatas() => 2;

        public string TipoDeporte() => "El Caballo se utiliza en varios deportes, como ";
        public bool EsOlimpico() => true;
    }

    public class Humano : Mamiferos
    {
        public Humano(string nombreHumano) : base(nombreHumano)
        {

        }
        //La advertencia surge dado que la clase 'humano' hereda de 'mamiferos' un metodo 'pensar()'. El metodo de la clase 'humano' OCULTA al heredado, por lo que se ejecuta 'pensar()' de la clase 'humano'
        //Esto no ocurriria si sobrecargo al metodo pensar(), es decir, si hago que le pase otra cantidad de parametros o distintos tipos de parametros.
        public void pensar() => Console.WriteLine("Soy capaz de pensar");

    }

    public class Gorila : Mamiferos, IMamiferosTerrestres
    {
        public Gorila(string nombreGorila) : base(nombreGorila)
        {

        }

        //Con la palabra reservada override, le decimos al compilador que el metodo pensar de la clase gorila, esta relacionada con el metodo pensar de mamiferos. 
        //Es decir que este metodo SOBREESCRIBE O MODIFICA el metodo pensar() del padre (mamiferos, en este caso).
        public override void pensar() => Console.WriteLine("Pensamiento instintivo avanzado");
        public void trepar() => Console.WriteLine("Soy capaz de trepar");
        public int NumeroPatas() => 2;

    }
}











    



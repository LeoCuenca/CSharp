using System;

internal class Curso_C
{
    static void Main(string[] args)
    {
        int opcion;
        Console.SetWindowSize(200, 50);
        Console.WriteLine("     ");
        Console.WriteLine("     MENU DE OPCIONES DEL CURSO DE C#");
        Console.WriteLine("     --------------------------------");
        Console.WriteLine("     ");

        Console.WriteLine("\t1. Impresion de Strings");
        Console.WriteLine("\t2. Manejo de Variables");
        Console.WriteLine("\t3. Conversion de Texto a Numero");
        Console.WriteLine("\t4. Utilizacion de Metodos");
        Console.WriteLine("\t5. Alcance o Ambito de las Variables");
        Console.WriteLine("\t6. Sobrecarga de Metodos");
        Console.WriteLine("\t7. Adivinar el numero");
        Console.WriteLine("\t8. Excepciones / TryCatch");
        Console.WriteLine("\t9. Bloque Finally / Acceso de Fichero");
        Console.WriteLine("\t10. Clases / Instancias / Campo de Clases");
        Console.WriteLine("\t11. Encapsulamiento / Ambito");
        Console.WriteLine("\t12. Setters y Getters");
        Console.WriteLine("\t13. Variable Static / Metodo Static");
        //Console.WriteLine("\t");
        //Console.WriteLine("\t");
        //Console.WriteLine("\t");
        //Console.WriteLine("\t");
        //Console.WriteLine("\t");
        //Console.WriteLine("\t");
        //Console.WriteLine("\t");
        //Console.WriteLine("\t");
        //Console.WriteLine("\t");

        Console.WriteLine();

        Console.Write("\t\t¿Que ejercicio desea ejecutar? ");

        opcion = Int32.Parse(Console.ReadLine()!);

        Console.Clear();

        switch (opcion)
        {
            case 1:

                impresionStrings primero = new impresionStrings();
                primero.impStr();
                break;

            case 2:

                manejoVariables segundo = new manejoVariables();
                segundo.manVar();
                break;

            case 3:

                converstionTXTaNUM tercero = new converstionTXTaNUM();
                tercero.convNUM();
                break;

            case 4:
                // Uso de diversos metodos ubicados en una misma clase.
                // La clase cuarto tiene dos metodos: met() y sumaNumeros(), cada uno es llamado cuando se lo requiere.

                metodos cuarto = new metodos();
                cuarto.met();

                // En el caso de sumaNumeros(), este recibe como argumentos 2 numeros enteros, los cuales son solicitados al usuario mediante consola, convirtiendo estos a enteros, utilizando el metodo .Parse().

                Console.Write("     Ingrese el primer numero : ");
                int num1 = int.Parse(Console.ReadLine()!);

                Console.Write("     Ingrese el segundo numero : ");
                int num2 = int.Parse(Console.ReadLine()!);

                cuarto.sumaNumeros(num1, num2);

                // El siguiente caso es con un retorno, el metodo va a recibir 2 argumentos y va a devolver un valor al MAIN.

                Console.WriteLine($"        La multiplicacion de estos numeros es : {cuarto.multiplicacionNumeros(num1, num2)}");
                Console.WriteLine($"        La division de estos numeros es : {cuarto.divisionNumeros(num1, num2)}");
                Console.WriteLine($"        La division de estos numeros con operador flecha es : {cuarto.divNumFlecha(num1, num2)}");

                break;

            case 5:

                alcanceVariables quinto = new alcanceVariables();
                quinto.primer();
                quinto.segunda();
                quinto.tercera();

                break;

            case 6:

                sobrecargaMetodos sexto = new sobrecargaMetodos();
                // Metodo suma()
                sexto.suma(10, 20);
                // Metodo suma() sobrecargado mismo tipo
                sexto.suma(10, 20, 30);
                // Metodo suma() sobrecargado en floats
                sexto.suma(5.5F, 10F, 6.7F);
                // Metodo parametrosOpcionales() el cual utiliza 3 parametros de los cuales el ultimo es opcional por ser asignado un valor 0. Esto es util cuando C# trabaja con otros lenguajes que no admiten la sobrecarga.
                sexto.parametrosOpcionales(10, 20);

                break;

            case 7:

                numAleaExcepcion numeros = new numAleaExcepcion();
                numeros.numAle();

                break;
            case 8:
                lanzamientoExcepciones excepciones = new lanzamientoExcepciones();
                Console.Write("Ingrese el numero del mes a consultar:");
                int numes = int.Parse(Console.ReadLine()!);

                try
                {
                    Console.WriteLine($"El mes {numes} es {excepciones.nombreMes(numes)}");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("El programa continuaria aca ...");

                break;

            case 9:

                bloqueFinally accFich = new bloqueFinally();
                accFich.accesoFichero();

                break;

            case 10:

                clasesInstancias miCirculo = new clasesInstancias(); //Creacion de objeto 'miCirculo' de tipo 'clasesInstancias' = Instanciacion de la clase
                clasesInstancias miCirculo2 = new clasesInstancias(); //Creacion de objeto 'miCirculo2' de tipo 'clasesInstancias' = Instanciacion de la clase

                Console.Write("    Ingrese el radio del circulo: ");

                int radio = int.Parse(Console.ReadLine()!);

                Console.WriteLine($"Area de miCirculo = {miCirculo.CalculoArea(radio)}");
                Console.WriteLine($"Area de miCirculo2 con un radio de 2 = {miCirculo2.CalculoArea(2)}");

                break;

            case 11:

                encapsulamientoAmbito exchange = new encapsulamientoAmbito();
                Console.WriteLine($"¿Cuanto son 50 euros a valor dolar 1.253? -> {exchange.convertidorEuroDolar(50)}");
                exchange.cambiaValorEuro(-1.50);
                Console.WriteLine($"¿Cuanto son 50 euros a valor dolar 1.50? -> {exchange.convertidorEuroDolar(50)}");

                break;

            case 12:

                auto skyline = new auto();

                //Extraemos la informacion desde cada getter por separado
                Console.WriteLine("\n\tUSANDO SETTERS SEPARADOS");
                Console.WriteLine($"\tEl Nissan Skyline tiene {skyline.getRuedas()} ruedas, mide {skyline.getLargo()} metros de largo y {skyline.getAncho()} metros de ancho.\n");

                //O bien podemos crear un unico getter que nos devuelva una cadena de texto con todos los datos del objeto 'skyline' de la clase 'auto'.
                Console.WriteLine("\tUSANDO SETTERS EN UN METODO QUE DEVUELVE DIRECTAMENTE LA CADENA DE TEXTO CON LOS DATOS");
                Console.WriteLine(skyline.getDatos());

                //Utilizacion del SETTER con el objeto 'skyline' de la clase 'auto'
                skyline.setExtras(true, "Cuero Refinado");
                Console.WriteLine($"\t{skyline.getExtras()}");

                //Creacion de un segundo objeto 'ferrari' de la clase 'auto', utilizando el constructor sobrecargado.
                auto ferrari = new auto(4.2, 2.7);
                Console.WriteLine($"\tLa Ferrari GT50 tiene {ferrari.getRuedas()} ruedas, mide {ferrari.getLargo()} metros de largo y {ferrari.getAncho()} metros de ancho.");

                break;

            case 13:

                punto origen = new punto();

                punto destino = new punto(128, 80);

                double distancia = origen.distanciaHasta(destino);

                Console.WriteLine($"La distancia es : {distancia}");

                //Los metodos STATIC se invocan directamente desde la clase y no desde un objeto de la misma.
                Console.WriteLine($"Actualmente hay creados : {punto.getContador()} objetos");

                break;

        }

    }
}
















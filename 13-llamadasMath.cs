using System;

namespace Tema
{
    public class punto
    {

        private int x, y;
        //Una variable static puede ser util, entre otras muchas cosas, para crear un contador de objetos.
        private static int contadorObjetos = 0;

        public punto()
        {

            //Console.WriteLine("Este es el constructor por defecto");
            //Los valores por defecto de los 'campos de clase' seran 0.
            this.x = 0;
            this.y = 0;
            contadorObjetos++;

        }

        public punto(int x, int y)
        {

            //Console.WriteLine($"Coordenada X : {x} / Coordenada Y : {y}");
            //this.'campo de clase' = 'parametro' recibido por el metodo
            this.x = x;
            this.y = y;
            contadorObjetos++;

        }

        //Este metodo recibe como parametro un OBJETO de tipo PUNTO.
        public double distanciaHasta(punto otroPunto)
        {

            int xDif = this.x - otroPunto.x;
            int yDif = this.y - otroPunto.y;

            return Math.Sqrt(Math.Pow(xDif, 2) + Math.Pow(yDif, 2));

        }

        //Este metodo es static para poder invocarlo directamente desde la clase propiamente dicha, en lugar que desde un objeto de clase.
        //¿Podrian los getters/setters declararse SIEMPRE como static?
        public static int getContador() => contadorObjetos;

    }
}
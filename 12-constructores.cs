using System;

namespace Tema
{
    /* ================================================================================================================= */
    //              CONSTRUCTORES / GETTERS / SETTERS / SOBRECARGA CONSTRUCTORES / USO DE THIS / PARTIAL CLASS
    /* ================================================================================================================= */

    //No se utilizara PARTIAL CLASS, pero quiero dejar en claro que es una forma de particionar una clase en varias secciones y asi poder ordenar el codigo de una mejor manera.
    //Para esto, solamente debemos incluir la palabra reservada 'partial' delante de la palabra 'class'.

    public class auto
    {
        //El constructor es un metodo especial, que no devuelve NADA, ni tampoco recibe ningun parametro.
        //Sirve para definir el estado INICIAL de un OBJETO INSTANCIADO de la clase, en este caso, 'auto'.
        public auto()
        {
            ruedas = 4;
            largo = 5.3;
            ancho = 3.2;
            tapiceria = "Tela";
        }

        //Sobrecarga de constructor
        public auto(double largoAuto, double anchoAuto)
        {
            ruedas = 4;
            largo = largoAuto;
            ancho = anchoAuto;
            tapiceria = "Tela";
        }

        //A esta clase de metodos se lo denominan 'GETTERS' porque son metodos que permiten acceder a un campo de clase private de una clase puntual, desde cualquier otra clase.
        public int getRuedas() => ruedas;

        public double getLargo() => largo;

        public double getAncho() => ancho;

        //Podemos crear multiples getters, o bien un getter que devuelva directamente el string con toda la informacion :
        public string getDatos() => $"\tEl Nissan Skyline tiene {ruedas} ruedas, mide {largo} metros de largo y {ancho} metros de ancho.";

        public void setExtras(bool climatizador, string tapiceria)
        {
            //Para diferenciar cuando me refiero a un campo de clase (Variable dentro de una clase), de un parametro, se utiliza la palabra reservada 'this'.
            this.climatizador = climatizador;
            this.tapiceria = tapiceria;
        }

        public string getExtras()
        {
            if (climatizador == true)
            {
                return $"Tapiceria : {tapiceria} / Climatizador : Si";
            }
            else
            {
                return $"Tapiceria : {tapiceria} / Climatizador : No";
            }
        }

        private int ruedas;
        private double largo;
        private double ancho;
        private bool climatizador;
        private string tapiceria;

    }
}

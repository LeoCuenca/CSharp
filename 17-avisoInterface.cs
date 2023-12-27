using System;

namespace Tema
{
    //Deberia crear cada interface y class en ficheros diferentes .cs, haciendo uso del principio de modularizacion. Pero a efectos practicos del curso, cada class e interface estara en el mismo archivo .cs.
    public class avisoInterface
    {
        public void ejecutar17()
        {

            AvisosTrafico av1 = new AvisosTrafico();
            av1.mostrarAviso();

            AvisosTrafico av2 = new AvisosTrafico("\n\tJefatura Provincial Moron", "Sancion por exceso de velocidad : $ 30.000", "21/02/20");

            Console.WriteLine($"\tFecha de la infraccion : {av2.getFecha()}");

            av2.mostrarAviso();

        }

        interface IAvisos
        {
            void mostrarAviso();
            string getFecha();
        }

        class AvisosTrafico : IAvisos
        {

            private string remitente;
            private string mensaje;
            private string fecha;

            public AvisosTrafico()
            {
                remitente = "Direccion General de Transito";
                mensaje = "La sancion cometida";
                fecha = "";
            }

            public AvisosTrafico(string remitente, string mensaje, string fecha)
            {
                this.remitente = remitente;
                this.mensaje = mensaje;
                this.fecha = fecha;
            }

            public string getFecha() => fecha;

            public void mostrarAviso() => Console.WriteLine($"\tMensaje : {mensaje} ha sido enviado por {remitente} el dia {fecha}");
        }
    }
}

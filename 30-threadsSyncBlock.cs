using System;

namespace Tema
{
    public class Banco
    {
        public void ProblemaBancario()
        {
            CuentaBancaria CuentaFamilia = new CuentaBancaria(2000);

            Thread[] hilosPersonas = new Thread[15];

            for (int i = 0; i <15; i++)
            {
                // El constructor de la clase Thread no admite el paso de metodos que reciban parametros.
                //Thread t = new Thread(CuentaFamilia.RetirarEfectivo(500));
                // Para resolver esto, creamos un metodo que llame al metodo que recibe parametros.
                Thread t = new Thread(CuentaFamilia.VamosRetirarEfectivo);

                t.Name = $"Hilo {i}";
                
                hilosPersonas[i] = t;

            }

            for (int i = 0; i < 15; i++)
            {
                hilosPersonas[i].Start();
                // Sincronizacion. Hasta que no termine uno no empieza el otro
                //hilosPersonas[i].Join();
                
            }
        }

    }

    class CuentaBancaria
    {
        double Saldo {  get; set; }
        private Object bloqueaSaldoPositivo = new Object();

        public CuentaBancaria(double Saldo)
        {
            this.Saldo = Saldo;
        }

        public double RetirarEfectivo(double cantidad)
        {
            if((Saldo-cantidad) < 0)
            {
                Console.WriteLine($"Lo siento, quedan $ {Saldo} en la cuenta. {Thread.CurrentThread.Name}");
                return Saldo;
            }

            // Tenemos que ubicar que parte del codigo es a la que no deberian acceder todos los Threads al mismo tiempo. Todos los usuarios no pueden retirar dinero al mismo tiempo.
            // La linea a la que no pueden acceder todos al mismo tiempo y para esto utilizamos el metodo 'lock()'
            // Solo un thread accede al codigo bloqueado

            lock(bloqueaSaldoPositivo){
                if (Saldo >= cantidad)
                {
                    Console.WriteLine($"Retirado {cantidad} y queda {Saldo - cantidad} en la cuenta. Retiro {Thread.CurrentThread.Name}");
                    Saldo -= cantidad;
                }
            }
         

            return Saldo;
        }

        public void VamosRetirarEfectivo()
        {
            Console.WriteLine($"Esta sacando dinero el hilo {Thread.CurrentThread.Name}");
            for (int i = 0; i<4;i++) RetirarEfectivo(500);
        }


    }








}




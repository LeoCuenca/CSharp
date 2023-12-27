using System;

namespace Tema
{
    public class vehiculo
    {

        public vehiculo()
        {

        }

        public void arrancarMotor() => Console.WriteLine("\tArrancando el motor");
        public void pararMotor() => Console.WriteLine("\tParando el motor");
        public virtual void conducir() => Console.WriteLine("\tConduciendo el vehiculo");

    }

    public class avion : vehiculo
    {
        public avion() : base()
        {
            arrancarMotor();
            pararMotor();
            conducir();
        }

        public override void conducir() => Console.WriteLine("\tEstoy conduciendo un avion");

    }

    public class coche : vehiculo
    {

        public coche() : base()
        {
            arrancarMotor();
            pararMotor();
            conducir();
        }

        public override void conducir() => Console.WriteLine("\tEstoy conduciendo un coche");

    }
}



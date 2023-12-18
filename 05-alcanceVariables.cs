using System;
// El ambito de las variables determinan desde donde pueden ser visibles y utilizadas
public class alcanceVariables
{
    // Las variables con ambito de clase pueden estar tanto al principio como al final del codigo. Por una cuestion personal y de buena practica en otros lenguajes, siempre declaro las variables en la parte superior del codigo.
    // A las variables con ambito de clase se las conoce como 'CAMPOS DE CLASE' en la POO.
    int ambClase = 5;

    public void primer()
    {
        Console.WriteLine($"Variable con ambito de clase impresa, cuyo valor es 5: {ambClase}");
    }
    public void segunda()
    {
        // Variable de ambito local al metodo. No puede usarse en otro metodo.
        int ambMetodo = 2;
        Console.WriteLine($"Variable con ambito local de la funcion 'segunda' impresa, cuyo valor es 2 : {ambMetodo}");
    }

    public void tercera()
    {
        Console.WriteLine($"Printeando otra vez la variable con ambito de clase, desde otra funcion : {ambClase}");
    }

    /*
    public void cuarta()
    {
        int ambMetodo = 2;
        Console.WriteLine($"Variable con ambito local de la funcion 'segunda' impresa, cuyo valor es 2 : {ambMetodo}");
    }
    No puedo hacer esto, ya que el metodo estaria intentando utilizar una variable con ambito en otro metodo, en este caso, el metodo 'segunda()'.
    */


}

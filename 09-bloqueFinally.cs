using System;

public class bloqueFinally
{
	public void accesoFichero()
	{
		System.IO.StreamReader archivo = null;
		try
		{
			string linea;
			int contador = 0;
			string path = @"C:\\Users\\iSkyline\\Escritorio\\Curso C#\000-bloqueFinally.txt";

			archivo = new StreamReader(path);

			while ((linea = archivo.ReadLine()) != null)
			{
                Console.WriteLine(linea);
				contador++;
			}

		}
		catch (Exception ex)
		{
            Console.WriteLine("Error en la lectura del archivo " + ex.Message);
        }
		//El bloque finally casi SIEMPRE se usa para cerrar una conexion con una BBDD y evitar asi el consumo innecesario de recursos.
		//El flujo de ejecucion en este bloque SIEMPRE pasa por el bloque FINALLY, garantiza que siempre se ejecuten las lineas dentro.
		finally
		{
			if (archivo != null) archivo.Close();
            Console.WriteLine("Conexion con el fichero cerrada");
        }
	}
}

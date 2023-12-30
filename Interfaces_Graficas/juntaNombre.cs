using System;
using System.ComponentModel;

public class JuntaNombre : INotifyPropertyChanged
{
    private string nombre, apellido, nombreCompleto;

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string property)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value;
            OnPropertyChanged("NombreCompleto");
        }
    }
    public string Apellido
    {
        get { return apellido; }
        set { apellido = value;
            OnPropertyChanged("NombreCompleto");
        }
    }
    public string NombreCompleto
    {
        get { return $"{apellido}, {nombre}"; }
        set {  }
        
    }

}

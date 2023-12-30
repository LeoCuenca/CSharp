using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Interfaces_Graficas
{
    /// <summary>
    /// Lógica de interacción para bindingINotifyPropertyChanged.xaml
    /// </summary>
    public partial class bindingINotifyPropertyChanged : Window
    {
        public bindingINotifyPropertyChanged()
        {
            InitializeComponent();

            JuntaNombreYApellido = new JuntaNombre { Nombre = "", Apellido = "" };

            this.DataContext = JuntaNombreYApellido;
        }

        public JuntaNombre JuntaNombreYApellido;


    }
}

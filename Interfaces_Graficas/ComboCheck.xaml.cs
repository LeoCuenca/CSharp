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
    /// Lógica de interacción para ComboCheck.xaml
    /// </summary>
    public partial class ComboCheck : Window
    {
        public ComboCheck()
        {
            InitializeComponent();

            List<Capitales> ListaCapitales = new List<Capitales>();

            ListaCapitales.Add(new Capitales {NombreCapital = "Madrid"});
            ListaCapitales.Add(new Capitales {NombreCapital = "Bogota"});
            ListaCapitales.Add(new Capitales {NombreCapital = "Lima"});
            ListaCapitales.Add(new Capitales {NombreCapital = "DF"});
            ListaCapitales.Add(new Capitales {NombreCapital = "Santiago"});

            Capitales.ItemsSource = ListaCapitales;

        }

        private void TodasCapitales_Checked(object sender, RoutedEventArgs e)
        {
            Madrid.IsChecked = true;
            Lima.IsChecked = true;
            DF.IsChecked = true;
            Santiago.IsChecked = true;
            Bogota.IsChecked = true;
        }

        private void TodasCapitales_Unchecked(object sender, RoutedEventArgs e)
        {
            Madrid.IsChecked = false;
            Lima.IsChecked = false;
            DF.IsChecked = false;
            Santiago.IsChecked = false;
            Bogota.IsChecked = false;
        }

        private void IndividualChecked(object sender, RoutedEventArgs e)
        {
            if (Madrid.IsEnabled == true && Bogota.IsEnabled == true && DF.IsEnabled == true && Santiago.IsChecked == true && Lima.IsChecked == true)
            {
                TodasCapitales.IsChecked = true;
            }
            else
            {
                TodasCapitales.IsChecked = null;
             }
        }
        
        private void IndividualUnchecked(object sender, RoutedEventArgs e)
        {
            if (Madrid.IsEnabled == false && Bogota.IsEnabled == false && DF.IsEnabled == false && Santiago.IsChecked == false && Lima.IsChecked == false)
            {
                TodasCapitales.IsChecked = false;
            }
            else
            {
                TodasCapitales.IsChecked = null;
             }
        }

    }

    public class Capitales
    {
        public string NombreCapital { get; set; }
    }




}

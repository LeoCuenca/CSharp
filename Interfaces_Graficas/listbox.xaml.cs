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
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            List<Poblaciones> listaPob = new List<Poblaciones>();

            listaPob.Add(new Poblaciones() {Poblacion1 = "Madrid", Poblacion2 = "Barcelona", Temperatura1 = 15, Temperatura2 = 17, diferenciaTemperatura = 0 });
            listaPob.Add(new Poblaciones() {Poblacion1 = "Valencia", Poblacion2 = "Alicante", Temperatura1 = 19, Temperatura2 = 10, diferenciaTemperatura = 0});
            listaPob.Add(new Poblaciones() {Poblacion1 = "Malaga", Poblacion2 = "Bilbao", Temperatura1 = 20, Temperatura2 = 25, diferenciaTemperatura = 0});
            listaPob.Add(new Poblaciones() {Poblacion1 = "Sevilla", Poblacion2 = "Coruña", Temperatura1 = 22, Temperatura2 = 30, diferenciaTemperatura = 0});
            
            listaPoblaciones.ItemsSource = listaPob;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(listaPoblaciones.SelectedItem != null)
            {
                MessageBox.Show($"{(listaPoblaciones.SelectedItem as Poblaciones)!.Poblacion1} {(listaPoblaciones.SelectedItem as Poblaciones)!.Temperatura1} ºC {(listaPoblaciones.SelectedItem as Poblaciones)!.Poblacion2} {(listaPoblaciones.SelectedItem as Poblaciones)!.Temperatura2} ºC y la diferencia de temperatura entre las regiones es de {(listaPoblaciones.SelectedItem as Poblaciones)!.diferenciaTemperatura} ºC");
            }
        }

        private void listaPoblaciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show($"{(listaPoblaciones.SelectedItem as Poblaciones)!.Poblacion1} {(listaPoblaciones.SelectedItem as Poblaciones)!.Temperatura1} ºC {(listaPoblaciones.SelectedItem as Poblaciones)!.Poblacion2} {(listaPoblaciones.SelectedItem as Poblaciones)!.Temperatura2} ºC y la diferencia de temperatura entre las regiones es de {(listaPoblaciones.SelectedItem as Poblaciones)!.diferenciaTemperatura} ºC");
        }
    }

    public class Poblaciones
    {
        public string Poblacion1 { get; set; }
        public int Temperatura1 { get; set; }
        public string Poblacion2 { get; set; }
        public int Temperatura2 { get; set; }
        public int diferenciaTemperatura
        {
            get { return Math.Abs(Temperatura1-Temperatura2); }
            set { }
        }
    }









}

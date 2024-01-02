using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Interfaces_Graficas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // ----------------------------------------------------------------------------------------------
        // Creacion de una Dependency Property
        //public int MiProperty
        //{
        //    get { return (int) GetValue(miDependencyProperty); }
        //    set { SetValue(miDependencyProperty, value); }
        //}

        //public static readonly DependencyProperty miDependencyProperty = DependencyProperty.Register("MiProperty", typeof(int), typeof(MainWindow), new PropertyMetadata(0));
        // ----------------------------------------------------------------------------------------------

        public MainWindow()
        {
            
            InitializeComponent();
            

        }

        private void ListBox(object sender, RoutedEventArgs e)
        {
            Window1 ventanaListBox = new Window1();
            ventanaListBox.Show();
            
        }

        private void INotifyPropertyChanged(object sender, RoutedEventArgs e)
        {
            bindingINotifyPropertyChanged ventanaINPC = new bindingINotifyPropertyChanged();
            ventanaINPC.Show();
        }

        private void ComboCheck(object sender, RoutedEventArgs e)
        {
            ComboCheck ventanaComboCheck = new ComboCheck();
            ventanaComboCheck.Show();
        }

        private void RadioButton(object sender, RoutedEventArgs e)
        {
            RadioButton ventanaRadioButton = new RadioButton();
            ventanaRadioButton.Show();
        }
    }
}
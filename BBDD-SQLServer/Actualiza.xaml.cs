using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Data;
using System.Configuration;

namespace BBDD_SQLServer
{
    /// <summary>
    /// Lógica de interacción para Actualiza.xaml
    /// </summary>
    public partial class Actualiza : Window
    {
        SqlConnection miConexionSQL;

        // Declaro la variable z para traerme el valor del ID del cliente de la ventana MAINWINDOWS a esta y poder utilizarla como parametro en la consulta SQL.
        private int z;

        // El CONSTRUCTOR de la clase recibira un int denominado elID donde almacenara el valor que le pasemos desde MAINWINDOWS y lo almacena en z, en la linea 36
        public Actualiza(int elID)
        {

            InitializeComponent();

            z = elID;

            string miConexion = ConfigurationManager.ConnectionStrings["BBDD_SQLServer.Properties.Settings.GestionPedidosConnectionString"].ConnectionString;

            miConexionSQL = new SqlConnection(miConexion);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string consulta = "UPDATE CLIENTE SET NOMBRE = @NOMBRE WHERE ID = " + z;

            SqlCommand miSQLComand = new SqlCommand(consulta, miConexionSQL);

            miConexionSQL.Open();

            miSQLComand.Parameters.AddWithValue("@NOMBRE", cuadroActualiza.Text);

            miSQLComand.ExecuteNonQuery();

            miConexionSQL.Close();

            // El THIS HACE REFERENCIA A LA CLASE EN LA QUE NOS ENCONTRAMOS. 
            this.Close();

        }
    }
}

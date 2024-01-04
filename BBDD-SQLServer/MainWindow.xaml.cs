using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace BBDD_SQLServer
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Instanciamos este objeto para establecer la conexion
        SqlConnection miConexionSQL;

        public MainWindow()
        {
            InitializeComponent();

            // Cadena de conexion a BBDD
            
            string miConexion = ConfigurationManager.ConnectionStrings["BBDD_SQLServer.Properties.Settings.GestionPedidosConnectionString"].ConnectionString;
            // Asignamos a la instancia un nuevo objeto
            miConexionSQL = new SqlConnection(miConexion);
            MuestraClientes();
            MuestraTodosPedidos();
        }

        private void MuestraClientes()
        {
            try
            {
                // En consulta establecemos el tipo de consulta a realizar. En este caso mostrara todos los datos de la tabla Clientes, pero puede ser un filtro, una busqueda, borrar, crear, editar, etc ...
                string consulta = "SELECT * FROM CLIENTE";

                // Instanciamos esta clase SQLDATAADAPTER para guardar los datos que vengan de la tabla en cuestion. El constructor esta sobrecargado, hay 4, uno de ellos nos permite pasarle dos argumentos a la instancia, una es la instruccion SQL (consulta) y el otro es la la instancia de SQLConection (miConexionSQL).
                SqlDataAdapter miAdaptadorSQL = new SqlDataAdapter(consulta, miConexionSQL);

                // Almacenamos en un DATATABLE los datos para finalmente mostrarlos, asi que utilizando el adaptador instanciado anteriormente, rellenamos la tabla 
                using (miAdaptadorSQL)
                {
                    DataTable clientesTabla = new DataTable();

                    miAdaptadorSQL.Fill(clientesTabla);

                    listaClientes.DisplayMemberPath = "nombre";
                    listaClientes.SelectedValuePath = "Id";
                    listaClientes.ItemsSource = clientesTabla.DefaultView;
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MuestraPedidos()
        {
            try
            {
                // CONSULTA PARAMETRICA. P = OBJETO DE TIPO PEDIDO, lo puedo llamar de cualquier otra forma.
                string consulta = "SELECT * FROM PEDIDO P INNER JOIN CLIENTE C ON C.Id = P.cCliente where C.Id = @ClienteID";

                // Instruccion que nos permite ejecutar una instruccion SQL PARAMETRIZADA 
                SqlCommand sqlComando = new SqlCommand(consulta, miConexionSQL);
                // Ahora nuestro objeto DataAdapter va a recibir los registros que devuelva una consulta parametrica.
                SqlDataAdapter miAdaptadorSQL = new SqlDataAdapter(sqlComando);

                using (miAdaptadorSQL)
                {
                    // Obtiene la informacion que nos devuelve la consulta con su parametro .AddWithValue( Nombre del Parametro , De donde viene el dato que se almacena en el paramtro );
                    sqlComando.Parameters.AddWithValue("@ClienteId", listaClientes.SelectedValue);

                    DataTable pedidosTabla = new DataTable();

                    miAdaptadorSQL.Fill(pedidosTabla);

                    // Muestra la informacion que quiero mostrar
                    pedidosCliente.DisplayMemberPath = "fechaPedido";
                    // Aca va el campo clave
                    pedidosCliente.SelectedValuePath = "Id";
                    // Le damos la source a la tabla
                    pedidosCliente.ItemsSource = pedidosTabla.DefaultView;
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MuestraTodosPedidos()
        {
            try
            {
                // CONSULTA DE CAMPO NUEVO CALCULADO
                // 
                string consulta = "select *, concat('Nro Cliente : ',cCliente,' Fecha : ',fechaPedido,' Forma de Pago : ',formapago) as infoCompleta from pedido ";

                SqlDataAdapter miAdaptadorSQL = new SqlDataAdapter(consulta, miConexionSQL);

                using (miAdaptadorSQL)
                {
                    // Creacion de una tabla virtual
                    DataTable pedidosTabla = new DataTable();

                    // Con esta instruccion rellenamos la tabla virtual con lo que tengo en miAdaptadorSQL
                    miAdaptadorSQL.Fill(pedidosTabla);

                    // Con esta instruccion le decimos que muestre los 3 campos
                    todosPedidos.DisplayMemberPath = "infoCompleta";
                    // Decimos cual es el campo clave
                    todosPedidos.SelectedValuePath = "Id";
                    todosPedidos.ItemsSource = pedidosTabla.DefaultView;
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Para poder borrar los registros, a la hora de mostrar todos los registros, con una consulta CALCULADA, tengo que agregar una seleccion a todo en la consulta (select*, blabla) EN MUESTRATODOSPEDIDOS
            // MessageBox.Show(todosPedidos.SelectedValue.ToString());
            string consulta = "DELETE FROM PEDIDO WHERE ID = @PEDIDOID";

            SqlCommand miSQLComand = new SqlCommand(consulta, miConexionSQL);

            miConexionSQL.Open();

            miSQLComand.Parameters.AddWithValue("@PEDIDOID", todosPedidos.SelectedValue);

            miSQLComand.ExecuteNonQuery();

            MuestraTodosPedidos();

            miConexionSQL.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string consulta = "INSERT INTO CLIENTE (NOMBRE) VALUES (@NOMBRE)";

            SqlCommand miSQLComand = new SqlCommand(consulta, miConexionSQL);

            miConexionSQL.Open();

            miSQLComand.Parameters.AddWithValue("@NOMBRE", insertaCliente.Text);

            miSQLComand.ExecuteNonQuery();

            MuestraClientes();

            miConexionSQL.Close();

            insertaCliente.Text = "";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string consulta = "DELETE FROM CLIENTE WHERE ID = @CLIENTEID";

            SqlCommand miSQLComand = new SqlCommand(consulta, miConexionSQL);

            miConexionSQL.Open();

            miSQLComand.Parameters.AddWithValue("@CLIENTEID", listaClientes.SelectedValue);

            miSQLComand.ExecuteNonQuery();

            MuestraClientes();

            miConexionSQL.Close();
        }

        private void listaClientes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MuestraPedidos();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            if (listaClientes.SelectedItems.Count != 0)
            {
                Actualiza ventanaActualizar = new Actualiza((int)listaClientes.SelectedValue);

                string consulta = "SELECT NOMBRE FROM CLIENTE WHERE ID=@CLID";

                SqlCommand sqlComando = new SqlCommand(consulta, miConexionSQL);

                SqlDataAdapter miAdaptadorSQL = new SqlDataAdapter(sqlComando);

                using (miAdaptadorSQL)
                {

                    sqlComando.Parameters.AddWithValue("@CLID", listaClientes.SelectedValue);

                    DataTable clientesTabla = new DataTable();

                    miAdaptadorSQL.Fill(clientesTabla);

                    ventanaActualizar.cuadroActualiza.Text = clientesTabla.Rows[0]["NOMBRE"].ToString();

                }


                // REFRESCAR LA PANTALLA MAIN SE PUEDE HACER TAMBIEN CON UN EVENTO DE TIPO ACTIVATED EN EL CODIGO XAML. EL EVENTO ACTIVATED SE DISPARA CUANDO LA VENTANA OBTIENE EL FOCO.
                // Setea la ventana que aparece en primer plano y detiene el flujo de ejecucion
                ventanaActualizar.ShowDialog();

                MuestraClientes();

            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro a eliminar");
            }
        }
    }
}

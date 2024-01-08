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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace CRUD_LINQ
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // LINQ TO SQL
        DataClasses1DataContext dataContext;

        public MainWindow()
        {
            InitializeComponent();
            // Cadena de conexion
            string miConexion = ConfigurationManager.ConnectionStrings["CRUD_LINQ.Properties.Settings.CrudLinqSql"].ConnectionString;
            // Mapeo de datos con los que vamos a conectar, que es un archivo que tenemos que agregar al proyecto de tipo LINQ TO SQL
            dataContext = new DataClasses1DataContext(miConexion);

            //InsertaEmpresas();
            //InsertaEmpleados();
            //InsertaCargos();
            //InsertaEmpleadoCargo();
            //ActualizaEmpleado();
            EliminaEmpleado();
        }

        public void InsertaEmpresas()
        {
            //dataContext.ExecuteCommand("Delete from Empresa");

            // Creo una instancia de una tabla que hayamos agregado previamente al archivo .dbml
            Empresa pildorasInformaticas = new Empresa();
            // Utilizando POO y el operador punto le damos los diferentes datos asociados al objeto creado.
            pildorasInformaticas.Nombre = "Pildoras Informaticas";
            // Inserta el registro en la tabla asociada al objeto instanciado ---> Sintaxis: dataContext.NOMBRE DE TABLA ASOCIADA.InsertOnSubmit(NOMBRE DE INSTANCIA);
            dataContext.Empresa.InsertOnSubmit(pildorasInformaticas);
            // Esta instruccion confirma los cambios. EL REGISTRO YA FUE SATISFACTORIAMENTE INGRESADO EN LA TABLA. Solo resta mostrarlo en el grid.
            // dataContext.SubmitChanges();
            // Mostrar en DataGrid
            //Principal.ItemsSource = dataContext.Empresa;

            Empresa empresaGoogle = new Empresa();
            empresaGoogle.Nombre = "Google";
            dataContext.Empresa.InsertOnSubmit(empresaGoogle);

            dataContext.SubmitChanges();            
            Principal.ItemsSource = dataContext.Empresa;
        }

        public void InsertaEmpleados()
        {
            // Para especificar a que empresa va a pertenecer un empleado, tengo que crear un objeto de tipo Empresa, para poder darle ID de Empresa al empleado
            // El metodo FIRST es una busqueda que devuelve la primer coincidencia
            // Utilizando expresiones LAMBDA, declaro una variable la cual mediante el operador punto, la relaciono con el nombre de la empresa con el metodo EQUALS
            // Con esta instruccion voy a tener dentro de este objeto, la Empresa Pildoras Informaticas
            Empresa pildorasInformaticas = dataContext.Empresa.First(em => em.Nombre.Equals("Pildoras Informaticas"));
            Empresa empresaGoogle = dataContext.Empresa.First(em => em.Nombre.Equals("Google"));
            // Esta es una forma de hacerlo utilizando una instruccion SQL, pero con LINQ, se simplifica utilizando expresiones LAMBDA
            // Empresa pildorasInformaticas = dataContext.Empresa.First("from Empresa in dataContext.Empresa where Empresa == 'Pildoras Informaticas' select Empresa");

            // Esto es para agregar varios empleados con una lista
            List<Empleado> listaEmpleados = new List<Empleado>();
            listaEmpleados.Add(new Empleado { Nombre = "Juan", Apellido = "Diaz", EmpresaID = pildorasInformaticas.Id });
            listaEmpleados.Add(new Empleado { Nombre = "Antonio", Apellido = "Fernandez", EmpresaID = pildorasInformaticas.Id });
            listaEmpleados.Add(new Empleado { Nombre = "Ana", Apellido = "Martin", EmpresaID = empresaGoogle.Id });
            listaEmpleados.Add(new Empleado { Nombre = "Maria", Apellido = "Lopez", EmpresaID = empresaGoogle.Id });

            dataContext.Empleado.InsertAllOnSubmit(listaEmpleados);
            dataContext.SubmitChanges();
            Principal.ItemsSource = dataContext.Empleado;

        }

        public void InsertaCargos()
        {
            List<Cargo> listaCargos = new List<Cargo>();

            listaCargos.Add(new Cargo { NombreCargo = "Director"});
            listaCargos.Add(new Cargo { NombreCargo = "Sub Director" });
            listaCargos.Add(new Cargo { NombreCargo = "Administrativo" });
            listaCargos.Add(new Cargo { NombreCargo = "Limpieza" });

            dataContext.Cargo.InsertAllOnSubmit(listaCargos);
            dataContext.SubmitChanges();
            Principal.ItemsSource = dataContext.Cargo;

        }

        public void InsertaEmpleadoCargo()
        {
            // CARGA INDIVIDUAL DE CARGOS DE EMPLEADOS
            
            //Empleado juan = dataContext.Empleado.First(em => em.Nombre.Equals("Juan"));
            //Empleado ana = dataContext.Empleado.First(em => em.Nombre.Equals("Ana"));
            //Empleado maria = dataContext.Empleado.First(em => em.Nombre.Equals("Maria"));
            //Empleado antonio = dataContext.Empleado.First(em => em.Nombre.Equals("Antonio"));

            //Cargo director = dataContext.Cargo.First(em => em.NombreCargo.Equals("Director"));
            //Cargo admin = dataContext.Cargo.First(em => em.NombreCargo.Equals("Administrativo"));

            //CargoEmpleado cargoJuan = new CargoEmpleado();
            //cargoJuan.Empleado = juan;
            //cargoJuan.CargoID = director.Id;
            
            List<CargoEmpleado> listaCargoEmpleados = new List<CargoEmpleado>();

            listaCargoEmpleados.Add(new CargoEmpleado { Empleado = dataContext.Empleado.First(em => em.Nombre.Equals("Ana")), Cargo = dataContext.Cargo.First(em => em.NombreCargo.Equals("Director")) });
            listaCargoEmpleados.Add(new CargoEmpleado { Empleado = dataContext.Empleado.First(em => em.Nombre.Equals("Maria")), Cargo = dataContext.Cargo.First(em => em.NombreCargo.Equals("Administrativo")) });
            listaCargoEmpleados.Add(new CargoEmpleado { Empleado = dataContext.Empleado.First(em => em.Nombre.Equals("Antonio")), Cargo = dataContext.Cargo.First(em => em.NombreCargo.Equals("Director")) });

            dataContext.CargoEmpleado.InsertAllOnSubmit(listaCargoEmpleados);
            dataContext.SubmitChanges();
            Principal.ItemsSource = dataContext.CargoEmpleado;

        }

        public void ActualizaEmpleado()
        {
            Empleado maria = dataContext.Empleado.First(em => em.Nombre.Equals("Maria"));
            maria.Nombre = "Maria Angeles";
            dataContext.SubmitChanges();
            Principal.ItemsSource = dataContext.Empleado;
        }

        public void EliminaEmpleado()
        {
            Empleado juan = dataContext.Empleado.First(em => em.Nombre.Equals("Juan"));
            dataContext.Empleado.DeleteOnSubmit(juan);
            dataContext.SubmitChanges();
            Principal.ItemsSource = dataContext.Empleado;
        }

    }
}

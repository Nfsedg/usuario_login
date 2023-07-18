using Proyecto_Final_23AM.Entities;
using Proyecto_Final_23AM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Proyecto_Final_23AM.Vista
{
    /// <summary>
    /// Lógica de interacción para Sistema.xaml
    /// </summary>
    public partial class Sistema : Window
    {

        public Sistema()
        {
            InitializeComponent();
            GetUserTable();
            Roles();
        }

        UsuarioServices services = new UsuarioServices();

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
           
                Usuario usuario = new Usuario();
                usuario.Nombre = txtNombre.Text;
                usuario.Username = txtUserName.Text;
                usuario.Password = txtPassword.Text;

                services.AddUser(usuario);

                txtNombre.Clear();
                txtUserName.Clear();
                txtPassword.Clear();
                GetUserTable();
            
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
           
        }
        public void GetUserTable()
        {
          UserTable.ItemsSource=services.GetUsuarios();
        }
       
        private void Roles()
        {
            try
            {
                List<Rol> roles = services.GetRoles();
                SelectRol.ItemsSource = roles;
                SelectRol.DisplayMemberPath = "Nombre";
                SelectRol.SelectedValuePath = "PkRol";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el ComboBox de roles: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

using RegistroDisco.BLL;
using RegistroDisco.DAL;
using RegistroDisco.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace RegistroDisco
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Discos Disco = new Discos();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = Disco;
            
        }

        private void buscarButton_Click(object sender, RoutedEventArgs e)
        {
            Contexto contexto = new Contexto();

            var disco = contexto.Discos.Find(int.Parse(idDiscoTextBox.Text));

            if(disco == null)
            {
                MessageBox.Show("Este registro no existe.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
                return;
            }

            if(Disco != null)
            {
                this.Disco = disco;
            }
            else
            {
                this.Disco = new Discos();
                this.Disco = disco;
            }

            this.DataContext = this.Disco;
        }

        private void nuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void guardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
            {
                return;
            }

            if (DiscosBLL.Guardar(Disco))
            {
                MessageBox.Show("Guardado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Algo salio mal", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (DiscosBLL.Eliminar(int.Parse(idDiscoTextBox.Text)))
            {
                MessageBox.Show("Eliminado", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Es posible que este registro ya se haya eliminado o no exista", "Exito", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void Limpiar()
        {
            this.Disco = new Discos();
            this.DataContext = this.Disco;
        }

        public bool Validar()
        {

            if (!Regex.IsMatch(idDiscoTextBox.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Caracter no admitido en campo Id Disco.", "Solo digitos",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (!Regex.IsMatch(nombreDiscoTextBox.Text, @"^[A-Za-z]+$"))
            {
                MessageBox.Show("Caracter no admitido en campo Nombre Disco.", "Solo caracteres alfebeticos",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (!Regex.IsMatch(catCancionesTextBox.Text, @"[1-9]+$"))
            {
                MessageBox.Show("Tome en cuenta lo siguiente:\n-Caracter no admitido en campo Cantidad de Canciones.\n" +
                    "-La cantidad de canciones no pueden ser menor a 0", "Aviso",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            else if(!Regex.IsMatch(nombreArtistaTextBox.Text, @"[A-Za-z]+$"))
            {
                MessageBox.Show("Caracter no admitido en campo Nombre del Artista.", "Solo caracteres alfebeticos",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
    }
}

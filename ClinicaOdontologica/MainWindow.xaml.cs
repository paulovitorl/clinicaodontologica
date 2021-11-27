using Microsoft.Data.SqlClient;
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

namespace ClinicaOdontologica
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void clickDentista(object sender, RoutedEventArgs e)
        {
            var window = new DentistaList();

            window.Owner = this;
            window.Show();
        }

        private void clickPaciente(object sender, RoutedEventArgs e)
        {
            var window = new PacienteList();

            window.Owner = this;
            window.Show();
        }

        private void clickConsulta(object sender, RoutedEventArgs e)
        {
            var window = new ConsultaList();

            window.Owner = this;
            window.Show();
        }

        private void clickServico(object sender, RoutedEventArgs e)
        {
            var window = new ServicoList();

            window.Owner = this;
            window.Show();
        }

    }
}

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

namespace ClinicaOdontologica
{
    public partial class ServicoWindow : Window
    {
        public ServicoWindow()
        {
            InitializeComponent();
        }

        private void addServico(object sender, RoutedEventArgs e)
        {

            if (!isValid())
            {
                return;
            }

            Servico servico = new Servico();
            servico.Nome = Nome.Text;
            servico.Valor = Double.Parse(Valor.Text.ToString());

            int id_consulta = servico.addServico();

            if (id_consulta > 0)
            {
                MessageBox.Show("Salvo com sucesso!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Não foi possível cadastrar a consulta");
            }

        }

        private void closeWin(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool isValid()
        {
            if (
                String.IsNullOrEmpty(Nome.Text) ||
                String.IsNullOrEmpty(Valor.Text)
                )
            {
                MessageBox.Show("Atenção: É necessário preencher todos os campos!");
                return false;
            }

            return true;
        }
    }
}

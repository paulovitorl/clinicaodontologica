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
    public partial class PacienteWindow : Window
    {
        public PacienteWindow()
        {
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void addPaciente(object sender, RoutedEventArgs e)
        {

            if (!isValid())
            {
                return;
            }

            Paciente paciente= new Paciente();
            paciente.Nome = Nome.Text;
            paciente.Sexo = Sexo.SelectedValue.ToString();
            paciente.DataNascimento = DataNascimento.SelectedDate.Value;
            paciente.Cpf = Cpf.Text;
            paciente.NumProntuario = NumProntuario.Text;

            paciente.Endereco.Estado = Estado.SelectedValue.ToString();
            paciente.Endereco.Cep = int.Parse(Cep.Text);
            paciente.Endereco.Cidade = Cidade.Text;
            paciente.Endereco.Bairro = Bairro.Text;
            paciente.Endereco.Logradouro = Logradouro.Text;
            paciente.Endereco.Referencia = Referencia.Text;
            paciente.Endereco.Numero = int.Parse(Numero.Text);
            paciente.Endereco.Complemento = Complemento.Text;

            paciente.Contato.Email = Email.Text;
            paciente.Contato.Telefone = Telefone.Text;

            int id_paciente = paciente.addPaciente();
            if(id_paciente > 0)
            {
                MessageBox.Show("Salvo com sucesso!");
                this.Close();
            } else
            {
                MessageBox.Show("Não foi possível cadastrar o paciente");
            }
          
        }

        public void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private bool isValid()
        {
            if(
                String.IsNullOrEmpty(Nome.Text) ||
                Sexo.SelectedValue == null ||
                DataNascimento.SelectedDate == null ||
                String.IsNullOrEmpty(Cpf.Text) ||
                String.IsNullOrEmpty(NumProntuario.Text) ||
                Estado.SelectedValue == null ||
                String.IsNullOrEmpty(Cidade.Text) ||
                String.IsNullOrEmpty(Cep.Text) ||
                String.IsNullOrEmpty(Logradouro.Text) ||
                String.IsNullOrEmpty(Bairro.Text)
                )
            {
                MessageBox.Show("Atenção: É necessário preencher todos os campos!");
                return false;
            }

            return true;
        }

        public void Cep_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Cep.Text != null)
            {
                dynamic addressResp = Endereco.getAddressByCep(Int32.Parse(Cep.Text));
                if (addressResp != null)
                {
                    Cidade.Text = addressResp.localidade;
                    Bairro.Text = addressResp.bairro;
                    Logradouro.Text = addressResp.logradouro;
                    Estado.SelectedValue = addressResp.uf;
                }
                else
                {
                    MessageBox.Show("Não foi possível encontrar o CEP!");
                }
            }
        }
    }
}

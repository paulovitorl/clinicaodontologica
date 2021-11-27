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
using System.Windows.Shapes;

namespace ClinicaOdontologica
{
    public partial class DentistaWindow : Window
    {
        public DentistaWindow()
        {
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void addDentista(object sender, RoutedEventArgs e)
        {

            if (!isValid())
            {
                return;
            }

            Dentista dentista = new Dentista();
            dentista.Nome = Nome.Text;
            dentista.Sexo = Sexo.SelectedValue.ToString();
            dentista.DataNascimento = DataNascimento.SelectedDate.Value;
            dentista.Cpf = Cpf.Text;
            dentista.Cro = Cro.Text;
            dentista.Funcionario.Salario = Double.Parse(Salario.Text.ToString());
            dentista.Funcionario.Situacao = Int32.Parse(Situacao.SelectedValue.ToString());
            dentista.Funcionario.IdCargo = Cargo.getCargoIdByName(Funcao.SelectedValue.ToString());

            dentista.Endereco.Estado = Estado.SelectedValue.ToString();
            dentista.Endereco.Cep = int.Parse(Cep.Text);
            dentista.Endereco.Cidade = Cidade.Text;
            dentista.Endereco.Bairro = Bairro.Text;
            dentista.Endereco.Logradouro = Logradouro.Text;
            dentista.Endereco.Referencia = Referencia.Text;
            dentista.Endereco.Numero = int.Parse(Numero.Text);
            dentista.Endereco.Complemento = Complemento.Text;

            dentista.Contato.Email = Email.Text;
            dentista.Contato.Telefone = Telefone.Text;

            int id_dentista = dentista.addDentista();
            if (id_dentista > 0)
            {
                MessageBox.Show("Salvo com sucesso!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Não foi possível cadastrar o dentista");
            }

        }

        public void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private bool isValid()
        {
            if (
                String.IsNullOrEmpty(Nome.Text) ||
                Sexo.SelectedValue == null ||
                DataNascimento.SelectedDate == null ||
                String.IsNullOrEmpty(Cpf.Text) ||
                String.IsNullOrEmpty(Cro.Text) ||
                Estado.SelectedValue == null ||
                Situacao.SelectedValue == null ||
                Funcao.SelectedValue == null ||
                String.IsNullOrEmpty(Cidade.Text) ||
                String.IsNullOrEmpty(Cep.Text) ||
                String.IsNullOrEmpty(Email.Text) ||
                String.IsNullOrEmpty(Logradouro.Text) ||
                String.IsNullOrEmpty(Bairro.Text) ||
                String.IsNullOrEmpty(Situacao.Text) ||
                String.IsNullOrEmpty(Salario.Text)
                )
            {
                MessageBox.Show("Atenção: É necessário preencher todos os campos!");
                return false;
            }

            return true;
        }

        public void Cep_LostFocus(object sender, RoutedEventArgs e)
        {
            if(Cep.Text != null)
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

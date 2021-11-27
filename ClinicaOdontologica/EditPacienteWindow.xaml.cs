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
    public partial class EditPacienteWindow : Window
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader dataReader;
        private string query = string.Empty;
        private int idPaciente;
        private int idEndereco;
        private int idContato;
        public EditPacienteWindow(int id_paciente)
        {
            InitializeComponent();
            initInfo(id_paciente);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void initInfo(int id_paciente)
        {
            idPaciente = id_paciente;
            try
            {
                using (connection = new SqlConnection())
                {
                    connection.ConnectionString = SqlParams.connectionString;

                    query = "SELECT * FROM Paciente WHERE id_paciente = " + id_paciente;

                    using (command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (dataReader = command.ExecuteReader())
                        {
                            dataReader.Read();

                            int id_pessoa = dataReader.GetInt32(2);
                            Pessoa pessoa = Pessoa.getPessoaById(id_pessoa);

                            Paciente paciente = new Paciente();
                            paciente.Id = dataReader.GetInt32(0);

                            Nome.Text = pessoa.Nome;
                            DataNascimento.SelectedDate = pessoa.DataNascimento;
                            Cpf.Text = pessoa.Cpf;
                            
                            foreach (ComboBoxItem item in Sexo.Items)
                            {
                                if (item.Tag.ToString() == pessoa.Sexo)
                                {
                                    Sexo.Text = item.Content.ToString();
                                    break;
                                }
                            }

                            Telefone.Text = pessoa.Contato.Telefone;
                            Email.Text = pessoa.Contato.Email;
                            NumProntuario.Text = dataReader.GetString(1);

                            Estado.SelectedValue = pessoa.Endereco.Estado;

                            foreach (ComboBoxItem item in Estado.Items)
                            {
                                if (item.Tag.ToString() == pessoa.Endereco.Estado)
                                {
                                    Estado.Text = item.Content.ToString();
                                    break;
                                }
                            }

                            idEndereco = pessoa.Endereco.IdEndereco;
                            Cep.Text = pessoa.Endereco.Cep.ToString();
                            Cidade.Text = pessoa.Endereco.Cidade;
                            Bairro.Text = pessoa.Endereco.Bairro;
                            Logradouro.Text = pessoa.Endereco.Logradouro;
                            Referencia.Text = pessoa.Endereco.Referencia;
                            Cep.Text = pessoa.Endereco.Cep.ToString();
                            Numero.Text = pessoa.Endereco.Numero.ToString();
                            Complemento.Text = pessoa.Endereco.Complemento;

                            idContato = pessoa.Contato.idContato;
                            Email.Text = pessoa.Contato.Email;
                            Telefone.Text = pessoa.Contato.Telefone;

                        }
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        private bool isValid()
        {
            if (
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

        private void Cep_LostFocus(object sender, RoutedEventArgs e)
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

        private void editPaciente(object sender, RoutedEventArgs e)
        {

            if (!isValid())
            {
                return;
            }

            Paciente paciente = new Paciente();
            paciente.Id = idPaciente;
            paciente.Nome = Nome.Text;
            paciente.Sexo = Sexo.SelectedValue.ToString();
            paciente.DataNascimento = DataNascimento.SelectedDate.Value;
            paciente.Cpf = Cpf.Text;
            paciente.NumProntuario = NumProntuario.Text;

            paciente.Endereco.IdEndereco = idEndereco;
            paciente.Endereco.Estado = Estado.SelectedValue.ToString();
            paciente.Endereco.Cep = int.Parse(Cep.Text);
            paciente.Endereco.Cidade = Cidade.Text;
            paciente.Endereco.Bairro = Bairro.Text;
            paciente.Endereco.Logradouro = Logradouro.Text;
            paciente.Endereco.Referencia = Referencia.Text;
            paciente.Endereco.Numero = int.Parse(Numero.Text);
            paciente.Endereco.Complemento = Complemento.Text;

            paciente.Contato.idContato = idContato;
            paciente.Contato.Email = Email.Text;
            paciente.Contato.Telefone = Telefone.Text;

            paciente.update(idPaciente);
         
            MessageBox.Show("Atualizado com sucesso!");
            this.Close();
        }
    }
}

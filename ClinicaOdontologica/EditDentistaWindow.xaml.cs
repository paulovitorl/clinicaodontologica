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
    public partial class EditDentistaWindow : Window
    {
        public EditDentistaWindow(int id_dentista)
        {
            InitializeComponent();
            initInfo(id_dentista);
        }

        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader dataReader;
        private string query = string.Empty;
        private int idDentista;
        private int idEndereco;
        private int idContato;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void initInfo(int id_dentista)
        {
            idDentista = id_dentista;
            try
            {
                using (connection = new SqlConnection())
                {
                    connection.ConnectionString = SqlParams.connectionString;

                    query = "SELECT * FROM Dentista WHERE id_dentista = " + id_dentista;

                    using (command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (dataReader = command.ExecuteReader())
                        {
                            dataReader.Read();

                            int id_pessoa = dataReader.GetInt32(2);
                            Pessoa pessoa = Pessoa.getPessoaById(id_pessoa);

                            Dentista dentista = new Dentista();
                            dentista.Id = dataReader.GetInt32(0);

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
                            Cro.Text = dataReader.GetString(1);

                            Estado.SelectedValue = pessoa.Endereco.Estado;

                            foreach (ComboBoxItem item in Estado.Items)
                            {
                                if (item.Tag.ToString() == pessoa.Endereco.Estado)
                                {
                                    Estado.Text = item.Content.ToString();
                                    break;
                                }
                            }
                            
                            int id_cargo = Cargo.getCargoIdByName("Dentista");
                            int id_funcionario = dentista.Funcionario.getIdFuncionario(id_pessoa, id_cargo);

                            Funcionario funcionario = Funcionario.getFuncionarioById(id_funcionario);
                            Salario.Text = funcionario.Salario.ToString();
                            Situacao.Text = funcionario.Situacao == 1 ? "Ativo": "Não Ativo";

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
                String.IsNullOrEmpty(Cro.Text) ||
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

        private void editDentista(object sender, RoutedEventArgs e)
        {

            if (!isValid())
            {
                return;
            }

            Dentista dentista = new Dentista();
            dentista.Id = idDentista;
            dentista.Nome = Nome.Text;
            dentista.Sexo = Sexo.SelectedValue.ToString();
            dentista.DataNascimento = DataNascimento.SelectedDate.Value;
            dentista.Cpf = Cpf.Text;
            dentista.Cro = Cro.Text;

            dentista.Endereco.IdEndereco = idEndereco;
            dentista.Endereco.Estado = Estado.SelectedValue.ToString();
            dentista.Endereco.Cep = int.Parse(Cep.Text);
            dentista.Endereco.Cidade = Cidade.Text;
            dentista.Endereco.Bairro = Bairro.Text;
            dentista.Endereco.Logradouro = Logradouro.Text;
            dentista.Endereco.Referencia = Referencia.Text;
            dentista.Endereco.Numero = int.Parse(Numero.Text);
            dentista.Endereco.Complemento = Complemento.Text;

            dentista.Contato.idContato = idContato;
            dentista.Contato.Email = Email.Text;
            dentista.Contato.Telefone = Telefone.Text;

            dentista.Funcionario.IdCargo = Cargo.getCargoIdByName("Dentista");
            dentista.Funcionario.Salario = Double.Parse(Salario.Text.ToString());
            dentista.Funcionario.Situacao = Int32.Parse(Situacao.SelectedValue.ToString());

            dentista.update();

            MessageBox.Show("Atualizado com sucesso!");
            this.Close();
        }
    }
}

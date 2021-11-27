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
    /// <summary>
    /// Lógica interna para DentistaList.xaml
    /// </summary>
    public partial class DentistaList : Window
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader dataReader;
        private string query = string.Empty;

        private List<Dentista> dentistaList;
        private Dentista dentista;

        public DentistaList()
        {
            InitializeComponent();
            listDentistas();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void listDentistas()
        {

            dentistaList = new List<Dentista>();

            try
            {
                using (connection = new SqlConnection())
                {
                    connection.ConnectionString = SqlParams.connectionString;

                    query = "SELECT * FROM Dentista";

                    using (command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {

                                int id_pessoa = dataReader.GetInt32(2);
                                Pessoa pessoa = Pessoa.getPessoaById(id_pessoa);

                                if (pessoa.Cpf != null)
                                {
                                    dentista = new Dentista();
                                    dentista.Id = dataReader.GetInt32(0);
                                    dentista.Cro = dataReader.GetString(1);

                                    dentista.Nome = pessoa.Nome;
                                    dentista.DataNascimento = pessoa.DataNascimento;
                                    dentista.Sexo = pessoa.Sexo;
                                    dentista.Cpf = pessoa.Cpf;

                                    int id_cargo = Cargo.getCargoIdByName("Dentista");
                                    int id_funcionario = dentista.Funcionario.getIdFuncionario(id_pessoa, id_cargo);
                                    Funcionario funcionario = Funcionario.getFuncionarioById(id_funcionario);
                                    
                                    dentista.Funcionario.Status = funcionario.Status;

                                    dentista.Contato.Telefone = pessoa.Contato.Telefone;
                                    dentista.Contato.Email = pessoa.Contato.Email;

                                    dentistaList.Add(dentista);
                                }

                            }
                        }
                    }
                }
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }


            DataGridDentistaList.ItemsSource = dentistaList;
        }

        public void addDentista(object sender, RoutedEventArgs e)
        {
            var window = new DentistaWindow();
            window.Closing += (o, args) =>
            {
                listDentistas();
            };

            window.Owner = this;
            window.Show();
        }

        public void removeDentista(object sender, RoutedEventArgs e)
        {
            if (DataGridDentistaList.SelectedItems.Count > 0)
            {
                Dentista dentista = (Dentista)DataGridDentistaList.SelectedValue;

                using (connection = new SqlConnection())
                {
                    connection.ConnectionString = SqlParams.connectionString;

                    string query = "SELECT * FROM Consulta WHERE id_dentista = " + dentista.Id;

                    using (command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (dataReader = command.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                MessageBox.Show("Nao é possível remover o dentista selecionado pois este têm vinculo com uma consulta...");
                                return;
                            }
                        }
                    }
                }

                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Você têm certeza que deseja remover o Dentista '#" + dentista.Id + " - " + dentista.Nome + "'?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    dentista.deleteDentista(dentista.Id);
                    listDentistas();
                }
            }
        }

        public void editDentista(object sender, RoutedEventArgs e)
        {
            if (DataGridDentistaList.SelectedItems.Count > 0)
            {
                Dentista dentista = (Dentista)DataGridDentistaList.SelectedValue;

                var window = new EditDentistaWindow(dentista.Id);
                window.Closing += (o, args) =>
                {
                    listDentistas();
                };

                window.Owner = this;
                window.Show();
            }
            else
            {
                MessageBox.Show("Selecione um dentista...");
            }
        }
    }
}

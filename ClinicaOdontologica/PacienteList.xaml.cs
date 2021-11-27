using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class PacienteList : Window
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader dataReader;
        private string query = string.Empty;

        private List<Paciente> pacienteList;
        private Paciente paciente;

        public PacienteList()
        {
            InitializeComponent();
            listPacientes();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void listPacientes()
        {

            pacienteList = new List<Paciente>();

            try
            {
                using (connection = new SqlConnection())
                {
                    connection.ConnectionString = SqlParams.connectionString;

                    query = "SELECT * FROM Paciente";

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
                                    paciente = new Paciente();
                                    paciente.Id = dataReader.GetInt32(0);
                                    paciente.NumProntuario = dataReader.GetString(1);

                                    paciente.Nome = pessoa.Nome;
                                    paciente.DataNascimento = pessoa.DataNascimento;
                                    paciente.Sexo = pessoa.Sexo;
                                    paciente.Cpf = pessoa.Cpf;

                                    paciente.Contato.Telefone = pessoa.Contato.Telefone;
                                    paciente.Contato.Email = pessoa.Contato.Email;

                                    pacienteList.Add(paciente);
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


            DataGridPacienteList.ItemsSource = pacienteList;
        }

        private void addPaciente(object sender, RoutedEventArgs e)
        {
            var window = new PacienteWindow();
            window.Closing += (o, args) =>
            {
                listPacientes();
            };

            window.Owner = this;
            window.Show();
        }

        private void removePaciente(object sender, RoutedEventArgs e)
        {
            if (DataGridPacienteList.SelectedItems.Count > 0)
            {
                Paciente paciente =   (Paciente)DataGridPacienteList.SelectedValue;

                using (connection = new SqlConnection())
                {
                    connection.ConnectionString = SqlParams.connectionString;

                    string query = "SELECT * FROM Consulta WHERE id_paciente = " + paciente.Id;

                    using (command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (dataReader = command.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                MessageBox.Show("Nao é possível remover o paciente selecionado pois este têm vinculo com uma consulta...");
                                return;
                            }
                        }
                    }
                }

                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Você têm certeza que deseja remover o Paciente '#" + paciente.Id +  " - " + paciente.Nome + "'?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    paciente.deletePaciente(paciente.Id);
                    listPacientes();
                } 
            }
        }

        private void editPaciente(object sender, RoutedEventArgs e)
        {
            if (DataGridPacienteList.SelectedItems.Count > 0)
            {
                Paciente paciente = (Paciente)DataGridPacienteList.SelectedValue;

                var window = new EditPacienteWindow(paciente.Id);
                window.Closing += (o, args) =>
                {
                    listPacientes();
                };
                
                window.Owner = this;
                window.Show();
            } else
            {
                MessageBox.Show("Selecione um paciente...");
            }
        }
    }
}

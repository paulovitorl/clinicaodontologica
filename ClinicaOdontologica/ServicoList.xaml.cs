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
    public partial class ServicoList : Window
    {
        private static SqlConnection connection;
        private static SqlCommand command;
        private static SqlDataReader dataReader;
        private static string query = string.Empty;
        private static SqlDataAdapter adapter = new SqlDataAdapter();

        public ServicoList()
        {
            InitializeComponent();
            listServicos();
        }


        private void listServicos()
        {

            List<Servico> servicoList = new List<Servico>();

            try
            {
                using (connection = new SqlConnection())
                {
                    connection.ConnectionString = SqlParams.connectionString;

                    query = "SELECT * FROM Servico";

                    using (command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                Servico servico = Servico.getServicoById(dataReader.GetInt32(0));
                                servicoList.Add(servico);
                            }
                        }
                    }
                }
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }


            DataGridServicoList.ItemsSource = servicoList;
        }

        public void addServico(object sender, RoutedEventArgs e)
        {
            var window = new ServicoWindow();
            window.Closing += (o, args) =>
            {
                listServicos();
            };

            window.Owner = this;
            window.Show();
        }

        public void removeServico(object sender, RoutedEventArgs e)
        {
            if (DataGridServicoList.SelectedItems.Count > 0)
            {

                Servico servico = (Servico)DataGridServicoList.SelectedValue;

                using (connection = new SqlConnection())
                {
                    connection.ConnectionString = SqlParams.connectionString;

                    string query = "SELECT * FROM Consulta WHERE id_servico = " + servico.Id;

                    using (command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (dataReader = command.ExecuteReader())
                        {
                            if (dataReader.HasRows) {
                                MessageBox.Show("Nao é possível remover o serviço selecionado pois este têm vinculo com uma consulta...");
                                return;
                            }
                        }
                    }
                }

                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Você têm certeza que deseja remover o serviço '#" + servico.Id + "'?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    servico.deleteServico(servico.Id);
                    listServicos();
                }
            }
        }

        public void editServico(object sender, RoutedEventArgs e)
        {
            if (DataGridServicoList.SelectedItems.Count > 0)
            {
                Servico servico = (Servico)DataGridServicoList.SelectedValue;

                var window = new EditServico(servico.Id);
                window.Closing += (o, args) =>
                {
                    listServicos();
                };

                window.Owner = this;
                window.Show();
            }
            else
            {
                MessageBox.Show("Selecione uma consulta...");
            }
        }
    }
}

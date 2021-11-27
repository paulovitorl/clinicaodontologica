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
    public partial class ConsultaList : Window
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader dataReader;
        private string query = string.Empty;
        private Consulta consulta;
        private List<Consulta> consultaList;

        public ConsultaList()
        {
            InitializeComponent();
            listConsultas();
        }

        private void listConsultas()
        {

            consultaList = new List<Consulta>();

            try
            {
                using (connection = new SqlConnection())
                {
                    connection.ConnectionString = SqlParams.connectionString; ;

                    query = "SELECT * FROM Consulta";

                    using (command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                consulta = Consulta.getConsultaById(dataReader.GetInt32(0));
                                consultaList.Add(consulta);
                            }
                        }
                    }
                }
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }


            DataGridConsultaList.ItemsSource = consultaList;
        }

        public void addConsulta(object sender, RoutedEventArgs e)
        {
            var window = new ConsultaWindow();
            window.Closing += (o, args) =>
            {
                listConsultas();
            };

            window.Owner = this;
            window.Show();
        }

        public void removeConsulta(object sender, RoutedEventArgs e)
        {
            if (DataGridConsultaList.SelectedItems.Count > 0)
            {
                Consulta consulta = (Consulta)DataGridConsultaList.SelectedValue;
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Você têm certeza que deseja remover a consulta '#" + consulta.Id + "'?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    consulta.deleteConsulta(consulta.Id);
                    listConsultas();
                }
            }
        }

        public void editConsulta(object sender, RoutedEventArgs e)
        {
            if (DataGridConsultaList.SelectedItems.Count > 0)
            {
                Consulta consulta = (Consulta)DataGridConsultaList.SelectedValue;

                var window = new EditConsulta(consulta.Id);
                window.Closing += (o, args) =>
                {
                    listConsultas();
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

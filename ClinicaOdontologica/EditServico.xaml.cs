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
    public partial class EditServico : Window
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader dataReader;
        private string query = string.Empty;

        private int idServico;

        public EditServico(int id_servico)
        {
            InitializeComponent();
            initInfo(id_servico);
        }

        private void initInfo(int id_servico)
        {
            idServico = id_servico;
            try
            {
                using (connection = new SqlConnection())
                {
                    connection.ConnectionString = SqlParams.connectionString;

                    query = "SELECT * FROM Servico WHERE id_servico = " + id_servico;

                    using (command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (dataReader = command.ExecuteReader())
                        {
                            dataReader.Read();

                            Nome.Text = dataReader.GetString(1);
                            Valor.Text = dataReader.GetDecimal(2).ToString();
                        }
                    }
                }
            }
            catch (Exception e)
            {

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

        private void editServico(object sender, RoutedEventArgs e)
        {

            if (!isValid())
            {
                return;
            }

            Servico servico = new Servico();
            servico.Id = idServico;
            servico.Nome = Nome.Text;
            servico.Valor = Double.Parse(Valor.Text);

            servico.update();

            MessageBox.Show("Atualizado com sucesso!");
            this.Close();
        } 
    }
}

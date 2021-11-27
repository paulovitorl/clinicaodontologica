using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class ConsultaWindow : Window
    {
        private static SqlConnection connection;
        private static SqlCommand command;
        private static SqlDataReader dataReader;
        private static string query = string.Empty;
        private static SqlDataAdapter adapter = new SqlDataAdapter();

        public ConsultaWindow()
        {
            InitializeComponent();
            initInfo();
        }

        private void initInfo()
        {
            
            List<Paciente> pacientes = Paciente.getPacientes();
            foreach (Paciente paciente in pacientes)
            {
                String comboboxPaciente = paciente.Id + " - " + paciente.Nome + " (" + paciente.NumProntuario + ")";
                IdPaciente.Items.Add(new ComboItem(comboboxPaciente, paciente.Id));
            }

            List<Dentista> dentistas = Dentista.getDentistas();
            foreach (Dentista dentista in dentistas)
            {
                String comboboxDentista = dentista.Id + " - " + dentista.Nome + " (" + dentista.Cro + ")";
                IdDentista.Items.Add(new ComboItem(comboboxDentista, dentista.Id));
            }


            List<Servico> servicos = Servico.getServicos();
            foreach (Servico servico in servicos)
            {
                String comboboxServico = servico.Nome + " - R$ " + servico.Valor;
                IdServico.Items.Add(new ComboItem(comboboxServico, servico.Id));
            }
        }

        private void closeWin(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addConsulta(object sender, RoutedEventArgs e)
        {

            if (!isValid())
            {
               return;
            }
            
            Consulta consulta = new Consulta();
            consulta.DataConsulta = DataConsulta.SelectedDate.Value;
            consulta.HoraConsulta = HoraConsulta.Text;
            consulta.Situacao = 1;
            consulta.Observacao = formatRtfText();
            consulta.IdPaciente = IdPaciente.SelectedItem.GetHashCode();
            consulta.IdDentista = IdDentista.SelectedItem.GetHashCode();
            consulta.IdServico = IdServico.SelectedItem.GetHashCode();

            int id_consulta = consulta.addConsulta();

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

        private string formatRtfText()
        {
            string richText = new TextRange(Observacao.Document.ContentStart, Observacao.Document.ContentEnd).Text;
            return richText;
        }
        private bool isValid()
        {
            if (
                IdServico.SelectedValue == null ||
                DataConsulta.SelectedDate == null ||
                IdDentista.SelectedValue == null ||
                IdPaciente.SelectedValue == null ||
                String.IsNullOrEmpty(HoraConsulta.Text) 
                )
            {
                MessageBox.Show("Atenção: É necessário preencher todos os campos!");
                return false;
            }


            bool invalidUsedDate = false;
            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString; ;

                string query = "" +
                    "SELECT * FROM Consulta" +
                        " WHERE" +
                        " (id_paciente = " + IdPaciente.SelectedItem.GetHashCode() + " OR id_dentista = " + IdDentista.SelectedItem.GetHashCode() + ")" +
                        " AND data_consulta = '" + DataConsulta.SelectedDate.Value.Date.ToString("yyyy-MM-dd") + "'" +
                        " AND hora_consulta = '" +  HoraConsulta.Text + "' " +
                        " AND situacao = 1";

                using (command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            invalidUsedDate = true;
                        }
                    }
                }
            }

            if(invalidUsedDate)
            {
                MessageBox.Show("Atenção: A data e hora selecionadas não esão disponíveis para este Dentista ou Paciente!");
                return false;
            }

            TimeSpan ttBD = TimeSpan.Parse(HoraConsulta.Text);

            int resultDate = DateTime.Compare(DataConsulta.SelectedDate.Value.Date, DateTime.UtcNow.Date);
            int resultHour = TimeSpan.Compare(ttBD, DateTime.Now.TimeOfDay);
            
            if (resultDate < 0 || (resultDate == 0 && resultHour < 0))
            {
                MessageBox.Show("Data inválida...");
                return false;
            } 

            return true;
        }
    }
}

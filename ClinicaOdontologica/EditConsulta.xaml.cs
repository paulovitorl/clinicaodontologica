using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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
    public partial class EditConsulta : Window
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader dataReader;
        private string query = string.Empty;
        private int idConsulta;
        public EditConsulta(int id_consulta)
        {
            InitializeComponent();
            initInfo(id_consulta);

        }

        private void initInfo(int id_consulta)
        {
            idConsulta = id_consulta;
            try
            {
                using (connection = new SqlConnection())
                {
                    connection.ConnectionString = SqlParams.connectionString;

                    query = "SELECT * FROM Consulta WHERE id_consulta = " + id_consulta;

                    using (command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (dataReader = command.ExecuteReader())
                        {
                            dataReader.Read();

                            List<Paciente> pacientes = Paciente.getPacientes();
                            int index = 0;
                            foreach (Paciente paciente in pacientes)
                            {
                                String comboboxPaciente = paciente.Id + " - " + paciente.Nome + " (" + paciente.NumProntuario + ")";
                                IdPaciente.Items.Add(new ComboItem(comboboxPaciente, paciente.Id));
                                if(paciente.Id == dataReader.GetInt32(5))
                                {
                                    IdPaciente.SelectedIndex = index;
                                }

                                index++;
                            }

                            List<Dentista> dentistas = Dentista.getDentistas();
                            index = 0;
                            foreach (Dentista dentista in dentistas)
                            {
                                String comboboxDentista = dentista.Id + " - " + dentista.Nome + " (" + dentista.Cro + ")";
                                IdDentista.Items.Add(new ComboItem(comboboxDentista, dentista.Id));
                                if (dentista.Id == dataReader.GetInt32(6))
                                {
                                    IdDentista.SelectedIndex = index;
                                }
                                index++;
                            }

                            String[] situacoes = new String[3] { "Cancelado", "Ativo", "Finalizado" };
                            
                            for(int i = 0; i < situacoes.Length; i++)
                            {
                                Situacao.Items.Add(new ComboItem(situacoes[i], i));
                                if (i == Int32.Parse(dataReader.GetByte(4).ToString()))
                                {
                                    Situacao.SelectedIndex = i;
                                }
                            }

                            List<Servico> servicos = Servico.getServicos();
                            index = 0;
                            foreach (Servico servico in servicos)
                            {
                                String comboboxServico = servico.Nome + " - R$ " + servico.Valor;
                                IdServico.Items.Add(new ComboItem(comboboxServico, servico.Id));
                                if (servico.Id == dataReader.GetInt32(7))
                                {
                                    IdServico.SelectedIndex = index;
                                }
                                index++;
                            }

                            byte[] byteArray = Encoding.ASCII.GetBytes(dataReader.GetString(1));
                            if(byteArray.Length > 0)
                            {
                                using (MemoryStream ms = new MemoryStream(byteArray))
                                {
                                    TextRange tr = new TextRange(Observacao.Document.ContentStart, Observacao.Document.ContentEnd);
                                    tr.Load(ms, DataFormats.Rtf);
                                }
                            }
                           

                            DataConsulta.SelectedDate = dataReader.GetDateTime(2);
                            TimeSpan tt = dataReader.GetTimeSpan(3);
                            HoraConsulta.Text = tt.Hours + ":" + tt.Minutes;

                            int situacao = dataReader.GetByte(4);
                            Situacao.Text = Consulta.getConsultaStatus(situacao);
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
                connection.ConnectionString = SqlParams.connectionString;

                string query = "" +
                    "SELECT * FROM Consulta" +
                        " WHERE" +
                        " (id_paciente = " + IdPaciente.SelectedItem.GetHashCode() + " OR id_dentista = " + IdDentista.SelectedItem.GetHashCode() + ")" +
                        " AND data_consulta = '" + DataConsulta.SelectedDate.Value.Date.ToString("yyyy-MM-dd") + "'" +
                        " AND hora_consulta = '" + HoraConsulta.Text + "' " +
                        " AND situacao = 1" +
                        " AND id_consulta != " + idConsulta;

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

            if (invalidUsedDate)
            {
                MessageBox.Show("Atenção: A data e hora selecionadas não esão disponíveis para este Dentista ou Paciente!");
                return false;
            }
            
            return true;
        }

        private void closeWin(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void editConsulta(object sender, RoutedEventArgs e)
        {

            if (!isValid())
            {
                return;
            }

            Consulta consulta = new Consulta();
            consulta.Id = idConsulta;
            consulta.DataConsulta = DataConsulta.SelectedDate.Value;
            consulta.HoraConsulta = HoraConsulta.Text;
            consulta.Observacao = formatRtfText();
            consulta.IdPaciente = IdPaciente.SelectedItem.GetHashCode();
            consulta.IdDentista = IdDentista.SelectedItem.GetHashCode();
            consulta.IdServico = IdServico.SelectedItem.GetHashCode();
            consulta.Situacao = Situacao.SelectedItem.GetHashCode();

            consulta.update();

            MessageBox.Show("Atualizado com sucesso!");
            this.Close();
        }

        private string formatRtfText()
        {
            string richText = new TextRange(Observacao.Document.ContentStart, Observacao.Document.ContentEnd).Text;
            return richText;
        }
    }
}

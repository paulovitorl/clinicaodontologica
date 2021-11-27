using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Documents;

namespace ClinicaOdontologica
{
    class Consulta
    {
        private static SqlConnection connection;
        private static SqlCommand command;
        private static SqlDataReader dataReader;
        private static string query = string.Empty;
        private static SqlDataAdapter adapter = new SqlDataAdapter();

        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _observacao;
        public string Observacao
        {
            get { return _observacao; }
            set { _observacao = value; }
        }

        private DateTime _dataConsulta;
        public DateTime DataConsulta
        {
            get { return _dataConsulta; }
            set { _dataConsulta = value; }
        }

        private String _dataConsultaLabel;
        public String DataConsultaLabel
        {
            get { return _dataConsultaLabel; }
            set { _dataConsultaLabel = value; }
        }


        private string _horaConsulta;
        public string HoraConsulta
        {
            get { return _horaConsulta; }
            set { _horaConsulta = value; }
        }

        private int _idPaciente;
        public int IdPaciente
        {
            get { return _idPaciente; }
            set { _idPaciente = value; }
        }

        private int _idDentista;
        public int IdDentista
        {
            get { return _idDentista; }
            set { _idDentista = value; }
        }
        
        private int _idServico;
        public int IdServico
        {
            get { return _idServico; }
            set { _idServico = value; }
        }

        private int _situacao;
        public int Situacao
        {
            get { return _situacao; }
            set { _situacao = value; }
        }

        private String _status;
        public String Status
        {
            get { return _status; }
            set { _status = value; }
        }


        private Pessoa _pessoa_dentista;
        public Pessoa PessoaDentista
        {
            get { return _pessoa_dentista; }
            set { _pessoa_dentista = value; }
        }


        private Pessoa _pessoa_paciente;
        public Pessoa PessoaPaciente
        {
            get { return _pessoa_paciente; }
            set { _pessoa_paciente = value; }
        }

        public int addConsulta()
        {
            int newId;
            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString; ;

                query = "INSERT INTO Consulta (" +
                            "observacao," +
	                        "data_consulta," +
                            "hora_consulta," +
	                        "situacao," +
                            "id_servico," +
                            "id_dentista," +
                            "id_paciente" +
                        ") " +
                        "VALUES(" +
                            "'" + HttpUtility.HtmlEncode(Observacao) + "', " +
                            "'" + DataConsulta.Date.ToString("yyyy-MM-dd")  + "', " +
                            "'" + HoraConsulta + "', " +
                            "'" + Situacao + "', " +
                            "'" + IdServico + "', " +
                            "'" + IdPaciente + "', " +
                            "'" + IdDentista + "'" +
                        "); SELECT SCOPE_IDENTITY() ";
                
                using (command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    newId = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return newId;
        }

        public void deleteConsulta(int id_consulta)
        {
            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString; ;
            
                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "DELETE FROM Consulta WHERE id_consulta = @id_consulta";
                    command.Parameters.AddWithValue("@id_consulta ", id_consulta);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static Consulta getConsultaById(int id_consulta)
        {

            Consulta consulta = new Consulta();

            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString; ;

                string query = "SELECT * FROM Consulta WHERE id_consulta = " + id_consulta;

                using (command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            consulta.Id = dataReader.GetInt32(0);
                            consulta.Observacao = dataReader.GetString(1);
                            consulta.DataConsulta = dataReader.GetDateTime(2);
                            consulta.DataConsultaLabel = consulta.DataConsulta.ToString("dd-MM-yyyy");
                            consulta.HoraConsulta = dataReader.GetTimeSpan(3).ToString();
                            consulta.Situacao = dataReader.GetByte(4);
                            consulta.IdPaciente = dataReader.GetInt32(5);
                            consulta.IdDentista = dataReader.GetInt32(6); ;
                            consulta.IdServico = dataReader.GetInt32(7);

                            int id_dentista_pessoa = Dentista.getIdPessoaByDentista(consulta.IdDentista);
                            consulta.PessoaDentista = Pessoa.getPessoaById(id_dentista_pessoa);

                            int id_paciente_pessoa = Paciente.getIdPessoaByPaciente(consulta.IdPaciente);
                            consulta.PessoaPaciente = Pessoa.getPessoaById(id_paciente_pessoa);

                            consulta.Status = Consulta.getConsultaStatus(consulta.Situacao);

                        }
                    }
                }
            }

            return consulta;
        }

        public static String getConsultaStatus(int Situacao)
        {
            switch (Situacao)
            {
                case 1:
                    return "Ativo";
                case 0:
                    return "Cancelado";
                default:
                    return "Finalizada";
            }
        }

        public void update()
        {
            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString;

                query = "UPDATE Consulta SET " +
                            "observacao = '" + HttpUtility.HtmlEncode(Observacao) + "'," +
                            "data_consulta = '" + DataConsulta.Date.ToString("yyyy-MM-dd") + "'," +
                            "hora_consulta = '" + HoraConsulta + "'," +
                            "situacao = '" + Situacao + "'," +
                            "id_servico = '" + IdServico + "'," +
                            "id_dentista = '" + IdDentista+ "'," +
                            "id_paciente = '" + IdPaciente + "'" +
                        " WHERE id_consulta = " + Id;

                using (command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }
    }
}

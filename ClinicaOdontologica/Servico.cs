using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica
{
    class Servico
    {

        private static SqlConnection connection;
        private static SqlCommand command;
        private static SqlDataReader dataReader;
        private static string query = string.Empty;
        private static SqlDataAdapter adapter = new SqlDataAdapter();

        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private double _valor;
        public double Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }
        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public int addServico()
        {
            int newId;
            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString;

                query = "INSERT INTO Servico (" +
                            "nome," +
                            "valor" +
                        ") " +
                        "VALUES(" +
                            "'" + Nome + "', " +
                            "'" + Valor + "'" +
                        "); SELECT SCOPE_IDENTITY() ";

                using (command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    newId = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return newId;
        }

        public void update()
        {
            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString;

                query = "UPDATE Servico SET " +
                            "nome = '" + Nome + "'," +
                            "valor = '" + Valor + "'" +
                        " WHERE id_servico = " + Id;

                using (command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }

        public void deleteServico(int id_servico)
        {
            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString;

                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "DELETE FROM Servico WHERE id_servico = @id_servico";
                    command.Parameters.AddWithValue("@id_servico ", id_servico);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static List<Servico> getServicos()
        {

            List<Servico> servicos = new List<Servico>();

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
                                Servico servico = new Servico();
                                servico.Id = dataReader.GetInt32(0);
                                servico.Nome = dataReader.GetString(1);
                                servico.Valor = Double.Parse(dataReader.GetDecimal(2).ToString());
                                servicos.Add(servico);
                            }
                        }
                    }
                }
            }
            catch (SqlException se)
            {
            }

            return servicos;
        }


        public static Servico getServicoById(int id_servico)
        {

            Servico servico = new Servico();

            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString;

                string query = "SELECT * FROM Servico WHERE id_servico = " + id_servico;

                using (command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (dataReader = command.ExecuteReader())
                    {
                        dataReader.Read();
                        servico.Id = dataReader.GetInt32(0);
                        servico.Nome = dataReader.GetString(1);
                        servico.Valor = Double.Parse(dataReader.GetDecimal(2).ToString());

                    }
                }
            }

            return servico;
        }
    }
}

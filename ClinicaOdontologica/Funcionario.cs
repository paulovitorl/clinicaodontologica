using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica
{
    class Funcionario : Cargo
    {

        private static SqlConnection connection;
        private static SqlCommand command;
        private static SqlDataReader dataReader;
        private static string query = string.Empty;
        private static SqlDataAdapter adapter = new SqlDataAdapter();

        private int _idFuncionario;
        public int IdFuncionario
        {
            get { return _idFuncionario; }
            set { _idFuncionario = value; }
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

        private Double _salario;
        public Double Salario
        {
            get { return _salario; }
            set { _salario = value; }
        }
        public void addFuncionario(int id_pessoa)
        {
            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString;

                query = "INSERT INTO Funcionario (" +
                            "id_pessoa," + 
                            "situacao," +
                            "salario," +
                            "id_cargo" +
                        ") " +
                        "VALUES(" +
                            "'" + id_pessoa + "', " +
                            "'" + Situacao + "', " +
                            "'" + Salario + "', " +
                            "'" + IdCargo + "'" +
                        "); SELECT SCOPE_IDENTITY() ";

                using (command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    Convert.ToInt32(command.ExecuteScalar());
                }
            }

        }

        public int getIdFuncionario(int id_pessoa, int id_cargo)
        {
            int id_funcionario = 0;
            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString;

                query = "SELECT id_funcionario FROM Funcionario WHERE id_cargo = " + id_cargo + "  AND id_pessoa = " + id_pessoa;
                using (command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (dataReader = command.ExecuteReader())
                    {
                        dataReader.Read();
                        id_funcionario = dataReader.GetInt32(0);
                    }
                }
            }

            return id_funcionario;
        }

        public static void deleteFuncionario(int id_funcionario)
        {
            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString;

                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "DELETE FROM Funcionario WHERE id_funcionario = @id_funcionario ";
                    command.Parameters.AddWithValue("@id_funcionario ", id_funcionario);
                    command.ExecuteNonQuery();
                }
            }
        }
        public static Funcionario getFuncionarioById(int id_funcionario)
        {

            Funcionario funcionario = new Funcionario();

            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString;

                string query = "SELECT * FROM Funcionario WHERE id_funcionario = " + id_funcionario;

                using (command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            funcionario.IdFuncionario = dataReader.GetInt32(0);
                            funcionario.Situacao = dataReader.GetByte(1);
                            funcionario.Salario = Double.Parse(dataReader.GetDecimal(2).ToString());
                            funcionario.IdCargo = dataReader.GetInt32(4);
                            funcionario.Status = funcionario.Situacao == 1 ? "Ativo" : "Não ativo";
                        }
                    }
                }
            }

            return funcionario;
        }
        public void update()
        {
            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString;

                query = "UPDATE Funcionario SET " +
                            "situacao = '" + Situacao + "'," +
                            "salario = '" + Salario + "'" +
                        " WHERE id_funcionario = " + IdFuncionario;

                using (command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

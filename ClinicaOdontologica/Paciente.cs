using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica
{
    class Paciente : Pessoa
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

        private string _NumProntuario;
        public string NumProntuario
        {
            get { return _NumProntuario; }
            set { _NumProntuario = value; }
        }

        public int addPaciente()
        {
            int id_pessoa = this.AddPessoa();

            int newId;
            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString;

                query = "INSERT INTO Paciente (" +
                            "numero_prontuario," +
                            "id_pessoa" +
                        ") " +
                        "VALUES(" +
                            "'" + NumProntuario + "', "
                            + id_pessoa +
                        "); SELECT SCOPE_IDENTITY() ";

                using (command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    newId = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return newId;
        }

        public void deletePaciente(int id_paciente) {

            int id_pessoa = getIdPessoaByPaciente(id_paciente);

            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString;
                query = "DELETE FROM Paciente WHERE id_paciente = " + id_paciente;

                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "DELETE FROM Paciente WHERE id_paciente = @id_paciente";
                    command.Parameters.AddWithValue("@id_paciente ", id_paciente);
                    command.ExecuteNonQuery();
                }
            }
                 
            Pessoa.deletePessoaById(id_pessoa);
        }

        public static int getIdPessoaByPaciente(int id_paciente) {
            int id_pessoa = 0;
            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString;
                
                query = "SELECT id_pessoa FROM Paciente WHERE id_paciente = " + id_paciente;
                using (command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (dataReader = command.ExecuteReader())
                    {
                        dataReader.Read();
                        id_pessoa = dataReader.GetInt32(0);
                    }
                }
            }
          
            return id_pessoa;
        }

        public void update(int idPaciente)
        {
            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString;

                query = "UPDATE Paciente SET " +
                            "numero_prontuario = '" + NumProntuario + "'" +
                        " WHERE id_paciente = " + Id;

                using (command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            int id_pessoa = getIdPessoaByPaciente(Id);

            updatePessoa(id_pessoa);
        }

        public static List<Paciente> getPacientes()
        {

            List<Paciente> pacientes = new List<Paciente>();

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
                                    Paciente paciente = new Paciente();
                                    paciente.Id = dataReader.GetInt32(0);
                                    paciente.NumProntuario = dataReader.GetString(1);

                                    paciente.Nome = pessoa.Nome;
                                    paciente.DataNascimento = pessoa.DataNascimento;
                                    paciente.Sexo = pessoa.Sexo;
                                    paciente.Cpf = pessoa.Cpf;

                                    paciente.Contato.Telefone = pessoa.Contato.Telefone;
                                    paciente.Contato.Email = pessoa.Contato.Email;

                                    pacientes.Add(paciente);
                                }

                            }
                        }
                    }
                }
            }
            catch (SqlException se)
            {
                
            }


            return pacientes;
        }

    }

}

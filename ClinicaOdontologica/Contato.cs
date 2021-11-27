using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica
{
    class Contato
    {

        private static SqlConnection connection;
        private static SqlCommand command;
        private static SqlDataReader dataReader;
        private static string query = string.Empty;
        private static SqlDataAdapter adapter = new SqlDataAdapter();

        private int _idContato;
        public int idContato
        {
            get { return _idContato; }
            set { _idContato = value; }
        }

        private string _Telefone;
        public string Telefone {
            get { return _Telefone; }
            set { _Telefone = value; }
        }
        private string _Email;
        public string Email {
            get { return _Email; }
            set { _Email = value; }
        }

        public int addContato(int id_pessoa)
        {

            int newId;
            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString; ;

                query = "INSERT INTO Contato (" +
                            "telefone," +
                            "email" +
                        ") " +
                        "VALUES(" +
                            "'" + Telefone + "'," +
                            "'" + Email + "'" +
                        "); SELECT SCOPE_IDENTITY()";

                using (command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    newId = Convert.ToInt32(command.ExecuteScalar());
                    vinculaPessoaContato(newId, id_pessoa);
                }
            }

            return newId;
        }

        public int vinculaPessoaContato(int id_pessoa, int id_contato)
        {

            int newId;
            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString; ;

                query = "INSERT INTO PessoaContato (" +
                            "id_contato," +
                            "id_pessoa" +
                        ") " +
                        "VALUES(" +
                            "'" + id_pessoa + "'," +
                            "'" + id_contato + "'" +
                        ")";

                using (command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (adapter.InsertCommand = new SqlCommand(query, connection))
                    {
                        newId = (int)adapter.InsertCommand.ExecuteNonQuery();
                    }
                }
            }

            return newId;
        }

        public static Contato getContatoByPessoaId(int id_pessoa)
        {

            Contato contato = new Contato();

            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString; ;

                query = "SELECT * FROM Contato c INNER JOIN PessoaContato pc ON pc.id_contato = c.id_contato WHERE pc.id_pessoa = " + id_pessoa;

                using (command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            contato.Telefone = dataReader.GetString(1);
                            contato.Email = dataReader.GetString(2);
                            contato.idContato = dataReader.GetInt32(0);
                        }
                    }
                }
            }

            return contato;
        }

        public static void deleteContatoById(int id_contato)
        {
            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString; ;
                using (var command = connection.CreateCommand())
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@id_contato ", id_contato);

                    command.CommandText = "DELETE FROM PessoaContato WHERE id_contato = @id_contato  ";
                    command.ExecuteNonQuery();

                    command.CommandText = "DELETE FROM Contato WHERE id_contato = @id_contato";
                    command.ExecuteNonQuery();

                }
            }
        }

        public void update()
        {
            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString; ;

                query = "UPDATE Contato SET " +
                            "telefone = '" + Telefone + "'," +
                            "email = '" + Email + "'" +
                        " WHERE id_contato = " + idContato;

                using (command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }
    }

}

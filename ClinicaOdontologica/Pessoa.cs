using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica
{
    class Pessoa
    {
        public Pessoa ()
        {
            Endereco = new Endereco();
            Contato = new Contato();
        }

        private static SqlConnection connection;
        private static SqlCommand command;
        private static SqlDataReader dataReader;
        private string query = string.Empty;
        private static SqlDataAdapter adapter = new SqlDataAdapter();

        protected int _idPessoa { get; set; }
        public int idPessoa
        {
            get { return _idPessoa; }
            set { _idPessoa = value; }
        }
        protected string _Nome { get; set; }
        public string Nome {
            get { return _Nome; }
            set { _Nome = value; }
        }
        protected DateTime _DataNascimento { get; set; }
        public DateTime DataNascimento
        {
            get { return _DataNascimento; }
            set { _DataNascimento = value; }
        }
        protected string _Sexo { get; set; }
        public string Sexo
        {
            set { _Sexo = value; }
            get { return _Sexo; }
        }
        protected string _Cpf { get; set; }
        public string Cpf
        {
            set { _Cpf = value; }
            get { return _Cpf; }
        }
        protected Endereco _Endereco { get; set; }
        public Endereco Endereco
        {
            set { _Endereco = value; }
            get { return _Endereco; }
        }
        protected Contato _Contato { get; set; }
        public Contato Contato
        {
            set { _Contato = value; }
            get { return _Contato; }
        }

        public int AddPessoa()
        {
            int newId;
            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString;

                query = "INSERT INTO Pessoa (" +
                            "nome," +
                            "sexo," +
                            "data_nascimento," +
                            "cpf" +
                        ") " +
                        "VALUES(" +
                            "'" + Nome + "'," +
                            "'" + Sexo + "'," +
                            "'" + DataNascimento.Date.ToString("yyyy-MM-dd") + "'," +
                            "'" + Cpf + "'" +
                        "); SELECT SCOPE_IDENTITY() ";

                using (command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    newId = Convert.ToInt32(command.ExecuteScalar());
                    Endereco.addEndereco(newId);
                    Contato.addContato(newId);
                }
            }

            return newId;
        }

        public void updatePessoa(int id_pessoa)
        {
            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString;

                query = "UPDATE Pessoa SET " +
                            "nome = '" + Nome + "'," +
                            "sexo = '" + Sexo + "'," +
                            "data_nascimento = '" + DataNascimento.Date.ToString("yyyy-MM-dd")  + "'," +
                            "cpf = '" + Cpf + "'" +
                        " WHERE id_pessoa = " + id_pessoa;

                using (command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    Endereco.update();
                    Contato.update();
                }
            }

        }
        public static Pessoa getPessoaById(int id_pessoa)
        {

            Pessoa pessoa = new Pessoa();

            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString;

                string query = "SELECT * FROM Pessoa WHERE id_pessoa = " + id_pessoa;

                using (command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (dataReader = command.ExecuteReader())
                    {
                       while(dataReader.Read())
                        {
                            pessoa.idPessoa = dataReader.GetInt32(0);
                            pessoa.Nome = dataReader.GetString(1);
                            pessoa.DataNascimento= dataReader.GetDateTime(2);
                            pessoa.Sexo = dataReader.GetString(3);
                            pessoa.Cpf = dataReader.GetString(4);

                            pessoa.Endereco = Endereco.getEnderecoByPessoaId(pessoa.idPessoa);
                            pessoa.Contato = Contato.getContatoByPessoaId(pessoa.idPessoa);
                        }
                    }
                }
            }

            return pessoa;
        }
        public static void deletePessoaById(int id_pessoa)
        {
            Pessoa pessoa = getPessoaById(id_pessoa);

            Endereco.deleteEnderecoById(pessoa.Endereco.IdEndereco);
            Contato.deleteContatoById(pessoa.Contato.idContato);
            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString;

                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "DELETE FROM Pessoa WHERE id_pessoa = @id_pessoa";
                    command.Parameters.AddWithValue("@id_pessoa", id_pessoa);
                    command.ExecuteNonQuery();
                }
            }
        }
    }

}

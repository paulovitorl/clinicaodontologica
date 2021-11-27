using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica
{
    class Dentista: Pessoa
    {
        public Dentista()
        {
            Funcionario = new Funcionario();
        }

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

        private String _Cro;
        public String Cro
        {
            get { return _Cro; }
            set { _Cro = value; }
        }

        protected Funcionario _funcionario{ get; set; }
        public Funcionario Funcionario
        {
            set { _funcionario = value; }
            get { return _funcionario; }
        }

        public int addDentista()
        {
            int id_pessoa = this.AddPessoa();
            Funcionario.addFuncionario(id_pessoa);

            int newId;
            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString;

                query = "INSERT INTO Dentista (" +
                            "cro," +
                            "id_pessoa" +
                        ") " +
                        "VALUES(" +
                            "'" + Cro + "', "
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

        public void deleteDentista(int id_dentista)
        {

            int id_pessoa = getIdPessoaByDentista(id_dentista);

            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString;
                query = "DELETE FROM Dentista WHERE id_dentista = " + id_dentista;

                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "DELETE FROM Dentista WHERE id_dentista = @id_dentista";
                    command.Parameters.AddWithValue("@id_dentista ", id_dentista);
                    command.ExecuteNonQuery();
                }
            }

            int id_cargo = Cargo.getCargoIdByName("Dentista");
            int id_funcionario = Funcionario.getIdFuncionario(id_pessoa, id_cargo);
            Funcionario.deleteFuncionario(id_funcionario);

            deletePessoaById(id_pessoa);
        }

        public static int getIdPessoaByDentista(int id_dentista)
        {
            int id_pessoa = 0;
            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString;

                query = "SELECT id_pessoa FROM Dentista WHERE id_dentista = " + id_dentista;
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
        public void update()
        {
            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString;

                query = "UPDATE Dentista SET " +
                            "cro = '" + Cro + "'" +
                        " WHERE id_dentista = " + Id;

                using (command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            int id_pessoa = getIdPessoaByDentista(Id);

            Funcionario.IdFuncionario = Funcionario.getIdFuncionario(id_pessoa, Funcionario.IdCargo);
            Funcionario.update();
           
            updatePessoa(id_pessoa);
        }

        public static List<Dentista> getDentistas()
        {

            List<Dentista> dentistas = new List<Dentista>();

            try
            {
                using (connection = new SqlConnection())
                {
                    connection.ConnectionString = SqlParams.connectionString;

                    query = "SELECT * FROM Dentista";

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
                                    Dentista dentista = new Dentista();
                                    dentista.Id = dataReader.GetInt32(0);
                                    dentista.Cro = dataReader.GetString(1);

                                    dentista.Nome = pessoa.Nome;
                                    dentista.DataNascimento = pessoa.DataNascimento;
                                    dentista.Sexo = pessoa.Sexo;
                                    dentista.Cpf = pessoa.Cpf;

                                    int id_cargo = Cargo.getCargoIdByName("Dentista");
                                    int id_funcionario = dentista.Funcionario.getIdFuncionario(id_pessoa, id_cargo);
                                    Funcionario funcionario = Funcionario.getFuncionarioById(id_funcionario);

                                    dentista.Funcionario.Status = funcionario.Status; ;

                                    dentista.Contato.Telefone = pessoa.Contato.Telefone;
                                    dentista.Contato.Email = pessoa.Contato.Email;

                                    dentistas.Add(dentista);
                                }

                            }
                        }
                    }
                }
            }
            catch (SqlException se)
            {
            }

            return dentistas; 
        }

    }
}

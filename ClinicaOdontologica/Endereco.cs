using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClinicaOdontologica
{

    public class Endereco
    {

        private static SqlConnection connection;
        private static SqlCommand command;
        private static SqlDataReader dataReader;
        private static string query = string.Empty;
        private static SqlDataAdapter adapter = new SqlDataAdapter();

        private int _IdEndereco { get; set; }

        public int IdEndereco
        {
            get { return _IdEndereco; }
            set { _IdEndereco = value; }
        }


        private int _IdPessoa;
        public int IdPessoa {
            get { return _IdPessoa; }
            set { _IdPessoa = value; }
        }

        private int _Cep { get; set; }
        public int Cep
        {
            get { return _Cep; }
            set { _Cep = value; }
        }
        private string _Estado;
        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
        private string _Cidade;
        public string Cidade
        {
            get { return _Cidade; }
            set { _Cidade = value; }
        }
        private string _Bairro;
        public string Bairro
        {
            get { return _Bairro; }
            set { _Bairro = value; }
        }
        private int _Numero;
        public int Numero
        {
            get { return _Numero; }
            set { _Numero = value; }
        }
        private string _Logradouro;
        public string Logradouro
        {
            get { return _Logradouro; }
            set { _Logradouro = value; }
        }
        private string _Complemento;
        public string Complemento
        {
            get { return _Complemento; }
            set { _Complemento = value; }
        }
        private string _Referencia;
        public string Referencia
        {
            get { return _Referencia; }
            set { _Referencia = value; }
        }
        public int addEndereco(int id_pessoa)
        {

            int newId;
            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString;

                query = "INSERT INTO Endereco (" +
                            "uf," +
                            "referencia," +
                            "cidade," +
                            "bairro," +
                            "complemento," +
                            "numero," +
                            "cep," +
                            "id_pessoa," +
                            "logradouro" +
                        ") " +
                        "VALUES(" +
                            "'" + Estado + "'," +
                            "'" + Referencia + "'," +
                            "'" + Cidade + "'," +
                            "'" + Bairro + "'," +
                            "'" + Complemento+"'," +
                            "'" + Numero +"'," +
                            "'" + Cep +"'," +
                            "'" + id_pessoa + "'," +
                            "'" + Logradouro +"'" +
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

        public static Endereco getEnderecoByPessoaId(int id_pessoa)
        {

            Endereco endereco = new Endereco();
           
            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString;

                query = "SELECT * FROM Endereco WHERE id_pessoa = " + id_pessoa;

                using (command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            endereco.IdEndereco = dataReader.GetInt32(0);
                            endereco.Estado = dataReader.GetString(1);
                            endereco.Referencia = dataReader.GetString(2);
                            endereco.Cidade = dataReader.GetString(3);
                            endereco.Bairro = dataReader.GetString(4);
                            endereco.Complemento = dataReader.GetString(5);
                            endereco.Numero = dataReader.GetInt32(6);
                            endereco.Cep = Int32.Parse(dataReader.GetString(7));
                            endereco.Logradouro = dataReader.GetString(9);
                        }
                    } 
                }
            }

            return endereco;
        }

        public static dynamic getAddressByCep(int cep)
        {
            dynamic address = JsonConvert.DeserializeObject("");

            try
            {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://viacep.com.br/ws/" + cep + "/json/");
            request.AllowAutoRedirect = false;
            HttpWebResponse ChecaServidor = (HttpWebResponse)request.GetResponse();

            using (Stream webStream = ChecaServidor.GetResponseStream())
            {
                if (webStream != null)
                {
                    using (StreamReader responseReader = new StreamReader(webStream))
                    {
                        string response = responseReader.ReadToEnd();
                        address = JsonConvert.DeserializeObject(response);

                        return address;
                    }
                }
            }


            }
            catch (Exception e)
            {
            }

            return address;
        }
        public void update()
        {
            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString;

                query = "UPDATE Endereco SET " +
                            "uf = '" + Estado + "'," +
                            "referencia = '" + Referencia + "'," +
                            "cidade = '" + Cidade+ "'," +
                            "bairro = '" + Bairro+ "'," +
                            "complemento = '" + Complemento+ "',"+
                            "numero = '" + Numero + "'," +
                            "cep = '" + Cep + "'," +
                            "logradouro = '" + Logradouro + "'" +
                        " WHERE id_endereco = " + IdEndereco;

                using (command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }

        public static void deleteEnderecoById(int id_endereco)
        {
            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString;

                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "DELETE FROM Endereco WHERE id_endereco = @id_endereco ";
                    command.Parameters.AddWithValue("@id_endereco ", id_endereco);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

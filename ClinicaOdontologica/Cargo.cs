using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica
{
    class Cargo
    {
        private static SqlConnection connection;
        private static SqlCommand command;
        private static SqlDataReader dataReader;
        private static string query = string.Empty;
        private static SqlDataAdapter adapter = new SqlDataAdapter();

        private int _idCargo;
        public int IdCargo
        {
            get { return _idCargo; }
            set { _idCargo = value; }
        }

        private String _nome;
        public String Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public static int getCargoIdByName(String nome)
        {
            int id_cargo = 0;

            using (connection = new SqlConnection())
            {
                connection.ConnectionString = SqlParams.connectionString; ;

                query = "SELECT id_cargo FROM Cargo WHERE nome = '" + nome + "'";

                 using (command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            id_cargo = dataReader.GetInt32(0);
                        }
                    }
                }
            }

            return id_cargo;
        }

    }
}

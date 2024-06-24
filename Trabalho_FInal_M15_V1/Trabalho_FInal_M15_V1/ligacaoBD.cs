using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_FInal_M15_V1
{
    internal class ligacaoBD
    {
        public MySqlConnection connection;
        string server;
        string port;
        public string data_base;
        string user_id;
        string password;

        public void inicializa()
        {
            server = "localhost"; // 127.0.0.1 OU localhost
            data_base = "bd_m15_casas";
            port = "3306";
            user_id = "root";
            password = "";
            string connection_string;
                
            connection_string = "SERVER=" + server + ";" + 
                                "PORT=" + port + ";" + 
                                "DATABASE=" + data_base + ";" + 
                                "UID=" + user_id + ";" + 
                                "PWD=" + password + ";";

            connection = new MySqlConnection(connection_string);
        }

        public bool open_connection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Não foi possível estabelacer ligação");
                        break;
                    case 1042:
                        MessageBox.Show("Execedeu o tempo de ligação");
                        break;
                    case 1045:
                        MessageBox.Show("Username/password incorretos");
                        break;
                }
                return false;
            }
        }
        public bool close_connection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public ligacaoBD()
        {

        }
    }
}

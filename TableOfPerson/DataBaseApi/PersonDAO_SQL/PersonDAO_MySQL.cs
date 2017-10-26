using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.Common;
using TableOfPerson.DataBaseApi.PersonDAO_SQL;

namespace TableOfPerson
{
    public class PersonDAO_MySQL: PersonDAO_SQL
    {
        MySqlConnection connection = null;
        public PersonDAO_MySQL()
        {
            string MySQLconnString = @"Server=localhost;" +
                                     @"Database=bisser;" +
                                     @"Uid=root;" +
                                     @"Pwd=;";

            connection = new MySqlConnection(MySQLconnString);
        }
        protected override void CloseConnection()
        {
            connection.Close();
        }

        protected override void ExecuteCommand(string cmd)
        {
            DbCommand command = new MySqlCommand();
            command = new MySqlCommand(cmd, connection);
            command.ExecuteNonQuery();
        }

        protected override void OpenConnection()
        {
            connection.Open();
        }

        protected override List<Person> ReadData(string cmd)
        {
            MySqlCommand sqlCmd = new MySqlCommand(cmd, connection);
            MySqlDataReader reader = sqlCmd.ExecuteReader();
            List<Person> listPerson = new List<Person>();

            while (reader.Read())
            {
                listPerson.Add(new Person(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3)));
            }

            reader.Close();
            return listPerson;
        }
        
    }
}

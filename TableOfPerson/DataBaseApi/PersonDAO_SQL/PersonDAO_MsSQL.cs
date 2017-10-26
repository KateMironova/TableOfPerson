using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TableOfPerson.DataBaseApi.PersonDAO_SQL;

namespace TableOfPerson
{
    public class PersonDAO_MsSQL: PersonDAO_SQL
    {
        SqlConnection connection = null;
        public PersonDAO_MsSQL()
        {
            string strConn = @"Data Source=(LocalDB)\MSSQLLocalDB;"+
                @"AttachDbFilename=D:\COURSE\TableOfPerson\TableOfPerson\PeopleDB.mdf;"+
                @"Integrated Security=True";

            connection = new SqlConnection(strConn);
        }

        protected override void CloseConnection()
        {
            connection.Close();
        }

        protected override void OpenConnection()
        {
            connection.Open();
        }

        protected override void ExecuteCommand(string cmd)
        {
            SqlCommand sqlCmd = new SqlCommand(cmd, connection);
            sqlCmd.ExecuteNonQuery();
        }

        protected override List<Person> ReadData(string cmd)
        {
            SqlCommand sqlCmd = new SqlCommand(cmd, connection);
            SqlDataReader reader = sqlCmd.ExecuteReader();

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

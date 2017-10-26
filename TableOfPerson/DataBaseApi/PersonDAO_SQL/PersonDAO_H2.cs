using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using java.sql;
using TableOfPerson.DataBaseApi.PersonDAO_SQL;

namespace TableOfPerson
{
    public class PersonDAO_H2: PersonDAO_SQL
    {
        Statement state = null;
        Connection connection = null;
        public PersonDAO_H2()
        {
            string connectionH2 = "jdbc:h2:tcp://localhost/~/test";
            string user = "sa";
            string pass = "1111";

            tableName = "person";
            org.h2.Driver.load();
            connection = DriverManager.getConnection(connectionH2, user, pass);
        }


        protected override List<Person> ReadData(string cmd)
        {
            ResultSet rs = state.executeQuery(cmd);
            List<Person> listPerson = new List<Person>();
            while (rs.next())
            {
                listPerson.Add(new Person(rs.getInt("ID"), rs.getString("FIRSTNAME"), rs.getString("LASTNAME"), rs.getInt("AGE")));
            }
            rs.close();
            return listPerson;
        }


        protected override void CloseConnection()
        {
            state.close();
        }

        protected override void ExecuteCommand(string cmd)
        {
            state.executeUpdate(cmd);
        }

        protected override void OpenConnection()
        {
            state = connection.createStatement();
        }
        
    }
}

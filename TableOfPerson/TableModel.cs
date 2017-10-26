using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TableOfPerson
{
    class TableModel
    {
        IPerson_DAO db = null;

        public void SetDataBase(string key)
        {
            db = DBFactory.getInstance(key);
        }

        public void Create(Person p)
        {
            db.Create(p);
        }

        public DataTable Read()
        {
            DataTable dt = new DataTable();
            List<Person> persons = db.Read();

            dt.Columns.Add(new DataColumn("Id"));
            dt.Columns.Add(new DataColumn("Fn"));
            dt.Columns.Add(new DataColumn("Ln"));
            dt.Columns.Add(new DataColumn("Age"));

            foreach (Person person in persons)
            {
                DataRow row = dt.NewRow();
                row[0] = person.id;
                row[1] = person.fn;
                row[2] = person.ln;
                row[3] = person.age;
                dt.Rows.Add(row);
            }

            return dt;
        }

        public void Update(Person p)
        {
            db.Update(p);
        }

        public void Delete(Person p)
        {
            db.Delete(p);
        }
    }
}

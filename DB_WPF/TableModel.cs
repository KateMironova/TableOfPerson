using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableOfPerson;

namespace DB_WPF
{
    public class TableModel
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

        public List<Person> Read()
        {
            return db.Read();
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

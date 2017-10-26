using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableOfPerson.DataBaseApi
{
    public class PersonContext: DbContext
    {
        public PersonContext() 
            : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\COURSE\TableOfPerson\TableOfPerson\DB_empty.mdf;Integrated Security=True")
        {

        }

        public DbSet<Person> Persons { get; set; }
    }
}

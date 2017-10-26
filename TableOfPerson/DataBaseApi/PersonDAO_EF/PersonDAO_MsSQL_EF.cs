using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace TableOfPerson.DataBaseApi
{
    public class PersonDAO_MsSQL_EF: IPerson_DAO
    {
        public void Create(Person p)
        {
            using (PersonContext context = new PersonContext())
            {
                context.Persons.Add(p);
                context.SaveChanges();
            }
        }

        public void Delete(Person p)
        {
            using (PersonContext context = new PersonContext())
            {
                Person pToDel = context.Persons.First(x => x.id == p.id);
                context.Persons.Remove(pToDel);
                context.SaveChanges();
            }
        }

        public List<Person> Read()
        {
            using (PersonContext context = new PersonContext())
            {
                return context.Persons.ToList();
            }
        }

        public void Update(Person p)
        {
            using (PersonContext context = new PersonContext())
            {
                Person original = context.Persons.FirstOrDefault(x => x.id == p.id);
                context.Entry(original).CurrentValues.SetValues(p);
                context.SaveChanges();
            }
        }
    }
}

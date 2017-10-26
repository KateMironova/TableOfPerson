using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableOfPerson.DataBaseApi.PersonDAO_File
{
    public abstract class PersonDAO_File: IPerson_DAO
    {
        protected string path = "";
        public PersonDAO_File(string path)
        {
            this.path = path;
        }

        public void Create(Person person)
        {
            List<Person> people = Load();
            Person add = people.Find((x) => x.id == person.id);
            if (add == null)
            {
                people.Add(person);
            }
            Save(people);
        }

        public void Delete(Person person)
        {
            List<Person> people = Load();
            Person del = people.Find((x) => x.id == person.id);
            if (del != null)
            {
                people.Remove(del);
            }
            Save(people);
        }

        public void Update(Person person)
        {
            List<Person> people = Load();
            Person add = people.Find((x) => x.id == person.id);
            if (add != null)
            {
                int i = people.IndexOf(add);
                people.ElementAt(i).fn = person.fn;
                people.ElementAt(i).ln = person.ln;
                people.ElementAt(i).age = person.age;
            }
            Save(people);
        }

        public List<Person> Read()
        {
            return Load();
        }

        abstract protected List<Person> Load();
        abstract protected void Save(List<Person> people);

    }
}

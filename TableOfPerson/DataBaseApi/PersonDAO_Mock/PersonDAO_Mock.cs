using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableOfPerson.DataBaseApi
{
    public class PersonDAO_Mock: IPerson_DAO
    {
        List<Person> persons = null;

        public PersonDAO_Mock()
        {
            persons = new List<Person>();
            persons.Add(new Person(1, "Vasya", "Pupkin", 22));
            persons.Add(new Person(2, "Kolya", "Lupkin", 33));
        }

        public void Create(Person p)
        {
            persons.Add(p);
        }

        public void Delete(Person p)
        {
            persons.RemoveAll(x => x.id == p.id);
        }

        public List<Person> Read()
        {
            return persons;
        }

        public void Update(Person p)
        {
            foreach (Person x in persons)
            {
                if (x.id == p.id)
                {
                    x.fn = p.fn;
                    x.ln = p.ln;
                    x.age = p.age;
                }
            }
        }

        //private class Data
        //{
        //    public string fn;
        //    public string ln;
        //    public int age;

        //    public Data()
        //    {
        //    }

        //    public Data(string fn, string ln, int age)
        //    {
        //        this.fn = fn;
        //        this.ln = ln;
        //        this.age = age;
        //    }
        //}

        //Dictionary<int, Data> innerPersons;

        //public PersonDAO_Mock()
        //{
        //    innerPersons = new Dictionary<int, Data>();
        //    innerPersons.Add(1, new Data("Vasya", "Pupkin", 20));
        //    innerPersons.Add(2, new Data("Ivan", "Ivanov", 28));
        //}

        //public void Create(Person p)
        //{
        //    innerPersons.Add(p.id, new Data(p.fn, p.ln, p.age));
        //}

        //public void Delete(Person p)
        //{
        //    innerPersons.Remove(p.id);
        //}

        //public List<Person> Read()
        //{
        //    List<Person> persons = new List<Person>();
        //    foreach (var p in innerPersons)
        //    {
        //        persons.Add(new Person(p.Key, p.Value.fn, p.Value.ln, p.Value.age));
        //    }


        //    return persons;
        //}

        //public void Update(Person p)
        //{
        //    innerPersons[p.id] = new Data(p.fn, p.ln, p.age);
        //}
    }
}

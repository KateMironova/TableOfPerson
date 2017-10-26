using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TableOfPerson.DataBaseApi.PersonDAO_File
{
    public class PersonDAO_XML: PersonDAO_File
    {
        public PersonDAO_XML() 
            : base("XML_DB.txt")
        { }

        protected override List<Person> Load()
        {
            List<Person> people = new List<Person>();
            if (File.Exists(path) == false)
            {
                FileStream fs = File.Create(path);
                fs.Close();
            }
            string[] lines = File.ReadAllLines(path);
            string[] XMLlines = new string[(lines.Length - 2) / 6];
            for (int i = 1, k = 0; i < lines.Length - 1; i++)
            {
                if (lines[i] == "\t</Person>")
                    k++;
                else if (lines[i] != "\t<Person>")
                    XMLlines[k] += lines[i];
            }
            foreach (string line in XMLlines)
            {
                people.Add(FromXML(line));
            }
            return people;

        }


        protected override void Save(List<Person> people)
        {
            StreamWriter file = new StreamWriter(path);
            file.WriteLine("<Persons>");
            foreach (Person person in people)
            {
                file.WriteLine(ToXML(person));
            }
            file.WriteLine("</Persons>");
            file.Close();

        }

        private string ToXML(Person person)
        {
            string str = "\t<Person>\n";
            str += $"\t\t<Id>{person.id}</Id>\n";
            str += $"\t\t<FirstName>{person.fn}</FirstName>\n";
            str += $"\t\t<LastName>{person.ln}</LastName>\n";
            str += $"\t\t<Age>{person.age}</Age>\n";
            str += "\t</Person>";
            return str;
        }
        private Person FromXML(string str)
        {
            Person person = new Person();
            str = str.Replace("\t", "");
            string[] args = str.Split('<', '>');
            person.id = Int32.Parse(args[2]);
            person.fn = args[6];
            person.ln = args[10];
            person.age = Int32.Parse(args[14]);
            return person;
        }
        
    }
}

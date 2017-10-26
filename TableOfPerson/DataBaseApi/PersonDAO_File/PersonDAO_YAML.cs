using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TableOfPerson.DataBaseApi.PersonDAO_File
{
    public class PersonDAO_YAML: PersonDAO_File
    {
        public PersonDAO_YAML()
            : base("YAML_DB.txt")
        {    }

        protected override List<Person> Load()
        {
            List<Person> people = new List<Person>();
            FileStream fs;
            if (File.Exists(path) == false)
            {
                fs = File.Create(path);
                fs.Close();
            }
            string[] lines = File.ReadAllLines(path);
            string[] YAMLlines = new string[(lines.Length - 1) / 4];
            for (int i = 1, k = 1; i < lines.Length; i++)
            {
                if (i != 4 * k + 1)
                    YAMLlines[k - 1] += lines[i] + "\n";
                else
                    YAMLlines[++k - 1] += lines[i] + "\n";
            }
            foreach (string str in YAMLlines)
            {
                people.Add(FromYAML(str));
            }
            return people;

        }

        protected override void Save(List<Person> people)
        {
            StreamWriter file = new StreamWriter(path);
            file.WriteLine("Persons:");
            foreach (Person person in people)
            {
                file.WriteLine(ToYAML(person));
            }
            file.Close();
        }


        private string ToYAML(Person person)
        {
            string str = "";
            str += $"- Id: {person.id}";
            str += $"\nFirstName: {person.fn}";
            str += $"\nLastName: {person.ln}";
            str += $"\nAge: {person.age}";
            return str;
        }
        private Person FromYAML(string yaml_string)
        {
            Person person = new Person();
            string[] args = yaml_string.Split('\n', ':', '-');
            person.id = Int32.Parse(args[2].Trim());
            person.fn = args[4].Trim();
            person.ln = args[6].Trim();
            person.age = Int32.Parse(args[8].Trim());
            return person;
        }
        
    }
}

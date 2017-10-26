using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Text;
using TableOfPerson;
using TableOfPerson.DataBaseApi;

namespace TableOfPerson.DataBaseApi.PersonDAO_File
{
    public class PersonDAO_CSV_L : PersonDAO_File
    {
        public PersonDAO_CSV_L() 
            : base("csv_db.csv")
        {     }

        protected override List<Person> Load()
        {
            if (File.Exists(path) == false)
            {
                FileStream fs = File.Create(path);
                fs.Close();
            }
            string csvString = File.ReadAllText(path);
            List<Person> persons = new List<Person>();
            if (csvString.Length == 0)
                persons = new List<Person>();
            else
                persons = CsvSerializer.DeserializeFromString<List<Person>>(csvString);
            return persons;
        }

        protected override void Save(List<Person> persons)
        {
            string csvString = CsvSerializer.SerializeToCsv(persons);
            File.WriteAllText(path, csvString);
        }
        
    }
}

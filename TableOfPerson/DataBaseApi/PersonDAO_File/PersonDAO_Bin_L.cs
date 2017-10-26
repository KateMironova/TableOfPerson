using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

namespace TableOfPerson.DataBaseApi.PersonDAO_File
{
    public class PersonDAO_Bin_L : PersonDAO_File
    {
        public PersonDAO_Bin_L() 
            : base("bin_db.dat")
        { }
        protected override List<Person> Load()
        {
            string binString = File.ReadAllText(path);
            BinaryFormatter formatter = new BinaryFormatter();
            List<Person> persons = null;
            if (binString.Length == 0)
                persons = new List<Person>();
            else
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    persons = (List<Person>)formatter.Deserialize(fs);
                }
            return persons;
        }

        protected override void Save(List<Person> persons)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, persons);
            }
        }
    }
}

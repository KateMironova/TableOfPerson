using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace TableOfPerson.DataBaseApi.PersonDAO_File
{
    public class PersonDAO_YAML_L : PersonDAO_File
    {
        public PersonDAO_YAML_L() 
            : base("yaml_db.yaml")
        {   }

        protected override List<Person> Load()
        {
            if (File.Exists(path) == false)
            {
                FileStream fs = File.Create(path);
                fs.Close();
            }
            string yamlString = File.ReadAllText(path);
            List<Person> persons;
            Deserializer deserializer = new Deserializer();
            if (yamlString.Length == 0)
                persons = new List<Person>();
            else
                persons = persons = deserializer.Deserialize<List<Person>>(yamlString);
            return persons;
        }

        protected override void Save(List<Person> persons)
        {
            Serializer serializer = new Serializer();
            string yamlString = serializer.Serialize(persons);
            File.WriteAllText(path, yamlString);
        }
        
    }
}

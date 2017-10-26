using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TableOfPerson.DataBaseApi
{
    public class PersonDAO_MongoDB: IPerson_DAO
    {
        IMongoCollection<Person> collection = null;
        public PersonDAO_MongoDB()
        {
            string strConn = @"mongodb://localhost:27017";

            MongoClient client = new MongoClient(strConn);
            IMongoDatabase database = client.GetDatabase("mongoPerson");
            collection = database.GetCollection<Person>("people");
        }

        public void Create(Person person)
        {
            if (collection.Find(x => x.id == person.id).ToList().Count == 0)
            {
                collection.InsertOne(person);
            }
        }

        public void Delete(Person person)
        {
            collection.DeleteOne(x => x.id == person.id);
        }

        public List<Person> Read()
        {
            List<Person> listPerson = new List<Person>();
            listPerson = collection.Find(x => true).ToList();
            return listPerson;
        }

        public void Update(Person person)
        {
            collection.ReplaceOne(x => x.id == person.id, person);
        }
    }
}

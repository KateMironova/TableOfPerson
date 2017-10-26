using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.Attributes;

namespace TableOfPerson
{
    [Serializable]
    public class Person
    {
        [BsonId]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string fn { get; set; }
        public string ln { get; set; }
        public int age { get; set; }

        public Person()
        {

        }
        public Person(int id, string fn, string ln, int age)
        {
            this.id = id;
            this.fn = fn;
            this.ln = ln;
            this.age = age;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableOfPerson
{
    public interface IPerson_DAO
    {
        void Create(Person p);
        List<Person> Read();
        void Update(Person p);
        void Delete(Person p);
    }
}

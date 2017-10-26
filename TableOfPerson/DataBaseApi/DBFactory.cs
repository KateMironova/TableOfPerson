using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableOfPerson.DataBaseApi;
using TableOfPerson.DataBaseApi.PersonDAO_File;
using TableOfPerson.DataBaseApi.PersonDAO_SQL;

namespace TableOfPerson
{
    public class DBFactory
    {
        public static IPerson_DAO getInstance(string key)
        {
            IPerson_DAO db = null;

            switch (key)
            {
                case "MsSQL":
                    db = new PersonDAO_MsSQL();
                    break;
                case "MySQL":
                    db = new PersonDAO_MySQL();
                    break;
                case "H2":
                    db = new PersonDAO_H2();
                    break;
                case "CSV":
                    db = new PersonDAO_CSV();
                    break;
                case "JSON":
                    db = new PersonDAO_JSON();
                    break;
                case "XML":
                    db = new PersonDAO_XML();
                    break;
                case "YAML":
                    db = new PersonDAO_YAML();
                    break;
                case "CSV_L":
                    db = new PersonDAO_CSV_L();
                    break;
                case "JSON_L":
                    db = new PersonDAO_JSON_L();
                    break;
                case "XML_L":
                    db = new PersonDAO_XML_L();
                    break;
                case "YAML_L":
                    db = new PersonDAO_YAML_L();
                    break;
                case "MsSQL_EF":
                    db = new PersonDAO_MsSQL_EF();
                    break;
                case "MongoDB":
                    db = new PersonDAO_MongoDB();
                    break;
                case "Mock":
                    db = new PersonDAO_Mock();
                    break;
                case "Binary_L":
                    db = new PersonDAO_Bin_L();
                    break;
                    //default: throw new ArgumentException();
            }

            return db;
        }
    }
}

using System;
using System.Collections.Generic;

namespace DP_05_Multiton
{
    class Program
    {
        static void Main(string[] args)
        {
            var persons = CreatePersons();
            string jsonFile = @"c:\myJson.json";
            string xmlFile = @"c:\myXML.xml";

            Saver.Json.Save(persons, xmlFile);
            Saver.XML.Save(persons, jsonFile);
        }

        static List<Person> CreatePersons()
        {
            List<Person> persons = new List<Person>();

            persons.Add(new Person() { FullName = "Romolo", Age = 30, Salary = 2000m });
            persons.Add(new Person() { FullName = "Numa Pompilio", Age = 33, Salary = 1600m });
            persons.Add(new Person() { FullName = "Tullo Ostilio", Age = 20, Salary = 1200m });
            persons.Add(new Person() { FullName = "Anco Marzio", Age = 26, Salary = 3000m });
            persons.Add(new Person() { FullName = "Tarquinio Prisco", Age = 28, Salary = 2200m });

            return persons;
        }
    }

    public class Person
    {
        public string FullName { get; set; }
        //public DateTime BirthDay { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
    }

    public interface ISaver
    {
        void Save(List<Person> persons, string fileName);
    }

    public abstract class Saver : ISaver
    {
        public static JSonSaver Json { get; }
        public static XMLSaver XML { get; }

        static Saver()
        {
            Json = new JSonSaver();
            XML = new XMLSaver();
        }        

        public void Save(List<Person> persons, string fileName)
        {
            string message = "";
            foreach (var p in persons) {
                message += SerializeObject(p) + Environment.NewLine;
            }

            var fileNameExt = GetFileNameExtension(fileName);

            System.IO.File.WriteAllText(fileNameExt, message);
        }

        internal abstract string GetFileNameExtension(string fileName);
        protected abstract string SerializeObject(Person person);
    }

    public class JSonSaver : Saver
    {
        internal JSonSaver() { }

        protected override string SerializeObject(Person person)
        {
            if (person == null) throw new NullReferenceException($"{nameof(Person)} is null");

            string message = "{";

            message += $"\"{nameof(person.FullName)}\":\"{person.FullName}\",";
            message += $"\"{nameof(person.Age)}\":{person.Age},";
            message += $"\"{nameof(person.Salary)}\":{person.Salary}";
            message += "}";

            return message;
        }

        internal override string GetFileNameExtension(string fileName)
        {
            return fileName + ".json";
        }
    }

    public class XMLSaver : Saver
    {
        internal XMLSaver() { }

        protected override string SerializeObject(Person person)
        {
            string message = $"<{nameof(Person)}>";

            message += $"<{nameof(person.FullName)}>";
            message += $"{person.FullName}";
            message += $"</{nameof(person.FullName)}>";

            message += $"<{nameof(person.Age)}>";
            message += $"{person.Age}";
            message += $"</{nameof(person.Age)}>";

            message += $"<{nameof(person.Salary)}>";
            message += $"{person.Salary}";
            message += $"</{nameof(person.Salary)}>";

            message += $"</{nameof(Person)}>";

            return message;
        }

        internal override string GetFileNameExtension(string fileName)
        {
            return fileName + ".xml";
        }
    }
}

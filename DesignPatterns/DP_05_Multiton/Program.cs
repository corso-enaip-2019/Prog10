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

            XMLSaver.Instance.Save(persons, xmlFile);
            JSonSaver.Instance.Save(persons, jsonFile);
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

    class Person
    {
        public string FullName { get; set; }
        //public DateTime BirthDay { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
    }

    interface ISaver
    {
        void Save(List<Person> persons, string fileName);
    }

    abstract class Saver : ISaver
    {
        //public static ISaver GetSaver<T>() where T : Saver
        //{
        //    try
        //    {
        //        return Activator.CreateInstance<T>();
        //    }
        //    catch (Exception)
        //    {
        //        throw new NotImplementedException("Saver not implemented yet!");
        //    }
        //}

        public void Save(List<Person> persons, string fileName)
        {
            string message = "";
            foreach (var p in persons) {
                message += SerializeObject(p) + Environment.NewLine;
            }

            System.IO.File.WriteAllText(fileName, message);
        }

        protected abstract string SerializeObject(Person person);
    }

    class JSonSaver : Saver
    {
        static JSonSaver()
        {
            Instance = new JSonSaver();
        }
        public static JSonSaver Instance { get; }

        private JSonSaver() { }

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
    }

    class XMLSaver : Saver
    {
        static XMLSaver()
        {
            Instance = new XMLSaver();
        }
        public static XMLSaver Instance { get; }

        private XMLSaver() { }

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
    }
}

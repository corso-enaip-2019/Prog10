using System;
using System.Collections.Generic;
using System.Text;
using DP_03_Template.Employees;

namespace DP_03_Template.Savers
{
    abstract class Saver : ISaver
    {
        public static ISaver GetSaver<T>() where T : Saver
        {
            try
            {
                return Activator.CreateInstance<T>();
            }
            catch (Exception)
            {
                throw new NotImplementedException("Saver not implemented yet!");
            }

        }

        public void Save(List<Person> persons, string fileName)
        {
            string message = "";
            foreach (var p in persons)
            {
                message += SerializeObject(p) + Environment.NewLine;
            }

            System.IO.File.WriteAllText(fileName, message);
        }

        protected abstract string SerializeObject(Person person);
    }
}

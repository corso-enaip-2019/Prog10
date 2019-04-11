using DP_03_Template.Employees;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DP_03_Template.Savers
{
    class JSonSaver : Saver
    {
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
}

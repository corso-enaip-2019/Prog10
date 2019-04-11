using DP_03_Template.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace DP_03_Template.Savers
{
    class XMLSaver : Saver
    {
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

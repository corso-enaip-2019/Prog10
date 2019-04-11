using DP_03_Template.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace DP_03_Template.Savers
{
    interface ISaver
    {
        void Save(List<Person> persons, string fileName);
    }
}

using System;

namespace DesignPattern_01.Entities.Employees
{
    interface IEmployee
    {
        int ID { get; set; }
        string Name { get; set; }

        bool IsPayDay(DateTime date);
        decimal CalculatePay(DateTime date);
    }
}

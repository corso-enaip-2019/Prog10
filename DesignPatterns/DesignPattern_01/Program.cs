using DesignPattern_01.Entities;
using DesignPattern_01.Entities.Employees;
using System;
using System.Collections.Generic;

namespace DesignPattern_01
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //lista impiegati creata come mock
            
            var employees = CreateEmployess();

            //per ogni impiegato della lista
            //    se è il suo giorno di paga
            //        calcola la sua paga
            //        crea un record con ID, paga e data di oggi
            //        salva record in una lista di record
            List<PayCheckRecord> payCheckRecords = new List<PayCheckRecord>();

            var date = new DateTime(2019, 8, 31);
            foreach (var e in employees)
            {
                if (e.IsPayDay(date))
                {
                    var pay = e.CalculatePay(date);
                    var record = new PayCheckRecord(e.ID, DateTime.Today, pay);
                    payCheckRecords.Add(record);
                }
            }

            Console.ReadKey();
        }

        static List<AEmployee> CreateEmployess()
        {
            List<AEmployee> employees = new List<AEmployee>();

            var fs = new FixedSalary_Employee()
            {
                ID = 1,
                Name = "Tiziano",
                Rate = 1600.00m,
            };
            employees.Add(fs);

            var hp = new HourlyPaid_Employee()
            {
                ID = 2,
                Name = "Jessica",
                Rate = 30m,
            };
            hp.Add_DaylyWorkedHours(new DateTime(2019, 8, 31), 4);
            hp.Add_DaylyWorkedHours(new DateTime(2019, 8, 30), 6);
            hp.Add_DaylyWorkedHours(new DateTime(2019, 8, 29), 5);
            hp.Add_DaylyWorkedHours(new DateTime(2019, 8, 14), 8);

            employees.Add(hp);

            var cp = new CommissionPaid_Employee()
            {
                ID = 2,
                Name = "Jessica",
                Rate = 0.02m,
            };
            cp.Add_Sale(new CommissionPaid_Employee.SoldCommision(new DateTime(2019, 8, 31), 40));
            cp.Add_Sale(new CommissionPaid_Employee.SoldCommision(new DateTime(2019, 8, 30), 68));
            cp.Add_Sale(new CommissionPaid_Employee.SoldCommision(new DateTime(2019, 8, 29), 59));
            cp.Add_Sale(new CommissionPaid_Employee.SoldCommision(new DateTime(2019, 8, 14), 87));
            employees.Add(cp);

            return employees;
        }
    }
}

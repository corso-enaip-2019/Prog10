﻿using DP_02_Strategy.Employees;
using DP_02_Strategy.PayCalculators;
using DP_02_Strategy.PayDaySchedulers;
using System;
using System.Collections.Generic;

namespace DP_02_Strategy
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
            //var endDay = new DateTime(2019, 8, 31);
            //var startDay = new DateTime(2019, 8, 22);

            foreach (var e in employees)
            {
                if (e.IsPayDay(date))
                {
                    var pay = e.CalculatePay(date);
                    if (pay != 0m)
                    {
                        var record = new PayCheckRecord(e.ID, DateTime.Today, pay);
                        payCheckRecords.Add(record);
                    }
                }
            }

            Console.ReadKey();
        }

        static List<Employee> CreateEmployess()
        {
            List<Employee> employees = new List<Employee>();

            var fs = new Employee(new MonthlyPay_Scheduler(), new FixedSalary_Calculator())
            {
                ID = 1,
                Name = "Tiziano",
                FixedSalary = 1600.00m,
            };
            fs.Add_DaylyWorkedHours(new DateTime(2019, 8, 31), 4);
            fs.Add_DaylyWorkedHours(new DateTime(2019, 8, 30), 6);
            fs.Add_Sale(new SoldCommision(new DateTime(2019, 8, 29), 59));
            fs.Add_Sale(new SoldCommision(new DateTime(2019, 8, 14), 87));
            employees.Add(fs);

            var hp = new Employee(new WeeklyPay_Scheduler(), new HourlyPay_Calculator())
            {
                ID = 2,
                Name = "Jessica",
                HourlyRate = 30m,
            };
            hp.Add_DaylyWorkedHours(new DateTime(2019, 8, 31), 4);
            hp.Add_DaylyWorkedHours(new DateTime(2019, 8, 30), 6);
            hp.Add_DaylyWorkedHours(new DateTime(2019, 8, 29), 5);
            hp.Add_DaylyWorkedHours(new DateTime(2019, 8, 14), 8);

            employees.Add(hp);

            var cp = new Employee(new DaylyPay_Scheduler(), new CommisionPay_Calculator())
            {
                ID = 3,
                Name = "Ken",
                CommisionPercentage = 2m,
            };
            cp.Add_Sale(new SoldCommision(new DateTime(2019, 8, 31), 4000));
            cp.Add_Sale(new SoldCommision(new DateTime(2019, 8, 30), 6800));
            cp.Add_Sale(new SoldCommision(new DateTime(2019, 8, 29), 5900));
            cp.Add_Sale(new SoldCommision(new DateTime(2019, 8, 14), 870));
            employees.Add(cp);

            return employees;
        }
    }
}

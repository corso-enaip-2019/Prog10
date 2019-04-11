using DP_03_Template.Employees;
using DP_03_Template.PayCalculators;
using DP_03_Template.PayDaySchedulers;
using DP_03_Template.Savers;
using System;
using System.Collections.Generic;

namespace DP_03_Template
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


            var persons = CreatePersons();
            string jsonFile = @"c:\myJson.json";
            string xmlFile = @"c:\myXML.xml";

            ISaver xmlSaver = Saver.GetSaver<XMLSaver>();
            xmlSaver.Save(persons, xmlFile);

            ISaver jsonSaver = Saver.GetSaver<JSonSaver>();
            jsonSaver.Save(persons, jsonFile);

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
            
            var monster = new Employee(new MonthlyPay_Scheduler(), new CommisionPay_Calculator())
            {
                ID = 3,
                Name = "Ken",
                CommisionPercentage = 2m,
            };
            monster.Add_Sale(new SoldCommision(new DateTime(2019, 8, 31), 4000));
            monster.Add_Sale(new SoldCommision(new DateTime(2019, 8, 30), 6800));
            monster.Add_Sale(new SoldCommision(new DateTime(2019, 8, 29), 5900));
            monster.Add_Sale(new SoldCommision(new DateTime(2019, 8, 14), 870));
            employees.Add(monster);

            return employees;
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
}

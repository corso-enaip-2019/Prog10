using System;

namespace DesignPattern_01.Entities
{
    class PayCheckRecord
    {
        public PayCheckRecord()
        {

        }

        public PayCheckRecord(int employeeID, DateTime date, decimal payCheck)
        {
            EmployeeID = employeeID;
            Date = date;
            PayCheck = payCheck;
        }

        public int EmployeeID { get; set; }
        public DateTime Date { get; set; }
        public decimal PayCheck { get; set; }
    }
}

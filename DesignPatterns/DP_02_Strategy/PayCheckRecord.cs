﻿using System;

namespace DP_02_Strategy
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

using System;
using System.Collections.Generic;
using System.Text;

namespace DP_02_Strategy.PayDaySchedulers
{
    interface IPayDayScheduler
    {
        bool IsPayDay(DateTime date);

        // la tupla permette di restituire due valori in uscita
        (DateTime Start, DateTime End) GetPayInterval(DateTime date);
    }
}

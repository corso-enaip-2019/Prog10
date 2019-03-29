using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recap4
{
    class UInterface
    {

        public int GetPositiveInt(string requestMessage)
        {
            int outValue = 0;
            bool valid = false;
            do
            {
                Console.Write(requestMessage);
                valid = Int32.TryParse(Console.ReadLine(), out outValue);
                if (!valid || outValue < 0)
                {
                    Console.WriteLine("Valore inserito non valido!");
                    requestMessage = "Inserire un valore valido: ";
                    valid = false;
                }
            }
            while (!valid);

            return outValue;
        }

        public void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}

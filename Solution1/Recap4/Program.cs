using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recap4
{
    class Program
    {
        static void Main(string[] args)
        {
            //NumeriTriangolari nt = new NumeriTriangolari();
            //nt.Run();

            NumeriPrimi np = new NumeriPrimi();
            np.Run(new UInterface());

            Console.ReadKey(true);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recap4
{
    class NumeriTriangolari
    {
        UInterface _uInterface = null;

        public void Run(UInterface uInterface)
        {
            _uInterface = uInterface ?? throw new ArgumentNullException(nameof(uInterface));

            ///Numeri triangolari
            ///chiesti due numeri all'utente
            ///stampare a console tutti i nuemri triangolari nel range
            ///

            int minRange = 0;
            int maxRange = 0;

            bool rangeValid = false;

            while (!rangeValid)
            {
                minRange = _uInterface.GetNumber("Inserisci min range: ");
                maxRange = _uInterface.GetNumber("Inserisci max range: ");

                rangeValid = maxRange >= minRange;
                if (!rangeValid)
                {
                    _uInterface.WriteMessage("Il valore massimo non può essere maggiore del minimo");
                }
            }

            for (int i = 1; i < int.MaxValue; i++)
            {
                int triangular = CalcolaTriangolare(i);
                if (triangular < minRange)
                {
                    continue;
                }
                if (triangular > maxRange)
                {
                    break;
                }

                _uInterface.WriteMessage($"Triangolare valido: {triangular}");
            }
        }

        int CalcolaTriangolare(int numero)
        {
            return (numero * (numero + 1)) / 2;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numTriangolare"></param>
        /// <returns>Seme del numero triangolare</returns>
        int ReverseTriangolare(int numTriangolare)
        {
            return 0;
        }
    }
}

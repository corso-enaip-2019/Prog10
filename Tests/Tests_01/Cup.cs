using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests_01_Cup
{
    /*
     * Se la tazza è vuota la posso riempire
     * Se è piena la posso bere
     * Bere una tazza vuota causa eccezione
     * Riempire una tazza piena causa eccezione
     * Posso riempire-bere infinite volte
     */
    class Cup
    {        
        public bool IsFull { get; private set; }

        /// <summary>
        /// This method fill the cup to Full status.
        /// </summary>
        /// <exception cref="InvalidOperationException">If the Cup is already full</exception>
        public void Fill()
        {
            if (IsFull)
                throw new InvalidOperationException("Cup is already full");
            
            IsFull = true;
        }

        public void Drink()
        {   
            if (!IsFull)
                throw new InvalidOperationException("Cup is empty");

            IsFull = false;
        }

        //// Se devo implementare metodi che restituiscono valori prima restituisco solo un defoult o un eccezione
        //// solo dopo aver scritto i test implemento il codice correttamente
        //public int GetQuantity()
        //{
        //    throw new NotImplementedException();
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests_03_Cup2
{
    /*
     * Se la tazza è vuota la posso riempire
     * Se è piena la posso bere
     * Bere una tazza vuota causa eccezione
     * Riempire una tazza piena causa eccezione
     * Posso riempire-bere infinite volte
     * 
     * --------------------------------
     * 1) Quanto la tazza è piena ha 10/10 di bevanda
     * 2) Si può bere solo in parte (in decimi)
     * 3) Non si può bere più del massimo (eccezione)
     * 4) Quando riempio, riempio sempre fino al massimo
     * 5) Una tazza piena (10/10) non può essere riempita ancora (eccezione)
     * 
     */
    class Cup
    {        
        public bool IsFull { get; private set; }
        public int FillLevel { get; private set; }
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

        public void Drink(int level)
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

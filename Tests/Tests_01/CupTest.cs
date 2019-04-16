using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests_01_Cup
{
    [TestClass]
    public class CupTest
    {

        ///Idealmente ogni metodo di test dovrebbe avere un solo assert per controllare le cose singolarmente
        ///potrei avere più assert per controllare una singola situazione ma non una sequenza di operazioni
        ///

        [TestMethod]
        public void New_empty_cup ()
        {
            var cup = new Cup();
            Assert.IsFalse(cup.IsFull);
        }

        [TestMethod]
        public void Fill_an_empty_cup()
        {
            var cup = new Cup();
            cup.Fill();

            Assert.IsTrue(cup.IsFull);
        }

        [TestMethod]
        public void Regular_fill_and_drink()
        {
            var cup = new Cup();
            cup.Fill();
            cup.Drink();

            Assert.IsFalse(cup.IsFull);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Can_not_fill_a_full_cup()
        {
            var cup = new Cup();
            cup.Fill();
            cup.Fill();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Can_not_drink_empty_cup()
        {
            var cup = new Cup();
            cup.Drink();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Can_not_drink_2_consecutive_times()
        {
            var cup = new Cup();
            cup.Fill();
            cup.Drink();
            cup.Drink();            
        }

        [TestMethod]
        public void Fill_and_drink_to_the_infinite()
        {
            var cup = new Cup();

            for (int i = 0; i < 1000; i++) {
                cup.Fill();
                cup.Drink();
            }

            Assert.IsFalse(cup.IsFull);
        }
    }
}

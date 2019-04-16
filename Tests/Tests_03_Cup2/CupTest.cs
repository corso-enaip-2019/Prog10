using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests_03_Cup2
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
            Assert.AreEqual(0, cup.FillLevel);
        }

        [TestMethod]
        public void Fill_an_empty_cup()
        {
            var cup = new Cup();
            cup.Fill();

            Assert.IsTrue(cup.IsFull);
            Assert.AreEqual(10, cup.FillLevel);
        }

        [TestMethod]
        public void A_cup_entirely_drank_is_empty()
        {
            var cup = new Cup();
            cup.Fill();
            cup.Drink(10);

            Assert.IsFalse(cup.IsFull);
            Assert.AreEqual(0, cup.FillLevel);
        }

        [TestMethod]
        public void A_cup_partially_drunk__consecutive_times()
        {
            var cup = new Cup();
            cup.Fill();
            cup.Drink(5);
            cup.Drink(2);

            Assert.IsFalse(cup.IsFull);
            Assert.AreEqual(3, cup.FillLevel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void A_cup_drinked_over_limit()
        {
            var cup = new Cup();
            cup.Fill();
            cup.Drink(5);
            cup.Drink(6);
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
            cup.Drink(0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Filling_a_partially_filled_cup()
        {
            var cup = new Cup();
            cup.Fill();
            cup.Drink(1);
            cup.Drink(6);
            cup.Fill();

            Assert.IsTrue(cup.IsFull);
            Assert.AreEqual(10, cup.FillLevel);
        }

        [TestMethod]
        public void Fill_and_drink_many_times()
        {
            var cup = new Cup();

            var drinkings = new[] {
                new[]{1,2 },
                new[]{9 },
                new[]{10 },
                new[]{1, 1, 1, 1, 1, 2, 1, 1, 1 },
            };

            foreach (var drinking in drinkings) {
                cup.Fill();
                foreach(var drink in drinking) {
                    cup.Drink(drink);

                }
            }
        }
    }
}

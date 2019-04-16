using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimeTest
{
    [TestClass]
    public class MathUtilities_Test
    {
        [TestMethod]
        public void Prime_numbers_return_true()
        {
            var primes = new[] {
                2, 3, 5, 7, 17, 101, 1002523
            };

            foreach (var p in primes) {
                Assert.IsTrue(MathUtils.IsPrime(p), $"input number: {p}");
            }
        }

        [TestMethod]
        public void Zero_and_one_return_false()
        {
            Assert.IsFalse(MathUtils.IsPrime(0));
            Assert.IsFalse(MathUtils.IsPrime(1));
        }

        [TestMethod]
        [DataRow(4)]
        [DataRow(6)]
        [DataRow(8)]
        [DataRow(9)]
        [DataRow(10)]
        [DataRow(25)]
        [DataRow(1002525)]
        public void Non_prime_return_false(int i)
        {
            Assert.IsFalse(MathUtils.IsPrime(i));

            //var nonPrimes = new[] {
            //    4, 8, 9, 10, 25, 1002525
            //};

            //foreach (var np in nonPrimes) {
            //    Assert.IsFalse(MathUtils.IsPrime(np), $"input number: {np}");
            //}
        }

        // sfrutto i DataRow per fare un unico grande metodo di test

        [TestMethod]
        [DataRow(-17, false)]
        [DataRow(0, false)]
        [DataRow(1, false)]

        [DataRow(2, true)]
        [DataRow(3, true)]
        [DataRow(5, true)]
        [DataRow(7, true)]
        [DataRow(17, true)]
        [DataRow(101, true)]
        [DataRow(1002523, true)]

        [DataRow(4, false)]
        [DataRow(6, false)]
        [DataRow(8, false)]
        [DataRow(9, false)]
        [DataRow(10, false)]
        [DataRow(25, false)]
        [DataRow(1002525, false)]
        public void Number_is_correctly_recognized(int n, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, MathUtils.IsPrime(n));            
        }


        [TestMethod]
        public void Negarive_return_false()
        {
            var nonPrimes = new[] {
                -1, -3, -4, -5, -9, -17, -25, -1002525
            };

            foreach (var np in nonPrimes) {
                Assert.IsFalse(MathUtils.IsPrime(np), $"input number: {np}");
            }
        }

        ///Troppo elaborato e facile cadere in errore
        //[TestMethod]
        //public void Is_Not_Prime_Negative()
        //{            
        //    Assert.IsFalse(MathUtils.IsPrime(-10));
        //}

        //[TestMethod]
        //public void Is_Not_Prime_0()
        //{            
        //    Assert.IsFalse(MathUtils.IsPrime(0));
        //}

        //[TestMethod]        
        //public void Is_Not_Prime_1()
        //{                        
        //    Assert.IsFalse(MathUtils.IsPrime(1));
        //}

        //[TestMethod]
        //public void Is_Prime_2()
        //{            
        //    Assert.IsTrue(MathUtils.IsPrime(2));
        //}

        //[TestMethod]
        //public void Is_Prime_3()
        //{            
        //    Assert.IsTrue(MathUtils.IsPrime(3));
        //}

        //[TestMethod]
        //public void Is_Not_Prime_9()
        //{            
        //    Assert.IsFalse(MathUtils.IsPrime(9));
        //}

        //[TestMethod]
        //public void Is_Prime_17()
        //{            
        //    Assert.IsTrue(MathUtils.IsPrime(17));
        //}

        //[TestMethod]
        //public void Is_Not_Prime_Even_Number()
        //{                      
        //    Assert.IsFalse(MathUtils.IsPrime(1000));
        //}
    }
}

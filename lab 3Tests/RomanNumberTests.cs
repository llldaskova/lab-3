using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Tests
{
    [TestClass()]
    public class RomanNumberTests
    {
        
        [TestMethod()]
        public void InvalidValue()
        {

            Assert.ThrowsException<RomanNumberException>(()=>new RomanNumber(0));
        }

        [TestMethod()]
        public void CloneTest()
        {
            var number = new RomanNumber(10);
            RomanNumber number2 = (RomanNumber)number.Clone();
            Assert.IsTrue(number.CompareTo(number2) == 0);
        }

        [TestMethod()]
        public void CompareToTest1()
        {
            var number = new RomanNumber(10);
            var number2 = new RomanNumber(20);
            Assert.IsTrue(number.CompareTo(number2) < 0);
        }
        [TestMethod()]
        public void CompareToTest2()
        {
            var number = new RomanNumber(10);
            var number2 = new RomanNumber(20);
            Assert.IsTrue(number2.CompareTo(number) > 0);
        }
        [TestMethod()]
        public void CompareToTest3()
        {
            var number = new RomanNumber(10);
            var number2 = new RomanNumber(10);
            Assert.IsTrue(number2.CompareTo(number) == 0);
        }
        [TestMethod()]
        public void add()
        {
            var res = new RomanNumber(20) + new RomanNumber(10);
            Assert.IsTrue(res.CompareTo(new RomanNumber(20 + 10)) == 0);
        }
        [TestMethod()]
        public void mul()
        {
           
            var res = new RomanNumber(20) * new RomanNumber(10);
            Assert.IsTrue(res.CompareTo(new RomanNumber(20 * 10)) == 0);
        }
        [TestMethod()]
        public void divUsual()
        { 
            var res = new RomanNumber(20) / new RomanNumber(10);
            Assert.IsTrue(res.CompareTo(new RomanNumber(20/10)) == 0);
        }
        [TestMethod()]
        public void divError()
        {
            var number = new RomanNumber(10);
            var number2 = new RomanNumber(20);
            Assert.ThrowsException<RomanNumberException>(() => number/number2);
        }
        [TestMethod()]
        public void subUsual()
        {
            var res = new RomanNumber(20) - new RomanNumber(10);
            Assert.IsTrue(res.CompareTo(new RomanNumber(20-10)) == 0);
        }
        [TestMethod()]
        public void subError()
        {
            var number = new RomanNumber(10);
            var number2 = new RomanNumber(20);
            Assert.ThrowsException<RomanNumberException>(() => number - number2);
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MindboxClassLibrary1;
using System;
using System.Collections.Generic;

namespace TestProject1
{
    [TestClass]
    public class CalcSquareTest
    {
        [TestMethod]
        public void CalcSquareTest1()
        {
            //arrange подстроить-настроить
            float _radius = 1;
            double expected = Math.PI;

            //act действие
            CalculationSquare a = new CalculationSquare(_radius);
            double actual = a.CalcSquareCircle(_radius);

            //assert утверждать - правильно или не правильно закончился наш код
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalcSquareTest2()
        {
            //arrange подстроить-настроить
            float _side1 = 3;
            float _side2 = 4;
            float _side3 = 5;
            double SquareTriangle2 = -1;
            double expected = 6;
            //act действие
            CalculationSquare a2 = new CalculationSquare(_side1, _side2, _side3);
            a2.CalcSquareTriangle(_side1, _side2, _side3, out SquareTriangle2);
            double actual = SquareTriangle2;
            //assert утверждать - правильно или не правильно закончился наш код
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void CalcSquareTest3()
        {
            //arrange подстроить-настроить
            List<float> _sides = new List<float>() { 3, 4, 5 };
            double expected = 6;

            //act действие
            CalculationSquare a3 = new CalculationSquare(_sides);
            a3.CalcSquareN(_sides, a3.CalcHalfPerim(_sides), out double SquareN);
            double actual = SquareN;

            //assert утверждать - правильно или не правильно закончился наш код
            Assert.AreEqual(expected, actual);
        }
        
    }
    
}

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
            //arrange ����������-���������
            float _radius = 1;
            double expected = Math.PI;

            //act ��������
            CalculationSquare a = new CalculationSquare(_radius);
            double actual = a.CalcSquareCircle(_radius);

            //assert ���������� - ��������� ��� �� ��������� ���������� ��� ���
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalcSquareTest2()
        {
            //arrange ����������-���������
            float _side1 = 3;
            float _side2 = 4;
            float _side3 = 5;
            double SquareTriangle2 = -1;
            double expected = 6;
            //act ��������
            CalculationSquare a2 = new CalculationSquare(_side1, _side2, _side3);
            a2.CalcSquareTriangle(_side1, _side2, _side3, out SquareTriangle2);
            double actual = SquareTriangle2;
            //assert ���������� - ��������� ��� �� ��������� ���������� ��� ���
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void CalcSquareTest3()
        {
            //arrange ����������-���������
            List<float> _sides = new List<float>() { 3, 4, 5 };
            double expected = 6;

            //act ��������
            CalculationSquare a3 = new CalculationSquare(_sides);
            a3.CalcSquareN(_sides, a3.CalcHalfPerim(_sides), out double SquareN);
            double actual = SquareN;

            //assert ���������� - ��������� ��� �� ��������� ���������� ��� ���
            Assert.AreEqual(expected, actual);
        }
        
    }
    
}

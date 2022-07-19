

#region SQL
/*В базе данных MS SQL Server есть продукты и категории. 
 * Одному продукту может соответствовать много категорий, 
 * в одной категории может быть много продуктов. 
 * Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». 
 * Если у продукта нет категорий, то его имя все равно должно выводиться.
 * 
 * сделал на примере базы SalesEnterpriseENU_3749295_0131 
 * 
 * select  [dbo].[Product].Name, [dbo].[ProductCategory].[Name]
from [dbo].[Product],[dbo].[ProductCategory]
LEFT JOIN [dbo].[Product] AS p ON p.[CategoryId] = [dbo].[ProductCategory].[Id]
 *
 * */
#endregion

/*
 * "Легкость добавления других фигур" и 
 * "Вычисление площади фигуры без знания типа фигуры в compile-time"
 * исполнил как вычисления для многогранника
 * */


using System;
using System.Collections.Generic;

namespace MindboxClassLibrary1
{
    /// <summary>
    /// вычисление площадей
    /// </summary>
    public class CalculationSquare
    {
        #region поля
        /// <summary>
        /// площадь многогранника
        /// </summary>
        public double SquareN = 0;
        /// <summary>
        /// возможная ошибка соотношения сторон многогранника
        /// </summary>
        public string ErrorN = "";
        /// <summary>
        /// возможная ошибка соотношения сторон треугольника
        /// </summary>
        public string ErrorTriangle = "";
        /// <summary>
        /// тип треугольника, например равнобедренный
        /// </summary>
        public string TypeTriangle = "";
        #endregion
        #region конструктор
        /// <summary>
        /// вычисление площади многогранника, 
        /// длины сторон должны быть записаны как элементы списка
        /// </summary>
        /// <param name="Sides"></param>
        public CalculationSquare(List<float> Sides)
        {
            List<float> _sides = Sides;
            
        }
        /// <summary>
        /// вычисление площади треугольника
        /// </summary>
        /// <param name="Side1"></param>
        /// <param name="Side2"></param>
        /// <param name="Side3"></param>
        public CalculationSquare(float Side1, float Side2, float Side3/*, double SquareTriangle, string TypeTriangle*/)
        {
            float _side1 = Side1;
            float _side2 = Side2;
            float _side3 = Side3;
        }
        /// <summary>
        /// вычисление площади круга
        /// </summary>
        /// <param name="Radius"></param>
        public CalculationSquare(float Radius/*, double SquareCircle*/)
        {
            float _radius = Radius;
        }
        #endregion
        #region многогранник
        /// <summary>
        /// вычисление полупериметра многогранника
        /// </summary>
        /// <param name="_sides"></param>
        public float CalcHalfPerim(List<float> _sides)
        {
            float HalfPerimeter = 0;
            int i;
            int n = _sides.Count;
            for (i = 0; i<n; i++)
            {
                HalfPerimeter += _sides[i];
            }
            HalfPerimeter = HalfPerimeter / 2;
            return HalfPerimeter;
        }
        /// <summary>
        /// вычисление площади по обобщенной формуле Герона и 
        /// проверка не превышает ли размер стороны половину периметра
        /// </summary>
        /// <param name="_sides"></param>
        /// <param name="CalcHalfPerim"></param>
        /// <returns></returns>
        public void CalcSquareN(List<float> _sides, float CalcHalfPerim, out double SquareN)
         {
            SquareN = -1;
            int i;
            int excess = -1;
            int n = _sides.Count;
            double SquaredSquare = CalcHalfPerim;
            for (i = 0; i < n; i++)
            {
                if (_sides[i] > CalcHalfPerim) excess = i;
            }

            if (excess != -1)
            {
                ErrorN = "У многогранника сторона №" + i + "  " + _sides[i] + "больше полупериметра, многогранник не существует";
            }
            else
            {
                for (i = 0; i < n; i++)
                {
                    SquaredSquare = SquaredSquare * (CalcHalfPerim - _sides[i]);
                }
                SquareN = Math.Sqrt(SquaredSquare);
            }
        }
        #endregion
        #region треугольник
        /// <summary>
        /// вычисление площади треугольника,
        /// проверка соотношения сторон,
        /// определение типа треугольника,- равнобедренный, равносторонний
        /// </summary>
        /// <param name="_side1"></param>
        /// <param name="_side2"></param>
        /// <param name="_side3"></param>
        public void CalcSquareTriangle(float _side1, float _side2, float _side3, out double SquareTriangle)
        {
            SquareTriangle = -1;
            float _halfPer = (_side1 + _side2 + _side3) / 2;
            if ((_halfPer < _side1) || (_halfPer < _side2) || (_halfPer < _side3))
            {
                ErrorTriangle = "одна из сторон треугольника больше суммы двух других, треугольник не существует";
            }
            else
            {
                SquareTriangle = Math.Sqrt(_halfPer * (_halfPer - _side1) * (_halfPer - _side2) * (_halfPer - _side3));
            };
            if ((_side1 == _side2) || (_side2 == _side3) || (_side3 == _side1))
            {
                TypeTriangle = "Равнобедренный";
                if ((_side1 == _side2) && (_side2 == _side3))
                {
                    TypeTriangle = "Равносторонний";
                }
            }
            else {
                TypeTriangle = "Разносторонний";
            }
        }
        #endregion
        #region круг
        /// <summary>
        /// вычисление площади круга
        /// </summary>
        /// <param name="_radius"></param>
        public double CalcSquareCircle(float _radius)
        {
            return Math.PI * Math.Pow(_radius, 2);  //math:) Math.PI
        }
        #endregion
    }

}

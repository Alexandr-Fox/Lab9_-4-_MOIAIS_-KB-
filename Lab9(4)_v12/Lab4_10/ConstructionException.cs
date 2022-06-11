using System;

namespace Lab4_1
{
    public delegate void EventConstrPointHandler(Point point);
    public class ConstructionException: Exception
    {
        public event EventConstrPointHandler EventConstr;
        public void PrintEx(Point point)
        {
            Console.WriteLine($"Точка вызвавшая исключение: {point}");
        }

        public ConstructionException(Point point): base("По данным координатам можно построить только прямоугольник")
        {
            EventConstr += PrintEx;
            EventConstr?.Invoke(point);
        }
    }
}
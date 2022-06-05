using System;

namespace Lab4_1
{
    public class Point
    {
        public double X { get; set; }

        public double Y { get; set; }
        private readonly char _name;
        public char Name { get => _name;
            private init => _name = char.ToUpper(value); }

        public Point()
        {
            X = 0;
            Y = 0;
            Random random = new();
            Name = (char)random.Next('A', 'Z' + 1);
        }
        public Point(double x, double y, char n)
        {
            X = x;
            Y = y;
            Name = n;
        }
        public override string ToString()
        {
            return $"{Name}({X},{Y})";
        }
        public void Print()
        {
            Console.WriteLine(ToString());
        }
    }
}
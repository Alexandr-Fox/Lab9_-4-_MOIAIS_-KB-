using System;


namespace Lab4_1
{
    public delegate void EventOneHandler(double s);
    public class Square
    {
        private Point []_coordinates = new Point [4];
        private const double Tolerance = 0.001;
        public event EventOneHandler SIsOne;
        public Point this[int i]
        {

            get => i < 4 && i >= 0 ? _coordinates[i] : _coordinates[0];
            set
            {
                if (i < 4 && i >= 0)
                {
                    double oldS = S;
                    _coordinates[i] = value;
                    if (IsSquare)
                    {
                        if (Math.Abs(S - 1) < Tolerance)
                        {
                            SIsOne.Invoke(oldS);
                        }
                    }
                }
            }
        }
        public double S => IsSquare?Math.Pow(Side, 2):0;

        private double Side => L(_coordinates[0],_coordinates[1]);

        private bool IsSquare =>  Math.Abs(L(_coordinates[0], _coordinates[1]) - L(_coordinates[0], _coordinates[3])) < Tolerance &&
                                  Math.Abs(L(_coordinates[2], _coordinates[1]) - L(_coordinates[2], _coordinates[3])) < Tolerance &&
                                  Math.Abs(L(_coordinates[1], _coordinates[2]) - L(_coordinates[1], _coordinates[0])) < Tolerance &&
                                  Math.Abs(L(_coordinates[3], _coordinates[2]) - L(_coordinates[3], _coordinates[0])) < Tolerance &&
                                  Math.Abs(L(_coordinates[0], _coordinates[2]) - L(_coordinates[1], _coordinates[3])) < Tolerance;

        private string Name =>
            $"{_coordinates[0].Name}" +
            $"{_coordinates[1].Name}" +
            $"{_coordinates[2].Name}" +
            $"{_coordinates[3].Name}";

        private double L(Point p1, Point p2) => 
            Math.Sqrt(
            (p1.X - p2.X) *
            (p1.X - p2.X) +
            (p1.Y - p2.Y) *
            (p1.Y - p2.Y)
            ); 

        public Square(Point[] coordinates)
        {
            _coordinates = coordinates;
        }
        public Square()
        {
            Random random = new();
            double x1 = random.Next(-10, 10), 
                   y1 = random.Next(-10, 10), 
                   side = random.Next(20);
            _coordinates[0] = new Point(x1, y1, (char)random.Next('A', 'Z' + 1));
            _coordinates[1] = new Point(x1, y1 + side, (char)random.Next('A', 'Z' + 1));
            _coordinates[3] = new Point(x1 + side, y1, (char)random.Next('A', 'Z' + 1));
            _coordinates[2] = new Point(x1 + side, y1 + side, (char)random.Next('A', 'Z' + 1));
        }
        public override string ToString()
        {
            return $"{(IsSquare ? "Квадрат" : "Квадрат(не все точки имеют правильные координаты)")}: {Name}\n" +
                   $"Координаты точек: \n" +
                   $"{_coordinates[0]}\n" +
                   $"{_coordinates[1]}\n" +
                   $"{_coordinates[2]}\n" +
                   $"{_coordinates[3]}\n" +
                   $"Сторона квадрата: {Side}\n" +
                   $"Площадь: {S}";
        }
        public void Print()
        {
            Console.WriteLine(ToString());
        }
        
    }
}
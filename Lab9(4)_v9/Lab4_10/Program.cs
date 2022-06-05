using System;

namespace Lab4_1
{
    class Program
    {
        private static Point Init()
        {
            while (true)
            {
                try
                {
                    Console.Write("Введите Х: ");
                    double x = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите Y: ");
                    double y = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите букву точки: ");
                    var n = Convert.ToChar(Console.ReadLine()![0]);
                    return new Point(x, y, n);
                }
                catch(InvalidCastException )
                {
                    Console.WriteLine("Это не число");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void Main()
        {
            Point[] points = new Point[4];

            for ( int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Введите координаты {i + 1} точки");
                points[i] = Init();
            }

            Square _square = new(points);
            _square.SIsOne += EventSIsOne.PrintSIsOne;
            while (true)
            {
                Console.WriteLine("1) Изменить координаты");
                Console.WriteLine("2) Вывести квадрат в консоль");
                Console.WriteLine("3) Создать новый квадрат");
                Console.WriteLine("4) Вывести площадь квадрата");
                Console.WriteLine("0) Выход");
                Console.Write("Выбирите действие: ");
                try
                {
                    int d = Convert.ToInt32(Console.ReadLine());
                    switch (d)
                    {
                        case 0:
                            {
                                Environment.Exit(0); 
                                break;
                            }
                        case 1:
                            {
                                for (int i = 0; i < 4; i++)
                                {
                                    Console.WriteLine($"{i + 1}) {_square[i]}");
                                }
                                Console.WriteLine("Выбирите точку для редактирования: ");
                                try
                                {
                                    int t = Convert.ToInt32(Console.ReadLine()) - 1;
                                    _square[t] = Init();
                                }
                                catch (ConstructionException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            }
                        case 2:
                            {
                                _square.Print();
                                break;
                            }
                        case 3:
                            {
                                points = new Point[4];
                                for (int i = 0; i < 4; i++)
                                {
                                    Console.WriteLine($"Введите координаты {i + 1} точки");
                                    points[i] = Init();
                                }
                                _square = new(points);
                                _square.SIsOne += EventSIsOne.PrintSIsOne;
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine($"Площадь: {_square.S}");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Неверное действие");
                                break;
                            }
                    }
                }
                catch (InvalidCastException)
                {
                    Console.WriteLine("Это не число");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}

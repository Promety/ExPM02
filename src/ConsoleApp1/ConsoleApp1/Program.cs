using System;
using System.Collections.Generic;
using System.IO;


namespace ConsoleApp1
{
    public class Plane
    {
        public string Model { get; set; }
        public double MaxRange { get; set; }
        public double CruiseSpeed { get; set; }

        public Plane(string model, double maxRange, double cruiseSpeed)
        {
            Model = model;
            MaxRange = maxRange;
            CruiseSpeed = cruiseSpeed;
        }
        
    }

    public class PlaneControl
    {
        private List<Plane> planes = new List<Plane>();

        public void AddPlane(Plane plane)
        {
            planes.Add(plane);
        }

        public void SortPlanes()
        {
            planes.Sort((x, y) =>
            {
                if (x.MaxRange != y.MaxRange)
                    return y.MaxRange.CompareTo(x.MaxRange);
                else
                    return y.CruiseSpeed.CompareTo(x.CruiseSpeed);
            });
        }

        public void SaveToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Plane plane in planes)
                {
                    writer.WriteLine($"Model: {plane.Model}, Max Range: {plane.MaxRange}, Cruise Speed: {plane.CruiseSpeed}");
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            PlaneControl control = new PlaneControl();

            Console.Write("Введите кол-во самолетов (размер массива): ");
            int size ;
            while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
            {
                Console.WriteLine("Неправильный ввод данных");
                Console.Write("Введите кол-во самолетов (размер массива) ");
            }

            for (int i = 0; i < size; i++)
            {
                Console.Write("Название модели: ");
                string model = Console.ReadLine();

                Console.Write("Максимальная дальность полёта: ");
                double maxRange;
                while (!double.TryParse(Console.ReadLine(), out maxRange) || maxRange <= 0)
                {
                    Console.WriteLine("Неправильный ввод данных, попробуйте еще раз");
                    Console.Write("Максимальная дальность полёта: ");
                }

                Console.Write("Крейсерская скорость: ");
                double cruiseSpeed;
                while (!double.TryParse(Console.ReadLine(), out cruiseSpeed) || cruiseSpeed <= 0)
                {
                    Console.WriteLine("Неправильный ввод данных, попробуйте еще раз");
                    Console.Write("Крейсерская скорость: ");
                }


                Plane plane = new Plane(model, maxRange, cruiseSpeed);
                control.AddPlane(plane);

            }

            control.SortPlanes();
            control.SaveToFile("planes.txt");

        }
    }

}
   


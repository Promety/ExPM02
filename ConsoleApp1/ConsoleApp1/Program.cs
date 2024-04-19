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
            int size = int.Parse(Console.ReadLine());

            for (int i = 0; i < size; i++)
            {
                Console.Write("Название модели: ");
                string model = Console.ReadLine();

                Console.Write("Максимальная дальность полёта: ");
                double maxRange = double.Parse(Console.ReadLine());

                Console.Write("Крейсерская скорость: ");
                double cruiseSpeed = double.Parse(Console.ReadLine());

                Plane plane = new Plane(model, maxRange, cruiseSpeed);
                control.AddPlane(plane);

            }

            control.SortPlanes();
            control.SaveToFile("planes.txt");

        }
    }

}
   


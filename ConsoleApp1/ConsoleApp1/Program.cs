using System;
using System.IO;


namespace ConsoleApp1
{
    class Plane
    {
        public string Model { get; set; } //Название
        public int MaxFlRange { get; set; } // Максимальная дальность полета
        public int CruisingSpeed { get; set; } // Крейсерная скорость
        public void Print()
        {
            Console.WriteLine("Введите модель: " + Model);
            Console.WriteLine("Введите максимальную дальность полёта: " + MaxFlRange);
            Console.WriteLine("Введите крейсерскую скорость: " + CruisingSpeed);

            using (StreamWriter os = new StreamWriter("result.txt", true))
            {
                os.WriteLine(Model + " " + MaxFlRange + " " + CruisingSpeed);
            }
        }

    }
    class Program
    {
        static void Main()
        {
            int size = 0;
            Console.WriteLine("Введите Кол-во самолетов (размерность массива):");

            size = int.Parse(Console.ReadLine());
            Plane[] A = new Plane[size];
            for (int i = 0; i < size; i++)
            {
                A[i] = new Plane();
            }

            for (int i = 0; i < size; i++)
            {
                Console.Write("Введите название " + (i + 1) + " самолета :");
                A[i].Model = Console.ReadLine();

                Console.Write("Введите максимальную дальность полёта " + (i + 1) + " самолета :");
                A[i].MaxFlRange = int.Parse(Console.ReadLine());

                Console.Write("Введите крейсерскую скорость " + (i + 1) + " самолета :");
                A[i].CruisingSpeed = int.Parse(Console.ReadLine());



            }

            
            foreach (var plane in A)
            {
                Array.Sort(A, (x, y) => x.MaxFlRange.CompareTo(y.MaxFlRange));
                Array.Sort(A, (x, y) => x.CruisingSpeed.CompareTo(y.CruisingSpeed));
                plane.Print();
            }
        }

    }
}
    //class PlaneControl
     //   {
     //   Plane.Sort();
       // Array.Sort(A, (x, y) => x..CompareTo(y.S));
          //  Array.Sort(A, (x, y) => x.kolvo.CompareTo(y.kolvo));
      //  }


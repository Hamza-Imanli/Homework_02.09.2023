using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Task_02._09._2023.Program.Car;

namespace Task_02._09._2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Gallery myGallery = new Gallery("Car Gallery");

            Car car1 = new Car("Chevrolet", 150, 16000);
            Car car2 = new Car("BMW X5", 220, 40000);
            Car car3 = new Car("Hyundai Accent", 180, 17000);

            myGallery.AddCar(car1);
            myGallery.AddCar(car2);
            myGallery.AddCar(car3);

            myGallery.GetGalleryCarShow();

            double totalPrice = myGallery.SumCar();
            Console.WriteLine($"Total Price of Cars in {myGallery.Name}:{totalPrice} AZN");

            myGallery.DeleteCar(3);

            myGallery.GetGalleryCarShow();
                     
        }
        public class Car
        {
            public int Id { get; set; }
            public static int Count { get; private set; } = 0;
            public string Name { get; set; }
            public int Speed { get; set; }
            public double Price { get; set; }

            public Car(string name, int speed, double price)
            {
                Id = ++Count;
                Name = name;
                Speed = speed;
                Price = price;
            }
            public string GetInfoCar()
            {
                return $"ID: {Id}, Name: {Name}, Speed: {Speed} km/h, Price:{Price} AZN";
            }
            public class Gallery
            {
                public string Name { get; set; }
                public Car[] Cars { get; private set; } = new Car[0];

                public Gallery(string name)
                {
                    Name = name;
                   
                }

                public void GetGalleryCarShow()
                {                  
                    foreach (var car in Cars)
                    {
                        Console.WriteLine(car.GetInfoCar());
                    }
                }


                public void AddCar(Car car)
                {
                    int newLength = Cars.Length + 1;
                    Car[] newCars = new Car[newLength];

                    for (int i = 0; i < Cars.Length; i++)
                    {
                        newCars[i] = Cars[i];
                    }

                    newCars[newLength - 1] = car;
                    Cars = newCars;
                }

                public double  SumCar()
                {
                    double total = 0;
                    foreach (var car in Cars)
                    {
                        total += car.Price;
                    }
                    return total;
                }

                public void DeleteCar(int id)
                {
                    var carToDelete = Cars.FirstOrDefault(car => car.Id == id);
                    if (carToDelete != null)
                    {
                        Cars = Cars.Where(car => car.Id != id).ToArray();
                        Console.WriteLine($"Car with ID {id} has been deleted ");
                        double totalPrice = SumCar();
                        Console.WriteLine($"Total Price of Cars in {Name} Gallery:{totalPrice} AZN");
                    }

                    else 
                    {
                        Console.WriteLine($"Car with ID {id} was not found ");
                    }
                }
            }
        }
    }
}

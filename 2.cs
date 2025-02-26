using System;
using Newtonsoft.Json;

class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter Car Brand: ");
        string brand = Console.ReadLine();

        Console.Write("Enter Car Model: ");
        string model = Console.ReadLine();

        Console.Write("Enter Car Year: ");
        int year = int.Parse(Console.ReadLine());

        Car car = new Car { Brand = brand, Model = model, Year = year };

        string carJson = JsonConvert.SerializeObject(car, Formatting.Indented);
        Console.WriteLine("\nCar JSON:\n" + carJson);
    }
}

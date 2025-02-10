/*3. Vehicle Rental System
Description: Design a system to manage vehicle rentals:
Define an abstract class Vehicle with fields like vehicleNumber, type, and rentalRate.
Add an abstract method CalculateRentalCost(int days).
Create subclasses Car, Bike, and Truck with specific implementations of CalculateRentalCost().
Use an interface IInsurable with methods CalculateInsurance() and GetInsuranceDetails().
Apply encapsulation to restrict access to sensitive details like insurance policy numbers.
Demonstrate polymorphism by iterating over a list of vehicles and calculating rental and insurance costs for each.
*/

using System;
using System.Collections.Generic;


// Abstract Class
public abstract class Vehicle
{
    public string VehicleNumber { get; set; }
    public string Type { get; set; }
    public double RentalRate { get; set; }


    public abstract double CalculateRentalCost(int days);
}


// Concrete Classes
public class Car : Vehicle
{
    public override double CalculateRentalCost(int days)
    {
        return days * RentalRate;  // Rental rate per day
    }
}


public class Bike : Vehicle
{
    public override double CalculateRentalCost(int days)
    {
        return days * RentalRate;  // Rental rate per day
    }
}


// Interface
public interface IInsurable
{
    double CalculateInsurance();
    string GetInsuranceDetails();
}


// Main Program
public class Program
{
    public static void Main()
    {
        List<Vehicle> vehicles = new List<Vehicle>
        {
            new Car { VehicleNumber = "CAR123", Type = "Car", RentalRate = 50 },
            new Bike { VehicleNumber = "BIKE123", Type = "Bike", RentalRate = 20 }
        };


        foreach (var vehicle in vehicles)
        {
            double rentalCost = vehicle.CalculateRentalCost(5);  // Assume 5 days of rental
            Console.WriteLine("Vehicle: " + vehicle.Type + ", Rental Cost for 5 days: " + rentalCost);
        }
    }
}

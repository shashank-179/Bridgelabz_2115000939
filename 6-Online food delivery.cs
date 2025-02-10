/*6. Online Food Delivery System
Description: Create an online food delivery system:
Define an abstract class FoodItem with fields like itemName, price, and quantity.
Add abstract methods CalculateTotalPrice() and concrete methods like GetItemDetails().
Extend it into classes VegItem and NonVegItem, overriding CalculateTotalPrice() to include additional charges.
Use an interface IDiscountable with methods ApplyDiscount() and GetDiscountDetails().
Use polymorphism to handle different types of food items dynamically.
*/

using System;
using System.Collections.Generic;


// Abstract Class
public abstract class FoodItem
{
    public string ItemName { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }


    public abstract double CalculateTotalPrice();
}


// Subclasses
public class VegItem : FoodItem
{
    public override double CalculateTotalPrice()
    {
        return Price * Quantity;  // Veg items may have no additional charge
    }
}


public class NonVegItem : FoodItem
{
    public override double CalculateTotalPrice()
    {
        return Price * Quantity + 2;  // Additional charge for non-veg items
    }
}


// Interface
public interface IDiscountable
{
    void ApplyDiscount();
    string GetDiscountDetails();
}


// Main Program
public class Program
{
    public static void Main()
    {
        List<FoodItem> foodItems = new List<FoodItem>
        {
            new VegItem { ItemName = "Salad", Price = 5, Quantity = 2 },
            new NonVegItem { ItemName = "Chicken Curry", Price = 10, Quantity = 1 }
        };


        foreach (var item in foodItems)
        {
            double totalPrice = item.CalculateTotalPrice();
            Console.WriteLine("Item: " + item.ItemName + ", Total Price: " + totalPrice);
        }
    }
}

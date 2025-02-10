/*2. E-Commerce Platform
Description: Develop a simplified e-commerce platform:
Create an abstract class Product with fields like productId, name, and price, and an abstract method CalculateDiscount().
Extend it into concrete classes: Electronics, Clothing, and Groceries.
Implement an interface ITaxable with methods CalculateTax() and GetTaxDetails() for applicable product categories.
Use encapsulation to protect product details, allowing updates only through setter methods.
Showcase polymorphism by creating a method that calculates and prints the final price (price + tax - discount) for a list of products.

*/
using System;

// Abstract Product Class
abstract class Product
{
    private int _productId;
    private string _name;
    private double _price;
    protected double finalPrice;

    // Properties
    public int ProductId { get { return _productId; } }
    public string Name { get { return _name; } }
    public double Price { get { return _price; } }

    // Constructor
    public Product(int productId, string name, double price)
    {
        _productId = productId;
        _name = name;
        _price = price;
    }

    // Abstract Method
    public abstract void CalculateDiscount();

    // Display Method
    public virtual void Display()
    {
        Console.WriteLine($"Product ID: {ProductId}");
        Console.WriteLine($"Product Name: {Name}");
        Console.WriteLine($"Price: {Price}");
    }
}

// ITaxable Interface
interface ITaxable
{
    void CalculateTax();
    double GetTaxDetails();
}

// Electronics Class
class Electronics : Product, ITaxable
{
    private double disc;
    private double tax;

    // Constructor
    public Electronics(int productId, string name, double price)
        : base(productId, name, price) { }

    // Calculate Discount (10% discount)
    public override void CalculateDiscount()
    {
        disc = 0.10 * Price;
    }

    // Calculate Tax (5% tax)
    public void CalculateTax()
    {
        tax = 0.05 * Price;
    }

    public double GetTaxDetails()
    {
        return tax;
    }

    // Override Display Method
    public override void Display()
    {
        CalculateDiscount();
        CalculateTax();
        finalPrice = Price + tax - disc;
        base.Display();
        Console.WriteLine($"Tax: {tax}");
        Console.WriteLine($"Discount: {disc}");
        Console.WriteLine($"Final Price: {finalPrice}");
    }
}

// Clothing Class
class Clothing : Product, ITaxable
{
    private double disc;
    private double tax;

    // Constructor
    public Clothing(int productId, string name, double price)
        : base(productId, name, price) { }

    // Calculate Discount (20% discount)
    public override void CalculateDiscount()
    {
        disc = 0.20 * Price;
    }

    // Calculate Tax (2% tax)
    public void CalculateTax()
    {
        tax = 0.02 * Price;
    }

    public double GetTaxDetails()
    {
        return tax;
    }

    // Override Display Method
    public override void Display()
    {
        CalculateDiscount();
        CalculateTax();
        finalPrice = Price + tax - disc;
        base.Display();
        Console.WriteLine($"Tax: {tax}");
        Console.WriteLine($"Discount: {disc}");
        Console.WriteLine($"Final Price: {finalPrice}");
    }
}

// Groceries Class
class Groceries : Product, ITaxable
{
    private double disc;
    private double tax;

    // Constructor
    public Groceries(int productId, string name, double price)
        : base(productId, name, price) { }

    // Calculate Discount (5% discount)
    public override void CalculateDiscount()
    {
        disc = 0.05 * Price;
    }

    // Calculate Tax (1% tax)
    public void CalculateTax()
    {
        tax = 0.01 * Price;
    }

    public double GetTaxDetails()
    {
        return tax;
    }

    // Override Display Method
    public override void Display()
    {
        CalculateDiscount();
        CalculateTax();
        finalPrice = Price + tax - disc;
        base.Display();
        Console.WriteLine($"Tax: {tax}");
        Console.WriteLine($"Discount: {disc}");
        Console.WriteLine($"Final Price: {finalPrice}");
    }
}

// Main Program
class Program
{
    public static void Main()
    {
        // Creating Products
        Electronics electronics = new Electronics(11, "Laptop", 40000);
        Clothing clothing = new Clothing(12, "T-Shirt", 2000);
        Groceries groceries = new Groceries(13, "Milk", 50);

        // Displaying Product Details
        Console.WriteLine("=== Electronics ===");
        electronics.Display();
        Console.WriteLine();

        Console.WriteLine("=== Clothing ===");
        clothing.Display();
        Console.WriteLine();

        Console.WriteLine("=== Groceries ===");
        groceries.Display();
    }
}




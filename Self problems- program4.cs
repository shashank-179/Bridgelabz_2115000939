/*Problem 4: E-commerce Platform with Orders, Customers, and Products
Description: Design an e-commerce platform with Order, Customer, and Product classes. Model relationships where a Customer places an Order, and each Order contains multiple Product objects.
Goal: Show communication and object relationships by designing a system where customers communicate through orders, and orders aggregate products.
*/

using System;
using System.Collections.Generic;
// Product class represents an individual product
class Product
{
    string name;
    int prodId;

    // Constructor to initialize product details
    public Product(string name, int prodId)
    {
        this.name = name;
        this.prodId = prodId;
    }
    // Display product details
    public void display()
    {
        Console.WriteLine($"Product name: {name}, Product ID: {prodId}");
    }
}
// Order class represents an order containing multiple products
class Order
{
    public int orderNumber;
    List<Product> products;

    // Constructor to initialize order details
    public Order(int orderNumber)
    {
        this.orderNumber = orderNumber;
        products = new List<Product>(); // Initializing product list
    }

    // Add a product to the order
    public void addProd(Product product)
    {
        products.Add(product);
    }

    // Display order details along with its products
    public void display()
    {
        Console.WriteLine($"Order Number: {orderNumber}");
        foreach (var product in products)
        {
            product.display();
        }
    }
}

// Customer class represents a customer who places multiple orders
class Customer
{
    public string name;
    List<Order> orders;

    // Constructor to initialize customer details
    public Customer(string name)
    {
        this.name = name;
        orders = new List<Order>(); // Initializing order list
    }

    // Add an order to the customer's order list
    public void addOrder(Order order)
    {
        orders.Add(order);
    }

    // Display customer details along with their orders
    public void display()
    {
        Console.WriteLine($"Customer name: {name}");
        foreach (var order in orders)
        {
            order.display();
        }
    }

    public static void Main()
    {
        // Creating products
        Product p1 = new Product("Apple", 123);
        Product p2 = new Product("Soap", 223);
        Product p3 = new Product("Oil", 3);

        // Creating orders
        Order o1 = new Order(1);
        Order o2 = new Order(2);

        // Creating customer
        Customer c1 = new Customer("Sudhanshu");

        // Adding products to orders
        o1.addProd(p1);
        o1.addProd(p2);
        o2.addProd(p3);

        // Adding orders to customer
        c1.addOrder(o1);
        c1.addOrder(o2);

        // Displaying customer orders
        c1.display();
    }
}


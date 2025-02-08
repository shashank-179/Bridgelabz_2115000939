/*Online Retail Order Management
Description: Create a multilevel hierarchy to manage orders, where Order is the base class, ShippedOrder is a subclass, and DeliveredOrder extends ShippedOrder.
Tasks:
Define a base class Order with common attributes like orderId and OrderDate.
Create a subclass ShippedOrder with additional attributes like TrackingNumber.
Create another subclass DeliveredOrder extending ShippedOrder, adding a DeliveryDate attribute.
Implement a method GetOrderStatus() to return the current order status based on the class level.
Goal: Explore multilevel inheritance, showing how attributes and methods can be added across a chain of classes.
*/

using System;

// Base class: Order
class Order
{
    int orderId;
    string OrderDate;

    // Constructor to initialize order details
    public Order(int orderId, string OrderDate)
    {
        this.orderId = orderId;
        this.OrderDate = OrderDate; 
    }

    // Method to display order status
    public void GetOrderStatus()
    {
        Console.WriteLine("Order placed");
        Console.WriteLine($"Order ID: {orderId}\nOrder Date: {OrderDate}");
    }
}

// Subclass: ShippedOrder (Inherits from Order)
class ShippedOrder : Order
{
    int TrackingNumber;

    // Constructor to initialize shipped order details
    public ShippedOrder(int orderId, string OrderDate, int TrackingNumber) 
        : base(orderId, OrderDate)  // Calls base class constructor
    {
        this.TrackingNumber = TrackingNumber;
    }

    // Method to display shipped order status
    public void GetOrderStatus()
    {   
        base.GetOrderStatus(); // Calls base class method
        Console.WriteLine("Order Shipped");
        Console.WriteLine($"Tracking Number: {TrackingNumber}");
    }
}

// Subclass: DeliveredOrder (Inherits from ShippedOrder)
class DeliveredOrder : ShippedOrder
{
    string DeliveryDate;

    // Constructor to initialize delivered order details
    public DeliveredOrder(int orderId, string OrderDate, int TrackingNumber, string DeliveryDate) 
        : base(orderId, OrderDate, TrackingNumber)  // Calls base class constructor
    {
        this.DeliveryDate = DeliveryDate;
    }

    // Method to display delivered order status
    public void GetOrderStatus()
    {
        base.GetOrderStatus(); // Calls base class method
        Console.WriteLine("Order delivered");
        Console.WriteLine($"Delivery Date: {DeliveryDate}");
    }
}

// Main class
class Program
{
    public static void Main()
    {
        // Creating an Order object and displaying its status
        Order order = new Order(12, "12.12.24");
        order.GetOrderStatus();
        Console.WriteLine();

        // Creating a ShippedOrder object and displaying its status
        ShippedOrder shipped = new ShippedOrder(12, "12.12.24", 211);
        shipped.GetOrderStatus();
        Console.WriteLine();

        // Creating a DeliveredOrder object and displaying its status
        DeliveredOrder delivered = new DeliveredOrder(12, "12.12.24", 211, "20.12.24");
        delivered.GetOrderStatus();
    }
}


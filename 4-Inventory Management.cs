/*Problem Statement: Design an inventory management system using a singly linked list where each node stores information about an item such as Item Name, Item ID, Quantity, and Price. Implement the following functionalities:
Add an item at the beginning, end, or at a specific position.
Remove an item based on Item ID.
Update the quantity of an item by Item ID.
Search for an item based on Item ID or Item Name.
Calculate and display the total value of inventory (Sum of Price * Quantity for each item).
Sort the inventory based on Item Name or Price in ascending or descending order.

*/
using System;


public class ItemNode
{
    public string ItemName;
    public int ItemID;
    public int Quantity;
    public double Price;
    public ItemNode Next;


    public ItemNode(string itemName, int itemID, int quantity, double price)
    {
        ItemName = itemName;
        ItemID = itemID;
        Quantity = quantity;
        Price = price;
        Next = null;
    }
}


public class InventoryList
{
    private ItemNode head;


    // Add an item at the beginning
    public void AddAtBeginning(string itemName, int itemID, int quantity, double price)
    {
        ItemNode newItem = new ItemNode(itemName, itemID, quantity, price);
        newItem.Next = head;
        head = newItem;
    }


    // Add an item at the end
    public void AddAtEnd(string itemName, int itemID, int quantity, double price)
    {
        ItemNode newItem = new ItemNode(itemName, itemID, quantity, price);
        if (head == null)
        {
            head = newItem;
        }
        else
        {
            ItemNode current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newItem;
        }
    }


    // Remove an item by Item ID
    public void RemoveItemByID(int itemID)
    {
        if (head == null) return;


        if (head.ItemID == itemID)
        {
            head = head.Next;
            Console.WriteLine("Item with ID " + itemID + " has been deleted.");
            return;
        }


        ItemNode current = head;
        while (current.Next != null && current.Next.ItemID != itemID)
        {
            current = current.Next;
        }


        if (current.Next == null)
        {
            Console.WriteLine("Item with ID " + itemID + " not found.");
        }
        else
        {
            current.Next = current.Next.Next;
            Console.WriteLine("Item with ID " + itemID + " has been deleted.");
        }
    }


    // Update item quantity by Item ID
    public void UpdateQuantity(int itemID, int newQuantity)
    {
        ItemNode current = head;
        while (current != null)
        {
            if (current.ItemID == itemID)
            {
                current.Quantity = newQuantity;
                Console.WriteLine("Quantity of item with ID " + itemID + " updated to " + newQuantity);
                return;
            }
            current = current.Next;
        }
        Console.WriteLine("Item with ID " + itemID + " not found.");
    }


    // Calculate total value of inventory
    public void CalculateTotalValue()
    {
        double totalValue = 0;
        ItemNode current = head;
        while (current != null)
        {
            totalValue += current.Quantity * current.Price;
            current = current.Next;
        }
        Console.WriteLine("Total value of inventory: $" + totalValue);
    }


    // Display all inventory items
    public void DisplayInventory()
    {
        ItemNode current = head;
        while (current != null)
        {
            Console.WriteLine("Item: " + current.ItemName + ", ID: " + current.ItemID + ", Quantity: " + current.Quantity + ", Price: $" + current.Price);
            current = current.Next;
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        InventoryList inventory = new InventoryList();
        inventory.AddAtBeginning("Laptop", 101, 50, 1000);
        inventory.AddAtEnd("Smartphone", 102, 30, 600);
        inventory.AddAtEnd("Headphones", 103, 100, 50);
       
        Console.WriteLine("Inventory List:");
        inventory.DisplayInventory();


        inventory.UpdateQuantity(102, 40);


        inventory.CalculateTotalValue();


        inventory.RemoveItemByID(103);


        Console.WriteLine("\nUpdated Inventory:");
        inventory.DisplayInventory();
    }
}



/*Smart Warehouse Management System
Concepts: Generic Classes, Constraints, Variance
Problem Statement: Develop a warehouse system that manages different types of items (Electronics, Groceries, Furniture).
Hints: 
Create an abstract class WarehouseItem that all items extend (Electronics, Groceries, Furniture).
Implement a generic class Storage<T> where T : WarehouseItem to store items safely.
Implement a method to display all items using List<T>.
*/


using System;
using System.Collections.Generic;

abstract class ProductCategory
{
    public string CategoryName { get; set; }
}

class BookCategory : ProductCategory
{
    public BookCategory()
    {
        CategoryName = "Books";
    }
}

class ClothingCategory : ProductCategory
{
    public ClothingCategory()
    {
        CategoryName = "Clothing";
    }
}

class Product<T> where T : ProductCategory
{
    public string Name { get; set; }
    public double Price { get; set; }
    public T Category { get; set; }


    public Product(string name, double price, T category)
    {
        this.Name = name;
        this.Price = price;
        this.Category = category;
    }
    public void DisplayInfo()
    {
        Console.WriteLine($"[Category: {Category.CategoryName}] Name: {Name}, Price: ${Price}");
    }
}

class Discount
{
    public static void ApplyDiscount<T>(Product<T> product, double percentage) where T : ProductCategory
    {
        product.Price -= product.Price * (percentage / 100);
        Console.WriteLine($"Discount applied! New price of {product.Name}: ${product.Price:F2}");
    }
}


class Program
{
    public static void Main( string[] args)
    {
        Product<BookCategory> book = new Product<BookCategory>("C# Programming", 500, new BookCategory());
        book.DisplayInfo();

        Product<ClothingCategory> cloth = new Product<ClothingCategory>("Shirt", 800, new ClothingCategory());
        cloth.DisplayInfo();

        Console.WriteLine("Applying Discount....");

        Discount.ApplyDiscount(book, 10);
        Discount.ApplyDiscount(cloth, 17);

    }
}



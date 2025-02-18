/*Dynamic Online Marketplace
Concepts: Type Parameters, Generic Methods, Constraints
Problem Statement: Build a generic product catalog for an online marketplace supporting various product types.
Hints: 
Define a generic class Product<T> where T is restricted to a category (BookCategory, ClothingCategory).
Implement a generic method void ApplyDiscount<T>(T product, double percentage) where T : Product.
Ensure type safety while allowing multiple product categories in the catalog.
*/


using System;


// Abstract class for product categories
abstract class ProductCategory { }


class BookCategory : ProductCategory { }
class ClothingCategory : ProductCategory { }


// Base class for product
abstract class ProductBase
{
    public string Name { get; set; }
    public double Price { get; set; }
}


// Generic Product class inheriting from ProductBase
class Product<T> : ProductBase where T : ProductCategory
{
}


// Marketplace with a generic discount method
static class Marketplace
{
    public static void ApplyDiscount<T>(T product, double percentage) where T : ProductBase
    {
        product.Price -= product.Price * (percentage / 100);
        Console.WriteLine($"{product.Name} discounted price: ${product.Price}");
    }
}


// Main execution
class Program
{
    static void Main()
    {
        Product<BookCategory> book = new Product<BookCategory> { Name = "C# Fundamentals", Price = 50 };
        Product<ClothingCategory> shirt = new Product<ClothingCategory> { Name = "T-Shirt", Price = 20 };


        Marketplace.ApplyDiscount(book, 10);
        Marketplace.ApplyDiscount(shirt, 5);
    }
}



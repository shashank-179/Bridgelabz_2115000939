/*Personalized Meal Plan Generator
Concepts: Generic Methods, Constraints, Interfaces
Problem Statement: Design a system where users can choose different meal categories like Vegetarian, Vegan, Keto, or High-Protein.
Hints: 
Define an interface IMealPlan with subtypes (VegetarianMeal, VeganMeal).
Implement a generic class Meal<T> where T : IMealPlan.
Use a generic method to validate and generate meal plans dynamically.
*/

using System;


// Interface for meal plans
interface IMealPlan
{
    string GetMealType();
}


class VegetarianMeal : IMealPlan
{
    public string GetMealType() => "Vegetarian Meal";
}


class VeganMeal : IMealPlan
{
    public string GetMealType() => "Vegan Meal";
}


// Generic Meal class
class Meal<T> where T : IMealPlan, new()
{
    public string Name { get; set; }
    public T MealType { get; set; } = new T();
}


// Meal planner with a generic method
static class MealPlanner
{
    public static void GenerateMealPlan<T>(T meal) where T : IMealPlan
    {
        Console.WriteLine($"Meal Plan Generated: {meal.GetMealType()}");
    }
}


// Main execution
class Program
{
    static void Main()
    {
        Meal<VegetarianMeal> vegMeal = new Meal<VegetarianMeal> { Name = "Salad & Rice" };
        Meal<VeganMeal> veganMeal = new Meal<VeganMeal> { Name = "Tofu Stir Fry" };


        MealPlanner.GenerateMealPlan(vegMeal.MealType);
        MealPlanner.GenerateMealPlan(veganMeal.MealType);
    }
}



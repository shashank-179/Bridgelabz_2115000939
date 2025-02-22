/*1. Basic NUnit Test: Testing a Calculator Class
Problem:
Create a Calculator class with methods:
Add(int a, int b)
Subtract(int a, int b)
Multiply(int a, int b)
Divide(int a, int b)
Write NUnit or MSTest test cases for each method.
👉 Bonus: Test for division by zero and handle exceptions properly.
*/

using System;

public class Calculator
{
    public int Add(int a, int b) => a + b;

    public int Subtract(int a, int b) => a - b;

    public int Multiply(int a, int b) => a * b;

    public int Divide(int a, int b)
    {
        if (b == 0)
            throw new DivideByZeroException("Cannot divide by zero.");
        return a / b;
    }
}
// Test Cases
using NUnit.Framework;
using System;

[TestFixture]
public class CalculatorTests
{
    private Calculator _calculator;

    [SetUp]
    public void Setup()
    {
        _calculator = new Calculator();
    }

    [Test]
    public void Add_TwoNumbers_ReturnsSum()
    {
        Assert.AreEqual(10, _calculator.Add(6, 4));
    }

    [Test]
    public void Subtract_TwoNumbers_ReturnsDifference()
    {
        Assert.AreEqual(2, _calculator.Subtract(6, 4));
    }

    [Test]
    public void Multiply_TwoNumbers_ReturnsProduct()
    {
        Assert.AreEqual(24, _calculator.Multiply(6, 4));
    }

    [Test]
    public void Divide_TwoNumbers_ReturnsQuotient()
    {
        Assert.AreEqual(2, _calculator.Divide(8, 4));
    }

    [Test]
    public void Divide_ByZero_ThrowsException()
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(8, 0));
    }
}


/*4. Testing Exception Handling
Problem:
Create a method Divide(int a, int b) that throws an ArithmeticException if b is zero. Write a unit test to verify that the exception is thrown properly.
*/

using System;

public class MathOperations
{
    public int Divide(int a, int b)
    {
        if (b == 0)
            throw new ArithmeticException("Cannot divide by zero.");
        return a / b;
    }
}
//Test Cases
using NUnit.Framework;
using System;

[TestFixture]
public class MathOperationsTests
{
    private MathOperations _mathOperations;

    [SetUp]
    public void Setup()
    {
        _mathOperations = new MathOperations();
    }

    [Test]
    public void Divide_ByZero_ThrowsArithmeticException()
    {
        Assert.Throws<ArithmeticException>(() => _mathOperations.Divide(10, 0));
    }

    [Test]
    public void Divide_ValidNumbers_ReturnsQuotient()
    {
        Assert.AreEqual(5, _mathOperations.Divide(10, 2));
    }
}


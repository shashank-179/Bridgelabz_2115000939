/*6. Testing Parameterized Tests
Problem:
Create a method IsEven(int number) that returns true if a number is even.
Use NUnit [TestCase] or MSTest [DataRow] to test this method with multiple values like 2, 4, 6, 7, 9.
*/

public class NumberUtils
{
    public bool IsEven(int number)
    {
        return number % 2 == 0;
    }
}
//Test Cases
using NUnit.Framework;

[TestFixture]
public class NumberUtilsTests
{
    private NumberUtils _numberUtils;

    [SetUp]
    public void Setup()
    {
        _numberUtils = new NumberUtils();
    }

    [TestCase(2, ExpectedResult = true)]
    [TestCase(4, ExpectedResult = true)]
    [TestCase(6, ExpectedResult = true)]
    [TestCase(7, ExpectedResult = false)]
    [TestCase(9, ExpectedResult = false)]
    public bool IsEven_ReturnsCorrectResult(int number)
    {
        return _numberUtils.IsEven(number);
    }
}


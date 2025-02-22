/*4. Testing Date Formatter
Problem:
Create a DateFormatter class with:
FormatDate(string inputDate): Converts yyyy-MM-dd format to dd-MM-yyyy.
✅ Write unit test cases for valid and invalid dates.
*/
using System;
using System.Globalization;

public class DateFormatter
{
    public string FormatDate(string inputDate)
    {
        if (string.IsNullOrWhiteSpace(inputDate))
            throw new ArgumentException("Input date cannot be null or empty.");

        if (DateTime.TryParseExact(inputDate, "yyyy-MM-dd",
                                   CultureInfo.InvariantCulture,
                                   DateTimeStyles.None,
                                   out DateTime parsedDate))
        {
            return parsedDate.ToString("dd-MM-yyyy");
        }
        else
        {
            throw new FormatException("Invalid date format. Expected format: yyyy-MM-dd");
        }
    }
}
//Test Cases
using NUnit.Framework;
using System;

[TestFixture]
public class DateFormatterTests
{
    private DateFormatter _formatter;

    [SetUp]
    public void Setup()
    {
        _formatter = new DateFormatter();
    }

    [Test]
    public void FormatDate_ValidDate_ShouldReturnFormattedDate()
    {
        string result = _formatter.FormatDate("2025-02-22");
        Assert.AreEqual("22-02-2025", result);
    }

    [Test]
    public void FormatDate_AnotherValidDate_ShouldReturnFormattedDate()
    {
        string result = _formatter.FormatDate("2000-12-31");
        Assert.AreEqual("31-12-2000", result);
    }

    [Test]
    public void FormatDate_InvalidFormat_ShouldThrowFormatException()
    {
        Assert.Throws<FormatException>(() => _formatter.FormatDate("22-02-2025"));
    }

    [Test]
    public void FormatDate_EmptyString_ShouldThrowArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _formatter.FormatDate(""));
    }

    [Test]
    public void FormatDate_NullInput_ShouldThrowArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _formatter.FormatDate(null));
    }

    [Test]
    public void FormatDate_InvalidDate_ShouldThrowFormatException()
    {
        Assert.Throws<FormatException>(() => _formatter.FormatDate("2025-13-40"));
    }
}


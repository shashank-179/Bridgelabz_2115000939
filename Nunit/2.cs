/*2. Testing String Utility Methods
Problem:
Create a StringUtils class with the following methods:
Reverse(string str): Returns the reverse of a given string.
IsPalindrome(string str): Returns true if the string is a palindrome.
ToUpperCase(string str): Converts a string to uppercase.
Write NUnit or MSTest test cases to verify that these methods work correctly.
*/

using System;

public class StringUtils
{
    // Reverses a string
    public string Reverse(string str)
    {
        if (string.IsNullOrEmpty(str)) return str;
        char[] charArray = str.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    // Checks if a string is a palindrome
    public bool IsPalindrome(string str)
    {
        if (string.IsNullOrEmpty(str)) return false;
        string reversed = Reverse(str);
        return string.Equals(str, reversed, StringComparison.OrdinalIgnoreCase);
    }

    // Converts a string to uppercase
    public string ToUpperCase(string str)
    {
        return str?.ToUpper();
    }
}
//Test Cases
using NUnit.Framework;

[TestFixture]
public class StringUtilsTests
{
    private StringUtils _stringUtils;

    [SetUp]
    public void Setup()
    {
        _stringUtils = new StringUtils();
    }

    [Test]
    public void Reverse_String_ReturnsReversedString()
    {
        Assert.AreEqual("olleh", _stringUtils.Reverse("hello"));
        Assert.AreEqual("racecar", _stringUtils.Reverse("racecar"));
        Assert.AreEqual("", _stringUtils.Reverse(""));
    }

    [Test]
    public void IsPalindrome_PalindromeString_ReturnsTrue()
    {
        Assert.IsTrue(_stringUtils.IsPalindrome("madam"));
        Assert.IsTrue(_stringUtils.IsPalindrome("Racecar"));
    }

    [Test]
    public void IsPalindrome_NonPalindromeString_ReturnsFalse()
    {
        Assert.IsFalse(_stringUtils.IsPalindrome("hello"));
    }

    [Test]
    public void ToUpperCase_String_ReturnsUppercaseString()
    {
        Assert.AreEqual("HELLO", _stringUtils.ToUpperCase("hello"));
        Assert.AreEqual("WORLD", _stringUtils.ToUpperCase("world"));
    }

    [Test]
    public void ToUpperCase_EmptyOrNullString_ReturnsSame()
    {
        Assert.AreEqual("", _stringUtils.ToUpperCase(""));
        Assert.IsNull(_stringUtils.ToUpperCase(null));
    }
}


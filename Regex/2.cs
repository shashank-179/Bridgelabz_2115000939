/*2. Testing Password Strength Validator
Problem:
Create a PasswordValidator class with:
Passwords must have at least 8 characters, one uppercase letter, and one digit.
✅ Write unit tests for valid and invalid passwords.
*/
using System;
using System.Text.RegularExpressions;

public class PasswordValidator
{
    public bool IsValid(string password)
    {
        if (string.IsNullOrEmpty(password))
            return false;

        return password.Length >= 8 &&
               Regex.IsMatch(password, @"[A-Z]") && // At least one uppercase letter
               Regex.IsMatch(password, @"\d");     // At least one digit
    }
}
//Test Cases
using NUnit.Framework;

[TestFixture]
public class PasswordValidatorTests
{
    private PasswordValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new PasswordValidator();
    }

    [Test]
    public void ValidPassword_ShouldReturnTrue()
    {
        Assert.IsTrue(_validator.IsValid("Secure123"));
    }

    [Test]
    public void ShortPassword_ShouldReturnFalse()
    {
        Assert.IsFalse(_validator.IsValid("S1abc"));
    }

    [Test]
    public void NoUppercaseLetter_ShouldReturnFalse()
    {
        Assert.IsFalse(_validator.IsValid("secure123"));
    }

    [Test]
    public void NoDigit_ShouldReturnFalse()
    {
        Assert.IsFalse(_validator.IsValid("SecurePass"));
    }

    [Test]
    public void EmptyPassword_ShouldReturnFalse()
    {
        Assert.IsFalse(_validator.IsValid(""));
    }

    [Test]
    public void NullPassword_ShouldReturnFalse()
    {
        Assert.IsFalse(_validator.IsValid(null));
    }
}


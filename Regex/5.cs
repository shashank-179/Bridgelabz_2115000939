/*5. Testing User Registration
Problem:
Create a UserRegistration class with:
RegisterUser(string username, string email, string password).
Throws ArgumentException for invalid inputs.
✅ Write unit tests to verify valid and invalid user registrations.
*/
using System;
using System.Text.RegularExpressions;

public class UserRegistration
{
    public void RegisterUser(string username, string email, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || username.Length < 5)
            throw new ArgumentException("Username must be at least 5 characters long.");

        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new ArgumentException("Invalid email format.");

        if (password.Length < 8 ||
            !Regex.IsMatch(password, @"[A-Z]") ||
            !Regex.IsMatch(password, @"\d"))
        {
            throw new ArgumentException("Password must be at least 8 characters long, contain one uppercase letter and one digit.");
        }
    }
}
//Test Cases
using NUnit.Framework;
using System;

[TestFixture]
public class UserRegistrationTests
{
    private UserRegistration _registration;

    [SetUp]
    public void Setup()
    {
        _registration = new UserRegistration();
    }

    [Test]
    public void RegisterUser_ValidInputs_ShouldNotThrowException()
    {
        Assert.DoesNotThrow(() => _registration.RegisterUser("ValidUser", "test@example.com", "Secure123"));
    }

    [Test]
    public void RegisterUser_ShortUsername_ShouldThrowArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _registration.RegisterUser("usr", "test@example.com", "Secure123"));
    }

    [Test]
    public void RegisterUser_InvalidEmail_ShouldThrowArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _registration.RegisterUser("ValidUser", "invalid-email", "Secure123"));
    }

    [Test]
    public void RegisterUser_ShortPassword_ShouldThrowArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _registration.RegisterUser("ValidUser", "test@example.com", "Pass1"));
    }

    [Test]
    public void RegisterUser_PasswordWithoutUppercase_ShouldThrowArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _registration.RegisterUser("ValidUser", "test@example.com", "password1"));
    }

    [Test]
    public void RegisterUser_PasswordWithoutDigit_ShouldThrowArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _registration.RegisterUser("ValidUser", "test@example.com", "Password"));
    }

    [Test]
    public void RegisterUser_EmptyUsername_ShouldThrowArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _registration.RegisterUser("", "test@example.com", "Secure123"));
    }

    [Test]
    public void RegisterUser_EmptyEmail_ShouldThrowArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _registration.RegisterUser("ValidUser", "", "Secure123"));
    }

    [Test]
    public void RegisterUser_EmptyPassword_ShouldThrowArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _registration.RegisterUser("ValidUser", "test@example.com", ""));
    }
}


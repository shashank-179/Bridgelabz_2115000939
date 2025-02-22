/*1. Testing Banking Transactions
Problem:
Create a BankAccount class with:
Deposit(double amount): Adds money to the balance.
Withdraw(double amount): Reduces balance.
GetBalance(): Returns the current balance.
✅ Write unit tests to check correct balance updates.
✅ Ensure withdrawals fail if funds are insufficient.
*/

using System;

public class BankAccount
{
    private double _balance;

    public BankAccount()
    {
        _balance = 0;
    }

    public void Deposit(double amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be positive.");

        _balance += amount;
    }

    public void Withdraw(double amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdrawal amount must be positive.");

        if (amount > _balance)
            throw new InvalidOperationException("Insufficient funds.");

        _balance -= amount;
    }

    public double GetBalance()
    {
        return _balance;
    }
}
//Test Cases
using NUnit.Framework;
using System;

[TestFixture]
public class BankAccountTests
{
    private BankAccount _account;

    [SetUp]
    public void Setup()
    {
        _account = new BankAccount();
    }

    [Test]
    public void Deposit_ShouldIncreaseBalance()
    {
        _account.Deposit(100);
        Assert.AreEqual(100, _account.GetBalance());
    }

    [Test]
    public void Withdraw_ShouldDecreaseBalance()
    {
        _account.Deposit(200);
        _account.Withdraw(50);
        Assert.AreEqual(150, _account.GetBalance());
    }

    [Test]
    public void Withdraw_InsufficientFunds_ShouldThrowException()
    {
        _account.Deposit(50);
        Assert.Throws<InvalidOperationException>(() => _account.Withdraw(100));
    }

    [Test]
    public void Deposit_NegativeAmount_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => _account.Deposit(-50));
    }

    [Test]
    public void Withdraw_NegativeAmount_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => _account.Withdraw(-20));
    }
}


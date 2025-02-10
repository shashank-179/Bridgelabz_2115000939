/*4. Banking System
Description: Create a banking system with different account types:
Define an abstract class BankAccount with fields like accountNumber, holderName, and balance.
Add methods like Deposit(double amount), Withdraw(double amount), and an abstract method CalculateInterest().
Implement subclasses SavingsAccount and CurrentAccount with unique interest calculations.
Create an interface ILoanable with methods ApplyForLoan() and CalculateLoanEligibility().
Use encapsulation to secure account details and restrict unauthorized access.
Demonstrate polymorphism by processing different account types and calculating interest dynamically.
*/

using System;
using System.Collections.Generic;


// Abstract Class
public abstract class BankAccount
{
    public string AccountNumber { get; set; }
    public string HolderName { get; set; }
    public double Balance { get; set; }


    public void Deposit(double amount)
    {
        Balance += amount;
    }


    public void Withdraw(double amount)
    {
        if (Balance >= amount)
            Balance -= amount;
    }


    public abstract double CalculateInterest();
}


// Subclasses
public class SavingsAccount : BankAccount
{
    public override double CalculateInterest()
    {
        return Balance * 0.04;  // 4% interest
    }
}


public class CurrentAccount : BankAccount
{
    public override double CalculateInterest()
    {
        return Balance * 0.02;  // 2% interest
    }
}


// Interface
public interface ILoanable
{
    void ApplyForLoan(double amount);
    bool CalculateLoanEligibility();
}


// Main Program
public class Program
{
    public static void Main()
    {
        List<BankAccount> accounts = new List<BankAccount>
        {
            new SavingsAccount { AccountNumber = "SA123", HolderName = "Ram", Balance = 5000 },
            new CurrentAccount { AccountNumber = "CA123", HolderName = "Shyam", Balance = 10000 }
        };


        foreach (var account in accounts)
        {
            double interest = account.CalculateInterest();
            Console.WriteLine("Account: " + account.HolderName + ", Interest: " + interest);
        }
    }
}



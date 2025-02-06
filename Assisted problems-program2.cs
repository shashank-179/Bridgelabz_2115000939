/*Problem 2: Bank and Account Holders (Association)
Description: Model a relationship where a Bank has Customer objects associated with it. A Customer can have multiple bank accounts, and each account is linked to a Bank.
Tasks:
Define a Bank class and a Customer class.
Use an association relationship to show that each Customer has an account in a Bank.
Implement methods that enable communication, such as OpenAccount() in the Bank class and ViewBalance() in the Customer class.
Goal: Illustrate association by setting up a relationship between customers and the bank.
*/
using System;
using System.Collections.Generic;

// Bank Class
class Bank
{
    public string Name { get; private set; }
    private List<Customer> customers; // List to store customers

    public Bank(string name)
    {
        Name = name;
        customers = new List<Customer>();
    }

    // Method to open an account for a customer
    public void OpenAccount(Customer customer, string accountNumber, double initialDeposit)
    {
        BankAccount account = new BankAccount(accountNumber, initialDeposit, this);
        customer.AddAccount(account);

        if (!customers.Contains(customer))
        {
            customers.Add(customer);
        }

        Console.WriteLine($"Account {accountNumber} opened for {customer.Name} at {Name}");
    }
}

// Customer Class
class Customer
{
    public string Name { get; private set; }
    private List<BankAccount> accounts; // A customer can have multiple accounts

    public Customer(string name)
    {
        Name = name;
        accounts = new List<BankAccount>();
    }

    public void AddAccount(BankAccount account)
    {
        accounts.Add(account);
    }

    // Method to view all account balances
    public void ViewBalance()
    {
        Console.WriteLine($"Balances for {Name}:");
        foreach (var account in accounts)
        {
            Console.WriteLine($"Account {account.AccountNumber}: ${account.Balance}");
        }
    }
}

// BankAccount Class
class BankAccount
{
    public string AccountNumber { get; private set; }
    public double Balance { get; private set; }
    private Bank bank; // Each account is linked to a Bank

    public BankAccount(string accountNumber, double initialDeposit, Bank bank)
    {
        AccountNumber = accountNumber;
        Balance = initialDeposit;
        this.bank = bank;
    }

    // Method to deposit money
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"Deposited ${amount} into Account {AccountNumber}. New Balance: ${Balance}");
        }
        else
        {
            Console.WriteLine("Invalid deposit amount.");
        }
    }

    // Method to withdraw money
    public void Withdraw(double amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrawn ${amount} from Account {AccountNumber}. New Balance: ${Balance}");
        }
        else
        {
            Console.WriteLine("Invalid withdrawal amount or insufficient funds.");
        }
    }
}

// Main Program
class Program
{
    static void Main()
    {
        Bank bank = new Bank("XYZ Bank");

        // Creating Customers
        Customer customer1 = new Customer("Alice");
        Customer customer2 = new Customer("Bob");

        // Opening Accounts
        bank.OpenAccount(customer1, "A123", 1000);
        bank.OpenAccount(customer1, "A456", 500);
        bank.OpenAccount(customer2, "B789", 1500);

        // Viewing Balances
        customer1.ViewBalance();
        customer2.ViewBalance();
    }
}



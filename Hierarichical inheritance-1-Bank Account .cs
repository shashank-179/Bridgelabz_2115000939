/*Bank Account Types
Description: Model a banking system with different account types using hierarchical inheritance. BankAccount is the superclass, with SavingsAccount, CheckingAccount, and FixedDepositAccount as subclasses.
Tasks:
Define a base class BankAccount with attributes like AccountNumber and Balance.
Define subclasses SavingsAccount, CheckingAccount, and FixedDepositAccount, each with unique attributes like interestRate for SavingsAccount and WithdrawalLimit for CheckingAccount.
Implement a method DisplayAccountType() in each subclass to specify the account type.
Goal: Explore hierarchical inheritance, demonstrating how each subclass can have unique attributes while inheriting from a shared superclass.
*/

using System;

// Base class: BankAccount
class BankAccount
{
    int AccountNumber;
    double balance;

    // Constructor to initialize account details
    public BankAccount(int AccountNumber, double balance)
    {
        this.AccountNumber = AccountNumber;
        this.balance = balance;
    }

    // Method to display account details
    public void DisplayDetails()
    {
        Console.WriteLine($"Account Number: {AccountNumber}\nBalance: {balance}");
    }
}

// Subclass: SavingsAccount (Inherits from BankAccount)
class SavingsAccount : BankAccount
{
    double interestRate;

    // Constructor to initialize savings account details
    public SavingsAccount(int AccountNumber, double balance, double interestRate)
        : base(AccountNumber, balance) // Calls base class constructor
    {
        this.interestRate = interestRate;
    }

    // Method to display account type
    public void DisplayAccountType()
    {
        Console.WriteLine("Account Type: Savings Account");
    }

    // Method to display savings account details
    public void DisplayDetails()
    {
        base.DisplayDetails(); // Calls base class method
        Console.WriteLine($"Interest Rate: {interestRate}%");
    }
}

// Subclass: CheckingAccount (Inherits from BankAccount)
class CheckingAccount : BankAccount
{
    int withdrawalLimit;

    // Constructor to initialize checking account details
    public CheckingAccount(int AccountNumber, double balance, int withdrawalLimit)
        : base(AccountNumber, balance) // Calls base class constructor
    {
        this.withdrawalLimit = withdrawalLimit;
    }

    // Method to display account type
    public void DisplayAccountType()
    {
        Console.WriteLine("Account Type: Checking Account");
    }

    // Method to display checking account details
    public void DisplayDetails()
    {
        base.DisplayDetails(); // Calls base class method
        Console.WriteLine($"Withdrawal Limit: {withdrawalLimit}");
    }
}

// Subclass: FixedDepositAccount (Inherits from BankAccount)
class FixedDepositAccount : BankAccount
{
    int depositedAmount;

    // Constructor to initialize fixed deposit account details
    public FixedDepositAccount(int AccountNumber, double balance, int depositedAmount)
        : base(AccountNumber, balance) // Calls base class constructor
    {
        this.depositedAmount = depositedAmount;
    }

    // Method to display account type
    public void DisplayAccountType()
    {
        Console.WriteLine("Account Type: Fixed Deposit Account");
    }

    // Method to display fixed deposit account details
    public void DisplayDetails()
    {
        base.DisplayDetails(); // Calls base class method
        Console.WriteLine($"Deposited Amount: {depositedAmount}");
    }
}

// Main class
class Program
{
    public static void Main()
    {
        // Creating SavingsAccount object
        SavingsAccount savings = new SavingsAccount(7798409, 12000, 3);

        // Creating CheckingAccount object
        CheckingAccount checking = new CheckingAccount(77984, 12000, 50000);

        // Creating FixedDepositAccount object
        FixedDepositAccount fixedDeposit = new FixedDepositAccount(779409, 12000, 8000);

        // Displaying details of Savings Account
        savings.DisplayAccountType();
        savings.DisplayDetails();
        Console.WriteLine();

        // Displaying details of Checking Account
        checking.DisplayAccountType();
        checking.DisplayDetails();
        Console.WriteLine();

        // Displaying details of Fixed Deposit Account
        fixedDeposit.DisplayAccountType();
        fixedDeposit.DisplayDetails();
    }
}



/*10. Implementing a Bank Transaction System
💡 Problem Statement:
Develop a Bank Account System where:
Withdraw(double amount) method:
Throws InsufficientFundsException if withdrawal amount exceeds balance.
Throws ArgumentException if the amount is negative.
Handle exceptions in Main().
Expected Behavior:
If valid, print "Withdrawal successful, new balance: X".
If balance is insufficient, throw and handle "Insufficient balance!".
If the amount is negative, throw and handle "Invalid amount!".
*/

using System;

class InsufficientFundsException : Exception
{
    public InsufficientFundsException(string message) : base(message) { }
}

class BankAccount
{
    public double Balance { get; private set; }

    public BankAccount(double balance)
    {
        Balance = balance;
    }

    public void Withdraw(double amount)
    {
        if (amount < 0)
            throw new ArgumentException("Invalid amount!");

        if (amount > Balance)
            throw new InsufficientFundsException("Insufficient balance!");

        Balance -= amount;
        Console.WriteLine("Withdrawal successful, new balance: " + Balance);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            BankAccount account = new BankAccount(1000);

            Console.Write("Enter withdrawal amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            account.Withdraw(amount);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}




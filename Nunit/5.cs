/*5. Testing Setup and Teardown (NUnit: [SetUp] & [TearDown])
Problem:
Create a class DatabaseConnection with methods:
Connect()
Disconnect()
Use [SetUp] (NUnit) or [TestInitialize] (MSTest) to initialize a database connection before each test.
Use [TearDown] (NUnit) or [TestCleanup] (MSTest) to close the connection after each test.
Write test cases to verify that the connection is established and closed correctly.
*/

using System;

public class DatabaseConnection
{
    public bool IsConnected { get; private set; } = false;

    public void Connect()
    {
        if (IsConnected)
            throw new InvalidOperationException("Already connected to the database.");

        IsConnected = true;
        Console.WriteLine("Database connected.");
    }

    public void Disconnect()
    {
        if (!IsConnected)
            throw new InvalidOperationException("No active connection to disconnect.");

        IsConnected = false;
        Console.WriteLine("Database disconnected.");
    }
}
//Test Cases
using NUnit.Framework;
using System;

[TestFixture]
public class DatabaseConnectionTests
{
    private DatabaseConnection _dbConnection;

    [SetUp]
    public void Setup()
    {
        _dbConnection = new DatabaseConnection();
        _dbConnection.Connect();
    }

    [TearDown]
    public void Cleanup()
    {
        _dbConnection.Disconnect();
    }

    [Test]
    public void Connect_EstablishesConnection()
    {
        Assert.IsTrue(_dbConnection.IsConnected);
    }

    [Test]
    public void Disconnect_ClosesConnection()
    {
        _dbConnection.Disconnect();
        Assert.IsFalse(_dbConnection.IsConnected);
    }

    [Test]
    public void Connect_ThrowsException_IfAlreadyConnected()
    {
        Assert.Throws<InvalidOperationException>(() => _dbConnection.Connect());
    }

    [Test]
    public void Disconnect_ThrowsException_IfAlreadyDisconnected()
    {
        _dbConnection.Disconnect();
        Assert.Throws<InvalidOperationException>(() => _dbConnection.Disconnect());
    }
}


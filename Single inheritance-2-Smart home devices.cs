/*Smart Home Devices
Description: Create a hierarchy for a smart home system where Device is the superclass and Thermostat is a subclass.
Tasks:
Define a superclass Device with attributes like DeviceId and Status.
Create a subclass Thermostat with additional attributes like TemperatureSetting.
Implement a method DisplayStatus() to show each device's current settings.
Goal: Understand single inheritance by adding specific attributes to a subclass, keeping the superclass general.*/


using System;

// Superclass: Device
class Device
{
    public int DeviceId;
    public string Status;

    public Device(int deviceId, string status)
    {
        DeviceId = deviceId;
        Status = status;
    }

    public virtual void DisplayStatus()
    {
        Console.WriteLine($"Device ID: {DeviceId}\nStatus: {Status}");
    }
}

// Subclass: Thermostat
class Thermostat : Device
{
    public double TemperatureSetting;

    public Thermostat(int deviceId, string status, double temperatureSetting)
        : base(deviceId, status)
    {
        TemperatureSetting = temperatureSetting;
    }

    public override void DisplayStatus()
    {
        base.DisplayStatus();
        Console.WriteLine($"Temperature Setting: {TemperatureSetting}°C");
    }
}

// Main Class
class Program
{
    static void Main()
    {
        Thermostat thermostat = new Thermostat(101, "On", 22.5);
        thermostat.DisplayStatus();
    }
}


using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Property)]
class InjectAttribute : Attribute { }

class Service { public void DoWork() => Console.WriteLine("Service is working..."); }

class Client
{
    [Inject] public Service service { get; set; }
}

class Program
{
    static void Main()
    {
        Client client = new Client();
        foreach (var prop in typeof(Client).GetProperties())
        {
            if (prop.GetCustomAttribute<InjectAttribute>() != null)
                prop.SetValue(client, Activator.CreateInstance(prop.PropertyType));
        }
        client.service?.DoWork();
    }
}

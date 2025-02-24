using System;
using System.Reflection;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Messaging;

public interface IGreeting
{
    void SayHello();
}

public class Greeting : IGreeting
{
    public void SayHello() => Console.WriteLine("Hello, World!");
}

public class LoggingProxy<T> : RealProxy where T : class
{
    private readonly T _instance;

    public LoggingProxy(T instance) : base(typeof(T))
    {
        _instance = instance;
    }

    public override IMessage Invoke(IMessage msg)
    {
        var methodCall = (IMethodCallMessage)msg;
        Console.WriteLine($"Logging: Calling {methodCall.MethodName}");
        return new ReturnMessage(methodCall.MethodBase.Invoke(_instance, methodCall.Args), null, 0, methodCall.LogicalCallContext, methodCall);
    }
}

class Program
{
    static void Main()
    {
        IGreeting greeting = new LoggingProxy<IGreeting>(new Greeting()).GetTransparentProxy() as IGreeting;
        greeting.SayHello();
    }
}

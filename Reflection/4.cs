using System;
using System.Reflection;

class Student
{
    public string Name { get; set; }
    public Student() { Name = "Default Student"; }
}

class Program
{
    static void Main()
    {
        Type type = typeof(Student);
        object instance = Activator.CreateInstance(type);
        Console.WriteLine("Created Object: " + ((Student)instance).Name);
    }
}


/*Exercise 2: Use Obsolete Attribute to Mark an Old Method
Problem Statement: Create a class LegacyAPI with an old method OldFeature(), which should not be used anymore. Instead, introduce a new method NewFeature().
Steps to Follow:
Define a class LegacyAPI.
Mark OldFeature() as [Obsolete].
Call both methods and observe the warning.
*/
using System;
class LegacyAPI
{
    [Obsolete("OldFeature() is deprecated. Use NewFeature() instead.")]
    public void OldFeature()
    {
        Console.WriteLine("This is an old feature. It should not be used.");
    }

    public void NewFeature()
    {
        Console.WriteLine("This is the new and improved feature!");
    }
}

class Program
{
    static void Main()
    {
        LegacyAPI api = new LegacyAPI();

        api.OldFeature();  // This will show a warning
        api.NewFeature();  // This is the recommended method
     }
}


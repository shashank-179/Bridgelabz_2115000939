/*7️⃣ Implement a Custom Caching System with CacheResult
Problem Statement: Define CacheResult to store method return values and avoid repeated execution.
Requirements:
Apply CacheResult to a computationally expensive method.
Implement a cache (Dictionary) to store previously computed results.
If a method is called with the same input, return the cached result instead of recomputation.
*/
using System;
using System.Collections.Generic;
using System.Reflection;

// Step 1: Define a CacheResult attribute
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
class CacheResultAttribute : Attribute { }

// Step 2: Create a caching mechanism using a dictionary
class MethodCache
{
    private static Dictionary<string, object> cache = new Dictionary<string, object>();

    public static object ExecuteWithCaching(object obj, string methodName, params object[] parameters)
    {
        MethodInfo method = obj.GetType().GetMethod(methodName);
        
        if (method == null)
            throw new Exception("Method not found.");

        if (method.GetCustomAttribute(typeof(CacheResultAttribute)) == null)
            return method.Invoke(obj, parameters);

        // Generate a unique cache key based on method name & parameters
        string cacheKey = methodName + "(" + string.Join(",", parameters) + ")";

        if (cache.ContainsKey(cacheKey))
        {
            Console.WriteLine($"Returning cached result for {cacheKey}");
            return cache[cacheKey];
        }

        // Compute the result and store it in cache
        object result = method.Invoke(obj, parameters);
        cache[cacheKey] = result;
        return result;
    }
}

// Step 3: Apply the attribute to an expensive method
class Computation
{
    [CacheResult]
    public long Factorial(int n)
    {
        Console.WriteLine($"Computing Factorial({n})...");
        if (n == 0 || n == 1)
            return 1;
        return n * Factorial(n - 1);
    }
}

// Step 4: Test caching in action
class Program
{
    static void Main()
    {
        Computation comp = new Computation();

        Console.WriteLine("First Call:");
        Console.WriteLine(MethodCache.ExecuteWithCaching(comp, "Factorial", 5)); // Computation happens

        Console.WriteLine("\nSecond Call:");
        Console.WriteLine(MethodCache.ExecuteWithCaching(comp, "Factorial", 5)); // Cached result is returned
    }
}


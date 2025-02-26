using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

class Program
{
    static void Main()
    {
        Console.Write("Enter JSON to validate: ");
        string json = Console.ReadLine();

        string schemaJson = @"
        {
            'type': 'object',
            'properties': {
                'email': { 'type': 'string', 'format': 'email' }
            },
            'required': ['email']
        }";

        JSchema schema = JSchema.Parse(schemaJson);
        JObject obj = JObject.Parse(json);

        if (obj.IsValid(schema, out var errors))
        {
            Console.WriteLine("\n Valid Email!");
        }
        else
        {
            Console.WriteLine("\n Invalid Email Format!");
        }
    }
}

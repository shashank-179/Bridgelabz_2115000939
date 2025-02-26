using System;
using Newtonsoft.Json;
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
                'name': { 'type': 'string' },
                'age': { 'type': 'integer' }
            },
            'required': ['name', 'age']
        }";

        JSchema schema = JSchema.Parse(schemaJson);
        JObject obj = JObject.Parse(json);

        if (obj.IsValid(schema, out var errors))
        {
            Console.WriteLine("\n JSON is valid!");
        }
        else
        {
            Console.WriteLine("\n Invalid JSON: " + string.Join(", ", errors));
        }
    }
}

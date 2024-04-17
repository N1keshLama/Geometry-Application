using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Geometry.Library;
class Program
{
    static async Task Main(string[] args) // Mark Main method as async and return Task
    {
        var featureManagement = new Dictionary<string, string>
        {
            { "FeatureManagement:Square", "true" },
            { "FeatureManagement:Rectangle", "false" },
            { "FeatureManagement:Triangle", "true" }
        };

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(featureManagement.Select(kv => new KeyValuePair<string, string?>(kv.Key, kv.Value)))
            .Build();

        var services = new ServiceCollection();
        services.AddFeatureManagement(configuration);

        var serviceProvider = services.BuildServiceProvider();

        var featureManager = serviceProvider.GetRequiredService<IFeatureManager>();

        if (await featureManager.IsEnabledAsync("Square"))
        {
            //display area and perimeter of square
            IShape square = new Square(9); 
            Console.WriteLine($"Area of the square: {square.CalculateArea()}");
            Console.WriteLine($"Perimeter of the square: {square.CalculatePerimeter()}");
        }
        else
        {
          //Displaying message if square feature is disabled
            Console.WriteLine("Square Feature is disabled!!!");
        }
        if (await featureManager.IsEnabledAsync("Rectangle"))
        {
            // display area and perimeter of rectangle
            IShape rectangle = new Rectangle(3, 7); 
            Console.WriteLine($"Area of the rectangle: {rectangle.CalculateArea()}");
            Console.WriteLine($"Perimeter of the rectangle: {rectangle.CalculatePerimeter()}");
        }
        else
        {
            Console.WriteLine("Rectangle feature is disabled!!!");
        }

        if (await featureManager.IsEnabledAsync("Triangle"))
        {
            // display area and perimeter of triangle
            IShape triangle = new Triangle(4, 2, 6); 
            Console.WriteLine($"Area of the triangle: {triangle.CalculateArea()}");
            Console.WriteLine($"Perimeter of the triangle: {triangle.CalculatePerimeter()}");
        }
        else
        {
            Console.WriteLine("Triangle feature is disabled!!!");
        }
    }
}

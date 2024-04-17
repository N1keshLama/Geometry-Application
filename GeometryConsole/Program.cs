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
        {    /// display area and perimeter of square
            double squareSide;
            if (TryGetUserInput("Enter side length for Square:", out squareSide))
            {
                IShape square = new Square(squareSide); 
                Console.WriteLine($"Area of the square: {square.CalculateArea()}");
                Console.WriteLine($"Perimeter of the square: {square.CalculatePerimeter()}");
            }
        }

        else
        {
          //Displaying message if square feature is disabled
            Console.WriteLine("Square Feature is disabled!!!");
        }
        if (await featureManager.IsEnabledAsync("Rectangle"))
        {
            // display area and perimeter of rectangle
            double rectangleLength, rectangleWidth;
            if (TryGetUserInput("Enter length for Rectangle:", out rectangleLength) &&
                TryGetUserInput("Enter width for Rectangle:", out rectangleWidth))
            {
                IShape rectangle = new Rectangle(rectangleLength, rectangleWidth); 
                Console.WriteLine($"Area of the rectangle: {rectangle.CalculateArea()}");
                Console.WriteLine($"Perimeter of the rectangle: {rectangle.CalculatePerimeter()}");
            }
        }
        else
        {
            Console.WriteLine("Rectangle feature is disabled!!!");
        }

        if (await featureManager.IsEnabledAsync("Triangle"))
        {
            // display area and perimeter of triangle
           double triangleSide1, triangleSide2, triangleSide3;
            if (TryGetUserInput("Enter side 1 for Triangle:", out triangleSide1) &&
                TryGetUserInput("Enter side 2 for Triangle:", out triangleSide2) &&
                TryGetUserInput("Enter side 3 for Triangle:", out triangleSide3))
            {
                IShape triangle = new Triangle(triangleSide1, triangleSide2, triangleSide3); 
                Console.WriteLine($"Area of the triangle: {triangle.CalculateArea()}");
                Console.WriteLine($"Perimeter of the triangle: {triangle.CalculatePerimeter()}");
            }
        }
        else
        {
            Console.WriteLine("Triangle feature is disabled!!!");
        }
        static bool TryGetUserInput(string prompt, out double result)
    {
        Console.Write(prompt);
        string input = Console.ReadLine();
        if (double.TryParse(input, out result) && result > 0)
        {
            return true;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid positive number.");
            result = 0;
            return false;
        }
    }

}
}

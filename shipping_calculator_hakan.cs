// Express Shipping Rate Calculator
// Programmer: Robert Wilson
// Date: March 2024
using System;

namespace ShippingSystem
{
    class PackageValidator
    {
        private const double MaxWeight = 50;
        private const double MaxSize = 50;
        private const double CostDivisor = 100;

        static void Main(string[] args)
        {
            // Display welcome screen
            Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");

            try
            {
                // Get package weight from user
                double weightKg = GetValidInput("Please enter the package weight:");

                // Check maximum weight limit
                if (weightKg > MaxWeight)
                {
                    Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
                    return;
                }

                // Input package dimensions
                double dimensionX = GetValidInput("Please enter the package width:");
                double dimensionY = GetValidInput("Please enter the package height:");
                double dimensionZ = GetValidInput("Please enter the package length:");

                // Calculate total package dimensions
                double packageVolume = dimensionX + dimensionY + dimensionZ;

                // Validate package size
                if (packageVolume > MaxSize)
                {
                    Console.WriteLine("Package too big to be shipped via Package Express.");
                    return;
                }

                // Calculate shipping rate
                // Rate = (width * height * length * weight) / 100
                double shippingAmount = (dimensionX * dimensionY * dimensionZ * weightKg) / CostDivisor;

                // Show shipping cost
                Console.WriteLine($"Your estimated total for shipping this package is: ${shippingAmount:F2}");
                Console.WriteLine("Thank you!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing request: {ex.Message}");
            }
        }

        private static double GetValidInput(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                if (double.TryParse(Console.ReadLine(), out double result))
                {
                    if (result > 0)
                        return result;
                    Console.WriteLine("Please enter a value greater than zero.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }
    }
} 
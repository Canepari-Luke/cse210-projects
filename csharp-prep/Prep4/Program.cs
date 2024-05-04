using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Prompt user to enter numbers
        Console.WriteLine("Enter a list of numbers, type 0 when finished:");

        // Variables to store input and calculations
        List<int> numbers = new List<int>();
        int number;
        int sum = 0;
        int count = 0;
        int max = int.MinValue;
        int minPositive = int.MaxValue;

        // Read numbers from user until 0 is entered
        do
        {
            number = int.Parse(Console.ReadLine());

            // Check if the number is not 0
            if (number != 0)
            {
                // Add number to sum
                sum += number;
                // Increment count
                count++;
                // Check if number is greater than current max
                if (number > max)
                {
                    max = number;
                }
                // Check if number is positive and smaller than minPositive
                if (number > 0 && number < minPositive)
                {
                    minPositive = number;
                }

                // Add number to the list
                numbers.Add(number);
            }
        } while (number != 0);

        // Check if any numbers were entered
        if (count > 0)
        {
            // Compute average
            double average = (double)sum / count;

            // Sort the list
            numbers.Sort();

            // Display results
            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {max}");
            Console.WriteLine($"The smallest positive number is: {minPositive}");
            Console.WriteLine("The sorted list is:");
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }
        }
        else
        {
            // No numbers entered
            Console.WriteLine("No numbers entered.");
        }
    }
}

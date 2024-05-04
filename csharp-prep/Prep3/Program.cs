using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        bool done = false;

        while (!done)
        {
            int number = random.Next(1, 101);
            int count = 0;
            int guess = -1;

            while (guess != number)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                count++;

                if (guess > number)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < number)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess == number)
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine(number);
                    Console.WriteLine($"It took you {count} guesses");
                }
            }

            Console.Write("Keep playing? (yes/no): ");
            string response = Console.ReadLine().ToLower();

            if (response == "no")
            {
                done = true;
                Console.WriteLine("Thank you for playing. Goodbye.");
            }
            else
            {
                done = false;
            }
        }
    }
}
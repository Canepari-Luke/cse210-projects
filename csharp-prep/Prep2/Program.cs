using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        int GradeScore = int.Parse(Console.ReadLine());
        if (GradeScore >= 90)
        {
            Console.WriteLine("You got an A!");
        }
        else if (GradeScore >= 80)
        {
            Console.WriteLine("You got a B!");
        }
        else if (GradeScore >= 70)
        {
            Console.WriteLine("You got a C!");
        }
        else if (GradeScore >= 60)
        {
            Console.WriteLine("You got a D!");
        }
        else if (GradeScore < 60)
        {
            Console.WriteLine("You got an F!");
        }
        else
        {
            Console.WriteLine("Please enter a valid number.");
        }
        
        if (GradeScore >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("Sorry, you failed. Don't give up!");
        }
    }
}
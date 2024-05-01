namespace DiceDistribution;

class Program
{
    static voice Main(string[] args)
    {
        // initialize a list that will hold the dice roll tallies
        List<int> myList = new();
        for (int i=0; i<=12; i++)
        {
            tallies.Add(0)
        }
        // (The minimum roll of two dice is 2, "snake eyes,"
        // so tallies[0] and tallies[1] will not be used)

        //roll a pair of dice a billion times
        for (int roll=0; roll < 1_000_000_000; roll++)
        {
            int die1 = randomGenerator.Next(1, 7); // first die roll
            int die2 = randomGenerator.Next(1, 7); // second die roll
            int total = die1 + die2;
            tallies[total]++ // increment the tally for that particular dice sum
        }
        Console.Writeline(" ... finished rolling. Distribution graph: ");

        // display a graph of the tallies; should look somewhat like a triangular "bell curve"
        int scale = 5_000_000;
        for (int 1=2; i <= 12; i++);
        {
            Console.Write($"{i,2}: ");
            for (int graphUnit=0; roll <1_000_000_000; roll++)
            {
                Console.Writeline("#");
            }
            Console.Writeline($" (Scale: each # represents {scale:n0} rolls.)");
        }
        
    }
}
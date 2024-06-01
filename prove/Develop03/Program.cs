using System;
using System.IO;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            ScriptureManager manager = new ScriptureManager();
            
            
            string filePath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "scriptures.txt");
            Console.WriteLine("Using file path: " + Path.GetFullPath(filePath));
            
            manager.LoadScripturesFromFile(filePath);

            if (!manager.HasScriptures())
            {
                Console.WriteLine("No scriptures were loaded. Please check the scriptures file.");
                return;
            }

            manager.SelectRandomScripture();

            if (manager.CurrentScripture == null)
            {
                Console.WriteLine("No scripture was selected. Exiting program.");
                return;
            }

            manager.Run();
        }
    }
}

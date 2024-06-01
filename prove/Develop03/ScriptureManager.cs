using System;
using System.Collections.Generic;
using System.IO;

namespace ScriptureMemorizer
{
    public class ScriptureManager
    {
        private List<Scripture> _scriptures;
        private Scripture _currentScripture;

        public Scripture CurrentScripture => _currentScripture;

        public ScriptureManager()
        {
            _scriptures = new List<Scripture>();
        }

        public void LoadScripturesFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 2)
                    {
                        _scriptures.Add(new Scripture(new Reference(parts[0]), parts[1]));
                    }
                }
            }
            else
            {
                Console.WriteLine("Scripture file not found.");
            }
        }

        public bool HasScriptures()
        {
            return _scriptures.Count > 0;
        }

        public void SelectRandomScripture()
        {
            if (_scriptures.Count > 0)
            {
                Random random = new Random();
                _currentScripture = _scriptures[random.Next(_scriptures.Count)];
            }
        }

        public void Run()
        {
            Console.Clear();
            _currentScripture.Show();

            while (!_currentScripture.IsFullyHidden())
            {
                Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    break;
                }

                _currentScripture.HideRandomWords();
                Console.Clear();
                _currentScripture.Show();
            }

            Console.WriteLine("All words are hidden. Program ended.");
        }
    }
}

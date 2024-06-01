using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();

            string[] wordsArray = text.Split(' ');
            foreach (string word in wordsArray)
            {
                _words.Add(new Word(word));
            }
        }

        public void Show()
        {
            Console.WriteLine(_reference.ToString());
            foreach (Word word in _words)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();
        }

        public void HideRandomWords()
        {
            Random random = new Random();
            int wordsToHide = Math.Max(1, _words.Count / 10); // Hide 10% of the words

            for (int i = 0; i < wordsToHide; i++)
            {
                int index = random.Next(_words.Count);
                _words[index].Hide();
            }
        }

        public bool IsFullyHidden()
        {
            foreach (Word word in _words)
            {
                if (!word.IsHidden)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

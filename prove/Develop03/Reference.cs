namespace ScriptureMemorizer
{
    public class Reference
    {
        private string _book;
        private int _chapter;
        private int _startVerse;
        private int? _endVerse;

        public Reference(string reference)
        {
            string[] parts = reference.Split(new char[] { ' ', ':' });
            _book = parts[0];
            _chapter = int.Parse(parts[1]);
            string[] verses = parts[2].Split('-');
            _startVerse = int.Parse(verses[0]);
            if (verses.Length > 1)
            {
                _endVerse = int.Parse(verses[1]);
            }
        }

        public override string ToString()
        {
            if (_endVerse.HasValue)
            {
                return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
            }
            else
            {
                return $"{_book} {_chapter}:{_startVerse}";
            }
        }
    }
}

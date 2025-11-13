using System;

namespace ScriptureMemorizerApp
{
    // Represents the scripture reference.
    public class Reference
    {
        private string _book;
        private int _chapter;
        private int _startVerse;
        private int _endVerse;
        private bool _hasRange;

        // Constructor 1: Single Verse
        public Reference(string book, int chapter, int startVerse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = startVerse;
            _endVerse = startVerse;
            _hasRange = false;
        }

        // Constructor 2: Verse Range
        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = startVerse;
            _endVerse = endVerse;
            _hasRange = true;
        }

        // Returns the formatted reference string.
        public string GetDisplayText()
        {
            if (_hasRange)
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
using System;

namespace ScriptureMemorizerApp
{
    // Represents a single word from the scripture text.
    public class Word
    {
        private string _text;
        private bool _isHidden;

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        public void Hide()
        {
            _isHidden = true;
        }

        public bool IsHidden => _isHidden;

        // Returns the word or a string of underscores of the same length.
        public string GetDisplayText()
        {
            return _isHidden ? new string('_', _text.Length) : _text;
        }
    }
}
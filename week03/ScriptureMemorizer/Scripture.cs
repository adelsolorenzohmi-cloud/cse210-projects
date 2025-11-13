using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizerApp
{
    // Holds the reference and a list of words, and handles the core hiding/display logic.
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private Random _random = new Random();

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();

            // Split the text into words by space.
            string[] rawWords = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string rawWord in rawWords)
            {
                _words.Add(new Word(rawWord));
            }
        }

        // Hides a specified count of random, unhidden words.
        public void HideRandomWords(int count)
        {
            // Only hide words that are not already hidden.
            List<Word> unhiddenWords = _words.Where(w => !w.IsHidden).ToList();

            if (unhiddenWords.Count == 0)
            {
                return;
            }

            int wordsToHide = Math.Min(count, unhiddenWords.Count);

            // Use a HashSet to ensure we select unique indices.
            HashSet<int> indicesToHide = new HashSet<int>();

            while (indicesToHide.Count < wordsToHide)
            {
                int index = _random.Next(0, unhiddenWords.Count);
                indicesToHide.Add(index);
            }

            // Hide the selected words.
            foreach (int index in indicesToHide)
            {
                unhiddenWords[index].Hide();
            }
        }

        // Returns the full scripture text with words replaced by underscores if hidden.
        public string GetDisplayText()
        {
            string referenceText = _reference.GetDisplayText();

            // Concatenate the words with spaces.
            string scriptureText = string.Join(" ", _words.Select(w => w.GetDisplayText()));

            return $"{referenceText}\n\n{scriptureText}";
        }

        // Checks if all words in the scripture are hidden.
        public bool IsCompletelyHidden()
        {
            return _words.All(w => w.IsHidden);
        }
    }
}
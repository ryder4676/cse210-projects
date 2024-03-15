using System; // For basic system functionalities
using System.Collections.Generic; // For List<T> data structure
using System.Linq; // For LINQ methods, such as .Select()

public class Scripture
{
    private List<Word> _words; // List to store words
    private Reference _reference; // Reference object

    // Constructor to initialize the Scripture object with a reference and scripture text
    public Scripture(Reference reference, string scriptureText)
    {
        _reference = reference;
        // Split the scripture text into words, create Word objects for each word, and store them in the _words list
        _words = scriptureText.Split(' ')
                              .Select(word => new Word(word))
                              .ToList();
    }

    // Method to hide a specified number of random words from the scripture
    public bool HideRandomWords(int numberToHide, Stack<int> hiddenWordIndices)
    {
        var random = new Random();
        var visibleWords = _words.Where((word, index) => !word.IsHidden()).ToList();

        int wordsHidden = 0; // Track the number of words hidden

        // Hide words until the specified number is hidden or there are no visible words left
        while (visibleWords.Count > 0 && (numberToHide == -1 || wordsHidden < numberToHide))
        {
            var randomIndex = random.Next(visibleWords.Count);
            var wordIndex = _words.FindIndex(w => w == visibleWords[randomIndex]);
            hiddenWordIndices.Push(wordIndex);
            visibleWords[randomIndex].Hide();
            wordsHidden++;

            // Refresh the list of visible words
            visibleWords = _words.Where((word, index) => !word.IsHidden()).ToList();
        }

        return wordsHidden > 0; // Indicates whether words were hidden
    }

    // Method to reveal a specified number of previously hidden words
    public void RevealWords(int numberToReveal, Stack<int> hiddenWordIndices)
    {
        for (int i = 0; i < numberToReveal; i++)
        {
            if (hiddenWordIndices.Count == 0)
                break;

            int lastIndex = hiddenWordIndices.Pop();
            _words[lastIndex].Show();
        }
    }

    // Method to get the display text of the scripture (including reference and words)
    public string GetDisplayText()
    {
        string referenceText = _reference.GetDisplayText();
        string wordsText = string.Join(" ", _words.Select(word => word.GetDisplayText()));

        // Check if there are words to display
        if (!string.IsNullOrEmpty(wordsText))
        {
            return $"{referenceText} ~ {wordsText}";
        }
        else
        {
            return referenceText;
        }
    }

    // Method to check if all words in the scripture are hidden
    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}

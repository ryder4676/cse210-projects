using System; // For basic system functionalities
using System.Collections.Generic; // For List<T> data structure
using System.Linq; // For LINQ methods, such as .Select()

public class Word
{
    private string _word; // Variable to store the word
    private bool _isHidden; // Variable to determine if the word is hidden or not

    // Constructor to initialize the word and set it as not hidden by default
    public Word(string word)
    {
        _word = word;
        _isHidden = false;
    }

    // Method to hide the word
    public void Hide()
    {
        _isHidden = true;
    }

    // Method to show the word
    public void Show()
    {
        _isHidden = false;
    }

    // Method to check if the word is hidden
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Method to get the display text of the word (either hidden or revealed)
    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _word.Length) : _word;
    }
}

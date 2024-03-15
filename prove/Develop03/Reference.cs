using System; // For basic system functionalities
using System.Collections.Generic; // For List<T> data structure
using System.Linq; // For LINQ methods, such as .Select()

public class Reference
{
    private string _book; // Variable to store the book name
    private int _chapter; // Variable to store the chapter number
    private int _startVerse; // Variable to store the starting verse number
    private int? _endVerse; // Variable to store the ending verse number (nullable)

    // Constructor to initialize the Reference object with book, chapter, starting verse, and optionally ending verse
    public Reference(string book, int chapter, int startVerse, int? endVerse = null)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    // Method to get the display text of the reference (including book, chapter, and verse range)
    public string GetDisplayText()
    {
        if (_endVerse.HasValue) // If the ending verse is provided
        {
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
        else // If only starting verse is provided
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }
    }
}

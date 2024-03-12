using System;
using System.Collections.Generic; // For List<T>
using System.Linq; // For LINQ methods, such as .Select()

public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int? _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = null;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        return _endVerse.HasValue
            ? $"{_book} {_chapter}:{_verse}-{_endVerse.Value}"
            : $"{_book} {_chapter}:{_verse}";
    }
}

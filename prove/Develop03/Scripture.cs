using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private List<Word> _words;
    private Reference _reference;

    public Scripture(Reference reference, string scriptureText)
    {
        _reference = reference;
        _words = scriptureText.Split(' ')
                              .Select(word => new Word(word))
                              .ToList();
    }

    public void HideRandomWord()
    {
        var visibleWords = _words.Where(word => !word.IsHidden).ToList();

        if (visibleWords.Any())
        {
            var random = new Random();
            var wordToHide = visibleWords[random.Next(visibleWords.Count)];
            wordToHide.Hide();
        }
    }

    public bool AreAllWordsHidden => _words.All(word => word.IsHidden);

    public string GetDisplayText()
    {
        return $"{_reference.GetDisplayText()}: " +
               string.Join(" ", _words.Select(word => word.GetDisplayText()));
    }
}
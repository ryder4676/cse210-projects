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

public bool HideRandomWords(int numberToHide, Stack<int> hiddenWordIndices)
{
    var random = new Random();
    var visibleWords = _words.Where((word, index) => !word.IsHidden()).ToList();

    int wordsHidden = 0; // Track the number of words hidden

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

    return wordsHidden > 0; // Words were hidden
}

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

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}
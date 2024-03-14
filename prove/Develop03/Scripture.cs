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

    public void HideRandomWords(int numberToHide)
    {
        var random = new Random();
        var visibleWords = _words.Where(word => !word.IsHidden()).ToList();

        for (int i = 0; i < Math.Min(numberToHide, visibleWords.Count); i++)
        {
            var randomIndex = random.Next(visibleWords.Count);
            visibleWords[randomIndex].Hide();
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
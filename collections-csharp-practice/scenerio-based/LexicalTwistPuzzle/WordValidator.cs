class WordValidator
{
    public static bool IsInvalid(string word)
    {
        return word.Trim().Contains(" ");
    }
}

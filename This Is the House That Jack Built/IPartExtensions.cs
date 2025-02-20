namespace This_Is_the_House_That_Jack_Built;

public static class PartExtensions
{
    public static string GetPoemAsString(this Part part)
    {
        if (part.Poem.IsEmpty) return string.Empty;

        return string.Join(Environment.NewLine, part.Poem);
    }
}
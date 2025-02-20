using System.Collections.Immutable;

namespace This_Is_the_House_That_Jack_Built;

public abstract class Part
{
    public ImmutableList<string> Poem { get; set; } = ImmutableList<string>.Empty;
    public abstract string Text { get; }
    public abstract string Replacement { get; }

    public void AddPart(ImmutableList<string>? poem = null)
    {
        if (poem == null)
        {
            Poem = ImmutableList.Create(Text);
            return;
        }

        var lines = new List<string> { Text };
        lines.AddRange(poem.ToList());

        lines[1] = lines[1].Replace("This is", Replacement);

        Poem = lines.ToImmutableList();
    }
}
using System.Collections.Immutable;

namespace This_Is_the_House_That_Jack_Built;

public interface IPart
{
    string Text { get; }
    string Replacement { get; }
    ImmutableList<string> Poem { get; set; }
    void AddPart(ImmutableList<string>? poem = null);
}
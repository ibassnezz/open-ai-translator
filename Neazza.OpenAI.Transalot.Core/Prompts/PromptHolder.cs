using System.Text;

namespace Neazza.OpenAI.Transalot.Core.Prompts;

public static class PromptHolder
{
    private static string GetStringOf(string path)
    {
        var assembly = typeof(PromptHolder).Assembly;
        var resourceStream = assembly.GetManifestResourceStream($"Neazza.OpenAI.Transalot.Core.Prompts.{path}.prompt");
        if (resourceStream is null)
        {
            throw new KeyNotFoundException(path);
        }
        using var reader = new StreamReader(resourceStream, Encoding.UTF8);
        return reader.ReadToEnd();
    }

    public static string TranslateFromEnglish => GetStringOf(nameof(TranslateFromEnglish));
    public static string AnyDoubts => GetStringOf(nameof(AnyDoubts));
    public static string ClearAnswer => GetStringOf(nameof(ClearAnswer));
    public static string ConjugateInPPS => GetStringOf(nameof(ConjugateInPPS));
}
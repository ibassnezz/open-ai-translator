namespace Neazza.OpenAI.Transalot.Core;

public interface ITranslatorService
{
    Task<HandledLexeme> TranslateAsync(OriginalLexeme originalLexeme, CancellationToken cancellationToken);

}
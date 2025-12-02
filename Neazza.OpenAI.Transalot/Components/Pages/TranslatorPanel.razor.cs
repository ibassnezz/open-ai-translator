using Microsoft.AspNetCore.Components;
using Neazza.OpenAI.Transalot.Core;

namespace Neazza.OpenAI.Transalot.Components.Pages;

public partial class TranslatorPanel : ComponentBase
{
    [Inject] private ITranslatorService TranslatorService { get; set; } = null!;

    protected string TranslationText { get; private set; } = null!;

    protected bool IsSuccess { get; private set; } = true;

    protected string OriginalText { get; set; } = null!;

    protected PromptType SelectedPromptType { get; set; }

    public async Task Translate()
    {
        var cts = new CancellationTokenSource();

        var result =
            await TranslatorService.TranslateAsync(
                new OriginalLexeme(Payload: OriginalText, PromptType: SelectedPromptType), cts.Token);

        IsSuccess = result.IsSuccess;

        TranslationText = result.Payload;
    }
}
using OpenAI.Chat;

namespace Neazza.OpenAI.Transalot.Core;

internal class TranslatorService(ChatClient chatClient, IChatMessageFactory chatMessageFactory) : ITranslatorService
{
    private const string ErrorMessage = "ERROR";
    
    public async Task<HandledLexeme> TranslateAsync(OriginalLexeme originalLexeme, CancellationToken cancellationToken)
    {
        try
        {
            var messages = chatMessageFactory.GetMessages(originalLexeme);
            var completion = await chatClient.CompleteChatAsync(messages, cancellationToken: cancellationToken);

            var strAnswer = completion.Value.Content.FirstOrDefault()?.Text;
            if (ErrorMessage.Equals(strAnswer) || string.IsNullOrEmpty(strAnswer))
            {
                return new HandledLexeme(Payload: "Incorrect lexeme", IsSuccess: false);
            }
            
            return new HandledLexeme(Payload: strAnswer, IsSuccess: true);

        }
        catch (Exception e)
        {
            return new HandledLexeme(e.Message, IsSuccess: false);
        }
        
    }
}
using OpenAI.Chat;


namespace Neazza.OpenAI.Transalot.Core;

internal interface IChatMessageFactory
{
    public IReadOnlyCollection<ChatMessage> GetMessages(OriginalLexeme originalLexeme);
}
using OpenAI.Chat;


namespace Neazza.OpenAI.Transalot.Core;

public interface IChatMessageFactory
{
    public IReadOnlyCollection<ChatMessage> GetMessages(OriginalLexeme originalLexeme);
}
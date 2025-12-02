using Neazza.OpenAI.Transalot.Core.Prompts;
using OpenAI.Chat;
#pragma warning disable OPENAI001
namespace Neazza.OpenAI.Transalot.Core;

public class ChatMessageFactory : IChatMessageFactory
{
    
    public IReadOnlyCollection<ChatMessage> GetMessages(OriginalLexeme originalLexeme)
        => originalLexeme.PromptType switch
        {
            PromptType.TranslateToPortugal => 
                new ChatMessage[]
                {
                    new UserChatMessage(string.Format(PromptHolder.TranslateFromEnglish, originalLexeme.Payload)),
                    new DeveloperChatMessage(PromptHolder.ClearAnswer),
                    new DeveloperChatMessage(PromptHolder.AnyDoubts)
                },
            PromptType.WriteConjugation => 
                new ChatMessage[]
                {
                    new UserChatMessage(string.Format(PromptHolder.ConjugateInPPS, originalLexeme.Payload)),
                    new DeveloperChatMessage(PromptHolder.AnyDoubts)
                },
            _ => ArraySegment<ChatMessage>.Empty
        };



}
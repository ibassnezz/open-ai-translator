using System.ClientModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI;
using OpenAI.Chat;

namespace Neazza.OpenAI.Transalot.Core;

public static class Composer
{
    public static IServiceCollection AddTranslator(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddSingleton<ChatClient>(_ =>
        {

            var apiKey = new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")!);
            var model = "gpt-4o-mini";
            var options = new OpenAIClientOptions
            {
                Endpoint = new Uri(configuration.GetSection("OpenAI:BaseAddress").Value!)
            };
            
            return new ChatClient(model, apiKey, options);
        });

        services.AddTransient<ITranslatorService, TranslatorService>();
        services.AddSingleton<IChatMessageFactory, ChatMessageFactory>();
        return services;

    }
}
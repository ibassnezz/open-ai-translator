using Microsoft.AspNetCore.Components;

namespace Neazza.OpenAI.Transalot.Components.Pages;

public partial class EnumRadio<TEnum> : ComponentBase 
{
    [Parameter] public TEnum Value { get; set; } = default!;
    [Parameter] public EventCallback<TEnum> ValueChanged { get; set; }

    private string GroupName { get; } = Guid.NewGuid().ToString();

    private async Task OnChanged(TEnum value)
    {
        await ValueChanged.InvokeAsync(value);
    }
    
    
}
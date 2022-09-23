namespace PsicoOnline.UI.Components;

public partial class ConfirmarExclusaoComponent
{
    async Task ConfirmarExclusaoAsync()
    {
        _ = await MessageBox!.Show();
        StateHasChanged();
    }

    MudMessageBox? MessageBox { get; set; }

    [Parameter]
    public string Mensagem { get; set; } = string.Empty;

    private async Task InvokeDeleteAsync() => await DeleteAsync.InvokeAsync();

    [Parameter]
    public EventCallback DeleteAsync { get; set; }
}
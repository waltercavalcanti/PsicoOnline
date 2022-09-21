namespace PsicoOnline.UI.Pages;

public partial class GrausParentesco
{
    protected override async Task OnInitializedAsync()
    {
        await GrauParentescoService.GetAllGrausParentescoAsync();
    }

    void EditarGrauParentesco(int id)
    {
        NavigationManager.NavigateTo($"grauparentesco/{id}");
    }

    void AddGrauParentesco()
    {
        NavigationManager.NavigateTo("grauparentesco");
    }
}
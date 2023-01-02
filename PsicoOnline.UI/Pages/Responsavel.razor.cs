namespace PsicoOnline.UI.Pages;

public partial class Responsavel
{
    [Parameter]
    public int? Id { get; set; }

    string btnText = string.Empty;

    string titulo = string.Empty;

    ResponsavelModel responsavel = new() { Genero = 'M' };

    protected override async Task OnInitializedAsync()
    {
        if (Id == null)
        {
            btnText = "Salvar";
            titulo = "Adicionar Respons�vel";
        }
        else
        {
            btnText = "Atualizar";
            titulo = "Editar Respons�vel";
        }
    }

    protected override async Task OnParametersSetAsync()
    {
        if (Id != null)
        {
            responsavel = await ResponsavelService.GetResponsavelByIdAsync((int)Id);
        }
    }

    async Task SubmeterAsync()
    {
        if (Id == null)
        {
            await ResponsavelService.AddResponsavelAsync(responsavel);
        }
        else
        {
            await ResponsavelService.UpdateResponsavelAsync(responsavel);
        }
    }

    async Task DeleteResponsavelAsync()
    {
        await ResponsavelService.DeleteResponsavelAsync(responsavel.Id);
    }
}
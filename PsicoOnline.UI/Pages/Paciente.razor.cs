namespace PsicoOnline.UI.Pages;

public partial class Paciente
{
    [Parameter]
    public int? Id { get; set; }

    string btnText = string.Empty;

    string titulo = string.Empty;

    PacienteModel paciente = new() { Genero = 'M' };

    protected override async Task OnInitializedAsync()
    {
        if (Id == null)
        {
            btnText = "Salvar";
            titulo = "Adicionar Paciente";
        }
        else
        {
            btnText = "Atualizar";
            titulo = "Editar Paciente";
        }
    }

    protected override async Task OnParametersSetAsync()
    {
        if (Id != null)
        {
            paciente = await PacienteService.GetPacienteByIdAsync((int)Id);
        }
    }

    async Task SubmeterAsync()
    {
        if (Id == null)
        {
            await PacienteService.AddPacienteAsync(paciente);
        }
        else
        {
            await PacienteService.UpdatePacienteAsync(paciente);
        }
    }

    async Task DeletePacienteAsync()
    {
        await PacienteService.DeletePacienteAsync(paciente.Id);
    }
}
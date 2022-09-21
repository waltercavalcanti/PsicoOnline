using Microsoft.AspNetCore.Components;

namespace PsicoOnline.UI.Pages;

public partial class Paciente
{
    [Parameter]
    public int? Id { get; set; }

    string btnText = string.Empty;

    PacienteModel paciente = new() { Genero = 'M' };

    static readonly List<GeneroModel> generos = new()
    {
        new GeneroModel { Id = 'M', Descricao = "Masculino" },
        new GeneroModel { Id = 'F', Descricao = "Feminino" }
    };

    protected override async Task OnInitializedAsync()
    {
        btnText = Id == null ? "Salvar" : "Atualizar";
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
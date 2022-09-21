using Microsoft.AspNetCore.Components;

namespace PsicoOnline.UI.Pages;

public partial class Pacientes
{
    readonly string[] cabecalhos = { "Nome", "Data de Nascimento", "Telefone", "Gênero", "" };

    protected override async Task OnInitializedAsync()
    {
        await PacienteService.GetAllPacientesAsync();
    }

    void EditarPaciente(int id)
    {
        NavigationManager.NavigateTo($"paciente/{id}");
    }

    void AddPaciente()
    {
        NavigationManager.NavigateTo("paciente");
    }
}
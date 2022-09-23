namespace PsicoOnline.UI.Services;

public interface ISessaoService
{
    List<SessaoModel> Sessoes { get; set; }

    Task AddSessaoAsync(SessaoModel sessao);

    Task DeleteSessaoAsync(int id);

    Task GetAllSessoesAsync();

    Task<SessaoModel> GetSessaoByIdAsync(int id);

    Task UpdateSessaoAsync(SessaoModel grauParentesco);
}
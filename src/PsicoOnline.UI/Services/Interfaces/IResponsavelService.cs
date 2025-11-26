namespace PsicoOnline.UI.Services.Interfaces;

public interface IResponsavelService
{
	List<ResponsavelModel> Responsaveis { get; set; }

	Task AddResponsavelAsync(ResponsavelModel responsavel);

	Task DeleteResponsavelAsync(int id);

	Task GetAllResponsaveisAsync();

	Task<ResponsavelModel> GetResponsavelByIdAsync(int id);

	Task UpdateResponsavelAsync(ResponsavelModel responsavel);
}
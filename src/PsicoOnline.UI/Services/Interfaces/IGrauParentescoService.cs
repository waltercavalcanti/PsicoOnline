namespace PsicoOnline.UI.Services.Interfaces;

public interface IGrauParentescoService
{
	List<GrauParentescoModel> GrausParentesco { get; set; }

	Task AddGrauParentescoAsync(GrauParentescoModel grauParentesco);

	Task DeleteGrauParentescoAsync(int id);

	Task GetAllGrausParentescoAsync();

	Task<GrauParentescoModel> GetGrauParentescoByIdAsync(int id);

	Task UpdateGrauParentescoAsync(GrauParentescoModel grauParentesco);
}
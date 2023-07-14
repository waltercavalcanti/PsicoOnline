namespace PsicoOnline.UI.Models;

public class GrauParentescoModel
{
	public int Id { get; set; }

	[Required(AllowEmptyStrings = false, ErrorMessage = "A descrição do grau de parentesco é obrigatória.")]
	[StringLength(100, ErrorMessage = " A descrição do grau de parentesco deve ter no máximo 100 caracteres.")]
	public string Descricao { get; set; }
}
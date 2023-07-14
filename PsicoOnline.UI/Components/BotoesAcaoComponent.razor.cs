namespace PsicoOnline.UI.Components;

public partial class BotoesAcaoComponent
{
	[Parameter]
	public int? Id { get; set; }

	string btnText = string.Empty;

	protected override async Task OnInitializedAsync() => btnText = Id == null ? "Salvar" : "Atualizar";

	[Parameter]
	public EventCallback DeleteAsync { get; set; }
}
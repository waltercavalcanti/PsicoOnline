namespace PsicoOnline.UI.Shared;

public partial class MainLayout
{
    bool gavetaAberta = true;
    private bool modoEscuro;

    void AlternarGaveta()
    {
        gavetaAberta = !gavetaAberta;
    }
}
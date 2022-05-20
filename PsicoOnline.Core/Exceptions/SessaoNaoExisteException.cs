namespace PsicoOnline.Core.Exceptions
{
    public class SessaoNaoExisteException : BaseException
    {
        public SessaoNaoExisteException(int id) : base($"Sessão Id {id} não existe.") { }
    }
}
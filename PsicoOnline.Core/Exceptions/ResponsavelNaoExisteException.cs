namespace PsicoOnline.Core.Exceptions;

public class ResponsavelNaoExisteException : BaseException
{
    public ResponsavelNaoExisteException(int id) : base($"Responsável Id {id} não existe.") { }
}
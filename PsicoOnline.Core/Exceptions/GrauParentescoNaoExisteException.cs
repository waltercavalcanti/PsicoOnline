namespace PsicoOnline.Core.Exceptions;

public class GrauParentescoNaoExisteException : BaseException
{
    public GrauParentescoNaoExisteException(int id) : base($"Grau de parentesco Id {id} não existe.") { }
}
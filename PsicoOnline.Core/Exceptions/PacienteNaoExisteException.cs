namespace PsicoOnline.Core.Exceptions
{
    public class PacienteNaoExisteException : BaseException
    {
        public PacienteNaoExisteException(int id) : base($"Paciente Id {id} não existe.") { }
    }
}
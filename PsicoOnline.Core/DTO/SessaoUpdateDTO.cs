namespace PsicoOnline.Core.DTO;

public record SessaoUpdateDTO(int Id, int PacienteId, DateTime DataSessao, string Anotacao);
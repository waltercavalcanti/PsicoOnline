namespace PsicoOnline.Core.DTO;

public record ResponsavelUpdateDTO(int Id, string Nome, DateTime DataNascimento, string Telefone, char Genero, int PacienteId, int GrauParentescoId);
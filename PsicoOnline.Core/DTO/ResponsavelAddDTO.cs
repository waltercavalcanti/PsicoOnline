namespace PsicoOnline.Core.DTO;

public record ResponsavelAddDTO(string Nome, DateTime DataNascimento, string Telefone, char Genero, int PacienteId, int GrauParentescoId);
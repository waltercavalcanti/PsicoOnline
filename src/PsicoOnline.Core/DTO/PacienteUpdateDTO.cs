namespace PsicoOnline.Core.DTO;

public record PacienteUpdateDTO(int Id, string Nome, DateTime DataNascimento, string Telefone, char Genero);
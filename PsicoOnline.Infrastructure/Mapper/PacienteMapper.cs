using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;

namespace PsicoOnline.Infrastructure.Mapper
{
    public static class PacienteMapper
    {
        public static Paciente Convert(PacienteDTO paciente)
        {
            if (paciente == null)
            {
                return null;
            }

            return new Paciente
            {
                Id = paciente.Id,
                Nome = paciente.Nome,
                DataNascimento = paciente.DataNascimento,
                Telefone = paciente.Telefone,
                Genero = paciente.Genero
            };
        }
    }
}
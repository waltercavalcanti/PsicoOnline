using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;

namespace PsicoOnline.Infrastructure.Mapper
{
    public static class PacienteMapper
    {
        public static void Convert(PacienteDTO pacienteDTO, ref Paciente paciente)
        {
            if (pacienteDTO is PacienteAddDTO pacienteAddDTO)
            {
                paciente.Nome = pacienteAddDTO.Nome;
                paciente.DataNascimento = pacienteAddDTO.DataNascimento;
                paciente.Telefone = pacienteAddDTO.Telefone;
                paciente.Genero = pacienteAddDTO.Genero;
            }
            else if (pacienteDTO is PacienteUpdateDTO pacienteUpdateDTO)
            {
                paciente.Id = pacienteUpdateDTO.Id;
                paciente.Nome = pacienteUpdateDTO.Nome;
                paciente.DataNascimento = pacienteUpdateDTO.DataNascimento;
                paciente.Telefone = pacienteUpdateDTO.Telefone;
                paciente.Genero = pacienteUpdateDTO.Genero;
            }
        }
    }
}
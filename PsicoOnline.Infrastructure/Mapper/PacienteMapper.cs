using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;

namespace PsicoOnline.Infrastructure.Mapper
{
    public static class PacienteMapper
    {
        public static Paciente Convert(PacienteDTO pacienteDTO)
        {
            if (pacienteDTO == null)
            {
                return null;
            }

            var paciente = new Paciente
            {
                Responsavel = null
            };

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

            return paciente;
        }
    }
}
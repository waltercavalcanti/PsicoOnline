using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;

namespace PsicoOnline.Infrastructure.Mapper
{
    public static class ResponsavelMapper
    {
        public static Responsavel Convert(ResponsavelDTO responsavelDTO)
        {
            if (responsavelDTO == null)
            {
                return null;
            }

            var responsavel = new Responsavel
            {
                Paciente = null,
                GrauParentesco = null
            };

            if (responsavelDTO is ResponsavelAddDTO responsavelAddDTO)
            {
                responsavel.Nome = responsavelAddDTO.Nome;
                responsavel.DataNascimento = responsavelAddDTO.DataNascimento;
                responsavel.Telefone = responsavelAddDTO.Telefone;
                responsavel.Genero = responsavelAddDTO.Genero;
                responsavel.PacienteId = responsavelAddDTO.PacienteId;
                responsavel.GrauParentescoId = responsavelAddDTO.GrauParentescoId;
            }
            else if (responsavelDTO is ResponsavelUpdateDTO responsavelUpdateDTO)
            {
                responsavel.Id = responsavelUpdateDTO.Id;
                responsavel.Nome = responsavelUpdateDTO.Nome;
                responsavel.DataNascimento = responsavelUpdateDTO.DataNascimento;
                responsavel.Telefone = responsavelUpdateDTO.Telefone;
                responsavel.Genero = responsavelUpdateDTO.Genero;
                responsavel.PacienteId = responsavelUpdateDTO.PacienteId;
                responsavel.GrauParentescoId = responsavelUpdateDTO.GrauParentescoId;
            }

            return responsavel;
        }
    }
}
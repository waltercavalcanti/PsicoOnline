using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;

namespace PsicoOnline.Infrastructure.Mapper
{
    public static class ResponsavelMapper
    {
        public static void Convert(ResponsavelDTO responsavelDTO, ref Responsavel responsavel)
        {
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
        }
    }
}
using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;

namespace PsicoOnline.Infrastructure.Mapper
{
    public static class ResponsavelMapper
    {
        public static Responsavel Convert(ResponsavelDTO responsavel)
        {
            if (responsavel == null)
            {
                return null;
            }

            return new Responsavel
            {
                Id = responsavel.Id,
                Nome = responsavel.Nome,
                DataNascimento = responsavel.DataNascimento,
                Telefone = responsavel.Telefone,
                Genero = responsavel.Genero,
                Paciente = PacienteMapper.Convert(responsavel.Paciente),
                GrauParentesco = GrauParentescoMapper.Convert(responsavel.GrauParentesco)
            };
        }
    }
}
using AutoMapper;
using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;

namespace PsicoOnline.Infrastructure.Mapper
{
    public class ResponsavelProfile : Profile
    {
        public ResponsavelProfile()
        {
            CreateMap<ResponsavelAddDTO, Responsavel>();
            CreateMap<Responsavel, ResponsavelAddDTO>();
            CreateMap<ResponsavelUpdateDTO, Responsavel>();
            CreateMap<Responsavel, ResponsavelUpdateDTO>();
        }
    }
}
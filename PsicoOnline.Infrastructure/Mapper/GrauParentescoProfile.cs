using AutoMapper;
using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;

namespace PsicoOnline.Infrastructure.Mapper;

public class GrauParentescoProfile : Profile
{
    public GrauParentescoProfile()
    {
        CreateMap<GrauParentescoAddDTO, GrauParentesco>();
        CreateMap<GrauParentesco, GrauParentescoAddDTO>();
        CreateMap<GrauParentescoUpdateDTO, GrauParentesco>();
        CreateMap<GrauParentesco, GrauParentescoUpdateDTO>();
    }
}
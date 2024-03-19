using AutoMapper;
using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;

namespace PsicoOnline.Infrastructure.Mapper;

public class SessaoProfile : Profile
{
	public SessaoProfile()
	{
		CreateMap<SessaoAddDTO, Sessao>();
		CreateMap<Sessao, SessaoAddDTO>();
		CreateMap<SessaoUpdateDTO, Sessao>();
		CreateMap<Sessao, SessaoUpdateDTO>();
	}
}
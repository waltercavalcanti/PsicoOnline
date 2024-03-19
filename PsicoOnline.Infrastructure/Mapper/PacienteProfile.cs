using AutoMapper;
using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;

namespace PsicoOnline.Infrastructure.Mapper;

public class PacienteProfile : Profile
{
	public PacienteProfile()
	{
		CreateMap<PacienteAddDTO, Paciente>();
		CreateMap<Paciente, PacienteAddDTO>();
		CreateMap<PacienteUpdateDTO, Paciente>();
		CreateMap<Paciente, PacienteUpdateDTO>();
	}
}
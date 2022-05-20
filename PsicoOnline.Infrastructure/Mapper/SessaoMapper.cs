using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;

namespace PsicoOnline.Infrastructure.Mapper
{
    public static class SessaoMapper
    {
        public static Sessao Convert(SessaoDTO sessaoDTO)
        {
            if (sessaoDTO == null)
            {
                return null;
            }

            var sessao = new Sessao
            {
                Paciente = null
            };

            if (sessaoDTO is SessaoAddDTO sessaoAddDTO)
            {
                sessao.PacienteId = sessaoAddDTO.PacienteId;
                sessao.DataSessao = sessaoAddDTO.DataSessao;
                sessao.Anotacao = sessaoAddDTO.Anotacao;
            }
            else if (sessaoDTO is SessaoUpdateDTO sessaoUpdateDTO)
            {
                sessao.Id = sessaoUpdateDTO.Id;
                sessao.PacienteId = sessaoUpdateDTO.PacienteId;
                sessao.DataSessao = sessaoUpdateDTO.DataSessao;
                sessao.Anotacao = sessaoUpdateDTO.Anotacao;
            }

            return sessao;
        }
    }
}
using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;

namespace PsicoOnline.Infrastructure.Mapper
{
    public static class SessaoMapper
    {
        public static void Convert(SessaoDTO sessaoDTO, ref Sessao sessao)
        {
            if (sessaoDTO is SessaoAddDTO sessaoAddDTO)
            {
                sessao.PacienteId = sessaoAddDTO.PacienteId;
                sessao.DataSessao = sessaoAddDTO.DataSessao;
                sessao.Anotacao = sessaoAddDTO.Anotacao;
            }
            else if (sessaoDTO is SessaoUpdateDTO sessaoUpdateDTO)
            {
                sessao.Anotacao = sessaoUpdateDTO.Anotacao;
            }
        }
    }
}
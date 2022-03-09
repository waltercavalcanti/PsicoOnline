using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;

namespace PsicoOnline.Infrastructure.Mapper
{
    public static class SessaoMapper
    {
        public static Sessao Convert(SessaoDTO sessao)
        {
            if (sessao == null)
            {
                return null;
            }

            return new Sessao
            {
                Id = sessao.Id,
                Paciente = PacienteMapper.Convert(sessao.Paciente),
                DataSessao = sessao.DataSessao,
                Anotacao = sessao.Anotacao,
            };
        }
    }
}
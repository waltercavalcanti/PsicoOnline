using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;

namespace PsicoOnline.Core.Interfaces
{
    public interface IResponsavelRepository
    {
        Responsavel GetResponsavelById(int id);

        IReadOnlyList<Responsavel> GetAllResponsaveis();

        Responsavel AddResponsavel(ResponsavelDTO responsavelDTO);

        void UpdateResponsavel(ResponsavelDTO responsavelDTO);

        void DeleteResponsavel(ResponsavelDTO responsavelDTO);

        void DeleteAllResponsaveis(List<ResponsavelDTO> responsaveisDTO);

        bool ResponsavelExists(int id);
    }
}
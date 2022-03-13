using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;

namespace PsicoOnline.Core.Interfaces
{
    public interface IResponsavelRepository
    {
        Task<Responsavel> GetResponsavelById(int id);

        Task<IReadOnlyList<Responsavel>> GetAllResponsaveis();

        Task<Responsavel> AddResponsavel(ResponsavelDTO responsavelDTO);

        Task UpdateResponsavel(ResponsavelDTO responsavelDTO);

        Task DeleteResponsavel(int id);

        Task DeleteAllResponsaveis();

        bool ResponsavelExists(int id);
    }
}
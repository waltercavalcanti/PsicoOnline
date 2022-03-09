using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;
using PsicoOnline.Core.Interfaces;
using PsicoOnline.Infrastructure.Mapper;

namespace PsicoOnline.Infrastructure.Data
{
    public class ResponsavelRepository : EFRepository<Responsavel, int>, IResponsavelRepository
    {
        public ResponsavelRepository(EFContext db) : base(db) { }

        public Responsavel AddResponsavel(ResponsavelDTO responsavelDTO)
        {
            if (responsavelDTO == null)
            {
                throw new ArgumentNullException(nameof(responsavelDTO));
            }

            var responsavel = ResponsavelMapper.Convert(responsavelDTO);

            Add(responsavel);

            return responsavel;
        }

        public void DeleteAllResponsaveis(List<ResponsavelDTO> responsaveisDTO)
        {
            if (responsaveisDTO == null)
            {
                throw new ArgumentNullException(nameof(responsaveisDTO));
            }

            var reponsaveis = new List<Responsavel>();

            responsaveisDTO.ForEach(responsavelDTO => reponsaveis.Add(ResponsavelMapper.Convert(responsavelDTO)));

            DeleteAll(reponsaveis);
        }

        public void DeleteResponsavel(ResponsavelDTO responsavelDTO)
        {
            if (responsavelDTO == null)
            {
                throw new ArgumentNullException(nameof(responsavelDTO));
            }

            var responsavel = ResponsavelMapper.Convert(responsavelDTO);

            Delete(responsavel);
        }

        public IReadOnlyList<Responsavel> GetAllResponsaveis()
        {
            return GetAll();
        }

        public Responsavel GetResponsavelById(int id)
        {
            return GetById(id);
        }

        public bool ResponsavelExists(int id)
        {
            return db.Responsavel.Any(responsavel => responsavel.Id == id);
        }

        public void UpdateResponsavel(ResponsavelDTO responsavelDTO)
        {
            if (responsavelDTO == null)
            {
                throw new ArgumentNullException(nameof(responsavelDTO));
            }

            if (ResponsavelExists(responsavelDTO.Id))
            {
                var responsavel = ResponsavelMapper.Convert(responsavelDTO);

                Update(responsavel);
            }
        }
    }
}
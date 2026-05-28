using Mapster;
using PsicoOnline.Core.DTOs.Sessao;
using PsicoOnline.Core.Entities;
using PsicoOnline.Core.Exceptions;
using PsicoOnline.Infrastructure.Data.Interfaces;
using System.Linq.Expressions;

namespace PsicoOnline.Infrastructure.Data;

public class SessaoRepository(EFContext db) : EFRepository<Sessao, int>(db), ISessaoRepository
{
	public async Task<Sessao> AddSessaoAsync(SessaoAddDTO sessaoDTO)
	{
		ArgumentNullException.ThrowIfNull(sessaoDTO);

		Sessao sessao = sessaoDTO.Adapt<Sessao>();

		await AddAsync(sessao);

		return sessao;
	}

	public async Task DeleteSessaoAsync(int id)
	{
		if (!SessaoExists(id))
		{
			throw new SessaoNaoExisteException(id);
		}

		Sessao sessao = await GetByIdAsync(id);

		await DeleteAsync(sessao);
	}

	public async Task<IReadOnlyList<Sessao>> GetAllSessoesAsync()
	{
		IReadOnlyList<Sessao> sessoes = await GetAllAsync();

		foreach (Sessao s in sessoes)
		{
			s.Paciente = _db.Paciente.FirstOrDefault(p => p.Id == s.PacienteId);
		}

		return sessoes;
	}

	public async Task<Sessao> GetSessaoByIdAsync(int id)
	{
		Sessao? sessao = await GetByIdAsync(id);

		if (sessao != null)
		{
			sessao.Paciente = _db.Paciente.FirstOrDefault(p => p.Id == sessao.PacienteId);
		}

		return sessao;
	}

	public async Task<IReadOnlyList<Sessao>> GetSessoesByPacienteIdDataAsync(SessaoFilterDTO sessaoDTO)
	{
		IReadOnlyList<Sessao>? sessoes = await GetAllSessoesAsync();

		if (sessoes != null && sessoes.Any())
		{
			if (sessaoDTO.PacienteId != null)
			{
				sessoes = sessoes.Where(s => s.PacienteId == sessaoDTO.PacienteId).ToList();
			}

			if (sessaoDTO.DataSessao != null)
			{
				sessoes = sessoes.Where(s => s.DataSessao == sessaoDTO.DataSessao).ToList();
			}

			foreach (Sessao s in sessoes)
			{
				s.Paciente = _db.Paciente.FirstOrDefault(p => p.Id == s.PacienteId);
			}
		}

		return sessoes;
	}

	public async Task<IReadOnlyList<Sessao>> GetSessoesWhereAsync(Expression<Func<Sessao, bool>> where)
	{
		IReadOnlyList<Sessao> sessoes = await GetWhereAsync(where);

		foreach (Sessao s in sessoes)
		{
			s.Paciente = _db.Paciente.FirstOrDefault(p => p.Id == s.PacienteId);
		}

		return sessoes;
	}

	public bool SessaoExists(int id) => _db.Sessao.Any(s => s.Id == id);

	public async Task UpdateSessaoAsync(SessaoUpdateDTO sessaoDTO)
	{
		ArgumentNullException.ThrowIfNull(sessaoDTO);

		if (!SessaoExists(sessaoDTO.Id))
		{
			throw new SessaoNaoExisteException(sessaoDTO.Id);
		}

		Sessao sessao = sessaoDTO.Adapt<Sessao>();

		await UpdateAsync(sessao);
	}
}
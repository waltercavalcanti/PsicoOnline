﻿using Mapster;
using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;
using PsicoOnline.Core.Exceptions;
using PsicoOnline.Core.Interfaces;
using System.Linq.Expressions;

namespace PsicoOnline.Infrastructure.Data;

public class SessaoRepository(EFContext db) : EFRepository<Sessao, int>(db), ISessaoRepository
{
	public async Task<Sessao> AddSessaoAsync(SessaoAddDTO sessaoDTO)
	{
		ArgumentNullException.ThrowIfNull(sessaoDTO);

		var sessao = sessaoDTO.Adapt<Sessao>();

		await AddAsync(sessao);

		return sessao;
	}

	public async Task DeleteSessaoAsync(int id)
	{
		if (!SessaoExists(id))
		{
			throw new SessaoNaoExisteException(id);
		}

		var sessao = await GetByIdAsync(id);

		await DeleteAsync(sessao);
	}

	public async Task<IReadOnlyList<Sessao>> GetAllSessoesAsync()
	{
		var sessoes = await GetAllAsync();

		foreach (var s in sessoes)
		{
			s.Paciente = _db.Paciente.FirstOrDefault(p => p.Id == s.PacienteId);
		}

		return sessoes;
	}

	public async Task<Sessao> GetSessaoByIdAsync(int id)
	{
		var sessao = await GetByIdAsync(id);

		if (sessao != null)
		{
			sessao.Paciente = _db.Paciente.FirstOrDefault(p => p.Id == sessao.PacienteId);
		}

		return sessao;
	}

	public async Task<IReadOnlyList<Sessao>> GetSessoesByPacienteIdDataAsync(SessaoFilterDTO sessaoDTO)
	{
		var sessoes = await GetAllSessoesAsync();

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

			foreach (var s in sessoes)
			{
				s.Paciente = _db.Paciente.FirstOrDefault(p => p.Id == s.PacienteId);
			}
		}

		return sessoes;
	}

	public async Task<IReadOnlyList<Sessao>> GetSessoesWhereAsync(Expression<Func<Sessao, bool>> where)
	{
		var sessoes = await GetWhereAsync(where);

		foreach (var s in sessoes)
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

		var sessao = sessaoDTO.Adapt<Sessao>();

		await UpdateAsync(sessao);
	}
}
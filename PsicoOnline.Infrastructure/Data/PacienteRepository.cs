﻿using AutoMapper;
using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;
using PsicoOnline.Core.Exceptions;
using PsicoOnline.Core.Interfaces;

namespace PsicoOnline.Infrastructure.Data;

public class PacienteRepository(EFContext db, IMapper mapper) : EFRepository<Paciente, int>(db), IPacienteRepository
{
	public async Task<Paciente> AddPacienteAsync(PacienteAddDTO pacienteDTO)
	{
		ArgumentNullException.ThrowIfNull(pacienteDTO);

		var paciente = mapper.Map<Paciente>(pacienteDTO);

		await AddAsync(paciente);

		return paciente;
	}

	public async Task DeletePacienteAsync(int id)
	{
		if (!PacienteExists(id))
		{
			throw new PacienteNaoExisteException(id);
		}

		var paciente = await GetByIdAsync(id);

		await DeleteAsync(paciente);
	}

	public async Task<IReadOnlyList<Paciente>> GetAllPacientesAsync()
	{
		var pacientes = await GetAllAsync();

		foreach (var p in pacientes)
		{
			p.Responsavel = _db.Responsavel.FirstOrDefault(r => r.PacienteId == p.Id);
		}

		return pacientes;
	}

	public async Task<Paciente> GetPacienteByIdAsync(int id)
	{
		var paciente = await GetByIdAsync(id);

		if (paciente != null)
		{
			paciente.Responsavel = _db.Responsavel.FirstOrDefault(r => r.PacienteId == id);
		}

		return paciente;
	}

	public bool PacienteExists(int id) => _db.Paciente.Any(p => p.Id == id);

	public async Task UpdatePacienteAsync(PacienteUpdateDTO pacienteDTO)
	{
		ArgumentNullException.ThrowIfNull(pacienteDTO);

		var pacienteId = pacienteDTO.Id;

		if (!PacienteExists(pacienteId))
		{
			throw new PacienteNaoExisteException(pacienteId);
		}

		var paciente = mapper.Map<Paciente>(pacienteDTO);

		await UpdateAsync(paciente);
	}
}
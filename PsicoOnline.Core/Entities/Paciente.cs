﻿using System.Text.Json.Serialization;

namespace PsicoOnline.Core.Entities;

public class Paciente : BaseEntity<int>
{
	public string Nome { get; set; }

	public DateTime DataNascimento { get; set; }

	public string? Telefone { get; set; }

	public char Genero { get; set; }

	[JsonIgnore]
	public Responsavel? Responsavel { get; set; }
}
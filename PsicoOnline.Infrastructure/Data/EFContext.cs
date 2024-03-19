using Microsoft.EntityFrameworkCore;
using PsicoOnline.Core.Entities;

namespace PsicoOnline.Infrastructure.Data;

public class EFContext(DbContextOptions<EFContext> options) : DbContext(options)
{
	public DbSet<GrauParentesco> GrauParentesco { get; set; }

	public DbSet<Paciente> Paciente { get; set; }

	public DbSet<Responsavel> Responsavel { get; set; }

	public DbSet<Sessao> Sessao { get; set; }
}